using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Searches {
    class Program {
        static void Main(string[] args) {
            Search<char> bfs = new BreadthFirstSearch<char>();
            Search<char> ucs = new UniformCostSearch<char>();
            Search<char> dls = new DepthLimitedSearch<char>(4);
            Search<char> dis = new IterativeDeepeningSearch<char>();

            Node<char> a = new {'2'}
            Node<char> b = new('2');
            Node<char> c = new('3');
            Node<char> d = new('4');
            Node<char> e = new('5');
            Node<char> f = new('6');

            a.AddArc(b, 2);
            a.AddArc(c, 1);

            b.AddArc(d, 1);
            b.AddArc(e, 3);

            c.AddArc(e, 3);

            d.AddArc(e, 1);
            d.AddArc(f, 2);

            e.AddArc(f, 4);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i < 10000; i++) {
                List<Node<char>> path = bfs.GetPath(a, f);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();
            for (int i = 0; i < 10000; i++) {
                List<Node<char>> path = ucs.GetPath(a, f);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);


            stopWatch.Restart();
            for (int i = 0; i < 10000; i++) {
                List<Node<char>> path = dls.GetPath(a, f);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);


            stopWatch.Restart();
            for (int i = 0; i < 10000; i++) {
                List<Node<char>> path = dis.GetPath(a, f);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            Console.WriteLine();
        }
    }
}
