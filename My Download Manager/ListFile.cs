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
        private List<File> files;
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
            running = false;
            this.fileconnection = fileconnection;
            files = new List<File>();
        }

        #endregion

        #region >- ObjDownload Members -<

        public void StartDownload()
        {
            if (!Running)
            {
                running = true;
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
                    if (i < files.Count && !files[i].Running && count < fileconnection && !files[i].IsCancelDownload && files[i].Status != DownloadStatus.Complete && files[i].Status != DownloadStatus.Building)
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
            running = false;
            for (int i = 0; i < files.Count; i++)
            {
                files[i].Running = false;
                files[i].IsCancelDownload = false;
            }
        }

        #endregion

        #region >- Content ListFile -<

        public void AddFile(File f)
        {
            files.Add(f);
            f.Parent = this;
        }
        public void InsertFile(int index,File f)
        {
            files.Insert(index, f);
            f.Parent = this;
        }
        public void RemoveAt(int index)
        {
            files.RemoveAt(index);
        }
        public void RemoveFileAt(int index)
        {
            files[index].Dispose();
            files.RemoveAt(index);
        }
        public void RemoveFile(File f)
        {
            f.Dispose();
            files.Remove(f);
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
                return files.Count;
            }
        }
        public int FileConnection
        {
            get
            {
                return fileconnection;
            }
            set
            {
                if (value > 0)
                    fileconnection = value;
            }
        }
        public File this[int index]
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
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string SaveTo
        {
            get
            {
                return saveto;
            }
            set
            {
                saveto = value;
            }

        }
        public bool Running
        {
            get
            {
                return running;
            }
            set
            {
                running = value;
            }
        }
        public bool ExitWindownWhenComplete
        {
            get
            {
                return exitwindownwhencomplete;
            }
            set
            {
                exitwindownwhencomplete = value;
            }
        }
        #endregion

    }
}
