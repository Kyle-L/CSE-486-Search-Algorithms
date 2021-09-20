using System;
using System.Collections.Generic;

namespace Searches {
    class AStar<T> : Search<T> {

        public delegate int Heurisitic(Node<T> node);

        public AStar(List<Node<T>> nodes, Heurisitic heuristicFunction = null) {
            if (heuristicFunction is not null) {
                foreach (Node<T> node in nodes) {
                    node.Heuristic = heuristicFunction(node);
                }
            }
        }

        protected override Dictionary<Node<T>, Node<T>> BuildTraversalMap(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> traversalMap = new();
            PriorityQueue<Node<T>, int> frontier = new();

            start.PathCost = 0;
            frontier.Enqueue(start, start.PathCost);

            while (frontier.Count > 0) {
                Node<T> node = frontier.Dequeue();
                foreach (Arc<T> arc in node.Arcs) {
                    Node<T> s = arc.Destination;

                    // Quit once we reach the destination.
                    if (s.Equals(destination)) {
                        traversalMap.Add(s, node);
                        return traversalMap;

                    // Expand the frontier for unvisited notes.
                    } else if (!traversalMap.ContainsKey(s)) {
                        s.PathCost = node.PathCost + arc.Weight;
                        frontier.Enqueue(s, s.PathCost + node.Heuristic);
                        traversalMap.Add(s, node);

                    // Replace existing node's best parent in the traversal map if their cost is lower
                    // with the new parent.
                    } else if (node.PathCost + arc.Weight < s.PathCost) {
                        s.PathCost = node.PathCost + arc.Weight;
                        traversalMap[s] = node;
                    }
                }
            }
            return traversalMap;
        }
    }
}
