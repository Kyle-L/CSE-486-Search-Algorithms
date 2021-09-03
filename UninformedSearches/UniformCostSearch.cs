using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    static class UniformCostSearch<T> {
        public static List<Node<T>> GetPath(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> reached = TraverseGraph(start, null);

            List<Node<T>> path = new();

            path.Add(destination);

            Node<T> temp = destination;
            while (reached.ContainsKey(temp)) {
                path.Insert(0, reached[temp]);
                temp = reached[temp];
            }
            return path;
        }

        /// <summary>
        /// Traverses a graph from the start until it reaches a specific destination.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private static Dictionary<Node<T>, Node<T>> TraverseGraph(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> reached = new();
            PriorityQueue<Node<T> ,int> frontier = new();


            if (start.Equals(destination)) {
                reached.Add(start, null);
            }

            start.Weight = 0;
            frontier.Enqueue(start, start.Weight);

            while (frontier.Count > 0) {
                Node<T> node = frontier.Dequeue();
                foreach (Arc<T> arc in node.Arcs) {
                    Node<T> s = (Node<T>)arc.Destination;

                    if (s.Equals(destination)) {
                        reached.Add(s, node);
                        return reached;
                    } else if (!reached.ContainsKey(s)) {
                        s.Weight = node.Weight + arc.Weight;
                        frontier.Enqueue(s, s.Weight);
                        reached.Add(s, node);
                    } else if (node.Weight + arc.Weight < s.Weight) {
                        s.Weight = node.Weight + arc.Weight;
                        reached[s] = node;
                    }
                }
            }
            return reached;
        }
    }
}
