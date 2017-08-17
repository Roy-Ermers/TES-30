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
    [DefaultEvent("ValueChanged")]
    public partial class TES_textbox : Control
    {
        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
        private string value;
        public string DefaultText { get; set; }
        [Browsable(true)]
        [Description("The Value changed event")]
        public event EventHandler<string> ValueChanged;
        private System.Timers.Timer CursorBlink;
        public TES_textbox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserMouse | ControlStyles.Selectable, true);
            CursorBlink = new System.Timers.Timer(500);
            CursorBlink.Elapsed += blinkCursor;
        }

        private void blinkCursor(object sender, System.Timers.ElapsedEventArgs e)
        {
            showCursor = !showCursor;
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode.ToString().Length == 1)
                value += e.Shift ? e.KeyCode.ToString() : e.KeyCode.ToString().ToLower();
            else if (e.KeyCode == Keys.Back && value.Length > 0)
            {
                value = value.Remove(value.Length - 1, 1);
            }
            else if (e.KeyCode == Keys.Space)
            {
                value += ' ';
            }
            else if (e.KeyCode.ToString().StartsWith("D")&&e.KeyCode.ToString().Length==2)
            {
                value += e.KeyCode.ToString().Substring(1);
            }
            else if (e.KeyCode == (Keys.Enter | Keys.Return))
            {
                FindForm().Controls[0].Focus();
            }
            if (ValueChanged != null) ValueChanged.Invoke(this, value);
            Invalidate();
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            CursorBlink.Start();
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            CursorBlink.Stop();
            Invalidate();
        }
        bool showCursor = true;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var g = pe.Graphics;
            g.Clear(BackColor);
            if (Focused)
            {
                g.DrawRectangle(new Pen(ControlPaint.Dark(BackColor, 0.2f), 8), ClientRectangle);
                if (showCursor)
                {
                    var x = TextRenderer.MeasureText(value, Font).Width;
                    g.DrawLine(new Pen(BackColor.TextColor()), x, ClientRectangle.Top + +ClientRectangle.Height * 0.1f, x, ClientRectangle.Top + +ClientRectangle.Height * 0.8f);
                }
            }
            g.DrawRectangle(new Pen(ControlPaint.Dark(BackColor, 0.01f), 5), ClientRectangle);
            if (!string.IsNullOrEmpty(value))
                g.DrawString(Value, Font, new SolidBrush(BackColor.TextColor()), ClientRectangle, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
            else if (!string.IsNullOrEmpty(DefaultText))
            {
                g.DrawString(DefaultText, Font, new SolidBrush(ControlPaint.LightLight(BackColor.TextColor())), ClientRectangle, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
            }
        }
    }
}
