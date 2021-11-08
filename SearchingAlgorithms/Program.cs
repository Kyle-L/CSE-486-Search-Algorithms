using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Searches {
    class Program {
        static void Main(string[] args) {
            // GRAPH 1
            Node<char> a1 = new('a');
            Node<char> b1 = new('b');
            Node<char> c1 = new('c');
            Node<char> d1 = new('d');
            Node<char> e1 = new('e');
            Node<char> f1 = new('f');

            a1.AddArc(b1, 2);
            a1.AddArc(c1, 1);

            b1.AddArc(d1, 1);
            b1.AddArc(e1, 3);

            c1.AddArc(e1, 3);

            d1.AddArc(e1, 1);
            d1.AddArc(f1, 2);

            e1.AddArc(f1, 4);

            // GRAPH 2
            Node<char> s2 = new('s', 6);
            Node<char> a2 = new('a', 0);
            Node<char> b2 = new('b', 6);
            Node<char> c2 = new('c', 4);
            Node<char> d2 = new('d', 1);
            Node<char> e2 = new('e', 10);
            Node<char> g2 = new('g', 0);

            s2.AddArc(g2, 9);
            s2.AddArc(a2, 2);
            s2.AddArc(b2, 1);
            a2.AddArc(c2, 2);
            a2.AddArc(d2, 3);
            b2.AddArc(d2, 2);
            b2.AddArc(e2, 4);
            c2.AddArc(g2, 4);
            d2.AddArc(g2, 4);


            Search<char> bfs = new BreadthFirstSearch<char>();
            Search<char> ucs = new UniformCostSearch<char>();
            Search<char> dls = new DepthLimitedSearch<char>(4);
            Search<char> dis = new IterativeDeepeningSearch<char>();
            Search<char> aStar = new AStar<char>();


            Console.WriteLine("BFS:");
            List<Node<char>> path = bfs.GetPath(a1, f1);
            Console.WriteLine("\tGraph 1: " + string.Join(" -> ", path));
            path = bfs.GetPath(s2, g2);
            Console.WriteLine("\tGraph 2: " + string.Join(" -> ", path));

            Console.WriteLine("UCS:");
            path = ucs.GetPath(a1, f1);
            Console.WriteLine("\tGraph 1: " + string.Join(" -> ", path));
            path = ucs.GetPath(s2, g2);
            Console.WriteLine("\tGraph 2: " + string.Join(" -> ", path));

            Console.WriteLine("DLS:");
            path = dls.GetPath(a1, f1);
            Console.WriteLine("\tGraph 1: " + string.Join(" -> ", path));
            path = dls.GetPath(s2, g2);
            Console.WriteLine("\tGraph 2: " + string.Join(" -> ", path));

            Console.WriteLine("DIS:");
            path = dis.GetPath(a1, f1);
            Console.WriteLine("\tGraph 1: " + string.Join(" -> ", path));
            path = dis.GetPath(s2, g2);
            Console.WriteLine("\tGraph 2: " + string.Join(" -> ", path));

            Console.WriteLine("A*:");
            path = aStar.GetPath(a1, f1);
            Console.WriteLine("\tGraph 1: " + string.Join(" -> ", path));
            path = aStar.GetPath(s2, g2);
            Console.WriteLine("\tGraph 2: " + string.Join(" -> ", path));
        }
    }
}
