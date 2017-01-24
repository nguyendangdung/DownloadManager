using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DL;

namespace My_Download_Manager
{
    public partial class CustomProcessBar : UserControl
    {
        #region >- Variable -<
        
        private long value;
        private long maxvalue;
        private string text;
        private Color valuecolor;
        private List<Part> parts;

        #endregion

        #region >- Constructure -<
        
        public CustomProcessBar()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            Value = 0;
            MaxValue = 100;
            ValueColor = Color.Blue;
            BackColor = Color.Black;
            Font = new Font("tahoma", 10);
        }

        #endregion

        #region >- Drawing -<

        private void CustomProcessBar_Paint(object sender, PaintEventArgs e)
        {
            DrawBackGround(e);
            if (maxvalue > 0)
            {
                if (parts == null)
                {
                    if(Value>0)
                        DrawValue(e);
                }
                else DrawMultiValue(e);
            }
        }
        private void DrawBackGround(PaintEventArgs e)
        {
            int x = 0;
            int y =0; 
            int w = Width;
            int h = Height;
            if (w < 1 || h < 1)
                return;
            Rectangle Rec = new Rectangle(x, y, w, h);
            LinearGradientBrush br = new LinearGradientBrush(Rec, BackColor, BackColor, LinearGradientMode.Vertical);
            ColorBlend cbl = new ColorBlend(3);
            cbl.Positions = new float[] { 0.0F, 0.5F, 1.0F };
            cbl.Colors = new Color[] { GetColor(BackColor, true), BackColor, GetColor(BackColor, true) };
            br.InterpolationColors = cbl;
            e.Graphics.FillRectangle(br, Rec);
        }
        private void DrawValue(PaintEventArgs e)
        {
            int x = 0;
            int y = 0;
            int w = Width;
            int h = Height;
            float width = (float)value * w / maxvalue;
            if (width == 0 || h == 0)
                return;
            RectangleF rec = new RectangleF(x, y, width, h);
            Color colorend = GetColor(valuecolor, true);
            LinearGradientBrush brush = new LinearGradientBrush(rec, Color.Black, Color.Black, LinearGradientMode.Vertical);
            ColorBlend cbl = new ColorBlend(3);
            cbl.Positions = new float[] { 0.0F, 0.5F, 1.0F };
            cbl.Colors = new Color[] { ValueColor, colorend, ValueColor };
            brush.InterpolationColors = cbl;
            e.Graphics.FillRectangle(brush, rec);

            string str = string.Empty;
            if (!string.IsNullOrEmpty(text))
            {
                str = text;
            }
            else
            {
                float percent = (float)value * 100 / maxvalue;
                str = percent.ToString("0.00") + "%";
            }
            SizeF size = e.Graphics.MeasureString(str, Font);
            float centerx = x + (w - size.Width) / 2;
            float centery = y + (h - size.Height) / 2;
            Brush btext = new SolidBrush(ForeColor);
            e.Graphics.DrawString(str, Font, btext, centerx, centery);
        }
        private void DrawMultiValue(PaintEventArgs e)
        {
            try
            {
                int x = 0;
                int y = 0;
                int w =Width ;
                int h = Height;
                Color colorend = GetColor(valuecolor, true);
                ColorBlend cbl = new ColorBlend(3);
                cbl.Positions = new float[] { 0.0F, 0.5F, 1.0F };
                cbl.Colors = new Color[] { ValueColor, colorend, ValueColor };
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(x, y, w, h), Color.Black, Color.Black, LinearGradientMode.Vertical);
                brush.InterpolationColors = cbl;
                for (int i = 0; i < parts.Count; i++)
                {
                    var p = parts[i];
                    float From = (float)p.Start * w / maxvalue;
                    float width = (float)p.DownloadedSize * w / maxvalue;// +1;
                    RectangleF rec = new RectangleF(From, y, width, h);
                    e.Graphics.FillRectangle(brush, rec);
                }
            }
            catch (Exception ex) { }
        }
        private Color GetColor(Color color,bool IsDarkMore)
        {
            int delta = 100;
            if(IsDarkMore)
                delta=-50;
            int r = (int)color.R + delta;
            int b = (int)color.B + delta;
            int g = (int)color.G + delta;
            if (r < 0) r = 0;
            if (r > 255) r = 255;

            if (b < 0) b = 0;
            if (b > 255) b = 255;

            if (g < 0) g = 0;
            if (g > 255) g = 255;

            return Color.FromArgb(r, g, b);
        }
        #endregion

        #region >- Properties -<

        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                Invalidate();
            }
        }
        public long Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value > maxvalue)
                    this.value = maxvalue;
                else
                    if (value < 0)
                        this.value = 0;
                    else this.value = value;
                Invalidate();
            }
        }
        public long MaxValue
        {
            get
            {
                return maxvalue;
            }
            set
            {
                if (maxvalue < this.value)
                    maxvalue = this.value;
                else maxvalue = value;
            }
        }
        public Color ValueColor
        {
            get
            {
                return valuecolor;
            }
            set
            {
                valuecolor = value;
            }
        }
        public List<Part> Parts
        {
            set
            {
                parts = value;
                Invalidate();
            }
        }
        public void UpdateValue()
        {
            Invalidate();
        }
        #endregion
    }
}
