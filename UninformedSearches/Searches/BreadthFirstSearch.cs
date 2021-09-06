namespace UninformedSearches {
    class BreadthFirstSearch<T> : UninformedSearch<T> {


        protected override Dictionary<Node<T>, Node<T>> BuildTraversalMap(Node<T> start, Node<T> destination) {
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
