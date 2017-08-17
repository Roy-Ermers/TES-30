using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TES30.Controls
{
    public partial class SpritePainter : UserControl
    {
        public SpritePainter()
        {
            InitializeComponent();
        }
        public void ChangeIndex(int index)
        {
            painter1.SetSprite(Game.Sprites[index]);
        }
        public void ToggleButton_OnClick(object sender, EventArgs e)
        {
            painter1.PaintingIndex = ((ToggleButton)sender).PaletteBackColor.ToString("X")[0];
                }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            tableLayoutPanel1.Size = new Size((ClientRectangle.Width < ClientRectangle.Height ? ClientRectangle.Width : ClientRectangle.Height)/3*2, (ClientRectangle.Width < ClientRectangle.Height ? ClientRectangle.Width : ClientRectangle.Height) / 3*2 / 4);
            tableLayoutPanel1.Location = new Point(ClientRectangle.X + ClientRectangle.Width/2-tableLayoutPanel1.Width/2, ClientRectangle.Height - tableLayoutPanel1.Size.Height);
            
            painter1.Size = painter1.GetPreferredSize(new Size(ClientSize.Width,ClientSize.Height-tableLayoutPanel1.Height));
            painter1.Location = new Point(ClientRectangle.X + ClientRectangle.Width/2-painter1.Size.Width/2, ClientRectangle.Top);
        }
    }
}
