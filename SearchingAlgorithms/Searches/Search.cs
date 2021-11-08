using System.Collections.Generic;

namespace Searches {
    abstract class Search<T> {

        /// <summary>
        /// Retrieves the best path from the start to the destination according to the specific uninformed search.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public virtual List<Node<T>> GetPath(Node<T> start, Node<T> destination) {
            Dictionary<Node<T>, Node<T>> reached = this.BuildTraversalMap(start, destination);
            return this.BacktrackMap(reached, start, destination);
        }

        /// <summary>
        /// Traverses a graph from the start until it reaches a specific destination.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        abstract protected Dictionary<Node<T>, Node<T>> BuildTraversalMap(Node<T> start, Node<T> destination);

        /// <summary>
        /// Backtracks through a traversal map to determine the best path according the uniform-cost search.
        /// </summary>
        /// <param name="traversalMap">A map that contains nodes and the best parent node that was used to reach it.</param>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        protected List<Node<T>> BacktrackMap(Dictionary<Node<T>, Node<T>> traversalMap, Node<T> start, Node<T> destination) {
            List<Node<T>> path = new();

            // Condition 1: Destination cannot be reached.
            if (!traversalMap.ContainsKey(destination)) {
                return path;
            }

            // Condition 2: Backtrack till we reach the start from the destination.
            path.Add(destination);
            Node<T> temp = destination;
            while (temp != start) {
                path.Insert(0, traversalMap[temp]);
                temp = traversalMap[temp];
            }
            return path;
        }

    }
}
