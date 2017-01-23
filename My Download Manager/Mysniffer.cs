using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net;

namespace My_Download_Manager
{
    public class Mysniffer
    {
        private DataManager m_Data;
        public TcpPacket packet;
        public Mysniffer()
        {
            m_Data = new DataManager();
        }
        public void Sniff(byte[] buffer)
        {
            int identification = 0;
            int num2 = 0;
            uint addr = 0;
            uint num4 = 0;
            int offset = 0;
            IPv4Datagram datagram = null;
            IPv4Fragment fragment = new IPv4Fragment();
            fragment.MoreFlag = HeaderParser.ToByte(buffer, 50, 1) > 0;
            fragment.Offset = HeaderParser.ToInt(buffer, 0x33, 13) * 8;
            fragment.TTL = HeaderParser.ToInt(buffer, 0x40, 8);
            fragment.Length = HeaderParser.ToUShort(buffer, 0x10, 0x10);
            offset = HeaderParser.ToInt(buffer, 4, 4) * 4;
            fragment.SetData(buffer, offset, fragment.Length - offset);
            identification = HeaderParser.ToByte(buffer, 0x20, 0x10);
            num2 = HeaderParser.ToByte(buffer, 0x48, 8);
            addr = HeaderParser.ToUInt(buffer, 0x60, 0x20);
            num4 = HeaderParser.ToUInt(buffer, 0x80, 0x20);
            IPAddress source = IPAddress.Parse(IPv4Datagram.GetIPString(addr));
            IPAddress dest = IPAddress.Parse(IPv4Datagram.GetIPString(num4));
            datagram = m_Data.GetIPv4Datagram(identification, source, dest);
            if (datagram == null)
            {
                datagram = new IPv4Datagram();
                datagram.Identification = identification;
                datagram.Source = source;
                datagram.Destination = dest;
                datagram.Protocol = num2;
            }
            datagram.AddFragment(fragment);
            if (!datagram.Complete)
            {
                m_Data.AddIPv4Datagram(datagram);
            }
            else
            {
                switch (datagram.Protocol)
                {
                    case 6:
                        HandleTcpPacket(datagram.Data, datagram.Source, datagram.Destination);
                        break;
                    default: break;
                }
                if (datagram.WasFragmented())
                {
                    m_Data.RemoveIPv4Datagram(datagram);
                }
            }        
        }
        private void HandleTcpPacket(byte[] data, IPAddress source, IPAddress destination)
        {
            packet = new TcpPacket();
            int port = HeaderParser.ToInt(data, 0, 0x10);
            int num2 = HeaderParser.ToInt(data, 0x10, 0x10);
            int offset = HeaderParser.ToInt(data, 0x60, 4) * 4;
            packet.Source = new IPEndPoint(source, port);
            packet.Destination = new IPEndPoint(destination, num2);
            packet.Sequence = HeaderParser.ToUInt(data, 0x20, 0x20);
            packet.Acknowledgement = HeaderParser.ToUInt(data, 0x40, 0x20);
            packet.Urgent = HeaderParser.ToByte(data, 0x6a, 1) != 0;
            packet.Ack = HeaderParser.ToByte(data, 0x6b, 1) != 0;
            packet.Push = HeaderParser.ToByte(data, 0x6c, 1) != 0;
            packet.Reset = HeaderParser.ToByte(data, 0x6d, 1) != 0;
            packet.Syn = HeaderParser.ToByte(data, 110, 1) != 0;
            packet.Fin = HeaderParser.ToByte(data, 0x6f, 1) != 0;
            packet.SetData(data, offset, data.Length - offset);
        }
    }
    public class HttpPacket
    {
        #region Old
        /*
        public static int ACTION_RECEIVE = 1;
        public static int ACTION_SEND = 0;
        public string m_Host = "";
        public string m_Method = "";
        public string m_URL = "";
        public long m_length = 0;
        public static string GetLineNumber(int LineNumber, string Buffer)
        {
            char[] separator = new char[] { '\r', '\n' };
            string[] strArray = Buffer.Split(separator);
            if (strArray.Length <= LineNumber)
            {
                return null;
            }
            return strArray[LineNumber];
        }
        public static string GetLineWith(string BeginLine, string Buffer)
        {
            char[] separator = new char[] { '\r', '\n' };
            string[] strArray = Buffer.Split(separator);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].StartsWith(BeginLine))
                {
                    return strArray[i];
                }
            }
            return null;
        }
        public static bool IsItNewPacket(string RawData)
        {
            return ((RawData.StartsWith("HTTP/") || RawData.StartsWith("GET ")) || RawData.StartsWith("POST"));
        }
        public void Parse(int Action, string Data)
        {
            string lineNumber = "";
            int length = 0;
            if (Action == ACTION_SEND)
            {
                lineNumber = GetLineNumber(0, Data);
                if ((lineNumber != null) && ((length = lineNumber.IndexOf(" ")) >= 0))
                {
                    this.m_Method = lineNumber.Substring(0, length).Trim();
                    this.m_URL = lineNumber.Substring(length, lineNumber.IndexOf(" ", (int)(length + 1)) - length).Trim();
                }
                this.m_Host = GetLineWith("Host:", Data);
                if (this.m_Host != null)
                {
                    this.m_Host = this.m_Host.Substring(5, this.m_Host.Length - 5);
                }
            }
            else
            {
                lineNumber = GetLineNumber(0, Data);
                if (lineNumber != null)
                {
                    this.m_URL = lineNumber;
                }
                string temp = GetLineWith("Content-Length:", Data);
                if (temp != null)
                    m_length = Convert.ToInt64(temp.Split(':')[1].Trim());
                this.m_Host = GetLineWith("Host:", Data);
                if (this.m_Host != null)
                {
                    this.m_Host = this.m_Host.Substring(5, this.m_Host.Length - 5);
                }
            }
        }
        public string Host
        {
            get
            {
                return this.m_Host;
            }
        }
        public long Length
        {
            set
            {
                m_length = value;
            }
            get
            {
                return m_length;
            }
        }
        public string Method
        {
            get
            {
                return this.m_Method;
            }
        }
        public string URL
        {
            get
            {
                return this.m_URL;
            }
        }
         */
        #endregion
        public string Url;
        public long Size = -1;
        public string ContentType;
        public string UserAgent;
        public void Parse(string Data,bool IsSend)
        {
            char[] separator = new char[] { '\n' };
            string[] strArray = Data.Split(separator);
            if (strArray.Length > 0)
            {
                if (IsSend)
                {
                    string path = string.Empty;
                    string host = string.Empty;
                    string Cookie = string.Empty;
                    if (strArray[0].StartsWith("GET "))
                        path = strArray[0].Split(' ')[1].ToLower();
                    for (int i = 1; i < strArray.Length; i++)
                    {
                        string temp = strArray[i];
                        if (temp.StartsWith("Host:"))
                        {
                            host = temp.Split(':')[1].Trim().ToLower();
                        }
                        if (temp.StartsWith("User-Agent:"))
                        {
                            UserAgent = temp.Split(':')[1].Trim();
                        }
                        if (temp.StartsWith("Cookie:"))
                        {
                            Cookie = temp.Split(':')[1].Trim();
                        }
                    }
                    if (path.StartsWith("http://"))
                        Url = path;
                    else
                        Url = "http://" + host + path;
                    if (!string.IsNullOrEmpty(Cookie))
                        ObjStatic.Cookies[host] = Cookie;
                }
                else
                {

                    for (int i = 1; i < strArray.Length; i++)
                    {
                        string temp = strArray[i];
                        if (temp.Trim().Length == 0)
                            break;
                        if (temp.StartsWith("Content-Length:"))
                        {
                            Size = Convert.ToInt64(temp.Split(':')[1].Trim());
                        }
                        else if (temp.StartsWith("Content-Type:"))
                        {
                            ContentType = temp.Split(':')[1].Trim();
                        }
                        else if (temp.StartsWith("Content-Range:"))
                        {
                            try
                            {
                                Size = Convert.ToInt64(temp.Split('/')[1]);
                            }
                            catch (Exception ex) { }
                        }
                        
                    }
                }
            }
        }
    }
    public class DataManager
    {
        private Hashtable m_IPv4Table = null;

