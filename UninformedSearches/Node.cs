using System.Collections.Generic;

namespace Searches {
    class Node<T> {
        public T Value { get; }
        public int PathCost { get; set; }
        public int Heuristic { get; set; }
        public List<Arc<T>> Arcs { get; }

        public Node(T value, int heuristic = 0) {
            this.Value = value;
            this.PathCost = int.MaxValue;
            this.Heuristic = heuristic;
            this.Arcs = new List<Arc<T>>();
        }

        public void AddArc(Node<T> destination, int weight = 1) {
            this.Arcs.Add(new Arc<T>(weight, this, destination));
        }
    }
}
