using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            LinkedList copiedList = list.Copy();
            copiedList.Print();
            //list.InsertAfter(list.Find(5), 10);
            //list.Print();

            //list.InsertBefore(list.Find(5), 10);
            //list.Print();

            //list.DeleteNode(list.Find(1));
            //Console.WriteLine(list.Head.Data);
            //list.Print();

            //list.DeleteNode(list.Find(5));
            //Console.WriteLine(list.Head.Data);
            //list.Print();


            //list.Print();
            //list.Print();
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
            length++;
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
            length++;
        }
      
     
        public void InsertBefore(LinkedListNode node, int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.next = node;

            if (node==this.Head)
            {
                Head = newNode;
            }
            else
            {
                node.back.next = newNode;
            }
            node.back = newNode;


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
            if (this.Head==this.Tail)
            {
                Head = Tail = null;
            }
            else if (node.back is null)
            {
                this.Head = node.next ;
                node.next.back = null;
            }
            else if (node.next is null)
            {
                this.Tail = node.back;
                node.back.next = null;
            }
            else
            {
                node.back.next = node.next;
                node.next.back = node.back;
            }
            node= null ;
            length--;
           
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
        public LinkedList Copy()
        {
            LinkedList copedLinkedList = new LinkedList();
            for (LinkedListIterator itr = this.begin(); itr.current() != null; itr.next())
            {
                // Append each data element to the new list
                copedLinkedList.InsertLast(itr.data());
            }

            return copedLinkedList;
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
