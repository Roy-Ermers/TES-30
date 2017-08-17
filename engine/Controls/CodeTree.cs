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
    public partial class CodeTree : ContainerControl
    {
        public TreeNode<CodeBlock> Tree;
        CodeBlock LastCaller;
        bool LastRoutine;

        public static CodeTree Instance { get; set; }
        public CodeTree()
        {
            Instance = this;
            SetStyle(ControlStyles.UserMouse, true);
            CodeBlock startBlock = new CodeBlock()
            {
                Part = new StartBlock(),
                CanDelete = false,
                CodeTree = this,
            };
            Controls.Add(startBlock);
            startBlock.Location = new Point(15, 15);
            Tree = new TES30.TreeNode<CodeBlock>(startBlock);
            startBlock.Node = Tree;
        }

        public void ShowBlockList(CodeBlock Caller, bool Routine)
        {
            var window = BlockList.Instance;
            window.BringToFront();
            LastCaller = Caller;
            LastRoutine = Routine;
            window.Visible = true;
        }
        public void ShowPropertyWindow(CodeBlock Caller)
        {
            TES30.Controls.PropertyEditor.Instance.Show<CodePart>(Caller.Part);
        }
        public void AddBlock(CodePart part)
        {
            if (LastRoutine) { AddRoutineBlock(part); return; }
            var Caller = LastCaller;
            CodeBlock Block = new CodeBlock()
            {
                Part = part,
                CodeTree = this,
                IsRoutineBlock = Caller.IsRoutineBlock
            };
            var p = Caller.Location;
            Block.Location = Caller.IsRoutineBlock ? new Point(p.X + Caller.Width + 15, p.Y) : new Point(p.X, p.Y + Caller.Height + 15);
            TreeNode<CodeBlock> node;
            if (Tree.value == Caller)
            {
                node = Tree.AddChild(Block);
            }
            else
            {
                node = Tree.FindChild(Tree, Caller).Parent.AddChild(Block);
            }
            Block.Node = node;
            Controls.Add(Block);
            Block.Invalidate();
            ActiveControl = Block;
        }
        void AddRoutineBlock(CodePart part)
        {
            var Caller = LastCaller;
            CodeBlock Block = new CodeBlock()
            {
                Part = part,
                CodeTree = this,
                IsRoutineBlock = true
            };
            var p = Caller.Location;
            Block.Location = new Point(p.X + Caller.Width + 15, p.Y);
            Block.Node = Tree.FindChild(Tree, Caller).AddChild(Block);
            Controls.Add(Block);
            Block.Invalidate();
            ActiveControl = Block;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.Clear(BackColor);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ActiveControl = null;
        }
    }
}