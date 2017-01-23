using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace My_Download_Manager
{

    #region >- Custom Cell -<

    public class CustomGridCell : DataGridViewTextBoxCell
    {
        private System.Drawing.Icon cellicon;
        private int WidthIcon = 17;
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            System.Drawing.SolidBrush brush;
            if ((cellState & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
                brush=new System.Drawing.SolidBrush(cellStyle.SelectionBackColor);
            else brush = new System.Drawing.SolidBrush(cellStyle.BackColor);
            graphics.FillRectangle(brush, cellBounds.X, cellBounds.Y, WidthIcon+1, cellBounds.Height);
            if (cellicon != null)
            {
                graphics.DrawIcon(cellicon, new System.Drawing.Rectangle(cellBounds.X+2, cellBounds.Y+1, WidthIcon-1, cellBounds.Height-2));
            }
            cellBounds.X += WidthIcon;
            cellBounds.Width -= WidthIcon;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
        protected override void PaintBorder(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle bounds, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            bounds.X -= WidthIcon;
            bounds.Width += WidthIcon;
            base.PaintBorder(graphics, clipBounds, bounds, cellStyle, advancedBorderStyle);
        }
        public System.Drawing.Icon CellIcon
        {
            set
            {
                cellicon = value;
            }
        }
    }

    #endregion

    #region >- Custom Column -<

    public class CustomGridColumn : DataGridViewTextBoxColumn
    {
        public CustomGridColumn()
        {
            CellTemplate = new CustomGridCell();
        }
    }

    #endregion

}
