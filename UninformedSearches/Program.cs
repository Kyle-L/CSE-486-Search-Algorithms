using System;

namespace UninformedSearches {
    class Program {
        static void Main(string[] args) {
            Node<char> a = new Node<char>('1');
            Node<char> b = new Node<char>('2');
            Node<char> c = new Node<char>('3');
            Node<char> d = new Node<char>('4');
            Node<char> e = new Node<char>('5');
            Node<char> f = new Node<char>('6');
            a.AddArc(b);
            a.AddArc(c);

            b.AddArc(e);
            b.AddArc(d);

            c.AddArc(e);

            d.AddArc(e);
            d.AddArc(f);

            e.AddArc(f);

            BreadthFirstSearch<char> search = new();
            search.PeformSearch(a, f);
        }
    }
}
