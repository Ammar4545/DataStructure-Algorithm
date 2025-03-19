using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap
    {
        private List<int> _list = new List<int>();
        private int _size;
        public Heap()
        {
            
            
            _list = new List<int>();
           _size = 0;
        }

        public void Insert(int data)
        {
            int i = _size;

            // Ensure list has enough capacity
            if (i >= _list.Count)
            {
                _list.Add(data);
            }
            else
            {
                _list[i] = data;
            }
            ++_size;
            _list[i] = data;

            int parent_index = (int)Math.Floor((i - 1) / 2.0);

            while (i != 0 && _list[i] < _list[parent_index])
            {
                var temp = _list[i];
                _list[i] = _list[parent_index];
                _list[parent_index] = temp;

                i = parent_index;
                parent_index = (int)Math.Floor((i - 1) / 2.0);
            }
        }

        public int?  Pop()
        {
            if (_size == 0) return null;
            int i = 0;
            int data =_list[i];
            _list[i] = _list[_size - 1];
            _list.Remove(_size - 1);
            _size--;

            var left_index= (i * 2) + 1;
            while (left_index < _size)
            {
                left_index = (i * 2) + 1;
                int right_index = (i * 2) + 2;
                int smaller_index=left_index;

                if (right_index < _size && _list[right_index] < _list[left_index])
                {
                    smaller_index = right_index;  
                }

                if (_list[smaller_index] >= _list[i])
                {
                    break;
                }

                var temp = _list[i];
                _list[i] = _list[smaller_index];
                _list[smaller_index] = temp;

                i = smaller_index;
                left_index = i*2 + 1;
            }
            return data;

        }
        public void Print()
        {
            string printData = "";
            for (int i = 0; i < _size; i++)
            {
                printData += _list[i] + " - ";
            }
            Console.WriteLine(printData);
        }

        public int Size()
        {
            return _size;
        }

        public void Draw()
        {
            int levelsCount = (int)Math.Log(_size, 2) + 1;
            int lineWidth = (int)Math.Pow(2, levelsCount - 1);

            int j = 0;
            for (int i = 0; i < levelsCount; i++)
            {
                int nodesCount = (int)Math.Pow(2, i);
                int space = (int)Math.Ceiling(lineWidth - nodesCount / 2.0);
                int spaceBetween = (int)Math.Ceiling(levelsCount / (double)nodesCount);
                spaceBetween = spaceBetween < 1 ? 1 : spaceBetween;
                int k = j;
                string str = new string(' ', space + spaceBetween);

                for (; j < k + nodesCount; j++)
                {
                    if (j == _size)
                    {
                        break;
                    }

                    str += _list[j] + new string(' ', spaceBetween);
                }

                str += new string(' ', space) + "\n";
                Console.WriteLine(str);
            }
        }
    }
}
