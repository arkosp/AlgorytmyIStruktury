using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Heap
    {
        private readonly List<int> _list = new List<int>();

        public Heap()
        {
            _list.Add(int.MinValue);
        }

        public Heap(IEnumerable<int> aValues):this()
        {
            foreach (var v in aValues)
                Enqueue(v);
        }

        public int Count { get { return _list.Count -1; } }

        public void Enqueue(int aValue)
        {
            _list.Add(aValue);
            MoveUp();
        }

        public int Dequeue()
        {
            var result = _list[1];
            _list[1] = _list.Last();
            _list.RemoveAt(_list.Count - 1);
            MoveDown();
            return result;
        }

        private void MoveUp()
        {
            int item = _list.Last();
            int i = _list.Count - 1;
            while ((i != 1) && (_list[Parent(i)] <= item))
            {
                SwapCells(i, Parent(i));
                i = Parent(i);
            }
        }

        private void MoveDown()
        {
            int i = 1;
            while (true)
            {
                var item = i * 2;
                if (item > _list.Count - 1) break;
                if ((item + 1 <= _list.Count - 1) && (_list[item] < _list[item + 1])) item++;
                if (_list[i] >= _list[item]) break;
                SwapCells(i, item);
                i = item;
            }
        }

        private void SwapCells(int i, int j)
        {
            var temp = _list[i];
            _list[i] = _list[j];
            _list[j] = temp;
        }

        private int Parent(int i)
        {
            return i / 2;
        }

        private int Left(int i)
        {
            return i * 2;
        }

        private int Right(int i)
        {
            return i * 2  +1;
        }

        public void Print()
        {
            Print(1, 0);
        }

        private void Print(int aIndex, int aIndent)
        {
            if (aIndex > _list.Count -1) return;

            Console.WriteLine(Indent(aIndent) + _list[aIndex]);
            Print(aIndex * 2, aIndent + 1);
            Print(aIndex * 2 + 1, aIndent + 1);
        }

        private string Indent(int count)
        {
            return "".PadLeft(count * 2);
        }
    }
}
