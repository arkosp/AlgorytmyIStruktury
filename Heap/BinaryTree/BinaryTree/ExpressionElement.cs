using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class ExpressionElement
    {
        public double Value { get; set; }
        public string Operator { get; set; }
        public bool IsOperator { get { return !string.IsNullOrEmpty(Operator); } }
    }
}
