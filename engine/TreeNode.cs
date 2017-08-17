using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES30
{
    public class TreeNode<t>
    {
        private List<TreeNode<t>> children = new List<TreeNode<t>>();
        public List<TreeNode<t>> Children
        {
            get
            {
                return children;
            }
        }
        private TreeNode<t> parent;
        public TreeNode<t> Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public t value;
        public int ChildIndex
        {
            get
            {
                if (Parent != null)
                {
                    return parent.children.IndexOf(this);
                }
                else return -1;
            }
        }
        public static string CreateMap(TreeNode<t> root)
        {
            List<TreeNode<t>> firstStack = new List<TreeNode<t>>();
            firstStack.Add(root);

            List<List<TreeNode<t>>> childListStack = new List<List<TreeNode<t>>>();
            childListStack.Add(firstStack);
            string result = "";
            while (childListStack.Count > 0)
            {
                List<TreeNode<t>> childStack = childListStack[childListStack.Count - 1];

                if (childStack.Count == 0)
                {
                    childListStack.RemoveAt(childListStack.Count - 1);
                }
                else
                {
                    root = childStack[0];
                    childStack.RemoveAt(0);

                    string indent = "";
                    for (int i = 0; i < childListStack.Count - 1; i++)
                    {
                        indent += (childListStack[i].Count > 0) ? "│  " : "   ";
                    }

                    result += indent + "└──" + root.value.ToString() + "\n";

                    if (root.Children.Count > 0)
                    {
                        childListStack.Add(new List<TreeNode<t>>(root.Children));
                    }
                }
            }
            return result;
        }
        public TreeNode<t> FindChild(TreeNode<t> rootNode, t Object)
        {
            var foundNode = rootNode.GetNodeAndDescendants()
                                    .FirstOrDefault(node => node.value.Equals(Object));
            return foundNode;
        }
        public IEnumerable<TreeNode<t>> GetNodeAndDescendants()
        {
            return new[] { this }
                   .Concat(Children.SelectMany(child => child.GetNodeAndDescendants()));
        }
        public event EventHandler Disconnect;
        public TreeNode<t> AddChild(t child)
        {
            var result = new TreeNode<t>(child) { parent = this };
            children.Add(result);
            return result;
        }
        public void Delete()
        {
            foreach (TreeNode<t> child in children)
            {
                if (child.Disconnect != null)
                {
                    child.Disconnect.Invoke(this, null);
                }
            }
            if (Disconnect != null)
                Disconnect.Invoke(this, null);
            Children.Clear();
        }
        public TreeNode(t Value)
        {
            value = Value;
        }

    }
}
