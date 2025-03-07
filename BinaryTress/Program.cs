﻿using System.Runtime.CompilerServices;
using System.Xml;

namespace BinaryTress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinaryTree<char> tree = new BinaryTree<char>();
            //tree.Insert('A');
            //tree.Insert('B');
            //tree.Insert('C');
            //tree.Insert('D');
            //tree.Insert('E');
            //tree.Insert('F');
            //tree.Insert('G');
            //tree.Insert('H');
            //tree.Insert('I');
            //tree.Print();
            //Console.WriteLine("height = " +tree.Height());

            //tree.PreOrder();
            //tree.InOrder();
            //tree.PostOrder();

            BinaryTree<int> tree = new BinaryTree<int>();
            tree.BSInsert(4);
            tree.BSInsert(2);
            tree.BSInsert(1);
            tree.BSInsert(3);
            tree.BSInsert(5);
            tree.BSInsert(6);
            tree.Print();

            Console.WriteLine(tree.IsExsit(5));
            Console.WriteLine(tree.IsExsit(8));
        }
        public class BinaryTree<Tdata> where Tdata :IComparable<Tdata>
        {
            TreeNode Root;
            public void BSInsert(Tdata data)
            {
                TreeNode newNdoe = new TreeNode(data);
                if (this.Root == null)
                {
                    Root = newNdoe;
                    return;
                }
                TreeNode currNode= this.Root;
                while (currNode is not null)
                {
                    if (currNode.Data.CompareTo(data) > 0)
                    {
                        if (currNode.Left is null)
                        {
                            currNode.Left = newNdoe;
                            break;
                        }
                        else
                        {
                            currNode = currNode.Left;
                        }
                    }
                    else
                    {
                        if (currNode.Right is null)
                        {
                            currNode.Right= newNdoe;
                            break;
                        }
                        else
                        {
                            currNode = currNode.Right;
                        }

                    }
                }

            }
            public bool IsExsit(Tdata _data)
            {
                return BSFind(_data) != null;
            }
            TreeNode BSFind(Tdata data)
            {
                TreeNode currNode = this.Root;
                while (currNode is not null) {
                    if (currNode.Data.CompareTo(data)==0)
                    {
                        return currNode;
                    }
                    else if(currNode.Data.CompareTo(data) > 0)
                    {
                        currNode= currNode.Left;
                    }
                    else
                    {
                        currNode = currNode.Right;
                    }
                }
                return null;
            }
            public void Insert(Tdata data)
            {
                TreeNode newNdoe= new TreeNode(data);
                if (this.Root==null)
                {
                    Root = newNdoe;
                    return;
                }

                Queue<TreeNode> q = new Queue<TreeNode> (); 
                q.Enqueue(Root);
                while (q.Count>0)
                {
                    TreeNode currentNope= q.Dequeue ();
                    if (currentNope.Left==null)
                    {
                        currentNope.Left = newNdoe;
                        break;
                    }
                    else
                    {
                        q.Enqueue(currentNope.Left);
                    }

                    if (currentNope.Right == null)
                    {
                        currentNope.Right = newNdoe;
                        break;
                    }
                    else
                    {
                        q.Enqueue(currentNope.Right);
                    }
                }
            }
            class TreeNode
            {
                public Tdata Data;
                public TreeNode Left;
                public TreeNode Right;
                public TreeNode(Tdata data)
                {
                    this.Data = data;
                }
            }

            #region Height
            public int Height()
            {
                return internalHeight(this.Root);
            }
            //using recursion to get the height of the "TREE"
            private int internalHeight(TreeNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                return 1 + Math.Max(internalHeight(node.Left), internalHeight(node.Right));
            }
            #endregion

            #region Depth based order
            public void PreOrder()
            {
                internalPreOrder(Root);
                Console.WriteLine("");
            }
            void internalPreOrder(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }
                Console.Write(node.Data + " -> ");
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
            #endregion

            class NodeInfo
            {
                public TreeNode Node;
                public string Text;
                public int StartPos;
                public int Size { get { return Text.Length; } }
                public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
                public NodeInfo Parent, Left, Right;
            }
            public void  Print(int topMargin = 2, int LeftMargin = 2)
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
        }
    }
}
