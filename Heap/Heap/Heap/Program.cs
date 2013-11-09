using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new[] { 22, 12, 48, 62, 90, 128, 200, 3 };
            EnqueueAndDequeue(values);
            Sort(values);
            Console.ReadLine();
        }

        static void EnqueueAndDequeue(IEnumerable<int> aValues)
        {
            var heap = new Heap();
            foreach (var v in aValues)
                heap.Enqueue(v);

            heap.Print();
            heap.Dequeue();
            heap.Print();
        }

        static void Sort(IEnumerable<int> aValues)
        {
            var heap = new Heap(aValues);
            while (heap.Count > 0)
                Console.WriteLine(heap.Dequeue());
        }
    }

    

}
