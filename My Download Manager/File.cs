using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Text;

namespace My_Download_Manager
{
    [Serializable()]
    public class File : AbsDownload
    {
        #region >- Variable -<

        public delegate void EventStartDownload(object sender);
        [field: NonSerialized()]
        public event EventStartDownload BeginDownload;
        public delegate void EventDownloadComplete(object sender);
        [field: NonSerialized()]
        public event EventDownloadComplete CompleteDownload;
        [field: NonSerialized()]
        public FileProperties frmProperties;

        private ListFile parent;
        private string link;
        private bool ismediafirelink;
        private string linkmediafire;
        private ResumeAble resume;
        private List<PartFile> Parts;
        private int connection = 0;
        private string filename;
        private string host;
        [NonSerialized()]
        public System.Windows.Forms.DataGridViewRow Row;
        [NonSerialized()]
        private bool filenotfound = false;

        private int timecount = 1000;
        [NonSerialized()]
        long oldloaded = 0;
        [NonSerialized()]
        private System.Threading.Thread TimerUpdateStatus;
        [NonSerialized()]
        private Boolean iscanceldownload = false;

        #endregion

        #region >- Constructure -<

        public File(string pathfile, string link, long size, string filename)
            : base(pathfile, size)
        {
            this.link = link;
            this.filename = filename;
            Parts = new List<PartFile>();
            resume = ResumeAble.Unknown;
            try
            {
                Uri uri = new Uri(link);
                host = uri.Host.ToLower();
            }
            catch (Exception ex) { }
        }

        #endregion

        #region >- Public Method -<

        public void DeleteAllButThis(PartFile part)
        {
            for (int i = 0; i < Parts.Count; )
            {
                if (Parts[i] == part)
                {
                    i++;
                }
                else
                {
                    Parts[i].DeleteFile();
                    Parts.RemoveAt(i);
                }
            }
        }
        public void Redownload()
        {
            if (!Running)
            {
                Loaded = 0;
                ClearPart();
                Parts.Clear();
                Status = DownloadStatus.Create;
                StartDownload();
            }
        }
        public string GetStatus()
        {
            if (Loaded > 0 && Size > 0 && Status != DownloadStatus.Complete)
            {
                float percent = (float)Loaded * 100 / Size;
                return percent.ToString("0.00") + "%";
            }
            return Status.ToString();
        }
        public string GetSize()
        {
            return ObjStatic.ToStringSize(Size);
        }
        public void Dispose()
        {
            StopDownload();
            ClearPart();
        }
        public List<PartFile> GetParts()
        {
            return Parts;
        }
        public bool IsDownloadComplete()
        {
            return Status == DownloadStatus.Complete || Status == DownloadStatus.Error;
        }
        public void SetFileName()
        {
            if (Row != null)
            {
                Row.Cells["FileName"].Value = filename;
                try
                {
                    if (!string.IsNullOrEmpty(filename))
                        ((CustomGridCell)Row.Cells[0]).CellIcon = ObjStatic.ObjGetIcon.GetIconFromExtension(System.IO.Path.GetExtension(filename), GetIconWindow.IconSize.Small);
                }
                catch (Exception ex) { }
            }
        }

        #endregion

        #region >-  override method  -<

