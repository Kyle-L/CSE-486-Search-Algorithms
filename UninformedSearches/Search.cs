using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    abstract class Search<T> {
        public abstract List<Node<T>> PeformSearch(Node<T> start, Node<T> destination);
    }
}
