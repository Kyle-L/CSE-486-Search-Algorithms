using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    class BreadthFirstSearch<T> : Search<T> {

        public override List<Node<T>> PeformSearch(Node<T> start, Node<T> destination) {
            return GetPath(Search(start, destination), destination);
        }

        private Dictionary<Node<T>, Node<T>> Search (Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> reached = new();
            Queue<Node<T>> frontier = new();


            if (start.Equals(destination)) {
                reached.Add(start, null);
            }

            frontier.Enqueue(start);

            while (frontier.Count > 0) {
                Node<T> node = frontier.Dequeue();
                foreach (Arc<T> arc in node.Arcs) {
                    Node<T> s = arc.Destination;

                    if (s.Equals(destination)) {
                        reached.Add(s, node);
                        return reached;
                    } else if (!reached.ContainsKey(s)) {
                        frontier.Enqueue(s);
                        reached.Add(s, node);
                    }
                }
            }
            return reached;
        }

        private List<Node<T>> GetPath (Dictionary<Node<T>, Node<T>> reached, Node<T> destination) {
            List<Node<T>> path = new();

            path.Add(destination);

            Node<T> start = destination;
            while (reached.ContainsKey(start)) {
                path.Insert(0, reached[start]);
                start = reached[start];
            }
            return path;
        }
    }
}
