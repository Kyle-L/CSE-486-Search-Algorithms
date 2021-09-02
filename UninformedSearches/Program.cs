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

            a.AddArc(b);
            a.AddArc(c);

            b.AddArc(e);
            b.AddArc(d);

            c.AddArc(e);

            d.AddArc(e);
            d.AddArc(f);

            e.AddArc(f);

            BreadthFirstSearch<char> search = new();
            List<Node<char>> path = search.PeformSearch(a, f);
            Console.WriteLine(path);
        }
    }
}
