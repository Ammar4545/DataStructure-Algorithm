﻿namespace SinglyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.InsertLast(1);
            list.InsertLast(5);
            list.InsertLast(4);
            list.Print();

            list.InsertAfter(list.Find(5), 10);
            list.Print();

            list.InsertBefore(list.Find(5), 15);
            list.Print();

            list.DeleteNode(list.Find(1));
            Console.WriteLine(list.Head.Data);
            //list.DeleteNode(5);
            list.Print();
        }
        public class LinkedListNode
        {
            public int Data; // data to store
            public LinkedListNode? next; // pointer for next node
            public LinkedListNode(int data)
            {
                this.Data = data;
                
            }
        }
        class LinkedListIterator
        {
            private LinkedListNode currentNode;
            public LinkedListIterator() { currentNode = null; } //uesd to end the loop
            public LinkedListIterator(LinkedListNode node) { currentNode = node; } // give it the node to start from
            public int data() => this.currentNode.Data;
            public LinkedListIterator next()
            {
                this.currentNode = currentNode.next;

                return this;
            }
            public LinkedListNode current()
            {
                return this.currentNode;
            }
        }
        class LinkedList
        {
            private int length;
            public LinkedListNode? Head;
            public LinkedListNode? Tail;

            public LinkedListIterator begin()
            {
                LinkedListIterator itr = new LinkedListIterator(this.Head);
                return itr;
            }

            public void InsertLast(int data)
            {
                LinkedListNode newNode = new LinkedListNode(data);
                if (Head is null)
                {
                    Head = newNode;
                    Tail = newNode;
                }
                else
                {
                    Tail.next = newNode;
                    Tail = newNode;
                }
                this.length++;
            }
            /// <summary>
            /// make newNode"next" point to node"next" that i want to add after it
            /// make node "next" pointer" point to newNode pointer"
            /// if node was the last node => make newNode "Tail"
            /// -- this method will use [Find()] to get the "node"
            /// </summary>
            /// <param name="node">node that u wnat to add after</param>
            /// <param name="data">data that u want to add</param>
            public void InsertAfter(LinkedListNode node, int data)
            {
                LinkedListNode newNode = new LinkedListNode(data);
                newNode.next = node.next;
                node.next = newNode;
                if (Tail == node)
                {
                    this.Tail = newNode;
                }
                this.length++;
            }
            /// <summary>
            /// make newNode"next" point to node that i want to add before it
            /// get parent that was pointing to "node"
            /// if node has parent that mean we are adding in the middle 
            /// if not that mean newNode will be the Head
            /// -- this method will use [FindParent()] to get the parent of "node"
            /// </summary>
            /// <param name="node">node that u wnat to add after</param>
            /// <param name="data">data that u want to add</param>
            public void InsertBefore(LinkedListNode node , int data)
            {
                LinkedListNode newNode = new LinkedListNode(data);
                newNode.next = node;
                LinkedListNode parent = FindParent(node);
                if (parent is null)
                {
                    this.Head = newNode;
                }
                else
                {
                    parent.next = newNode;
                }
                length++;
            }
            /// <summary>
            /// make sure that node not null
            /// if Head= Tail this means that node is only added node 
            /// if deleted node is head make Head point to the node which deleted node point to
            /// tail = deleted node this mean it is the last node so u should make parent of deleted "node" Tail
            /// if deleted node not the tail make"parentNode.next" equal to deleted node.next"
            /// </summary>
            /// <param name="node">node that u want to delete <param>
            public void DeleteNode(LinkedListNode node)
            {
                if (node != null)
                {
                    if (this.Head==this.Tail)
                    {
                        this.Head = null;
                        this.Tail = null;
                    }
                    else if (this.Head==node)
                    {
                        this.Head = node.next;
                    }
                    else
                    {
                        LinkedListNode parentNode = FindParent(node);
                        if (this.Tail==node)
                        {
                            this.Tail = parentNode;
                        }
                        else
                        {
                            parentNode.next = node.next;
                        }
                    }
                    length--;
                }
                
            }
            public void DeleteNode(int data)
            {
                LinkedListNode node = this.Find(data);
                if (node == null)
                {
                    return;
                }
                this.DeleteNode(node);
            }
            public void Print()
            {
                for (LinkedListIterator itr = this.begin(); itr.current() != null; itr.next())
                {
                    Console.Write(itr.data() + " -> ");
                }
                Console.Write("\n");
            }
            public LinkedListNode Find(int data)
            {
                for (LinkedListIterator itr = this.begin(); itr.current() != null; itr.next())
                {
                    if (data ==itr.data())
                    {
                        return itr.current();
                    }
                    
                }
                return null;
            }

            public LinkedListNode FindParent(LinkedListNode node)
            {
                for (LinkedListIterator itr = this.begin(); itr.current() != null; itr.next())
                {
                    if (itr.current().next == node)
                    {
                        return itr.current(); // the parent of the node
                    }
                }
                return null;
            }
        }
    }
}
