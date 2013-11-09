using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ExpressionTree();
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert("+");
            tree.Insert(7);
            tree.Insert(9);
            tree.Insert("*");
            tree.Insert("+");
            tree.Insert(12.5);
            tree.Insert("*");

            tree.Print();
            Console.WriteLine();
            Console.WriteLine(tree.Calculate());



            Console.ReadLine();
        }
    }
}
