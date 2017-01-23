using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32;
namespace MDMCom
{
    #region >- COM Download With -<

    [Guid("B67E8060-18B1-4266-A487-F0247D13F283")]
    [ComVisible(true)]
    public class DownloadWithMDM
    {
        public void Download(string args)
        {
            if (args != null && args.Length > 0)
            {
                string paththis = System.IO.Path.GetDirectoryName(typeof(DownloadWithMDM).Assembly.Location);
                string filelink ="ielinks.txt";
                try
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter( paththis + "\\"+ filelink, true, Encoding.UTF8);
                    Hashtable temp = new Hashtable();
                    string[] str = args.Split('\n');
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i].Length > 0)
                        {
                            string strtemp=str[i].ToLower();
                            if (temp[strtemp] == null)
                            {
                                sw.WriteLine(str[i]);
                                temp[strtemp] = true;
                            }
                        }
                    }
                    sw.Close();
                    temp.Clear();
                    System.Diagnostics.ProcessStartInfo processinfo = new System.Diagnostics.ProcessStartInfo(paththis + "\\MDM.exe");
                    processinfo.Arguments = filelink;
                    System.Diagnostics.Process.Start(processinfo);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error :" + ex.Message);
                }
            }
        }
    }
    #endregion
    /*
    #region >- DownloadUI -<
    [Guid("E53F11EF-443A-4caf-A5FF-F948C97DBD76")]
    [ComVisible(true)]
    public class MainDownload : IDownloadManager
    {
        public MainDownload()
        {
            System.Windows.Forms.MessageBox.Show("Co khai bao !");
        }
        public void Download(IMoniker pmk, IBindCtx pbc, uint dwBindVerb, int grfBINDF, ref IntPtr pBindInfo, string pszHeaders, string pszRedir, uint uiCP)
        {
            System.Windows.Forms.MessageBox.Show("URL : Co vao !");
            string url = string.Empty;
            try
            {
                pmk.GetDisplayName(pbc, (IMoniker)null, out url);
            }
            catch (Exception ex)
            {
                url = ex.Message;
            }
            System.Windows.Forms.MessageBox.Show("URL :" + url);
            string extension = System.IO.Path.GetExtension(url).ToLower();
            
            string paththis = System.IO.Path.GetDirectoryName(typeof(MainDownload).Assembly.Location) + "\\" + "My Download Manager.exe";
            System.Diagnostics.Process.Start(paththis, url);
        }

        private string GetExtensionAutoStartDownload()
        {
            string RegistrySource = @"Software\My Download Manager";
            string result = string.Empty;
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistrySource);
                return key.OpenSubKey(RegistrySource).GetValue("DownloadExtension").ToString().ToLower();
            }
            catch (Exception ex)
            { }
            return result;
        }
        private bool CheckIsExtensionAutoDownload(string extesion)
        {
            extesion = extesion.ToLower().Remove(0, 1);
            string[] auto = GetExtensionAutoStartDownload().Split(' ');
            for (int i = 0; i < auto.Length; i++)
            {
                if (auto[i] == "*" || auto[i] == extesion)
                    return true;
                if (extesion.Length == auto[i].Length)
                {
                    int count = 0;
                    int counttrue = 0;
                    while (count < extesion.Length)
                    {
                        if (auto[i][count] == '*' || extesion[count] == auto[i][count])
                            counttrue++;
                        count++;
                    }
                    if (count == counttrue)
                        return true;
                }
            }
            return false;
        }
    }
    #endregion

    #region >- Interface IDownloadManager -<
    [ComVisible(true), ComImport]
    [Guid("C0E2C2BC-BAA5-4234-9051-54BF0BC10E67")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDownloadManager
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        void Download(IMoniker pmk, IBindCtx pbc, [In, MarshalAs(UnmanagedType.U4)] UInt32 dwBindVerb, [In] Int32 grfBINDF, ref IntPtr pBindInfo, [In, MarshalAs(UnmanagedType.LPWStr)] string pszHeaders, [In, MarshalAs(UnmanagedType.LPWStr)] string pszRedir, [In, MarshalAs(UnmanagedType.U4)] UInt32 uiCP);
    }
    #endregion
     */
}
