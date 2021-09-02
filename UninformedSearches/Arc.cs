using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    class Arc<T> {
        public int Weight { get; }
        public Node<T> Origin { get; }
        public Node<T> Destination { get; }

        public Arc(int weight, Node<T> origin, Node<T> destination) {
            this.Weight = weight;
            this.Origin = origin;
            this.Destination = destination;
        }
    }
}
