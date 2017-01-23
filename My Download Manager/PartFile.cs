using System;
using System.Collections.Generic;
using System.Text;

namespace My_Download_Manager
{
    [Serializable]
    public class PartFile : AbsDownload
    {
        #region >- Init Variable -<

        public delegate void EventPartDownloadComplete(object sender);
        [field: NonSerialized()]
        public event EventPartDownloadComplete PartDownloadComplete;
        private long from;
        private File parent;
        [field: NonSerialized()]
        public bool CanSplit = false;
        [field: NonSerialized()]
        public int TotalError = 0;
        #endregion

        #region >- Contructure PartFile -<

        public PartFile(long from, long size, string pathfile, File parent)
            : base(pathfile, size)
        {
            this.from = from;
            this.parent = parent;
            Status = DownloadStatus.Create;
            Running = false;
        }

        #endregion

        #region >- Content PartFile -<

        public override void StartDownload()
        {
            if (!Running)
                Running = true;
            else return;
            Status = DownloadStatus.Downloading;
            System.Threading.ThreadStart ts = PerformStart;
            System.Threading.Thread ThreadDownload = new System.Threading.Thread(ts);
            ThreadDownload.Start();
        }
        private void PerformStart()
        {
            System.Net.HttpWebRequest request;
            System.Net.HttpWebResponse response;
            System.IO.FileStream fs = null;
            System.IO.Stream stream;
            if (System.IO.File.Exists(PathFile))
            {
                System.IO.FileInfo ftemp = new System.IO.FileInfo(PathFile);
                Loaded = ftemp.Length;
                if (Loaded >= Size && Size > 0)
                {
                    Status = DownloadStatus.Complete;
                    Running = false;
                    if (PartDownloadComplete != null)
                        PartDownloadComplete(this);
                    return;
                }
            }
            else
            {
                Loaded = 0;
                string directory = System.IO.Path.GetDirectoryName(PathFile);
                if (!System.IO.Directory.Exists(directory))
                    System.IO.Directory.CreateDirectory(directory);
            }
            request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(parent.Link);
            request.UserAgent = ObjStatic.UserAgent;
            //!parent.IsMediafireLink&&
            if (ObjStatic.Cookies[parent.Host] != null)
                request.Headers[System.Net.HttpRequestHeader.Cookie] = ObjStatic.Cookies[parent.Host].ToString();
            request.AllowAutoRedirect = true;
            request.ConnectionGroupName = PathFile;
            request.KeepAlive = true;
            long requestlength = 0;
            if (Size > 0)
            {
                AddRange(request.Headers, from + Loaded, from + Size - 1);
                try
                {
                    response = (System.Net.HttpWebResponse)request.GetResponse();
                }
                catch (Exception ex)
                {
                    parent.FileNotFound = true;
                    TotalError = ObjStatic.MaxTryConnect + 1;
                    Running = false;
                    if (PartDownloadComplete != null)
                        PartDownloadComplete(this);
                    return;
                }
                requestlength = Convert.ToInt64(response.Headers[System.Net.HttpResponseHeader.ContentLength]);
                if (parent.Resume == ResumeAble.Yes)
                {
                    if (requestlength != (Size - Loaded))
                    {
                        parent.FileNotFound = true;
                        TotalError++;
                        Running = false;
                        response.Close();
                        if (parent.IsMediafireLink)
                        {
                            ObjLinkMediafire objmd = new ObjLinkMediafire();
                            string strlinktemp = objmd.GetLinkMediaFire(parent.LinkMediaFire);
                            if (!string.IsNullOrEmpty(strlinktemp))
                                parent.Link = strlinktemp;
                        }
                        if (PartDownloadComplete != null)
                            PartDownloadComplete(this);
                        return;
                    }
                    try
                    {
                        fs = new System.IO.FileStream(PathFile, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
                    }
                    catch (Exception ex)
                    {
                        TotalError++;
                        Running = false;
                        response.Close();
                        if (PartDownloadComplete != null)
                            PartDownloadComplete(this);
                        return;
                    }
                }
                else
                {
                    if (requestlength == (Size - Loaded))
                    {
                        parent.Resume = ResumeAble.Yes;
                        parent.PerformStart();
                        try
                        {
                            fs = new System.IO.FileStream(PathFile, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
                        }
                        catch (Exception ex)
                        {
                            TotalError++;
                            Running = false;
                            response.Close();
                            if (PartDownloadComplete != null)
                                PartDownloadComplete(this);
                            return;
                        }

                    }
                    else// if (requestlength == parent.Size)
                    {
                        parent.Resume = ResumeAble.No;
                        from = 0;
                        Size = parent.Size;
                        Loaded = 0;
                        try
                        {
                            fs = new System.IO.FileStream(PathFile, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Write);
                        }
                        catch (Exception ex)
                        {
                            TotalError++;
                            Running = false;
                            response.Close();
                            if (PartDownloadComplete != null)
                                PartDownloadComplete(this);
                            return;
                        }
                        parent.DeleteAllButThis(this);
                        parent.Loaded = 0;
                    }
                }
            }
            else
            {
                try
                {
                    response = (System.Net.HttpWebResponse)request.GetResponse();
                }
                catch (Exception ex)
                {
                    parent.FileNotFound = true;
                    TotalError++;
                    Running = false;
                    if (fs != null)
                        fs.Close();
                    if (PartDownloadComplete != null)
                        PartDownloadComplete(this);
                    return;
                }
                parent.Resume = ResumeAble.No;
                try
                {
                    fs = new System.IO.FileStream(PathFile, System.IO.FileMode.Create);
                }
                catch (Exception ex)
                {
                    TotalError++;
                    Running = false;
                    response.Close();
                    if (PartDownloadComplete != null)
                        PartDownloadComplete(this);
                    return;
                }
                parent.DeleteAllButThis(this);
                Loaded = 0;
                parent.Loaded = 0;
            }
            stream = response.GetResponseStream();
            int getbyte = 0;
            int buffer = ObjStatic.Config.Buffer;
            byte[] data = new byte[buffer];
            while (parent.Running && Running)
            {
                if (CanSplit)
                    break;
                try
                {
                    getbyte = stream.Read(data, 0, buffer);
                }
                catch (Exception ex)
                {
                    Running = false;
                    TotalError++;
                    break;
                }
                if (getbyte > 0)
                {
                    try
                    {
                        fs.Write(data, 0, getbyte);
                        fs.Flush();
                    }
                    catch (Exception ex)
                    {
                        Running = false;
                        TotalError++;
                        break;
                    }
                    Loaded += getbyte;
                    lock ((object)parent.Loaded)
                    {
                        parent.Loaded += getbyte;
                    }
                    lock ((object)ObjStatic.TotalLoad)
                    {
                        ObjStatic.TotalLoad += getbyte;
                    }
                }
                if (Loaded >= Size && Size > 0)
                    break;
                if (getbyte <= 0)
                {
                    TotalError++;
                    Running = false;
                    break;
                }
            }
            stream.Close();
            response.Close();
            fs.Close();
            fs.Dispose();
            if (parent.Running && Running && !CanSplit)
                Status = DownloadStatus.Complete;
            else Status = DownloadStatus.Error;
            Running = false;
            if (CanSplit)
                parent.SplitPart(this);
            else
            {
                if (PartDownloadComplete != null)
                    PartDownloadComplete(this);
            }
        }
        private void AddRange(System.Net.WebHeaderCollection Headers, long from, long to)
        {
            System.Reflection.MethodInfo method = typeof(System.Net.WebHeaderCollection).GetMethod("AddWithoutValidate", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            string Key = "Range";
            string Range = string.Format("bytes={0}-{1}", from, to);
            method.Invoke(Headers, new object[] { Key, Range });
        }
        #endregion

        #region >- Properties -<

        public long From
        {
            get
            {
                return from;
            }
        }
        public int FileSize
        {
            get
            {
                int result = 0;
                if (System.IO.File.Exists(PathFile))
                {
                    try
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(PathFile);
                        result = (int)fi.Length;
                    }
                    catch (Exception ex)
                    {
                        result = 0;
                    }
                }
                return result;
            }
        }

        #endregion
    }
}
