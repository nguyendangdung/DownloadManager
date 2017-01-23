using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
namespace My_Download_Manager
{
    public class ObjLinkMediafire
    {
        private string Cookie = string.Empty;
        /*public string GetLinkMediaFireOld(string Url)
        {
            string Result = string.Empty;
            Cookie = string.Empty;
            string MainContent = ReadContent(Url, true);
            string cu = Getcu(MainContent);
            if (!string.IsNullOrEmpty(cu))
            {
                string qk, pk, r;
                string[] Keys = cu.Split(',');
                qk = Keys[0].Substring(1, Keys[0].Length - 2);
                pk = Keys[1].Substring(1, Keys[1].Length - 2);
                r = Keys[2].Substring(1, Keys[2].Length - 2);
                string UrlContainLink = "http://www.mediafire.com/dynamic/download.php?qk=" + qk + "&pk=" + pk + "&r=" + r;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlContainLink);
                request.Headers[HttpRequestHeader.Cookie] = Cookie;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());

                string ContainLink = string.Empty;
                System.Collections.Hashtable Values = new System.Collections.Hashtable();
                string line = string.Empty;
                bool Start = false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (Start)
                    {
                        if (line.StartsWith("var"))
                        {
                            string[] str1 = line.Split(';');
                            for (int j = 0; j < str1.Length; j++)
                            {
                                if (!string.IsNullOrEmpty(str1[j]))
                                {
                                    string[] str2 = str1[j].Split('=');
                                    string value = str2[1].Trim();
                                    string key = str2[0].Split(' ')[1].Trim();
                                    Values[key] = value.Substring(1, value.Length - 2);
                                }
                            }
                        }
                        else
                        {
                            ContainLink = sr.ReadToEnd();
                            break;
                        }
                    }
                    if (Start == false)
                    {
                        if (line.StartsWith("var iAction = 15;"))
                            Start = true;
                    }
                }
                string[] ListValue = GetListValue(ContainLink);
                string strlstvalue = string.Empty;
                for (int i = 0; i < ListValue.Length; i++)
                {
                    strlstvalue += Values[ListValue[i]];
                }
                Result = "http://" + Values["sServer"] + "/" + strlstvalue + "g/" + Values["sQk"] + "/" + Values["sFile"];
                sr.Close();
                response.Close();
            }
            return Result;
        }*/
        public string GetLinkMediaFire(string Url)
        {
            string Result = string.Empty;
            try
            {
                Cookie = string.Empty;
                string MainContent = ReadContent(Url);
                string cu = Getcu(MainContent);
                string id = GetID(MainContent);
                if (!string.IsNullOrEmpty(cu))
                {
                    string qk, pk, r;
                    string[] Keys = cu.Split(',');
                    qk = Keys[0].Substring(1, Keys[0].Length - 2);
                    pk = Keys[1].Substring(1, Keys[1].Length - 2);
                    r = Keys[2].Substring(1, Keys[2].Length - 2);
                    string UrlContainLink = "http://www.mediafire.com/dynamic/download.php?qk=" + qk + "&pk=" + pk + "&r=" + r;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlContainLink);
                    request.Headers[HttpRequestHeader.Cookie] = Cookie;
                    request.UserAgent = ObjStatic.UserAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    if (!string.IsNullOrEmpty(response.Headers[HttpResponseHeader.SetCookie]))
                        Cookie = response.Headers[HttpResponseHeader.SetCookie];
                    string ContainLink = string.Empty;
                    System.Collections.Hashtable Values = new System.Collections.Hashtable();
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] str1 = line.Split(';');
                        for (int j = 0; j < str1.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(str1[j]) && str1[j].StartsWith("var"))
                            {
                                string[] str2 = str1[j].Split('=');
                                string value = str2[1].Trim();
                                string key = str2[0].Split(' ')[1].Trim();
                                Values[key] = value.Replace("'", "");
                            }
                        }
                        ContainLink += line;
                    }
                    ContainLink = ContainLink.Substring(ContainLink.IndexOf(id) + id.Length);
                    string totaldata = GetDataBettween(ContainLink, "http://\"", "'\">");
                    string[] ListValue = totaldata.Split('+');
                    string strlstvalue = string.Empty;
                    for (int i = 0; i < ListValue.Length; i++)
                    {
                        string o = ListValue[i].Trim();
                        if (!string.IsNullOrEmpty(o))
                        {
                            if (o.StartsWith("'"))
                                strlstvalue += o.Replace("'", "");
                            else strlstvalue += Values[o];
                        }
                    }
                    Result = "http://" + strlstvalue;
                    sr.Close();
                    response.Close();
                }
                //Uri tempurl = new Uri(Result);
                //ObjStatic.Cookies[tempurl.Host.ToLower()] = Cookie;
            }
            catch (Exception ex)
            {
                //  System.Windows.Forms.MessageBox.Show("Loi O Day : "+ex.Message);
            }
            return Result;
        }
        private string Getcu(string data)
        {
            string result = string.Empty;
            int index1 = data.IndexOf("cu('");
            string strtemp = data.Substring(index1);
            int index2 = strtemp.IndexOf(")");
            result = strtemp.Substring(3, index2 - 3);
            return result;
        }
        private string GetID(string content)
        {
            int index = content.IndexOf("<div id=\"remove_ads_button3\"");
            string str = content.Substring(0, index);
            int d1 = str.LastIndexOf("<div");
            int d2 = str.LastIndexOf("</div>");
            str = str.Substring(d1, d2 - d1);
            d1 = str.IndexOf("id=\"");
            string id = str.Substring(d1 + 4);
            return id.Substring(0, id.IndexOf("\""));
        }
        private string[] GetListValue(string data)
        {
            string start = "sServer +'/' +";
            int index1 = data.IndexOf(start);
            string strtemp = data.Substring(index1);
            int index2 = strtemp.IndexOf("+ 'g/'");
            return strtemp.Substring(start.Length, index2 - start.Length).Split('+');
        }
        private string GetDataBettween(string data, string start, string end)
        {
            int index1 = data.IndexOf(start);
            string strtemp = data.Substring(index1);
            int index2 = strtemp.IndexOf(end);
            return strtemp.Substring(start.Length, index2 - start.Length);
        }
        private string ReadContent(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = ObjStatic.UserAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string str = sr.ReadToEnd();
            sr.Close();
            Cookie = response.Headers[HttpResponseHeader.SetCookie];
            response.Close();
            return str;
        }
        private string GetShareKey(string url)
        {
            try
            {
                string key = url.Split('?')[1].Split('&')[0].Split('=')[1];
                return key.Trim();
            }
            catch (Exception ex) { }
            return string.Empty;
        }
        public List<string[]> GetLinkFolder(string link)
        {
            List<string[]> Res = new List<string[]>();
            string sharekey = GetShareKey(link);
            string url = "http://www.mediafire.com/js/myfiles.php?tool=&key=" + sharekey + "&t=_shared";
            string HTML = ReadContent(url);
            string[] analyst = HTML.Split(';', '\n');
            for (int i = 0; i < analyst.Length; i++)
            {
                string str = analyst[i];
                if (!string.IsNullOrEmpty(str))
                {
                    str = str.Trim();
                    if (str.StartsWith("es"))
                    {
                        string[] arrtemp = str.Split('=');
                        if (arrtemp.Length > 1)
                        {
                            string arr = arrtemp[1];
                            arr = arr = arr.Substring(6, arr.Length - 7);
                            string[] lastanalyst = arr.Split(',');
                            string filename = GetContentInString(lastanalyst[5]);
                            string size = GetContentInString(lastanalyst[6]);
                            string key = GetContentInString(lastanalyst[3]);
                            Res.Add(new string[] { filename, key, size });
                        }
                    }
                }
            }
            return Res;
        }
        private string GetContentInString(string data)
        {
            return data.Substring(1, data.Length - 2);
        }
    }
}
