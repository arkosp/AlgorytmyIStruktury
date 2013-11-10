using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// Element wyrażenia
    /// </summary>
    class ExpressionElement
    {
        public double Value { get; set; }
        public string Operator { get; set; }
        public bool IsOperator { get { return !string.IsNullOrEmpty(Operator); } }
    }
}
