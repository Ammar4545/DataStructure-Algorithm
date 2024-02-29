using SinglyLinkedList;
using System.ComponentModel.DataAnnotations;

//`using System.Collections.Generic;
using System.Security.Principal;
namespace Stack_LinkedListBased
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack(true);
            Console.WriteLine(stack.IsEmpty());
            stack.Push(1);
            stack.Push(1);
            stack.Push(5);
            stack.Push(61);
            stack.Print();

            #region test function
            //Console.WriteLine(stack.IsEmpty());
            //Console.WriteLine($"Size={stack.Size()}");
            //stack.Print();
            //stack.Pop();
            //Console.WriteLine($"Size={stack.Size()}");
            //stack.Print();
            //stack.Peek();
            //Console.WriteLine($"Size={stack.Size()}");
            //stack.Print();
            #endregion

            while(!stack.IsEmpty())
            {
                Console.WriteLine($"pop {stack.Pop()}");
                Console.WriteLine($"size {stack.Size()}");
                stack.Print()   ;
            }

        }
        public class Stack
        {
            private SinglyLinkedList.Program.LinkedList data_list;
            public bool unique = false;
           
            public Stack(bool unique)
            {
                this.data_list = new SinglyLinkedList.Program.LinkedList(unique);
                this.unique = unique;
            }
            public void Push(int data)
            {
                this.data_list.InsertFirst(data);
            }
            public int Pop()
            {
               var head_data= this.data_list.Head.Data;

               this.data_list.DeleteNode(head_data);

               return head_data;
            }

            public int Peek()
            {
               return this.data_list.Head.Data;
            }

            public bool IsEmpty()
            {
                return this.data_list.length <= 0;
            }

            public void Print()
            {
                this.data_list.Print();
            }
            public int Size()
            {
              return this.data_list.length;
            }
        }
    }
}
