using System;

namespace QUADTREE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "xxwwwbxwxwbbbwwxxxwwbbbwwwwbb";

            var aa = new TreeNode(input);
            aa.PrintTree();
            aa.UpsideDown();
            Console.WriteLine();
            aa.PrintTree();
        }
    }
    public class TreeNode
    {
        public TreeNode(char value)
        {
            this.Value = value;
        }
        public TreeNode(string input)
        {
            foreach (char c in input)
            {
                TreeNode newNode = new TreeNode(c);
                this.Add(newNode);
            }
        }
        public bool isFull { get; set; }
        public char Value { get; set; }
        public TreeNode LeftUp { get; set; }
        public TreeNode RightUp { get; set; }
        public TreeNode LeftDown { get; set; }
        public TreeNode RightDown { get; set; }
        public void Add(TreeNode additionalNode)
        {
            if (this.Value == '\0')
            {
                this.Value = additionalNode.Value;
            }
            else
            {
                var position = FindParent(this);
                if(position.LeftUp == null)
                {
                    position.LeftUp = additionalNode;
                }
                else if(position.RightUp == null)
                {
                    position.RightUp = additionalNode;
                }
                else if(position.LeftDown == null)
                {
                    position.LeftDown = additionalNode;
                }
                else if(position.RightDown == null)
                {
                    position.RightDown = additionalNode;
                }
            }
            
        }
        public TreeNode FindParent(TreeNode rootNode)
        {
            if (rootNode.LeftUp == null)
            {
                return rootNode;
            }
            else if (rootNode.LeftUp.Value == 'x' && !rootNode.LeftUp.isFull)
            {
                return FindParent(rootNode.LeftUp);
            }
            else if (rootNode.RightUp == null)
            {
                return rootNode;
            }
            else if (rootNode.RightUp.Value == 'x' && !rootNode.RightUp.isFull)
            {
                return FindParent(rootNode.RightUp);
            }
            else if (rootNode.LeftDown == null)
            {
                return rootNode;
            }
            else if (rootNode.LeftDown.Value == 'x' && !rootNode.LeftDown.isFull)
            {
                return FindParent(rootNode.LeftDown);
            }
            else if (rootNode.RightDown == null)
            {
                rootNode.isFull = true;
                return rootNode;
            }
            else if (rootNode.RightDown.Value == 'x' && !rootNode.RightDown.isFull)
            {
                return FindParent(rootNode.RightDown);
            }
            else
            {
                return rootNode;
            }
        }
        public void UpsideDown()
        {
            if(this.Value != 'x')
            {
                return;
            }
            else
            {
                TreeNode orgLeftUp = this.LeftUp;
                TreeNode orgRightUp = this.RightUp;
                this.LeftUp = this.LeftDown;
                this.RightUp = this.RightDown;
                this.LeftDown = orgLeftUp;
                this.RightDown = orgRightUp;

                this.LeftUp.UpsideDown();
                this.RightUp.UpsideDown();
                this.LeftDown.UpsideDown();
                this.RightDown.UpsideDown();
            }
        }
        public void PrintTree()
        {
            if(Value == '\0')
            {
                return;
            }
            else
            {
                Console.Write(this.Value);
            }

            if(LeftUp != null)
            {
                LeftUp.PrintTree();
            }
            if(RightUp != null)
            {
                RightUp.PrintTree();
            }
            if(LeftDown != null)
            {
                LeftDown.PrintTree();
            }
            if(RightDown != null)
            {
                RightDown.PrintTree();
            }
        }
    }
}
