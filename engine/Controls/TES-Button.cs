using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TES30.API;
namespace TES30
{
    public partial class TES_Button : Control
    {
        public delegate void DataOnClickHandler(object sender, object data);
        public DataOnClickHandler DataOnClick;
        private object Data;
        public TES_Button(string text)
        {
            InitializeComponent();
            Text = text;
        }
        public TES_Button(string text, object data)
        {
            InitializeComponent();
            Text = text;
            Data = data;
        }
        public TES_Button()
        {
            InitializeComponent();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDown = true;
            Invalidate();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;
            Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (DataOnClick != null)
                DataOnClick.Invoke(this, Data);
        }
        bool mouseDown = false;
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.Clear(mouseDown ? ControlPaint.Dark(BackColor) : BackColor);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var g = pe.Graphics;
            if (!(Data is CodePart))
            {
                g.DrawRectangle(new Pen(ControlPaint.Dark(BackColor, 0.01f), 5), ClientRectangle);
                g.DrawString(Text, Font, new SolidBrush(BackColor.TextColor()), ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            else
            {
                var part = (CodePart)Data;
                g.DrawRectangle(new Pen(Color.Orange, 3), ClientRectangle);
                g.DrawLine(Pens.Orange, ClientRectangle.X + 10, ClientRectangle.Y + ClientRectangle.Height / 4, ClientRectangle.X + ClientRectangle.Width - 10, ClientRectangle.Y + ClientRectangle.Height / 4);
                StringFormat headerAlign = new StringFormat() { Alignment = StringAlignment.Center };
                g.DrawString(part.DisplayName, new Font("Courier New", 11.25F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, 0), Brushes.Black, new RectangleF(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height / 4), headerAlign);

                StringFormat detailsAlign = new StringFormat() { Alignment = StringAlignment.Center };
                g.DrawString(part.Details, new Font("Courier New", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0),Brushes.Black, new RectangleF(ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height / 4, ClientRectangle.Width, ClientRectangle.Height / 4 * 3), detailsAlign);

            }
        }
    }
}
