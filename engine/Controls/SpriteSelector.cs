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
    public partial class SpriteSelector : Control
    {
        public int Selected { get; private set; } = -1;
        public event EventHandler<int> SelectedIndexChanged;
        public SpriteSelector()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserMouse | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int CellSize = ClientRectangle.Width < ClientRectangle.Height ? ClientRectangle.Width / 16 : ClientRectangle.Height / 16;
            if (new Rectangle(ClientRectangle.X, ClientRectangle.Y, CellSize * 16, CellSize * 16).Contains(e.Location))
            {
                var X = e.X - ClientRectangle.X;
                var Y = e.Y - ClientRectangle.Y;
                if (X / CellSize < 16 && Y / CellSize < 16)
                {
                    Selected = X / CellSize + (Y / CellSize) * 16;
                    if (SelectedIndexChanged != null)
                        SelectedIndexChanged.Invoke(this, Selected);
                }
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            int index = 0;
            int CellSize = ClientRectangle.Width < ClientRectangle.Height ? ClientRectangle.Width / 16 : ClientRectangle.Height / 16;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (Game.Sprites[x + y * 16] != null)
                    {
                        int SpriteCellSize = CellSize / 8;
                        for (int spriteX = 0; spriteX < 8; spriteX++)
                        {
                            for (int spriteY = 0; spriteY < 8; spriteY++)
                            {
                                pe.Graphics.FillRectangle(
                                    new SolidBrush(Game.Palette[
                                        int.Parse(Game.Sprites[x + y * 16].data[spriteX, spriteY].ToString(), System.Globalization.NumberStyles.HexNumber)]),
                                    x * CellSize + spriteX * SpriteCellSize,
                                    y * CellSize + spriteY * SpriteCellSize,
                                    SpriteCellSize, SpriteCellSize);
                            }
                        }
                    }
                    pe.Graphics.DrawRectangle(Pens.White, ClientRectangle.X + x * CellSize, ClientRectangle.Y + y * CellSize, CellSize, CellSize);
                    index++;
                }
            }
            if (Selected != -1)
                pe.Graphics.DrawRectangle(new Pen(Color.White, 10), Selected % 16 * CellSize, Selected / 16 * CellSize, CellSize, CellSize);
            pe.Graphics.DrawRectangle(Pens.Orange, new Rectangle(ClientRectangle.X, ClientRectangle.Y, CellSize * 16, CellSize * 16));
        }
    }
}
