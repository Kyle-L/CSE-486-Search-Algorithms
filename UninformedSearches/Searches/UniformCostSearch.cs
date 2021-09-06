namespace UninformedSearches {
    class UniformCostSearch<T> : UninformedSearch<T> {

        protected override Dictionary<Node<T>, Node<T>> BuildTraversalMap(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> traversalMap = new();
            PriorityQueue<Node<T>, int> frontier = new();

            start.D = 0;
            frontier.Enqueue(start, start.D);

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
                        s.D = node.D + arc.Weight;
                        frontier.Enqueue(s, s.D);
                        traversalMap.Add(s, node);

                        // Replace existing node's best parent in the traversal map if their cost is lower
                        // with the new parent.
                    } else if (node.D + arc.Weight < s.D) {
                        s.D = node.D + arc.Weight;
                        traversalMap[s] = node;
                    }
                }
            }
            return traversalMap;
        }
    }
}
