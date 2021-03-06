using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
namespace My_Download_Manager
{
    public class GetIconWindow
    {
        #region >- Variable & Struct & Enum -<

        private Hashtable SmallIcons;
        private Hashtable LargeIcons;
        const uint SHGFI_ICON = 0x100;
        const uint SHGFI_USEFILEATTRIBUTES = 0x10;
        struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            public string szDisplayName;
            public string szTypeName;
        };
        public enum IconSize : uint
        {
            Large = 0x0,  //32x32
            Small = 0x1 //16x16		
        }

        #endregion

        #region >- Contructure -<

        public GetIconWindow()
        {
            SmallIcons = new Hashtable();
            LargeIcons = new Hashtable();
            GetDefaultIcon();
        }

        #endregion
       
        #region >- Content -<
        
        private void GetDefaultIcon()
        {
            try
            {
                IntPtr[] large = new IntPtr[1], small = new IntPtr[1];
                ExtractIconEx("Shell32.dll", 0, large, small, 1);
                if (large[0] != null)
                {
                    LargeIcons["*"] = Icon.FromHandle(large[0]);
                }
                if (small[0] != null)
                {
                    SmallIcons["*"] = Icon.FromHandle(small[0]);
                }
            }
            catch (Exception ex) { }
        }
        public Icon GetIconFromExtension(string Extention,IconSize Size)
        {
            Extention = Extention.ToLower();
            try
            {
                Hashtable hash = (Size == IconSize.Large) ? LargeIcons : SmallIcons;
                if (hash[Extention]!=null)
                {
                    return (Icon)hash[Extention];
                }
                SHFILEINFO TempInfo = new SHFILEINFO();
                SHGetFileInfo(Extention, 0, ref TempInfo, (uint)Marshal.SizeOf(TempInfo), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | (uint)Size);
                Icon temp = Icon.FromHandle(TempInfo.hIcon);
                if (temp != null)
                {
                    hash[Extention] = temp;
                }
                else
                {
                    temp = (Icon)hash["*"];
                }
                return temp;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error :" + ex.Message);
            }
            return null;
        }

        #endregion

        #region >- Shell method -<

        [DllImport("Shell32", CharSet = CharSet.Auto)]
        extern static int ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phIconLarge, IntPtr[] phIconSmall, int nIcons);
        [DllImport("shell32.dll")]
        static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        #endregion
    }
      
}
