using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TES30
{
    public partial class Console : Control
    {
        #region Properties 
        public List<string> Lines;

        [DefaultValue("0")]
        public new string BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
            }
        }
        public string _BackColor = "0";
        bool show = false;
        private System.Timers.Timer Blinker = new System.Timers.Timer(250);
        public static Console Instance { get; set; }
        public TabPage Page { get; set; }
        #endregion

        #region events
        public event OnCommandSubmitted CommandSubmitted;
        public delegate void OnCommandSubmitted(Console sender, string command);
        #endregion

        public Console()
        {
            InitializeComponent();
            Instance = this;
            Lines = new List<string>() { "^4TES-30 ^fv0.0.0.1 ^1(C) Roy Ermers", "", "^1type^f'help' ^1to get a list of possible commands!" };
            DoubleBuffered = true;
            Log("");
            SetStyle(ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.ResizeRedraw |
            ControlStyles.OptimizedDoubleBuffer | ControlStyles.StandardClick | ControlStyles.AllPaintingInWmPaint, true);
            Blinker.Elapsed += Blinker_Elapsed;
            Blinker.Start();

        }

        #region public functions
        public void Clear()
        {
            Lines.Clear();
        }
        public void Log(string log)
        {
            foreach (string line in log.Split('\n'))
                Lines.Add("^f" + line);
            if (log.Length>0&&log.Last() != '\n') Lines.Add("");
            if (Page != null)
                ((TabControl)Page.Parent).SelectTab(Page);
        }
        #endregion

        #region Control
        private void Blinker_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            show = !show;
            Invalidate();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Focus();
            Invalidate();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == '>' || e.KeyChar == '\n')
                return;
            Lines[Lines.Count - 1] += e.KeyChar;
            Invalidate();
            e.Handled = true;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Enter | Keys.Return))
            {
                e.Handled = true;
                Invalidate();
                CommandSubmitted.Invoke(this, FormattedText(Lines[Lines.Count - 1]));
                Log("");


            }
            if (e.KeyCode == Keys.Back && Lines[Lines.Count - 1].Length > 2)
            {
                Lines[Lines.Count - 1] = Lines[Lines.Count - 1].Remove(Lines[Lines.Count - 1].Length - 1);
            }
            Invalidate();
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if(!DesignMode)
            pevent.Graphics.Clear(Game.Palette[HexToNumber(_BackColor)]);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            float y = 0;
            var rows = Lines.FindAll(x => true);
            foreach (string line in rows)
            {
                float x = 0;
                var UnformattedLine = line.Split('^');

                foreach (string FormattedLine in UnformattedLine)
                {
                    if (FormattedLine.Length == 0||DesignMode) continue;
                    pe.Graphics.DrawString(FormattedText(FormattedLine.Substring(1)), Font, new SolidBrush(Game.Palette[HexToNumber(FormattedLine.Substring(0, 1))]), new PointF(x, y));
                    x += pe.Graphics.MeasureString(FormattedText(FormattedLine.Substring(1)), base.Font).Width;
                }
                y += Font.GetHeight();
                if (y > pe.ClipRectangle.Height) Lines.RemoveAt(0);
            }
            if (show && Lines != null && Focused)
                pe.Graphics.DrawString("▁", Font, Brushes.White, TextRenderer.MeasureText(FormattedText(Lines[Lines.Count - 1]), Font).Width, (Lines.Count - 1) * Font.GetHeight());
        }
        #endregion
        #region Helpers
        private string FormattedText(string unformattedText)
        {
            string result = "";
            char lastChar = char.MinValue;
            foreach (char c in unformattedText)
            {
                if (lastChar != '^' && c != '^')
                {
                    result += c;
                }
                lastChar = c;
            }
            return result.Trim('\n','\r');
        }
        int HexToNumber(string hex)
        {
            return int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }
        #endregion
    }
}