        public DataManager()
        {
            m_IPv4Table = new Hashtable();
        }

        public void AddIPv4Datagram(IPv4Datagram datagram)
        {
            m_IPv4Table.Add(datagram.GetHashString(), datagram);
        }

        public IPv4Datagram GetIPv4Datagram(int identification, IPAddress source, IPAddress dest)
        {
            string format = "{0}:{1}:{2}";
            string key = string.Format(format, identification, source.Address.ToString(), dest.Address.ToString());
            if (m_IPv4Table.Contains(key))
            {
                return (IPv4Datagram)m_IPv4Table[key];
            }
            return null;
        }

        public void RemoveIPv4Datagram(IPv4Datagram datagram)
        {
            m_IPv4Table.Remove(datagram.GetHashString());
        }
    }
    public class IPv4Datagram
    {
        private bool m_Complete = false;
        private byte[] m_Data = null;
        private IPAddress m_Destination = null;
        private IPv4Fragment m_FragmentHead = null;
        private int m_Identification = 0;
        private int m_Length = 0;
        private int m_Protocol = 0;
        private IPAddress m_Source = null;
        private int m_TypeOfService = 0;
        private string m_UpperProtocol = null;

        public void AddFragment(IPv4Fragment fragment)
        {
            if (m_FragmentHead == null)
            {
                m_FragmentHead = fragment;
            }
            else if (fragment.Offset < m_FragmentHead.Offset)
            {
                fragment.Next = m_FragmentHead;
                m_FragmentHead = fragment;
            }
            else
            {
                IPv4Fragment fragmentHead = m_FragmentHead;
                IPv4Fragment next = fragmentHead.Next;
                while ((fragmentHead != null) && (fragment.Offset > fragmentHead.Offset))
                {
                    next = fragmentHead;
                    fragmentHead = fragmentHead.Next;
                }
                next.Next = fragment;
                fragment.Next = fragmentHead;
            }
            TestComplete();
        }

