using System.Collections.Generic;
using System.ComponentModel.Design;

namespace DoublyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertLast(1);
            list.InsertLast(5);
            list.InsertLast(4);
            list.InsertLast(6);
            list.InsertLast(3);
            list.Print();

            list.InsertAfter(list.Find(5), 10);
            list.Print();
        }
    }
    public class LinkedListNode
    {
        public int Data; // data to store
        public LinkedListNode? next; // pointer for next node
        public LinkedListNode? back; // point to last node
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
        /// <summary>
        /// make newNode"next" point to node"next" that i want to add after it
        /// make node "next" pointer" point to newNode "next" pointer"
        /// if node was the last node => make newNode "Tail"
        /// else make the 'back' of the newNode.next "forward node" point to "newNode"
        /// -- this method will use [Find()] to get the "node"
        /// </summary>
        /// <param name="node">node that u wnat to add after</param>
        /// <param name="data">data that u want to add</param>
        public void InsertAfter(LinkedListNode node, int data)
        {
            LinkedListNode newNode=new LinkedListNode(data);
            newNode.next = node.next;
            newNode.back = node;
            node.next = newNode;
            if (newNode.next is null)
            {
                this.Tail = newNode;
            }
            else
            {
                newNode.next.back = newNode;
            }
        }
        public void InsertLast(int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            if (this.Tail==null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                newNode.back = this.Tail;
                this.Tail.next = newNode;
                 this.Tail= newNode;
            }
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
        public void InsertBefore(LinkedListNode node, int data)
        {
           
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
                if (data == itr.data())
                {
                    return itr.current();
                }

            }
            return null;
        }

    }
}
