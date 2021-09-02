using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    class Node<T> {
        public T Value { get; }
        public List<Arc<T>> Arcs { get; }

        public Node(T value) {
            this.Value = value;
            this.Arcs = new List<Arc<T>>();
        }

        public void AddArc(Node<T> destination, int weight = 1) {
            this.Arcs.Add(new Arc<T>(weight, this, destination));
        }
    }
}
