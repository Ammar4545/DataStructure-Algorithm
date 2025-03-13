using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BTREE
{
    public class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
    {
        TreeNode Root;
        public class TreeNode
        {
            public Tdata Data;
            public TreeNode Left;
            public TreeNode Right;
            public TreeNode(Tdata data)
            {
                this.Data = data;
            }
            public override string ToString()
            {
                return Data.ToString();
            }
        }

        public void Balance()
        {
            List<Tdata> nodes = new List<Tdata>();
            InOrderToArray(Root, nodes);
            this.Root=RecursiveBanalnce(0, nodes.Count - 1, nodes);
        }
        public void InOrderToArray(TreeNode node, List<Tdata> nodes)
        {
            if (node == null) return;
            InOrderToArray(node.Left, nodes);
            nodes.Add(node.Data);
            InOrderToArray(node.Right, nodes);
        }

        TreeNode RecursiveBanalnce(int start, int end, List<Tdata> nodes)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;

            TreeNode nodeToRoot = new TreeNode(nodes[mid]);
            nodeToRoot.Left = RecursiveBanalnce(start, mid - 1, nodes);
            nodeToRoot.Right = RecursiveBanalnce(mid + 1, end, nodes);
            return nodeToRoot;

        }


        public NodeAndParent FindNodeAndPaternt(Tdata data) 
        {
            TreeNode currentNode = this.Root;
            TreeNode parent = null;
            bool left = false;
            NodeAndParent nodeAndParentInfo = null;

            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(data) == 0)
                {
                    nodeAndParentInfo = new NodeAndParent
                    {
                        node = currentNode,
                        Parent= parent,
                        isLeft=left
                    };
                    break;
                }
                else if (currentNode.Data.CompareTo(data) > 0)
                {
                    parent = currentNode;
                    left = true;
                    currentNode = currentNode.Left;
                }
                else
                {
                    parent = currentNode;
                    left = false;
                    currentNode = currentNode.Right;
                }

            }
            return nodeAndParentInfo;

        }
        public class NodeAndParent
        {
            public TreeNode Parent;
            public TreeNode node;
            public bool isLeft;
        }
        public void BSInsert(Tdata data)
        {
            if (Root == null)
            {
                Root = new TreeNode(data);
                return;
            }
            TreeNode currentNode = Root;

            while (currentNode != null) 
            {
                if (currentNode.Data.CompareTo(data)>0)
                {
                    if (currentNode.Left is  null)
                    {
                        currentNode.Left = new TreeNode(data);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else 
                {
                    if (currentNode.Right is null)
                    {
                        currentNode.Right = new TreeNode(data);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }

        public bool IsExist(Tdata data)
        {
            if (BSFind(data) is not null)
            {
                return true;
            }
            return false;
        }
        private TreeNode BSFind(Tdata data)
        {
            TreeNode currentNode = this.Root;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(data)==0)
                {
                    return currentNode;
                }
                else if (currentNode.Data.CompareTo(data) > 0)
                {
                    currentNode = currentNode.Left;
                }
                else 
                {
                    currentNode = currentNode.Right;
                }
                
            }
            return null;
        }

        public void Insert(Tdata data)
        {
            TreeNode newNode = new TreeNode(data);
            if (Root == null)
            {
                this.Root = newNode;
                return;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(currentNode.Right);
                }

            }

        }

        public TreeNode Find(Tdata data)
        {
            return internalFind(this.Root,data);

        }
        private TreeNode internalFind(TreeNode node ,Tdata data)
        {
            if (node == null) return null;

            if (node.Data.CompareTo(data)==0) return node;
            

            TreeNode foundNode = internalFind(node.Left, data);
            if (foundNode != null) return foundNode;

            
            return internalFind(node.Right, data);
        }

        //How to get height of tree 
        //we will use recursion
        public int Height()
        {
            return internalHeight(this.Root);
        }
        private int internalHeight(TreeNode node)
        {
            if (node == null) return 0;
            return 1+ Math.Max(internalHeight(node.Left), internalHeight(node.Right));
        }

        public void PreOrder()
        {
            internalPreOrder(this.Root);
            Console.WriteLine("");
        }
        void internalPreOrder(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.Data+"->");
            internalPreOrder(node.Left);
            internalPreOrder(node.Right);
        }

        public void InOrder()
        {
            internalInOrder(this.Root);
            Console.WriteLine("");
        }
        void internalInOrder(TreeNode node)
        {
            if (node == null) return;
            internalInOrder(node.Left);
            Console.Write(node.Data + " -> ");
            internalInOrder(node.Right);
        }


        public void PostOrder()
        {
            internalPostOrder(this.Root);
            Console.WriteLine("");
        }
        void internalPostOrder(TreeNode node)
        {
            if (node == null) return;
            internalPostOrder(node.Left);
            internalPostOrder(node.Right);
            Console.Write(node.Data + " -> ");
        }
        public void BSDelete(Tdata data)
        {
            NodeAndParent nodeAndParentInfo = this.FindNodeAndPaternt(data);

            if (nodeAndParentInfo == null) return;

            if (nodeAndParentInfo.node.Left != null && nodeAndParentInfo.node.Right !=null)
            {
                BSDelete_Has_Child(nodeAndParentInfo.node);
            }

            else if (nodeAndParentInfo.node.Left != null ^ nodeAndParentInfo.node.Right != null)
            {
                BSDelete_Has_One_Child(nodeAndParentInfo.node);
            }

            else
            {
                BSDelete_Is_Leaf(nodeAndParentInfo);
            }

        }
        void BSDelete_Has_Child(TreeNode nodeToDelete)
        {
            TreeNode currentNode = nodeToDelete.Right; //go to right sub tree to get smallest in order successor  (9)

            TreeNode parent = null;

            while (currentNode.Left != null) 
            {
                parent = currentNode;
                currentNode = currentNode.Left;
            }
            if (parent != null) 
            {
                parent.Left = currentNode.Right;
            }
            else
            {
                nodeToDelete.Right = currentNode.Right;
            }

            nodeToDelete.Data = currentNode.Data;
        }

        void BSDelete_Has_One_Child(TreeNode nodeToDelete)
        {
            TreeNode nodeToReplace = null;
            if (nodeToDelete.Left is not null)
            {
                nodeToReplace = nodeToDelete.Left;
            }
            else
            {
                nodeToReplace = nodeToDelete.Right;
            }

            nodeToDelete.Data=nodeToReplace.Data;
            nodeToDelete.Left=nodeToReplace.Left;
            nodeToDelete.Right=nodeToReplace.Right;
        }

        void BSDelete_Is_Leaf(NodeAndParent nodeAndParentInfo)
        {
            if (nodeAndParentInfo.Parent == null)
            {
                this.Root = null;
            }
            else
            {
                if (nodeAndParentInfo.isLeft)
                {
                    nodeAndParentInfo.Parent.Left = null;
                }
                else 
                {
                    nodeAndParentInfo.Parent.Right = null;
                }
            }
        }
        public void Delete(Tdata data)
        {
            if(this.Root == null) return;

            TreeNode nodeForDelete = null;
            TreeNode parentOfDeepestNode = null;
            TreeNode deepestNode = null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0) 
            { 
                TreeNode current = queue.Dequeue();
                if (current.Data.CompareTo(data)==0)
                    nodeForDelete = current;

                if (current.Left is not null)
                {
                    queue.Enqueue(current.Left);
                    parentOfDeepestNode = current;
                    
                }

                if (current.Right is not null)
                {
                    queue.Enqueue(current.Right);
                    parentOfDeepestNode = current;
                    
                }

                deepestNode=current;

            }

            if (deepestNode is not null && nodeForDelete is not null)
            {
                nodeForDelete.Data = deepestNode.Data; // Replace target with deepest node value

                // Remove the deepest node
                if (parentOfDeepestNode != null)
                {
                    if (parentOfDeepestNode.Right == deepestNode)
                        parentOfDeepestNode.Right = null;
                    else
                        parentOfDeepestNode.Left = null;
                }
                else
                {
                    Root = null; // If only one node exists
                }
            }

        }

        //============================ Printer
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this.Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = LeftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int Left, int Right = -1)
        {
            Console.SetCursorPosition(Left, top);
            if (Right < 0) Right = Left + s.Length;
            while (Console.CursorLeft < Right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    } // class BinaryTree
}
