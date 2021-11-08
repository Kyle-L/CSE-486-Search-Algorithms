using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Searches {
    class Program {
        static void Main(string[] args) {
            Node<char> a = new('a');
            Node<char> b = new('b');
            Node<char> c = new('c');
            Node<char> d = new('d');
            Node<char> e = new('e');
            Node<char> f = new('f');

            a.AddArc(b, 2);
            a.AddArc(c, 1);

            b.AddArc(d, 10);
            b.AddArc(e, 3);

            c.AddArc(e, 11);

            d.AddArc(e, 1);
            d.AddArc(f, 2);

            e.AddArc(f, 4);

            Search<char> bfs = new BreadthFirstSearch<char>();
            Search<char> ucs = new UniformCostSearch<char>();
            Search<char> dls = new DepthLimitedSearch<char>(4);
            Search<char> dis = new IterativeDeepeningSearch<char>();
            Search<char> aStar = new AStar<char>();


            Console.WriteLine("BFS:");
            List<Node<char>> path = bfs.GetPath(a, f);
            Console.WriteLine("\t" + string.Join(" -> ", path));

            Console.WriteLine("UCS:");
            path = ucs.GetPath(a, f);
            Console.WriteLine("\t" + string.Join(" -> ", path));

            Console.WriteLine("DLS:");
            path = dls.GetPath(a, f);
            Console.WriteLine("\t" + string.Join(" -> ", path));

            Console.WriteLine("DIS:");
            path = dis.GetPath(a, f);
            Console.WriteLine("\t" + string.Join(" -> ", path));

            Console.WriteLine("A*:");
            path = aStar.GetPath(a, f);
            Console.WriteLine("\t" + string.Join(" -> ", path));
        }
    }
}
