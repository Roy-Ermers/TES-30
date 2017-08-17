using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TES30
{
    public partial class Scrollview : ContainerControl
    {
        public Scrollview()
        {
            InitializeComponent();
            AutoScroll = true;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

        }
        public void Add(Control control)
        {
            control.Size = new Size(Width-30,control.Height);
            int totalY = 15;
            foreach (Control c in Controls)
            {
                totalY += c.Size.Height + 15;
            }
            Controls.Add(control);
            control.Location = new Point(15, totalY);
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate();
        }
        public void Clear()
        {
         foreach(Control c in Controls)
            {
                c.Dispose();
            }
            Controls.Clear();
        }
        public void Remove(Control control)
        {
            control.Dispose();
            Controls.Remove(control);
            UpdateLayout();
        }
        public void UpdateLayout()
        {
            int totalY = 0;
            foreach (Control c in Controls)
            {
                totalY += c.Size.Height + 15;
                c.Location = new Point(0, totalY);
            }

        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.Clear(BackColor);
            pevent.Graphics.DrawRectangle(new Pen(ControlPaint.Dark(BackColor,0.01f), 10), ClientRectangle);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
