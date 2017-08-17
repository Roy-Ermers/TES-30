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
    public partial class Painter : Control
    {
        private Sprite Sprite;
        public char PaintingIndex = '0';
        public void SetSprite(Sprite s)
        {
            if (s == null)
            {
                Console.Instance.Log("ERROR: Sprite not intialized");
            }
            else
            {
                Sprite = s;
                Invalidate();
            }
        }
        public Painter()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserMouse, true);
        }
        public override Size GetPreferredSize(Size proposedSize)
        {
            int CellSize = proposedSize.Width < proposedSize.Height ? proposedSize.Width / 8 : proposedSize.Height / 8;
            return new Size(CellSize * 8, CellSize * 8);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (ClientRectangle.Contains(e.Location) && MouseButtons == MouseButtons.Left)
            {
                var X = e.X - ClientRectangle.X;
                var Y = e.Y - ClientRectangle.Y;
                int CellSize = ClientRectangle.Width < ClientRectangle.Height ? ClientRectangle.Width / 8 : ClientRectangle.Height / 8;
                if (X / CellSize < 8 && Y / CellSize < 8 && Sprite != null)
                    Sprite.data[(int)X / CellSize, (int)Y / CellSize] = PaintingIndex;
                Invalidate();
            }

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ClientRectangle.Contains(e.Location) && MouseButtons == MouseButtons.Left)
            {
                var X = e.X - ClientRectangle.X;
                var Y = e.Y - ClientRectangle.Y;
                int CellSize = ClientRectangle.Width < ClientRectangle.Height ? ClientRectangle.Width / 8 : ClientRectangle.Height / 8;
                if (X / CellSize < 8 && Y / CellSize < 8 && Sprite != null)
                    Sprite.data[(int)X / CellSize, (int)Y / CellSize] = PaintingIndex;
                Invalidate();
            }

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            int CellSize = ClientRectangle.Width < ClientRectangle.Height ? ClientRectangle.Width / 8 : ClientRectangle.Height / 8;
            if (Sprite != null)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        pe.Graphics.FillRectangle(new SolidBrush(Game.Palette[HexToNumber(Sprite.data[x, y])]), x * CellSize, y * CellSize, CellSize, CellSize);
                        pe.Graphics.DrawRectangle(new Pen(InvertedColor(Game.Palette[HexToNumber(Sprite.data[x, y])])), x * CellSize, y * CellSize, CellSize, CellSize);
                    }
                }
            }
            pe.Graphics.DrawRectangle(new Pen(Color.Orange, 5), ClientRectangle);
        }
        public Color InvertedColor(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        int HexToNumber(char hex)
        {
            return int.Parse(hex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
