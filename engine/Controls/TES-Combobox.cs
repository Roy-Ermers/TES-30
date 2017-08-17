using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace TES30.Controls
{
    public partial class TES_Combobox : ComboBox
    {
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                g.Clear(BackColor);
                var darkPen = new Pen(ControlPaint.Dark(BackColor, 0.01f), 5);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                g.DrawRectangle(darkPen, bounds);
                Rectangle dropdownBox = new Rectangle(bounds.Right - bounds.Height, bounds.Y, bounds.Height, bounds.Height);
                if (MouseButtons == MouseButtons.Left)
                    g.FillRectangle(new SolidBrush(ControlPaint.DarkDark(BackColor)), dropdownBox);
                g.DrawRectangle(darkPen, dropdownBox);
                var ArrowPen = new Pen(ControlPaint.Dark(BackColor, 0.01f), 2);
                g.DrawLine(ArrowPen, dropdownBox.Left + dropdownBox.Width / 6,
                    dropdownBox.Top + dropdownBox.Height / 3,
                    dropdownBox.Left + dropdownBox.Width / 2,
                    dropdownBox.Top + dropdownBox.Height / 3 * 2);

                g.DrawLine(ArrowPen, dropdownBox.Right - dropdownBox.Width / 6,
                    dropdownBox.Top + dropdownBox.Height / 3,
                    dropdownBox.Right - dropdownBox.Width / 2,
                    dropdownBox.Top + dropdownBox.Height / 3 * 2);
                if (SelectedIndex >= 0)
                    TextRenderer.DrawText(g, Items[SelectedIndex].ToString(), Font, new Rectangle(0, 0, bounds.Width - bounds.Height, bounds.Height), BackColor.TextColor());


            }
        }
        public TES_Combobox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            DropDownStyle = ComboBoxStyle.DropDownList;
            BackColor = Color.Yellow;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Invalidate();
        }
        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var darkPen = new Pen(ControlPaint.Dark(BackColor, 0.01f), 5);
            Rectangle bounds = new Rectangle(-3, -3, Width + 3, Height + 3);
            g.DrawRectangle(darkPen, bounds);
            Rectangle dropdownBox = new Rectangle(bounds.Right - bounds.Height, bounds.Y, bounds.Height, bounds.Height);
            if (MouseButtons == MouseButtons.Left)
                g.FillRectangle(new SolidBrush(ControlPaint.DarkDark(BackColor)), dropdownBox);
            g.DrawRectangle(darkPen, dropdownBox);
            var ArrowPen = new Pen(ControlPaint.Dark(BackColor, 0.01f), 2);
            g.DrawLine(ArrowPen, dropdownBox.Left + dropdownBox.Width / 6,
                dropdownBox.Top + dropdownBox.Height / 3,
                dropdownBox.Left + dropdownBox.Width / 2,
                dropdownBox.Top + dropdownBox.Height / 3 * 2);

            g.DrawLine(ArrowPen, dropdownBox.Right - dropdownBox.Width / 6,
                dropdownBox.Top + dropdownBox.Height / 3,
                dropdownBox.Right - dropdownBox.Width / 2,
                dropdownBox.Top + dropdownBox.Height / 3 * 2);
            TextRenderer.DrawText(e.Graphics, Items[SelectedIndex].ToString(), Font, new Rectangle(0, 0, bounds.Width - bounds.Height, bounds.Height), BackColor.TextColor());

        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
            TextRenderer.DrawText(e.Graphics, Items[e.Index].ToString(), Font, e.Bounds, e.BackColor.TextColor());
        }
    }
}
