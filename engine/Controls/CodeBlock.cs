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
using TES30.API;
namespace TES30
{
    public partial class CodeBlock : Control
    {
        public Font HeaderFont { get; set; } = new Font("Courier New", 11.25F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, 0);
        public Font DetailsFont { get; set; } = new Font("Courier New", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);

        public string HeaderText { get { return Part.DisplayName; } }
        public string Details { get { return Part.Details; } }
        public CodePart Part { get; set; }
        public ContentAlignment HeaderAlignment { get; set; } = ContentAlignment.BottomCenter;
        public ContentAlignment DetailsAlignment { get; set; } = ContentAlignment.TopCenter;
        [DefaultValue(true)]
        public bool CanDelete { get; set; } = true;
        [Localizable(true)]
        public Icon PinnedIcon { get; set; }
        public CodeTree CodeTree;
        public bool AllowChildren { get { return Part.IsRoutine; } }
        public bool IsRoutineBlock { get; set; } = false;

        public TreeNode<CodeBlock> Node
        {
            set
            {
                node = value;
                value.Disconnect += Node_Disconnect;
            }
        }
        TreeNode<CodeBlock> node;
        public override string ToString()
        {
            return HeaderText;
        }
        public CodeBlock()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserMouse | ControlStyles.FixedHeight | ControlStyles.FixedWidth, true);
            Size = new Size(200, 75);
        }

        private void Node_Disconnect(object sender, EventArgs e)
        {
            this.Dispose();
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            CodeTree.ShowPropertyWindow(this);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button== MouseButtons.Right)
            {
                if (AllowChildren && CodeTree.Tree.FindChild(CodeTree.Tree, this).Parent == CodeTree.Tree)
                {
                    ContextMenuStrip c = new ContextMenuStrip();
                    c.Items.Add("Add Block Underneath", null, AddBlock);
                    c.Items.Add("Add Routine Block", null, AddCoRoutineBlock);
                    c.Show(Cursor.Position);
                }
                else AddBlock(null, null);
            }

        }
        void AddBlock(object sender, EventArgs e)
        {
            CodeTree.ShowBlockList(this, false);
        }
        void AddCoRoutineBlock(object sender, EventArgs e)
        {
            CodeTree.ShowBlockList(this, true);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Invalidate();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Delete && CanDelete)
            {
                CodeTree.Tree.FindChild(CodeTree.Tree, this).Delete();
                this.Dispose();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.Clear(Color.Yellow);
            g.FillRectangle(Focused ? Brushes.Navy : Brushes.Yellow, ClientRectangle);
            g.DrawRectangle(Focused ? new Pen(Color.Blue, 3) : new Pen(Color.Orange, 3), ClientRectangle);
            g.DrawLine(Focused ? Pens.Blue : Pens.Orange, ClientRectangle.X + 10, ClientRectangle.Y + ClientRectangle.Height / 4, ClientRectangle.X + ClientRectangle.Width - 10, ClientRectangle.Y + ClientRectangle.Height / 4);
            StringFormat headerAlign = new StringFormat();
            Int32 HeaderNum = (Int32)Math.Log((Double)this.HeaderAlignment, 2);
            headerAlign.LineAlignment = (StringAlignment)(HeaderNum / 4);
            headerAlign.Alignment = (StringAlignment)(HeaderNum % 4);
            g.DrawString(HeaderText, HeaderFont ?? SystemFonts.DefaultFont, Focused ? Brushes.White : Brushes.Black, new RectangleF(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height / 4), headerAlign);

            StringFormat detailsAlign = new StringFormat();
            Int32 Detailsnum = (int)Math.Log((double)this.DetailsAlignment, 2);
            detailsAlign.LineAlignment = (StringAlignment)(Detailsnum / 4);
            detailsAlign.Alignment = (StringAlignment)(Detailsnum % 4);
            g.DrawString(Details, DetailsFont ?? SystemFonts.DefaultFont, Focused ? Brushes.White : Brushes.Black, new RectangleF(ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height / 4, ClientRectangle.Width, ClientRectangle.Height / 4 * 3), detailsAlign);

            if (!CanDelete && PinnedIcon != null)
                g.DrawIcon(PinnedIcon, ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height - PinnedIcon.Height);
        }
    }
}