        public override void StartDownload()
        {
            if (!Running && Status != DownloadStatus.Complete)
            {
                Running = true;
                System.Threading.ThreadStart ts = ExcuteStartDownload;
                System.Threading.Thread t = new System.Threading.Thread(ts);
                t.Start();
            }
        }
        private void ExcuteStartDownload()
        {
            FileNotFound = false;
            if (ismediafirelink)
            {
                ObjLinkMediafire obj = new ObjLinkMediafire();
                string strlinktemp = obj.GetLinkMediaFire(linkmediafire);
                if (!string.IsNullOrEmpty(strlinktemp))
                {
                    link = strlinktemp;
                    if (string.IsNullOrEmpty(filename))
                    {
                        PathFile = PathFile + System.IO.Path.GetFileName(strlinktemp);
                    }
                }
            }
            if (Size <= 0)
            {
                LinkInfo lf = new LinkInfo(link);
                if (lf.FileExist)
                {
                    Size = lf.Size;
                    SetSize();
                }
                else
                {
                    filenotfound = true;
                    Status = DownloadStatus.Error;
                    SetTimeLeft_Status_TransferRate(Status.ToString(), string.Empty, string.Empty);
                    Running = false;
                    return;
                }
            }
            connection = ObjStatic.Config.Connection;
            if (Parts.Count == 0)
            {
                CreateParts();
            }
            else
            {
                StopAllPart();
                GetLastStatus();
                UpdateParts();
            }
            resume = ResumeAble.Unknown;
            System.Threading.ThreadStart ts = PerformStart;
            System.Threading.Thread t = new System.Threading.Thread(ts);
            t.Start();
            oldloaded = Loaded;
            StartCount();
            BeginDownload?.Invoke(this);
            ObjStatic.FormMain.SaveCategory();
        }
        private void PerformCount()
        {
            while (Running)
            {
                long loaded = Loaded;
                long speed = (loaded - oldloaded);// *1000 / timecount;
                oldloaded = Loaded;
                string strStatus = string.Empty;
                string strTransferRate = string.Empty;
                string strTimeLeft = string.Empty;
                if (Size > 0)
                {
                    strStatus = ObjStatic.ToStringPercent(loaded, Size);
                }
                strTransferRate = ObjStatic.ToStringSize(speed) + "/sec";
                if (speed > 0)
                {
                    long end = Size - loaded;
                    strTimeLeft = ObjStatic.ToStringTime((int)(end / speed));
                }
                SetTimeLeft_Status_TransferRate(strStatus, strTimeLeft, strTransferRate);
                System.Threading.Thread.Sleep(timecount);
            }
        }
        public override void StopDownload()
        {
            Running = false;
            Status = DownloadStatus.Disconect;
            if (TimerUpdateStatus != null)
            {
                TimerUpdateStatus.Abort();
            }
            IsCancelDownload = true;
        }

        #endregion

        #region >- Private Method -<

