﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    static class BreadthFirstSearch<T> {

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
        private static Dictionary<Node<T>, Node<T>> TraverseGraph (Node<T> start, Node<T> destination) {
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
    }
}
