using System;
using System.Collections.Generic;
using System.Text;
namespace My_Download_Manager
{
    [Serializable()]
    public class AbsDownload : ObjDownload
    {
        #region >- Variable -<
        
        private long loaded = 0;
        private long size = 0;
        private string pathfile = string.Empty;
        private DownloadStatus status;
        [NonSerialized()]
        private bool running = false;

        #endregion

        #region >- Contructure -<

        public AbsDownload()
        {
            Status = DownloadStatus.Create;
        }

        #endregion

        #region >- ObjDownload Members -<

        public AbsDownload(string pathfile, long size)
        {
            PathFile = pathfile;
            Size = size;
            Status = DownloadStatus.Create;
        }
        public virtual void StartDownload()
        {
        }
        public virtual void StopDownload()
        {
        }
        public void DeleteFile()
        {
            if (System.IO.File.Exists(pathfile))
                try
                {
                    System.IO.File.Delete(pathfile);
                }
                catch (Exception ex) { }
        }

        #endregion

        #region >- Properties -<

        /// <summary>
        /// Số bytes đã download được
        /// </summary>
        public long Loaded
        {
            get
            {
                return loaded;
            }
            set
            {
                loaded = value;
            }
        }
        /// <summary>
        /// Kích thước của file
        /// </summary>
        public long Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        /// <summary>
        /// Đường dẫn lưu file
        /// </summary>
        public virtual string PathFile
        {
            get
            {
                return pathfile;
            }
            set
            {
                pathfile = value;
            }
        }
        /// <summary>
        /// Trạng thái download của file
        /// </summary>
        public DownloadStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        /// <summary>
        /// Trạng thái tuyến trình download
        /// </summary>
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

        #endregion

    }
}
