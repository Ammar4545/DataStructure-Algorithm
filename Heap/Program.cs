namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap();
            heap.Insert(14);
            heap.Insert(16);
            heap.Insert(32);
            heap.Insert(45);
            heap.Insert(53);
            heap.Insert(20);
            heap.Insert(24);
            heap.Insert(27);
            //heap.Insert(15);

            heap.Print();
            heap.Draw();

            Console.WriteLine(heap.Pop());
            heap.Print();
            heap.Draw();

            Console.WriteLine( heap.Size());
        }
    }
}