        private void ClearPart()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].DeleteFile();
            }
            if (Parts.Count > 0)
            {
                try
                {
                    System.IO.Directory.Delete(System.IO.Path.GetDirectoryName(Parts[0].PathFile));
                }
                catch (Exception ex) { }
            }
        }
        private void StopAllPart()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].Running = false;
            }
        }
        private void GetLastStatus()
        {
            Loaded = 0;
            for (int i = 0; i < Parts.Count; i++)
            {
                int size = Parts[i].FileSize;
                Parts[i].CanSplit = false;
                Parts[i].TotalError = 0;
                if (size > 0)
                {
                    Parts[i].Loaded = size;
                    Loaded += size;
                    if (i < Parts.Count - 1)
                        Parts[i].Size = Parts[i + 1].From - Parts[i].From;
                    else Parts[i].Size = Size - Parts[i].From;
                    if (Parts[i].Size == size)
                        Parts[i].Status = DownloadStatus.Complete;
                }
            }
        }
        public void PerformStart()
        {
            lock (this)
            {
                int conn = (resume == ResumeAble.Yes) ? connection : 1;
                int countconn = 0;
                bool hasError = false;
                for (int i = 0; i < Parts.Count; i++)
                {
                    if (i < Parts.Count && Parts[i].Status == DownloadStatus.Complete)
                        continue;
                    if (i < Parts.Count && Parts[i].Running)
                    {
                        countconn++;
                        continue;
                    }
                    if (Parts[i].TotalError > ObjStatic.MaxTryConnect)
                    {
                        hasError = true;
                        break;
                    }
                    if (i < Parts.Count && !Parts[i].Running && countconn < conn && !Parts[i].CanSplit)
                    {
                        countconn++;
                        Parts[i].PartDownloadComplete -= FileDownload_PartDownloadComplete;
                        Parts[i].PartDownloadComplete += FileDownload_PartDownloadComplete;
                        Parts[i].StartDownload();
                    }
                }
                if (hasError)
                {
                    Running = false;
                    filenotfound = true;
                    Status = DownloadStatus.Error;
                    SetTimeLeft_Status_TransferRate(Status.ToString(), string.Empty, string.Empty);
                    if (CompleteDownload != null)
                        CompleteDownload(this);
                }
                if (IsAllPartComplete())//count == Parts.Count)
                {
                    Loaded = Size;
                    Running = false;
                    JoinFile();
                    ObjStatic.FormMain.SaveCategory();
                    return;
                }
            }
        }
        private bool IsAllPartComplete()
        {
            for (int i = 0; i < Parts.Count; i++)
                if (Parts[i].Status != DownloadStatus.Complete)
                    return false;
            return true;
        }
        private void FileDownload_PartDownloadComplete(object sender)
        {
            PartFile part = sender as PartFile;
            bool Continue = true;
            PartFile psplit = null;
            if (resume == ResumeAble.Yes && Running && Parts.Count < 48)
            {
                long max = 524288;//524288(512 kb)    128Kb(131072)  1 MB(1048576) 32Kb ( 32768 )
                int totalcomplete = 0;
                for (int i = 0; i < Parts.Count; i++)
                {
                    if (Parts[i].Status == DownloadStatus.Complete)
                    {
                        totalcomplete++;
                        continue;
                    }
                    if (!Parts[i].CanSplit)
                    {
                        long temp = Parts[i].Size - Parts[i].Loaded;
                        if (temp >= max)
                        {
                            max = temp;
                            psplit = Parts[i];
                        }
                    }

                }
                if (psplit != null && (Parts.Count - totalcomplete) < connection)
                {
                    psplit.CanSplit = true;
                    if (!psplit.Running)
                    {
                        SplitPart(psplit);
                        Continue = false;
                    }
                }
            }
            if (Continue && Running)
                PerformStart();
        }
        public void SplitPart(PartFile part)
        {
            lock (this)
            {
                for (int i = 0; i < Parts.Count; i++)
                {
                    if (Parts[i] == part)
                    {
                        long size = part.Size;
                        long end = part.Size - part.Loaded;
                        if (end > 4096)
                        {
                            long s1 = end / 2;
                            long s2 = end - s1;
                            part.Size = part.Loaded + s1;
                            string pathfile = System.IO.Path.GetDirectoryName(part.PathFile) + "\\mdm";
                            PartFile p = new PartFile(part.Size + part.From, s2, pathfile + ObjStatic.Config.ExtensionTempFile + Parts.Count, this);
                            Parts.Insert(i + 1, p);
                        }
                        part.CanSplit = false;
                        break;
                    }
                }
            }
            if (Running)
                PerformStart();
        }
        private void UpdateParts()
        {
            lock (this)
            {
                while (Parts.Count < connection)
                {
                    long max = 0;
                    int index = -1;
                    for (int i = 0; i < Parts.Count; i++)
                    {
                        long temp = (Parts[i].Size - Parts[i].Loaded);
                        if (max < temp)
                        {
                            max = temp;
                            index = i;
                        }
                    }
                    if (index >= 0)
                    {
                        long size = Parts[index].Size;
                        long end = Parts[index].Size - Parts[index].Loaded;
                        if (end > 4096)
                        {
                            long s1 = end / 2;
                            long s2 = end - s1;
                            Parts[index].Size = Parts[index].Loaded + s1;
                            string pathfile = System.IO.Path.GetDirectoryName(Parts[index].PathFile) + "\\mdm";
                            PartFile p = new PartFile(Parts[index].Size + Parts[index].From, s2, pathfile + ObjStatic.Config.ExtensionTempFile + Parts.Count, this);
                            Parts.Insert(index + 1, p);
                        }
                    }
                    else break;
                }
            }
        }
        private string GetFolderTemp(string filename)
        {
            string foldertemp = ObjStatic.Config.FolderTemp;
            int index = 0;
            string end = filename;
            string foldername = string.Empty;
            do
            {
                foldername = foldertemp + "\\" + end;
                if (!System.IO.Directory.Exists(foldername))
                {
                    System.IO.Directory.CreateDirectory(foldername);
                    return foldername;
                }
                else
                {
                    end = filename + "_" + index;
                    index++;
                }
            }
            while (true);
            return string.Empty;
        }
        private void CreateParts()
        {
            int numpart = connection;
            string folder = GetFolderTemp(filename);
            folder += "\\mdm"; //filename;
            string extension = ObjStatic.Config.ExtensionTempFile;
            if (Size >= 4096)
            {
                long sizepart = (int)Math.Ceiling((double)Size / numpart);// this.connection);
                long from = 0;
                int count = 0;
                while (from < Size)
                {
                    if (from + sizepart > Size)
                        sizepart = Size - from;
                    PartFile part = new PartFile(from, sizepart, folder + extension + count, this);
                    Parts.Add(part);
                    from += sizepart;
                    count++;
                }
            }
            else
            {
                PartFile part = new PartFile(0, Size, folder + extension + 0, this);
                Parts.Add(part);
            }
        }
        private void JoinFile()
        {
            if (Status == DownloadStatus.Building)
                return;
            Status = DownloadStatus.Building;
            string path = System.IO.Path.GetDirectoryName(PathFile);
            if (!System.IO.Directory.Exists(path))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (Exception ex) { Status = DownloadStatus.Error; return; }
            }
            SetTimeLeft_Status_TransferRate(Status.ToString(), string.Empty, string.Empty);
            System.IO.FileStream f = new System.IO.FileStream(PathFile, System.IO.FileMode.Create);
            int buffer = ObjStatic.Config.Buffer;
            byte[] data = new byte[buffer];
            int count = 0;
            try
            {
                for (int i = 0; i < Parts.Count; i++)
                {
                    if (System.IO.File.Exists(Parts[i].PathFile))
                    {
                        System.IO.FileStream part = new System.IO.FileStream(Parts[i].PathFile, System.IO.FileMode.Open);
                        int readbyte = 0;
                        while ((readbyte = part.Read(data, 0, buffer)) > 0)
                        {
                            f.Write(data, 0, readbyte);
                            f.Flush();
                        }
                        part.Close();
                        count++;
                    }
                }
            }
            catch (Exception ex) { Status = DownloadStatus.Error; return; }
            f.Close();
            if (count == Parts.Count)
            {
                ClearPart();
                Status = DownloadStatus.Complete;
            }
            else
            {
                Status = DownloadStatus.Error;
            }
            SetTimeLeft_Status_TransferRate(Status.ToString(), string.Empty, string.Empty);
            if (CompleteDownload != null)
                CompleteDownload(this);
            ObjStatic.FormMain.UpdateTotalComplete(parent);
        }
        private void StartCount()
        {
            System.Threading.ThreadStart ts = PerformCount;
            TimerUpdateStatus = new System.Threading.Thread(ts);
            TimerUpdateStatus.Start();
        }
        private void SetSize()
        {
            if (Row != null)
            {
                try
                {
                    Row.Cells["Size"].Value = ObjStatic.ToStringSize(Size);
                }
                catch (Exception ex) { }
            }
        }
        private void SetTimeLeft_Status_TransferRate(string Status, string TimeLeft, string TransferRate)
        {
            try
            {
                if (Row != null)
                {
                    Row.Cells["Status"].Value = Status;
                    Row.Cells["TimeLeft"].Value = TimeLeft;
                    Row.Cells["TransferRate"].Value = TransferRate;
                }
                if (frmProperties != null && !frmProperties.IsDisposed)
                    frmProperties.SetTranferRate(TransferRate, TimeLeft);
            }
            catch (Exception ex) { }
        }
        #endregion

        #region >- Properties -<

        public bool IsCancelDownload
        {
            get
            {
                return iscanceldownload;
            }
            set
            {
                iscanceldownload = value;
            }
        }
        public string FileName
        {
            get
            {
                return filename;
            }
        }
        public bool FileNotFound
        {
            get
            {
                return filenotfound;
            }
            set
            {
                filenotfound = value;
            }
        }
        public string Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }
        public ResumeAble Resume
        {
            get
            {
                return resume;
            }
            set
            {
                resume = value;
            }
        }
        public int TotalPart
        {
            get
            {
                return Parts.Count;
            }
        }
        public PartFile this[int index]
        {
            get
            {
                if (index >= Parts.Count)
                    return null;
                return Parts[index];
            }
        }
        public override string PathFile
        {
            get
            {
                return base.PathFile;
            }
            set
            {
                base.PathFile = value;
                string name = System.IO.Path.GetFileName(value);
                if (!string.IsNullOrEmpty(name))
                {
                    filename = name;
                    SetFileName();
                }
            }
        }
        public ListFile Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        public bool IsMediafireLink
        {
            get
            {
                return ismediafirelink;
            }
            set
            {
                ismediafirelink = value;
            }
        }
        public string LinkMediaFire
        {
            get
            {
                return linkmediafire;
            }
            set
            {
                linkmediafire = value;
            }
        }
        public string Host
        {
            get
            {
                return host;
            }
            set
            {
                host = value;
            }
        }

        #endregion

    }
}