        private void CombineData()
        {
            IPv4Fragment fragment;
            int num = 0;
            int destinationIndex = 0;
            for (fragment = m_FragmentHead; fragment != null; fragment = fragment.Next)
            {
                num += fragment.Length;
            }
            m_Data = new byte[num];
            m_Length = num;
            for (fragment = m_FragmentHead; fragment != null; fragment = fragment.Next)
            {
                Array.Copy(fragment.Data, 0, m_Data, destinationIndex, fragment.Length);
                destinationIndex += fragment.Length;
            }
        }

        public string GetHashString()
        {
            string format = "IPv4:{0}:{1}";
            return string.Format(format, SourceIP, DestinationIP);
        }

        public static string GetIPString(uint addr)
        {
            uint num = addr >> 0x18;
            uint num2 = (addr >> 0x10) & 0xff;
            uint num3 = (addr >> 8) & 0xff;
            uint num4 = addr & 0xff;
            string format = "{0}.{1}.{2}.{3}";
            return string.Format(format, new object[] { num, num2, num3, num4 });
        }

        public string GetUpperProtocol()
        {
            return m_UpperProtocol;
        }

        private void SetUpperProtocol(int protocol)
        {
            m_Protocol = protocol;
            switch (Protocol)
            {
                case 1:
                    m_UpperProtocol = "ICMP";
                    return;

                case 3:
                    m_UpperProtocol = "GW To GW";
                    return;

                case 4:
                    m_UpperProtocol = "CMCC";
                    return;

                case 5:
                    m_UpperProtocol = "ST";
                    return;

                case 6:
                    m_UpperProtocol = "Tcp";
                    return;

                case 7:
                    m_UpperProtocol = "Ucl";
                    return;

                case 8:
                    m_UpperProtocol = "7";
                    return;

                case 9:
                    m_UpperProtocol = "Secure";
                    return;

                case 10:
                    m_UpperProtocol = "BBN";
                    return;

                case 11:
                    m_UpperProtocol = "NVP";
                    return;

                case 12:
                    m_UpperProtocol = "PUP";
                    return;

                case 13:
                    m_UpperProtocol = "Pluribus";
                    return;

                case 14:
                    m_UpperProtocol = "Telenet";
                    return;

                case 15:
                    m_UpperProtocol = "XNET";
                    return;

                case 0x10:
                    m_UpperProtocol = "Chaos";
                    return;

                case 0x11:
                    m_UpperProtocol = "Udp";
                    return;

                case 0x12:
                    m_UpperProtocol = "Multiplexing";
                    return;

                case 0x13:
                    m_UpperProtocol = "DCN";
                    return;

                case 20:
                    m_UpperProtocol = "TAC Monitoring";
                    return;

                case 0x3f:
                    m_UpperProtocol = "Any local network";
                    return;

                case 0x40:
                    m_UpperProtocol = "SATNET";
                    return;

                case 0x41:
                    m_UpperProtocol = "MIT Subnet Support";
                    return;

                case 0x45:
                    m_UpperProtocol = "SATNET Monitoring";
                    return;

                case 0x47:
                    m_UpperProtocol = "Internet packet core utility";
                    return;

                case 0x4c:
                    m_UpperProtocol = "Backroom SATNET";
                    return;

                case 0x4e:
                    m_UpperProtocol = "WIDEBAND Monitoring";
                    return;

                case 0x4f:
                    m_UpperProtocol = "WIDEBAND EXPAK";
                    return;
            }
            m_UpperProtocol = Protocol.ToString();
        }

