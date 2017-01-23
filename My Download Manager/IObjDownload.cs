using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My_Download_Manager
{
    interface IObjDownload
    {
       Task StartDownloadAsync();
       void StopDownload();
    }
}
