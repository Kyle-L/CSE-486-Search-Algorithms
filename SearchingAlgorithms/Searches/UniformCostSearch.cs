using System.Collections.Generic;

namespace Searches {
    class UniformCostSearch<T> : Search<T> {

        protected override Dictionary<Node<T>, Node<T>> BuildTraversalMap(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> traversalMap = new();
            PriorityQueue<Node<T>, int> frontier = new();

            start.PathCost = 0;
            frontier.Enqueue(start, start.PathCost);

            while (frontier.Count > 0) {
                Node<T> node = frontier.Dequeue();
                if (node.Equals(destination)) {
                    return traversalMap;
                }
                foreach (Arc<T> arc in node.Arcs) {
                    Node<T> s = arc.Destination;

                    if (!traversalMap.ContainsKey(s)) {
                        s.PathCost = node.PathCost + arc.Weight;
                        frontier.Enqueue(s, s.PathCost);
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