        private void TestComplete()
        {
            bool flag = false;
            IPv4Fragment fragmentHead = m_FragmentHead;
            int num = 0;
            while (fragmentHead != null)
            {
                if (fragmentHead.Next != null)
                {
                    if (fragmentHead.Offset == num)
                    {
                        fragmentHead = fragmentHead.Next;
                        num += fragmentHead.Length;
                    }
                    else
                    {
                        fragmentHead = null;
                    }
                }
                else if ((fragmentHead.Offset == num) && !fragmentHead.MoreFlag)
                {
                    fragmentHead = null;
                    flag = true;
                }
                else
                {
                    fragmentHead = null;
                }
            }
            if (flag)
            {
                CombineData();
            }
            m_Complete = flag;
        }

        public bool WasFragmented()
        {
            return (FragmentList.Next != null);
        }

        public bool Complete
        {
            get
            {
                return m_Complete;
            }
        }

        public byte[] Data
        {
            get
            {
                return m_Data;
            }
        }

        public IPAddress Destination
        {
            get
            {
                return m_Destination;
            }
            set
            {
                m_Destination = value;
            }
        }

        public string DestinationIP
        {
            get
            {
                return Destination.ToString();
            }
        }

        public IPv4Fragment FragmentList
        {
            get
            {
                return m_FragmentHead;
            }
        }

        public int Identification
        {
            get
            {
                return m_Identification;
            }
            set
            {
                m_Identification = value;
            }
        }

        public int Length
        {
            get
            {
                return m_Length;
            }
            set
            {
                m_Length = value;
            }
        }

        public int Protocol
        {
            get
            {
                return m_Protocol;
            }
            set
            {
                SetUpperProtocol(value);
            }
        }

        public IPAddress Source
        {
            get
            {
                return m_Source;
            }
            set
            {
                m_Source = value;
            }
        }

        public string SourceIP
        {
            get
            {
                return Source.ToString();
            }
        }

        public int TypeOfService
        {
            get
            {
                return m_TypeOfService;
            }
            set
            {
                m_TypeOfService = value;
            }
        }
    }
    public class IPv4Fragment
    {
        private byte[] m_Data = null;
        private int m_Length = 0;
        private bool m_MoreFlag = false;
        private IPv4Fragment m_Next = null;
        private int m_Offset = 0;
        private int m_TTL = 0;

        public void SetData(byte[] Data, int offset, int length)
        {
            m_Data = new byte[length];
            m_Length = length;
            Array.Copy(Data, offset, m_Data, 0, length);
        }

        public byte[] Data
        {
            get
            {
                return m_Data;
            }
        }

        public int Length
        {
            get
            {
                return m_Length;
            }
            set
            {
                m_Length = value;
            }
        }

        public bool MoreFlag
        {
            get
            {
                return m_MoreFlag;
            }
            set
            {
                m_MoreFlag = value;
            }
        }

