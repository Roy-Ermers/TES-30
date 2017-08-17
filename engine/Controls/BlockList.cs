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
namespace TES30
{
    public partial class BlockList : ContainerControl
    {
        public static List<CodePart> Blocks = new List<CodePart>();
        public static BlockList Instance { get; set; }
        public Scrollview ScrollView { get { return ((MainForm)MainForm.ActiveForm).scrollview1; } }
        public BlockList()
        {
            Instance = this;
            InitializeComponent();
            SetStyle(ControlStyles.UserMouse | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable, true);
            AutoScroll = true;
        }
        public void OnCancel(object sender, EventArgs e)
        {
            Visible = false;
            Invalidate();
        }
        public void Refresh(object s, EventArgs e)
        {
            if (!DesignMode)
            {
                ScrollView.Clear();
                foreach (CodePart c in Blocks)
                {
                    var b = new TES_Button(c.ToString(), c);
                    b.DataOnClick += Block_OnClick;
                    b.Height = 75;
                    ScrollView.Add(b);
                }
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible == true&&!DesignMode)
                Refresh(null, null);
        }
        public void Block_OnClick(object sender, object data)
        {
            CodeTree.Instance.AddBlock((CodePart)data);
            Visible = false;
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (Visible)
                e.Graphics.Clear(BackColor);
            e.Graphics.DrawRectangle(Focused ? new Pen(ControlPaint.Dark(BackColor), 10) : new Pen(ControlPaint.Dark(BackColor), 5), ClientRectangle);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
