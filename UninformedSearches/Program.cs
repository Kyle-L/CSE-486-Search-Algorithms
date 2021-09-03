using System;
using System.Collections.Generic;

namespace UninformedSearches {
    class Program {
        static void Main(string[] args) {
            Node<char> a = new('1');
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

            List<Node<char>> path1 = BreadthFirstSearch<char>.GetPath(a, f);
            Console.WriteLine(path1);

            List<Node<char>> path2 = UniformCostSearch<char>.GetPath(a, f);
            Console.WriteLine(path2);
        }
    }
}
