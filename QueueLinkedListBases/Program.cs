namespace Queue_LinkedListBases
{
    public class Program
    {
        static void Main(string[] args)
        {
            var queueTest = new Queue(false);

            Console.WriteLine(queueTest.IsEmpty());

            queueTest.Enqueue(10);
            queueTest.Enqueue(15);
            queueTest.Enqueue(20);
            queueTest.Enqueue(30);
            //Console.WriteLine(queueTest.Dequeue());
            //Console.WriteLine(queueTest.Dequeue());
            //Console.WriteLine(queueTest.Dequeue());
            //Console.WriteLine(queueTest.Dequeue());
            //Console.WriteLine(queueTest.IsEmpty());
            queueTest.Print();

            while (!queueTest.IsEmpty())
            {
                Console.WriteLine($"peeking {queueTest.Peek()}");
                Console.WriteLine($"dequeueing {queueTest.Dequeue()}");
                queueTest.Print();
                Console.WriteLine($"size = {queueTest.Size()}\n");
            }

        }
        public class Queue
        {
            private SinglyLinkedList.Program.LinkedList dataList;
            public bool unique = false;
            public Queue(bool unique)
            {
                this.unique=unique;
                this.dataList= new SinglyLinkedList.Program.LinkedList(unique);  
            }
            public void Enqueue(int data)
            {
                this.dataList.InsertLast(data);
            }

            public int Dequeue()
            {
                int nodeData = this.dataList.Head.Data;
                this.dataList.DeleteHead();
                return nodeData;
            }

            public int Peek()
            {
                if (this.dataList.Head == null)
                {
                    return 0;
                }
                return this.dataList.Head.Data;
            }

            public bool IsEmpty()
            {
                return this.dataList.length <= 0;
            }

            public int Size()
            {
                return this.dataList.length;
            }

            public void Print()
            {
                this.dataList.Print();
            }
        }
    }
}
