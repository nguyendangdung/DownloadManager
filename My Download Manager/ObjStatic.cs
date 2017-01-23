using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace My_Download_Manager
{
   public class ObjStatic
   {

       #region >- Static Variable -<
       public static Hashtable Cookies;
       public static Configuration Config;
       public static Main FormMain;
       public static GetIconWindow ObjGetIcon;
       public static Sniffer FormSniffer;
       public static ShowFileSniffer FrmShowFileSniff;
       public static MDMImage MdmImages;
       public static int MaxTryConnect = 20;
       public static long TotalLoad = 0;

       public static string MessageBoxCaption = ".: My download manager :.";
       public static string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
       public static string Website = "http://www.tmvn.vn";

       private static Hashtable SimpleExtensionAutoDownload;
       private static List<string> ComplexExtensionAutoDownload;
       public static string PathAppUserTemp = string.Empty;
       public static bool IsRunningSniffer = false;
       #endregion

       #region >- Static Method -<

       public static string ToStringSize(long bytes)
       {
           string Result = string.Empty;
           float temp = 0;
           if (bytes >= 1073741824)
           {
               temp = (float)bytes / 1073741824;
               return temp.ToString("0.00") + " Gb";
           }
           else if (bytes >= 1048576)
           {
               temp = (float)bytes / 1048576;
               return temp.ToString("0.00") + " Mb";
           }
           else if (bytes >= 1024)
           {
               temp = (float)bytes / 1024;
               return temp.ToString("0.00") + " Kb";
           }
           else if (bytes < 0)
               return "unknown";
           return bytes + " bytes";
       }
       public static string ToStringSize(long bytes,string format)
       {
           string Result = string.Empty;
           float temp = 0;
           if (bytes >= 1073741824)
           {
               temp = (float)bytes / 1073741824;
               return temp.ToString(format) + " Gb";
           }
           else if (bytes >= 1048576)
           {
               temp = (float)bytes / 1048576;
               return temp.ToString(format) + " Mb";
           }
           else if (bytes >= 1024)
           {
               temp = (float)bytes / 1024;
               return temp.ToString(format) + " Kb";
           }
           else if (bytes < 0)
               return "unknown";
           return bytes + " bytes";
       }
       public static string ToStringTime(int sec)
       {
           int hour = sec / 3600;
           int temp = sec % 3600;
           int min = temp / 60;
           int second = temp % 60;
           if (hour > 0)
               return hour + " hour " + min + " min " + second + " sec";
           if (min > 0)
               return min + " min " + second + " sec";
           return second + " sec";
       }
       public static string ToStringPercent(long value, long maxvalue)
       {
           float percent = 0;
           if (maxvalue > 0)
           {
               percent = (float)value * 100 / maxvalue;
           }
           return percent.ToString("0.00") + "%";
       }
       public static void CreateSniffForm()
       {
           if (FrmShowFileSniff == null || FrmShowFileSniff.IsDisposed)
           {
               FrmShowFileSniff = new ShowFileSniffer();
               FrmShowFileSniff.Opacity = 0;
               FrmShowFileSniff.Show();
               FrmShowFileSniff.Visible = false;
               FrmShowFileSniff.Opacity = 100;
           }
           if (FormSniffer == null || FormSniffer.IsDisposed)
           {
               FormSniffer = new Sniffer();
               FormSniffer.Visible = false;
               //FormSniffer.Show();
           }
       }
       public static void ShowFormSniff()
       {
           if (ObjStatic.FormSniffer == null || ObjStatic.FormSniffer.IsDisposed)
           {
               ObjStatic.FormSniffer = new Sniffer();
               ObjStatic.FormSniffer.Show();
           }
           else
           {
               ObjStatic.FormSniffer.Show();
               ObjStatic.FormSniffer.Activate();
           }
       }

       public static void UpdateAutoStartDownload()
       {
           try
           {
               SimpleExtensionAutoDownload = new Hashtable();
               ComplexExtensionAutoDownload = new List<string>();
               string[] str = ObjStatic.Config.ExtensionAutoDownload.ToLower().Split(' ');
               for (int i = 0; i < str.Length; i++)
               {
                   if (str[i].IndexOf('*') >= 0)
                   {
                       ComplexExtensionAutoDownload.Add(str[i]);
                   }
                   else SimpleExtensionAutoDownload[str[i]] = true;
               }
           }
           catch(Exception ex){}
       }
       public static bool IsExtensionAutoDownload(string extension)
       {
           if (!string.IsNullOrEmpty(extension))
               extension = extension.Remove(0, 1);
           if (extension.IndexOf('*') >= 0)
           {
               for (int i = 0; i < ComplexExtensionAutoDownload.Count; i++)
               {
                   if (ComplexExtensionAutoDownload[i].Length == extension.Length)
                   {
                       string temp=ComplexExtensionAutoDownload[i];
                       int count1=0,count2=0;

                       for (int j = 0; j < temp.Length; j++)
                       {
                           if(temp[j]!='*')
                           {
                               count1++;
                               if (temp[j] == extension[j])
                                   count2++;
                           }
                       }
                       if (count1 == count2)
                           return true;
                   }
               }
           }
           else
           {
               return SimpleExtensionAutoDownload[extension] != null;
           }
           return false;
       }
       #endregion
   }
}
