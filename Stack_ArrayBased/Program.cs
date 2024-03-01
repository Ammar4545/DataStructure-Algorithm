using System.Security.Cryptography;

namespace Stack_ArrayBased
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            Console.WriteLine($"is empty {stack.IsEmpty()}");
            stack.Push(15);
            Console.WriteLine($"is empty {stack.IsEmpty()}");
            stack.Print();
            stack.Push(9);
            stack.Print();

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Size());
                
                stack.Print();
            }
        }
    }
    public class Stack<T>
    {
        private T[] items;
        int topIndex = -1;
        int initialSize;
        int currentSize;
        public Stack()
        {
            this.initialSize = 1;
            this.items = new T[this.initialSize];
            this.currentSize = this.initialSize;
        }
        public void resizeOrNot()
        {
            if (this.topIndex < this.currentSize - 1) return;
            Console.WriteLine("resizing the array....");
            T[] newArray=new T[this.currentSize+this.initialSize];
            items.CopyTo(newArray, 0);
            this.currentSize += this.initialSize;
            items = newArray;
        }

        public void Push(T data)
        {
            this.resizeOrNot();
            this.items[++topIndex]= data;
        }

        public T Peek()
        {
            if (topIndex == -1)
                return default(T);
            return this.items[this.topIndex];
        }

        public T Pop()
        {
               if (topIndex == -1)
                    return default(T);

                T headData = this.items[this.topIndex];
                this.items[this.topIndex] = default(T);
                this.topIndex--;
                return headData;
        }

        public bool IsEmpty()
        {
            if (this.topIndex==-1)
            {
                return true;
            }
            return false;
        }

        public int Size()
        {
            return this.topIndex+1;
        }

        public void Print()
        {
            for (int i = this.topIndex; i >=0 ; i--)
            {
                Console.Write($"{items[i]}  ->");
            }
        }

    }
}
