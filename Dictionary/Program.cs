using System.Drawing;
using System.Security.Cryptography;

namespace Dictionary
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> newDic = new Dictionary<string, string>();

            newDic.Print();

            newDic.Set("Sinar", "sinar@gmail.com");
            newDic.Set("Elvis", "elvis@gmail.com");
            newDic.Print();

            newDic.Set("Tane", "tane@gmail.com");
            newDic.Set("Gerti", "gerti@gmail.com");
            newDic.Set("Arist", "arist@gmail.com");

            newDic.Set("rArist", "rarist@gmail.com");
            newDic.Set("tArist", "tarist@gmail.com");
            newDic.Set("yArist", "yarist@gmail.com");
            newDic.Print();

            Console.WriteLine(newDic.Get("yArist"));
            Console.WriteLine(newDic.Get("yrist"));
          
        }

        public class Dictionary<Tkey, Tvalue> where Tkey : class
        {
            KeyValuePair[] items;
            int initialSize;
            int itemsCount;
            public Dictionary()
            {
                this.initialSize = 3;
                this.items = new KeyValuePair[initialSize];

            }

            public void Set(Tkey key, Tvalue value)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null && items[i].Key == key)
                    {
                        this.items[i].Value = value;
                        return;
                    }
                }

                this.ResizeOrNot();
                KeyValuePair newPair = new KeyValuePair(key, value);
                this.items[this.itemsCount] = newPair;
                this.itemsCount++;
            }

            public Tvalue Get(Tkey key)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (this.items[i] != null && this.items[i].Key == key)
                    {
                        return this.items[i].Value;
                    }
                }
                return default(Tvalue);
            }
            public bool Remove(Tkey key)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null && items[i].Key == key)
                    {
                        this.items[i] = this.items[itemsCount - 1];
                        this.items[itemsCount - 1] = null;
                        itemsCount--;
                        return true;
                    }
                }
                return false;
            }
            public void ResizeOrNot()
            {
                if (this.itemsCount < this.items.Length - 1)
                {
                    return;
                }
                int newSize = items.Length + initialSize;
                Console.WriteLine($"Resize from {items.Length} to {newSize}");
                KeyValuePair[] newArray = new KeyValuePair[newSize];
                Array.Copy(this.items, newArray, this.items.Length);
                this.items = newArray;
            }
            public void Print()
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"[size]= {Size()}");
                for (int i = 0; i < items.Length; i++)
                {
                    if (this.items[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{this.items[i].Value} : {this.items[i].Key}");
                    }

                }
                Console.WriteLine("''''''''''''''''''");


            }

            public int Size()
            {
                return this.itemsCount;
            }

            public class KeyValuePair
            {
                Tkey _key;
                Tvalue _value;
                public Tkey Key
                {
                    get { return _key; }
                }
                public Tvalue Value
                {
                    get { return _value; }
                    set { _value = value; }
                }
                public KeyValuePair(Tkey key, Tvalue value)
                {
                    _value = value;
                    _key = key;
                }
            }
        }
    }
}
