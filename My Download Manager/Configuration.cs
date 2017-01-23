using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace My_Download_Manager
{

    public enum DownloadStatus {Create,Downloading,Error,Building,Complete,Disconect};
    public enum ResumeAble {Yes,No,Unknown };
    
    [Serializable()]
    public class Configuration
    {
        #region >- Variable -<
        
        private int buffer = 0;
        private int connection = 0;
        private string foldertemp = string.Empty;
        private string extensiontempfile = string.Empty;
        private int fileconnection = 0;
        private bool autodownloadwhenhaslink = false;
        private string currentcategory = string.Empty;

        public string AutoDownload = string.Empty;
        public string DefaultNoSniff="js swf htm html aspx asp php jsp txt xml css ashx";
        public string DefaultAutoDownload = "exe zip arj rar lzh z gz gzip tar bin mp3 m4a wav ra ram aac aif avi mpg mpeg m4v qt plj asf mov rm mp4 wma wmv mpe mpa r0* r1* a0* a1* tif tiff pdf msi msu ace iso img ogg 7z sea sit sitx ppt pps bz2";

        public string ExtensionNoSniff = string.Empty;
        public string ExtensionAutoDownload = string.Empty;
        public bool RegisterWithIE = false;
        public bool RegisterWithFirefox = false;
        public bool RegisterWithOpera = false;
        public bool RegisterWithGoogleChrome = false;
        public bool AutoStartSniffer = true;
        public Hashtable LastPathSaveFile = null;
        public bool Installed = false;
        public bool RunOnStartup = false;

        public TypeSniffer[] DefaultTypeSniffer = new TypeSniffer[]
            {
                new TypeSniffer("video","Video (flv,mp4,wmv,3pg...)",true),
                new TypeSniffer("audio","Audio (mp3,wma...)",true),
                new TypeSniffer("application","Application (rar,swf,js...)",true),
                new TypeSniffer("image","Image (jpg,bmp,gif...)",false),
                new TypeSniffer("text","Text (txt,htm,css,xml...)",false),
                new TypeSniffer("*","All (*.*)",false)
            };
        #endregion

        #region >- Contructure -<
        
        public Configuration()
        {
            buffer = 4096;
            connection = 16;
            extensiontempfile = ".part";
            fileconnection = 2;
            RegisterWithIE = true;
            LastPathSaveFile = new Hashtable();
            Installed = false;
            ExtensionNoSniff = DefaultNoSniff;
            ExtensionAutoDownload = DefaultAutoDownload;
            RunOnStartup = true;
        }
        public string GetPathSaveFileFromExtension(string extension)
        {
            if (LastPathSaveFile != null&&!string.IsNullOrEmpty(extension))
            {
                if (LastPathSaveFile[extension] != null)
                    return LastPathSaveFile[extension].ToString();
            }
            else LastPathSaveFile = new Hashtable();
            return string.Empty;
        }
        public void SaveConfigExtension(string path)
        {
            string extension = System.IO.Path.GetExtension(path).ToLower();
            if (ObjStatic.Config.LastPathSaveFile == null)
                ObjStatic.Config.LastPathSaveFile = new Hashtable();
            ObjStatic.Config.LastPathSaveFile[extension] = System.IO.Path.GetDirectoryName(path);
            ObjStatic.FormMain.SaveConfig();
        }
        #endregion

        #region >- Properties -<

        public string CurrentCategory
        {
            get
            {
                return currentcategory;
            }
            set
            {
                currentcategory = value;
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
                fileconnection = value;
            }
        }
        public int Buffer
        {
            get
            {
                return buffer;
            }
            set
            {
                buffer = value;
            }
        }
        public int Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }
        public string FolderTemp
        {
            get
            {
                return foldertemp;
            }
            set
            {
                foldertemp = value;
            }
        }
        public string ExtensionTempFile
        {
            get
            {
                return extensiontempfile;
            }
        }
        public bool AutoDownloadWhenHasLink
        {
            get
            {
                return autodownloadwhenhaslink;
            }
            set
            {
                autodownloadwhenhaslink = value;
            }
        }

        #endregion
    }
    [Serializable()]
    public class TypeSniffer
    {
        public string Type;
        public string Description;
        public bool Selected;
        public string PathSave;
        public TypeSniffer(string type, string description, bool selected)
        {
            Type = type;
            Description = description;
            Selected = selected;
        }
    }
}
