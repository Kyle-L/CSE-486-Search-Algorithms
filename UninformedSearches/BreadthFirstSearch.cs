using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    class BreadthFirstSearch<T> : Search<T> {

        public override List<Node<T>> PeformSearch(Node<T> start, Node<T> destination) {
            Search(start, destination);
            throw new NotImplementedException();
        }

        private Node<T> Search (Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> reached = new();
            Queue<Node<T>> frontier = new();

            frontier.Enqueue(start);

            if (start.Equals(destination)) {
                return start;
            }

            while (frontier.Count > 0) {
                Node<T> node = frontier.Dequeue();
                Console.WriteLine(node.Value);
                foreach (Arc<T> arc in node.Arcs) {
                    Node<T> s = arc.Destination;
                    reached.Add(s, node);

                    if (s.Equals(destination)) {
                        return s;
                    }
                    else if (!reached.ContainsKey(s)) {
                        frontier.Enqueue(s);
                    }
                }
            }
            return null;
        }

        private 
    }
}
