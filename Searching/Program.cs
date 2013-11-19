using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 3, 5, 6, 8, 12, 20, 33, 50, 82, 90, 120, 130, 178, 456, 789, 999, 1020 };

            Console.WriteLine(BinarySearch.Recursve(numbers, 1020));
            Console.WriteLine(BinarySearch.Iterative(numbers, 1020));

            Console.ReadLine();
        }
    }
}
