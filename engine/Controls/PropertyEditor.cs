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
using System.Reflection;
namespace TES30.Controls
{
    public partial class PropertyEditor : ContainerControl
    {
        public static PropertyEditor Instance { get { return instance; } }
        private static PropertyEditor instance;

        public Label DisplayName { get; set; }
        public Label Details { get; set; }
        public int LineHeight { get; set; } = 25;
        private List<PropertyInfo> properties;
        private object selectedPart;
        private Type selectedType;
        public PropertyEditor()
        {
            InitializeComponent();
            instance = this;
        }
        public void Show<t>(object parts)
        {
            properties = parts.GetType().GetProperties().ToList();
            selectedPart = parts;
            DisplayName.Text = ((CodePart)parts).DisplayName;
            Details.Text = ((CodePart)parts).Details;
            selectedType = typeof(t);
            foreach (Control c in Controls) c.Dispose();
            Controls.Clear();
            foreach (PropertyInfo info in properties)
            {
                if (info.GetAccessors(false).Length != 2) continue;
                Label label = new Label();
                label.Text = info.Name;
                label.TextAlign = ContentAlignment.MiddleRight;
                label.BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(label);

                PropertyItem item = new PropertyItem(info,parts);
                Controls.Add(item);
            }
            OnLayout(null);
            if (!Parent.Visible)
            {
                Parent.BringToFront();
                Parent.Visible = true;
            }
        }
        protected override void OnLayout(LayoutEventArgs e)
        {
            int x = ClientRectangle.X, y = ClientRectangle.Y, index = -1;

            foreach (Control c in Controls)
            {
                if (c is Label) ((Label)c).AutoSize = false;
                c.SetBounds(x, y, ClientRectangle.Width / 2, LineHeight);
                if (index % 2 == 0)
                {
                    x = ClientRectangle.X;
                    y += LineHeight;
                }
                else x = ClientRectangle.Width / 2;
                index++;
            }

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