        public IPv4Fragment Next
        {
            get
            {
                return m_Next;
            }
            set
            {
                m_Next = value;
            }
        }

        public int Offset
        {
            get
            {
                return m_Offset;
            }
            set
            {
                m_Offset = value;
            }
        }

        public int TTL
        {
            get
            {
                return m_TTL;
            }
            set
            {
                m_TTL = value;
            }
        }
    }
    public class HeaderParser
    {
        public static byte ToByte(byte[] datagram, int offset, int length)
        {
            return (byte)ToUInt(datagram, offset, length);
        }
        public static int ToInt(byte[] datagram, int offset, int length)
        {
            return (int)ToUInt(datagram, offset, length);
        }
        public static uint ToUInt(byte[] datagram, int offset, int length)
        {
            uint num = 0;
            for (int i = 0; i < length; i++)
            {
                int num3 = (offset + i) % 8;
                int index = ((offset + i) - num3) / 8;
                byte num5 = datagram[index];
                int num4 = num5 >> (7 - num3);
                num4 &= 1;
                if (num4 > 0)
                {
                    num += (uint)Math.Pow(2.0, (double)((length - i) - 1));
                }
            }
            return num;
        }
        public static ushort ToUShort(byte[] datagram, int offset, int length)
        {
            return (ushort)ToUInt(datagram, offset, length);
        }
    }
    public class TcpPacket
    {
        private bool m_Ack = false;
        private uint m_Acknowledgement = 0;
        private byte[] m_Data = null;
        private int m_DataOffset = 0;
        private IPEndPoint m_Destination = null;
        private bool m_Fin = false;
        private int m_Length = 0;
        private bool m_Push = false;
        private bool m_Reset = false;
        private uint m_Sequence = 0;
        private IPEndPoint m_Source = null;
        private bool m_Syn = false;
        private bool m_Urgent = false;

        public string GetHashString()
        {
            string format = "Tcp:{0}:{1}:{2}:{3}";
            return string.Format(format, new object[] { SourceIP, SourcePort, DestinationIP, DestinationPort });
        }

        public void SetData(byte[] data, int offset, int length)
        {
            m_Data = new byte[length];
            Array.Copy(data, offset, m_Data, 0, length);
        }

        public bool Ack
        {
            get
            {
                return m_Ack;
            }
            set
            {
                m_Ack = value;
            }
        }

        public uint Acknowledgement
        {
            get
            {
                return m_Acknowledgement;
            }
            set
            {
                m_Acknowledgement = value;
            }
        }

        public byte[] Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
            }
        }

        public int DataOffset
        {
            get
            {
                return m_DataOffset;
            }
            set
            {
                m_DataOffset = value;
            }
        }

        public IPEndPoint Destination
        {
            get
            {
                return m_Destination;
            }
            set
            {
                m_Destination = value;
            }
        }

        public string DestinationIP
        {
            get
            {
                return Destination.Address.ToString();
            }
        }

        public int DestinationPort
        {
            get
            {
                return m_Destination.Port;
            }
        }

        public bool Fin
        {
            get
            {
                return m_Fin;
            }
            set
            {
                m_Fin = value;
            }
        }

        public int Length
        {
            get
            {
                return m_Length;
            }
            set
            {
                m_Length = value;
            }
        }

        public bool Push
        {
            get
            {
                return m_Push;
            }
            set
            {
                m_Push = value;
            }
        }

        public bool Reset
        {
            get
            {
                return m_Reset;
            }
            set
            {
                m_Reset = value;
            }
        }

        public uint Sequence
        {
            get
            {
                return m_Sequence;
            }
            set
            {
                m_Sequence = value;
            }
        }

        public IPEndPoint Source
        {
            get
            {
                return m_Source;
            }
            set
            {
                m_Source = value;
            }
        }
        public string SourceIP
        {
            get
            {
                return Source.Address.ToString();
            }
        }
        public int SourcePort
        {
            get
            {
                return m_Source.Port;
            }
        }
        public bool Syn
        {
            get
            {
                return m_Syn;
            }
            set
            {
                m_Syn = value;
            }
        }
        public bool Urgent
        {
            get
            {
                return m_Urgent;
            }
            set
            {
                m_Urgent = value;
            }
        }
    }
}
