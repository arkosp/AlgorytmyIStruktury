using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class ExpressionTree
    {
        private Stack<Node<ExpressionElement>> _stack = new Stack<Node<ExpressionElement>>();
        
        public void Insert(string anOperator)
        {
            var node = new Node<ExpressionElement>(new ExpressionElement { Operator = anOperator });
            node.Left = _stack.Pop();
            node.Right = _stack.Pop();

            _stack.Push(node);
        }

        public void Insert(double aValue)
        {
            var node = new Node<ExpressionElement>(new ExpressionElement { Value = aValue });
            _stack.Push(node);
        }

        public void Print()
        {
            foreach (var node in _stack)
                PrintNode(node);
        }

        private void PrintNode(Node<ExpressionElement> aNode)
        {
            if (aNode.Value.IsOperator)
            {
                PrintNode(aNode.Left);
                Console.Write(aNode.Value.Operator);
                PrintNode(aNode.Right);
            }
            else
                Console.Write(aNode.Value.Value);
        }

        public double Calculate()
        {
            return CalculateNode(_stack.First());
        }

        private double CalculateNode(Node<ExpressionElement> aNode)
        {
            if (aNode.Value.IsOperator)
            {
                switch (aNode.Value.Operator)
                {
                    case "+": return CalculateNode(aNode.Left) + CalculateNode(aNode.Right);
                    case "-": return CalculateNode(aNode.Left) - CalculateNode(aNode.Right);
                    case "*": return CalculateNode(aNode.Left) * CalculateNode(aNode.Right);
                    case "/": return CalculateNode(aNode.Left) / CalculateNode(aNode.Right); //sprawdzenie czy aNode.Right != 0
                    default: throw new NotSupportedException();

                }
            }
            else
                return aNode.Value.Value;
        }
    }
}
