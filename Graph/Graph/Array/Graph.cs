using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph.Array
{
    /// <summary>
    /// Implementacja grafy bazująca na tablicy druwymiarowej
    /// </summary>
    class Graph
    {
        /// <summary>
        /// Tablica dwuwymiarowa zawierająca graf.
        /// Wiersze zawierają węzły początkowe krawędzi grafu.
        /// Kolumny zawierają węzły końcowe krawędzi grafu.
        /// </summary>
        private readonly int[,] _graph;
        /// <summary>
        /// Liczba węzłów w grafie
        /// </summary>
        private readonly int _nodeCout;
        /// <summary>
        /// Informacja o tym czy graf jest skierowany
        /// </summary>
        private readonly bool _directed;

        /// <summary>
        /// Dostęp read only do krawędzi grafu
        /// </summary>
        /// <param name="index"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        public int this[int i, int j]
        {
            get { return _graph[i, j]; }
        }

        /// <summary>
        /// Przyjmuje informacje o maksymalnej liczbie węzłów w grafie i czy graf jest skierowany
        /// </summary>
        /// <param name="aNodeCount"></param>
        /// <param name="aDirected"></param>
        public Graph(int aNodeCount, bool aDirected)
        {
            _graph = new int[aNodeCount, aNodeCount];
            _nodeCout = aNodeCount;
            _directed = aDirected;
            Initialize();
        }
        
        /// <summary>
        /// Inicjalizuje wszystie komórki wartością 0 - czyli brak krawędzi
        /// </summary>
        private void Initialize()
        {
            for (int i = 0; i < _nodeCout; i++)
                for (int j = 0; j < _nodeCout; j++)
                    _graph[i,j] = 0;
        }

        /// <summary>
        /// Łączy podane węzły 
        /// </summary>
        /// <param name="aFirstNode"></param>
        /// <param name="aSecondNode"></param>
        public void Connect(int aFirstNode, int aSecondNode)
        {
            if (aFirstNode > _nodeCout || aSecondNode > _nodeCout) return;
            
            _graph[aFirstNode, aSecondNode] = 1;
            //dla grafu nieskierowanego powielane są informacje o krawędziach czyli jeżeli łączone są A-B to również B-A
            if (_directed) 
                _graph[aSecondNode, aFirstNode] = 1;
        }

        public bool ConnectionExists(int aFirstNode, int aSecondNode)
        {
            if (aFirstNode > _nodeCout || aSecondNode > _nodeCout) return false;

            var graph = Roy_Warshall();
            return graph[aFirstNode, aSecondNode] != 0;
        }

        /// <summary>
        /// Metoda zwraca drogę pomiędzy węzłami
        /// </summary>
        /// <param name="aFirstNode"></param>
        /// <param name="aSecondNode"></param>
        /// <returns></returns>
        public string FindRoute(int aFirstNode, int aSecondNode)
        {
            var r = this.Copy();
            
            //W miejsce informacji o tym, że istnieje krawędź jest wpisywany węzeł końcowy krawędzi.
            for (int a = 0; a < _nodeCout; a++)
                for (int b = 0; b < _nodeCout; b++)
                    if (r[a, b] != 0)
                        r[a, b] = b;

            //Modywikacja algorytmu Roy'a-Warshall'a
            for (int i = 0; i < _nodeCout; i++)
                for (int j = 0; j < _nodeCout; j++)
                    if (r[j, i] != 0)
                        for (int z = 0; z < _nodeCout; z++)
                            if ((r[j, z] == 0) && (r[i, z] != 0))
                                r[j, z] = r[j, i];

            
            if (r[aFirstNode, aSecondNode] == 0) 
                return string.Format("Route from node: {0} to node {1} don't exist.", aFirstNode, aSecondNode);

            var node = aFirstNode;
            var route = node.ToString();
            while (node != aSecondNode)
            {
                node = r[node, aSecondNode];
                route += "->" + node.ToString();
            }
            return route;
        }

        /// <summary>
        /// Obliczenie domknięcia przechodzniego grafu.
        /// Domknięcie przechodnie informuje czy pomiędzy węzłami istnieje połączenie.
        /// </summary>
        private int[,] Roy_Warshall()
        {
            var temp = this.Copy();
            for (int i = 0; i < _nodeCout; i++)
                for (int j = 0; j < _nodeCout; j++)
                    for (int z = 0; z < _nodeCout; z++)
                        if (temp[j, z] == 0)
                            temp[j, z] = _graph[j, i] * _graph[i, z];
            return temp;     
        }

        private int[,] Copy()
        {
            var result = new int[_nodeCout, _nodeCout];
            for (int i = 0; i < _nodeCout; i++)
                for (int j = 0; j < _nodeCout; j++)
                    result[i, j] = _graph[i, j];
            
            return result;
        }
    }
}


