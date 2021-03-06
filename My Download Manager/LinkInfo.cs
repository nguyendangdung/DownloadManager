using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
namespace My_Download_Manager
{
    public class LinkInfo
    {

        #region >- Variable -<

        private long size = 0;
        private string filename = string.Empty;
        private bool fileexist = true;
        private string link = string.Empty;

        #endregion

        #region >- Contructure -<

        public LinkInfo(string Link)
        {
            size = -1;
            link = Link;
            try
            {
                Uri uri = new Uri(Link);
                string host=uri.Host.ToLower();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Link);
                request.UserAgent = ObjStatic.UserAgent;
                request.KeepAlive = true;
                request.ConnectionGroupName = "GetSize" + Link;
                if (ObjStatic.Cookies[host] != null)
                    request.Headers[HttpRequestHeader.Cookie] = ObjStatic.Cookies[host].ToString();
                
                FileName = System.IO.Path.GetFileName(request.RequestUri.AbsolutePath);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (string.IsNullOrEmpty(FileName))
                    FileName = "Index.htm";
                else
                {
                    if (response.Headers[HttpResponseHeader.ContentType].ToLower().Contains("htm"))
                    {
                        string extension = System.IO.Path.GetExtension(FileName);
                        if (!extension.ToLower().Contains("htm"))
                            FileName = FileName + ".htm";
                    }
                }
                Size = Convert.ToInt64(response.Headers[HttpResponseHeader.ContentLength]);
                if (Size == 0)
                    fileexist = false;
                response.Close();
            }
            catch (Exception ex)
            {
                fileexist = false;
            }
        }
        #endregion

        #region >- Properties -<

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
        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
        public bool FileExist
        {
            get
            {
                return fileexist;
            }
            set
            {
                fileexist = value;
            }
        }
        public string Link
        {
            get
            {
                return link;
            }
        }

        #endregion
    }
}
