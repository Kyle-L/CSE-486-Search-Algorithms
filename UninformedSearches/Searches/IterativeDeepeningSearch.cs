using System.Collections.Generic;

namespace Searches {
    class IterativeDeepeningSearch<T> : DepthLimitedSearch<T> {

        public IterativeDeepeningSearch() : base(0) { }

        public override List<Node<T>> GetPath(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> map;
            levelLimit = 1;
            do {
                map = this.BuildTraversalMap(start, destination);
                levelLimit++;
            } while (!map.ContainsKey(destination));
            return this.BacktrackMap(map, start, destination);
        }
    }
}
