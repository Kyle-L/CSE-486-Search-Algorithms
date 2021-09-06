namespace UninformedSearches {
    class DepthLimitedSearch<T> : UninformedSearch<T> {

        protected int levelLimit;

        public DepthLimitedSearch(int levelLimit) {
            this.levelLimit = levelLimit;
        }


        protected override Dictionary<Node<T>, Node<T>> BuildTraversalMap(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> reached = new();
            Stack<Node<T>> frontier = new();

            start.D = 0;
            frontier.Push(start);

            while (frontier.Count > 0) {
                Node<T> node = frontier.Pop();
                if (node.Equals(destination)) {
                    return reached;
                } else if (node.D >= levelLimit) {
                    continue;
                } else {
                    foreach (Arc<T> arc in node.Arcs) {
                        Node<T> child = arc.Destination;
                        if (!reached.ContainsKey(child)) {
                            child.D = node.D + 1;
                            frontier.Push(child);
                            reached.Add(child, node);
                        }
                    }
                }
            }
            return reached;
        }
    }
}
