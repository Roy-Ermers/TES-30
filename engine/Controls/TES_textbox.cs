using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TES30.Controls
{
    public partial class TES_textbox : TextBox
    {
        public event EventHandler CueTextChanged;
        private string _cueText;

        public string DefaultText
        {
            get { return _cueText; }
            set
            {
                value = value ?? string.Empty;
                if (value != _cueText)
                {
                    _cueText = value;
                    OnCueTextChanged(EventArgs.Empty);
                }
            }
        }

        public TES_textbox()
        : base()
        {
            _cueText = string.Empty;
            BorderStyle = BorderStyle.None;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            
        }

        protected virtual void OnCueTextChanged(EventArgs e)
        {
            this.Invalidate(true);
            if (this.CueTextChanged != null)
                this.CueTextChanged(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(ControlPaint.Dark(BackColor, 0.01f), 5), ClientRectangle);
            base.OnPaint(e);

            if (string.IsNullOrEmpty(this.Text.Trim()) && !string.IsNullOrEmpty(this.DefaultText) && !this.Focused)
            {
                Point startingPoint = new Point(0, 0);
                StringFormat format = new StringFormat();
                Font font = new Font(this.Font.FontFamily.Name, this.Font.Size, FontStyle.Italic);
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    format.LineAlignment = StringAlignment.Far;
                    format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                }
                e.Graphics.DrawString(DefaultText, font, Brushes.Gray, this.ClientRectangle, format);
            }
        }

        const int WM_PAINT = 0x000F;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                this.OnPaint(new PaintEventArgs(Graphics.FromHwnd(m.HWnd), this.ClientRectangle));
            }
        }
    }
}

