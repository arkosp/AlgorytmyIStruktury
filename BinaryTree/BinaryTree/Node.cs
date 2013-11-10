using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// Węzeł drzewa
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public Node(T aValue)
        {
            Value = aValue;
        }

        public T Value { get; private set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
    }
}
