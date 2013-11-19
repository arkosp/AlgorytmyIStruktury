using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            var g = new Array.Graph(5, false);
            g.Connect(0, 1);
            g.Connect(0, 3);
            g.Connect(1, 3);
            g.Connect(2, 1);
            g.Connect(3, 2);
            g.Connect(4, 2);

            var is0and2connected = g.ConnectionExists(0, 2);
            var is0and4connected = g.ConnectionExists(0, 4);
            var route0To2 = g.FindRoute(0, 2);
            var route0To4 = g.FindRoute(0, 4);
        }
    }
}
