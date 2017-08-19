using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TES30.API;

namespace TES30.Controls
{
    public partial class PropertyItem : ContainerControl
    {
        public PropertyInfo Property { get; set; }
        public object Object;
        TES_Button ToggleButton;
        Control Editor;
        TES_Combobox VariableBox;
        bool StaticValue = false;
        List<KeyValuePair<PropertyInfo, object>> Properties = new List<KeyValuePair<PropertyInfo,object>>();
        public PropertyItem(PropertyInfo pi, object Class)
        {
            InitializeComponent();
            Property = pi;
            Object = Class;

            VariableBox = new TES_Combobox();
            VariableBox.DropDown += VariableBox_DropDown;
            VariableBox.SelectedIndexChanged += VariableBox_SelectedIndexChanged;
            Controls.Add(VariableBox);
            if (pi.PropertyType == typeof(string))
            {
                Editor = new TES_textbox() { Text = (string)pi.GetValue(Object) };
                ((TES_textbox)Editor).TextChanged += (object sender, EventArgs e) => { ChangeValue(((TES_textbox)sender).Text); };
                ToggleButton = new TES_Button("S");
                ToggleButton.Click += ToggleButton_Click;
                Controls.Add(ToggleButton);
                Controls.Add(Editor);
            }
        }
        private void VariableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VariableBox.SelectedIndex != -1)
                Property.SetValue(Object, Properties.ElementAt(VariableBox.SelectedIndex).Key.GetValue(Properties.ElementAt(VariableBox.SelectedIndex).Value));
        }
        void ChangeValue(object Value)
        {
            Property.SetValue(Object, Value);
        }
        private void VariableBox_DropDown(object sender, EventArgs e)
        {
            Properties.Clear();
            VariableBox.Items.Clear();
            foreach (TreeNode<CodePart> cb in CodeTree.Instance.Tree.GetNodeAndDescendants())
            {
                var props = cb.value.GetType().GetProperties();
                foreach (PropertyInfo pi in props)
                {
                    if (pi.PropertyType.IsSubclassOf(Property.PropertyType)||pi.PropertyType.IsEquivalentTo(Property.PropertyType))
                    {
                        Properties.Add(new KeyValuePair<PropertyInfo,object>(pi,cb.value));
                        VariableBox.Items.Add($"{pi.DeclaringType.Name} \t\t->\t\t {pi.Name}\t\t = \"{pi.GetValue(cb.value)}\"");
                    }
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (ToggleButton != null)
            {
                ToggleButton.Size = new Size(ClientSize.Height, ClientSize.Height);
                ToggleButton.Location = new Point(ClientRectangle.Right - ClientSize.Height, ClientRectangle.Y);
            VariableBox.Size = new Size(ClientSize.Width - ClientSize.Height, ClientSize.Height);
            Editor.Size = new Size(ClientSize.Width - ClientSize.Height, ClientSize.Height);
                Editor.Location = Point.Empty;
            }
            else
                VariableBox.Size = new Size(ClientSize.Width, ClientSize.Height);
            VariableBox.Location = new Point(0, 0);
        }
        private void ToggleButton_Click(object sender, EventArgs e)
        {
            StaticValue = !StaticValue;
            ToggleButton.Text = StaticValue ? "S" : "V";
            Editor.Visible = Editor.Enabled = StaticValue; 
            VariableBox.Visible = VariableBox.Enabled = !StaticValue;
            OnSizeChanged(null);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.Clear(Color.Yellow);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.DrawRectangle(new Pen(ControlPaint.Dark(Color.Yellow, 0.01f), 5), ClientRectangle);
        }
    }
}
