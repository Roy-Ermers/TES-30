using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TES30.Controls
{
    public partial class ToggleButton : Control
    {
        public static ToggleButton CheckedToggle;
        public bool Checked
        {
            get
            {               
                return CheckedToggle == this;
            }
            set
            {
                if (value == true)
                {
                    CheckedToggle = this;
                    RepaintRequest();
                }
                Invalidate();
            }
        }
        [Category("Appearance")]
        public int PaletteBackColor
        {
            get;
            set;
        }
        private static event Action RepaintRequest = delegate { };
        public ToggleButton()
        {
            InitializeComponent();
            Invalidate();
            RepaintRequest += ToggleButton_RepaintRequest;
            Game.PaletteChanged += Game_PaletteChanged;
            SetStyle(ControlStyles.UserMouse, true);
        }

        private void Game_PaletteChanged(object sender, Color[] e)
        {
            Invalidate();
        }

        private void ToggleButton_RepaintRequest()
        {
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.Clear(Game.Palette[PaletteBackColor]);
            if (Checked) pe.Graphics.DrawRectangle(new Pen(ControlPaint.Dark(InvertedColor(Game.Palette[PaletteBackColor])), 25) { StartCap = LineCap.Round, EndCap = LineCap.Round }, ClientRectangle);
            pe.Graphics.DrawRectangle(new Pen(ControlPaint.Light(Game.Palette[PaletteBackColor]), 5), ClientRectangle);
        }
        public Color InvertedColor(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }
    }
}
