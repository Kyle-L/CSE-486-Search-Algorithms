using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UninformedSearches {
    class Graph<T> {
        public Node<T> Root { get; }
        public List<Node<T>> AllNodes = new();

    }
}
