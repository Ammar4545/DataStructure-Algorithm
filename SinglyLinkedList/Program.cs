namespace SinglyLinkedList
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
        }
        public class LinkedListNode
        {
            public int Data; // data to store
            public LinkedListNode? next; // pointer for next node
            public LinkedListNode(int data)
            {
                this.Data = data;
                this.next = null;
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
            public void Print()
            {
                for (LinkedListIterator itr = this.begin(); itr.current() != null; itr.next())
                {
                    Console.Write(itr.data() + " -> ");
                }
                Console.Write("\n");
            }
        }
    }
}
