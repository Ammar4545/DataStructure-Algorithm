﻿using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HashTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, string> table = new HashTable<string, string>();
            table.Print();
            table.Set("Sinar", "sinar@gmail.com");
            table.Set("Elvis", "elvis@gmail.com");
            table.Set("Tane", "tane@gmail.com");
            table.Print();
            Console.WriteLine("[get] " + table.Get("Sinar"));
            //Console.WriteLine("[get] " + table.Get("Tane"));
            table.Set("Gerti", "gerti@gmail.com");
            table.Set("Arist", "arist@gmail.com");
            table.Print();
            Console.WriteLine("[get] " + table.Get("Sinar"));
        }
        public class HashTable<Tkey,Tvalue> where Tkey : class
        {
            KeyValuePair[] entries;
            int initialSize;
            int entriesCount;
            public HashTable()
            {
                this.initialSize = 3;
                this.entriesCount = 0;
                this.entries = new KeyValuePair[initialSize];

            }
             
            void AddToEntries(Tkey key, Tvalue value)
            {
                int hash = this.GetHash(key);

                if (this.entries[hash] != null && this.entries[hash].Key!=key)
                {
                    hash = this.CollisionHandling(key, hash, true);
                }
                if (hash==-1)
                {
                    throw new Exception("INVALID HASH TABLE");
                }
                if (this.entries[hash] ==null)
                {
                    KeyValuePair newPair = new KeyValuePair(key , value);
                    this.entries[hash] = newPair;
                    this.entriesCount++;

                }
                else if (this.entries[hash].Key == key)
                {
                    this.entries[hash].Value = value;
                }
                else
                {
                    throw new Exception("INVALID HASH TABLE");
                }
            }

            int GetHash(Tkey key)
            {
                uint FnvOffsetBasis = 2166136261;
                uint FNVPrime = 16777619;

                byte[] data = Encoding.ASCII.GetBytes(key.ToString());

                uint hash = FnvOffsetBasis;

                for (int i = 0; i < data.Length; i++)
                {
                    hash = hash ^ data[i];
                    hash = hash * FNVPrime;
                }

                Console.WriteLine("[hash] " + key.ToString()
                    + " " + hash + " " + hash.ToString("x")
                      + " " + hash % (uint)this.entries.Length);

                return (int)(hash % (uint)this.entries.Length);
            }

            int CollisionHandling(Tkey key, int hash, bool Set)
            {
                int newHash;
                for (int i = 0; i < this.entries.Length; i++)
                {
                    newHash = (hash + i) % this.entries.Length;

                    if (Set && (this.entries[newHash] ==null|| this.entries[newHash].Key==key))
                    {
                        return newHash;
                    }
                    else if (!Set && this.entries[newHash].Key == key)
                    {
                        return newHash;
                    }
                }
                return -1;
            }

            public void ResizeOrNot()
            {
                if (this.entriesCount < this.entries.Length)
                {
                    return;
                }
                int newSize = this.entries.Length * 2;

                Console.WriteLine("[resize] from " + this.entries.Length + " to " + newSize);
                //new arr of pairs with "entries.Length" to copy data to it
                KeyValuePair[] entriesCopy = new KeyValuePair[this.entries.Length];
                Array.Copy(this.entries, entriesCopy, entriesCopy.Length);
                //make new new arr of pairs with newsize 
                //why resize then copy with hashing and fixing the prolem of collision
                //becouse we use the size of array for hashin and if we double the array of pairs this mean new size for hashing
                this.entries = new KeyValuePair[newSize];
                this.entriesCount = 0;
                for (int i = 0; i < entriesCopy.Length; i++)
                {
                    if (entriesCopy[i]==null)
                    {
                        continue;
                    }
                    this.AddToEntries(entriesCopy[i].Key, entriesCopy[i].Value);
                }

            }

            public Tvalue Get(Tkey key)
            {
                int hash = GetHash(key);
                if (this.entries[hash]==null && this.entries[hash].Key!=key)
                {
                    this.CollisionHandling(key, hash, false);
                }
                if (hash==-1 && this.entries[hash]==null)
                {
                    return default(Tvalue);
                }
                if (this.entries[hash].Key==key)
                {
                    return this.entries[hash].Value;
                }
                else
                {
                    throw new Exception("INVALID HASH TABLE");
                }
            }

            public void Set(Tkey key, Tvalue value)
            {
                this.ResizeOrNot();
                this.AddToEntries(key, value);
            }

            public int Size()
            {
               return this.entriesCount;
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

            public void Print()
            {
                Console.WriteLine("-----------");
                Console.WriteLine("[Size] " + this.Size());

                for (int i = 0; i < this.entries.Length; i++)
                {
                    if (this.entries[i] == null)
                    {
                        Console.WriteLine("[" + i + "] null");
                    }
                    else
                    {
                        Console.WriteLine("[" + i + "] " +
                          this.entries[i].Key + ":" +
                            this.entries[i].Value);
                    }
                }

                Console.WriteLine("============");
            }
        }
    }
}
