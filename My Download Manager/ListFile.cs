using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace My_Download_Manager
{
    [Serializable()]
    public class ListFile : ObjDownload
    {
        #region >- Variable -<

        private string name = string.Empty;
        private List<FileDownload> files;
        private int fileconnection;
        private string saveto = string.Empty;
        private bool exitwindownwhencomplete = false;
        [NonSerialized()]
        private bool running;

        #endregion

        #region >- Contructure -<

        public ListFile(string name, int fileconnection)
        {
            this.name = name;
            this.running = false;
            this.fileconnection = fileconnection;
            files = new List<FileDownload>();
        }

        #endregion

        #region >- ObjDownload Members -<

        public void StartDownload()
        {
            if (!Running)
            {
                this.running = true;
                for (int i = 0; i < files.Count; i++)
                {
                    files[i].Running = false;
                    files[i].IsCancelDownload = false;
                }
                System.Threading.ThreadStart ts = new System.Threading.ThreadStart(PerformDownload);
                System.Threading.Thread t = new System.Threading.Thread(ts);
                t.Start();
            }
        }

        #endregion

        #region >- ObjDownload method -<

        private void PerformDownload()
        {
            Hashtable list = new Hashtable();
            int count = 0;
            bool Finish = false;
            while (running && !Finish)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    if (i < files.Count && files[i].IsCancelDownload)
                    {
                        if (list[files[i]] != null)
                        {
                            list.Remove(files[i]);
                            count--;
                        }
                        continue;
                    }
                    if (i < files.Count && files[i].Running)// && list[files[i]] != null)
                    {
                        if (list[files[i]] == null)
                        {
                            list[files[i]] = true;
                            count++;
                        }
                        continue;
                    }
                    if (i < files.Count && !files[i].Running && count < this.fileconnection && !files[i].IsCancelDownload && files[i].Status != DownloadStatus.Complete && files[i].Status != DownloadStatus.Building)
                    {
                        if (list[files[i]] == null)
                        {
                            list[files[i]] = true;
                            count++;
                            files[i].StartDownload();
                        }
                        continue;
                    }
                    if (i < files.Count && files[i].IsDownloadComplete())
                    {
                        if (list[files[i]] != null)
                        {
                            list.Remove(files[i]);
                            count--;
                        }
                    }
                }
                if (list.Count == 0)
                {
                    Finish = true;
                    if (exitwindownwhencomplete)
                    {
                        bool CanShutdown=true;
                        for (int i = 0; i < 0; i++)
                        {
                            ListFile objt = ObjStatic.FormMain.Category[i];
                            if (objt != this && objt.Running)
                            {
                                CanShutdown = false;
                                break;
                            }
                        }
                        if (CanShutdown)
                        {
                            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(ShowShutDown);
                            System.Threading.Thread tshutdown = new System.Threading.Thread(ts);
                            tshutdown.Start();
                        }
                    }
                    break;
                }
                System.Threading.Thread.Sleep(200);
            }
            running = false;
        }
        private void ShowShutDown()
        {
            ShutdownComputer frmCanshutDown = new ShutdownComputer();
            frmCanshutDown.ShowDialog();
        }
        public void StopDownload()
        {
            this.running = false;
            for (int i = 0; i < files.Count; i++)
            {
                files[i].Running = false;
                files[i].IsCancelDownload = false;
            }
        }

        #endregion

        #region >- Content ListFile -<

        public void AddFile(FileDownload f)
        {
            this.files.Add(f);
            f.Parent = this;
        }
        public void InsertFile(int index,FileDownload f)
        {
            this.files.Insert(index, f);
            f.Parent = this;
        }
        public void RemoveAt(int index)
        {
            this.files.RemoveAt(index);
        }
        public void RemoveFileAt(int index)
        {
            files[index].Dispose();
            this.files.RemoveAt(index);
        }
        public void RemoveFile(FileDownload f)
        {
            f.Dispose();
            this.files.Remove(f);
        }
        public void Clear()
        {
            for (int i = 0; i < files.Count; i++)
            {
                files[i].Dispose();
            }
            files.Clear();
        }

        #endregion

        #region >- Properties -<

        public int Count
        {
            get
            {
                return this.files.Count;
            }
        }
        public int FileConnection
        {
            get
            {
                return this.fileconnection;
            }
            set
            {
                if (value > 0)
                    this.fileconnection = value;
            }
        }
        public FileDownload this[int index]
        {
            get
            {
                return files[index];
            }
            set
            {
                files[index] = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string SaveTo
        {
            get
            {
                return this.saveto;
            }
            set
            {
                this.saveto = value;
            }

        }
        public bool Running
        {
            get
            {
                return this.running;
            }
            set
            {
                this.running = value;
            }
        }
        public bool ExitWindownWhenComplete
        {
            get
            {
                return this.exitwindownwhencomplete;
            }
            set
            {
                this.exitwindownwhencomplete = value;
            }
        }
        #endregion

    }
}
