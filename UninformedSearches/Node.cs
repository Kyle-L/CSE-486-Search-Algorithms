namespace UninformedSearches {
    class Node<T> {
        public T Value { get; }
        public int D { get; set; }
        public List<Arc<T>> Arcs { get; }

        public Node(T value) {
            this.Value = value;
            this.D = int.MaxValue;
            this.Arcs = new List<Arc<T>>();
        }

        public void AddArc(Node<T> destination, int weight = 1) {
            this.Arcs.Add(new Arc<T>(weight, this, destination));
        }
    }
}
