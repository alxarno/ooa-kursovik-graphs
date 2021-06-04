using System;
using System.Collections.Generic;
using System.Text;
using GraphsAlgorithms.Interfaces;
using GraphsAlgorithms.Utils;

namespace GraphsAlgorithms.Data
{
    public class WeightedGraph : IGraph
    {
        private const long EMPTY_LINK_VALUE = 0;
        protected virtual int _linksCount { get; set; }
        protected virtual string _firstInsertedNode { get; set; }
        protected virtual Dictionary<string, LinkedList<WeightedLink>> _adjacencyList { get; set; }


        public WeightedGraph() : this(10) { }

        public WeightedGraph(uint initialCapacity)
        {
            _linksCount = 0;
            _adjacencyList = new Dictionary<string, LinkedList<WeightedLink>>((int)initialCapacity);
        }


        protected virtual WeightedLink _tryGetLink(string source, string destination)
        {
            WeightedLink link = null;

            // Predicate
            var sourceToDestinationPredicate = new Predicate<WeightedLink>((item) => item.Source == source && item.Destination == destination);

            // Try to find a match
            if (_adjacencyList.ContainsKey(source))
                _adjacencyList[source].TryFindFirst(sourceToDestinationPredicate, out link);

            // Return!
            // Might return a null object.
            return link;
        }

        protected virtual bool _doesEdgeExist(string source, string destination)
        {
            return _tryGetLink(source, destination) != null;
        }

        private long _getLinkWeight(string source, string destination)
        {
            return _tryGetLink(source, destination).Weight;
        }


        public virtual bool IsDirected
        {
            get { return false; }
        }

        public virtual bool IsWeighted
        {
            get { return true; }
        }

        public int LinksCount
        {
            get { return _linksCount; }
        }

        public int PointsCount
        {
            get { return _adjacencyList.Count; }
        }

        public IEnumerable<string> Points
        {
            get
            {
                foreach (var point in _adjacencyList)
                    yield return point.Key;
            }
        }


        IEnumerable<ILink> IGraph.Links
        {
            get { return this.Links; }
        }

        IEnumerable<ILink> IGraph.IncomingLinks(string point)
        {
            return this.IncomingLinks(point);
        }

        IEnumerable<ILink> IGraph.OutgoingLinks(string point)
        {
            return this.OutgoingLinks(point);
        }

        public virtual IEnumerable<WeightedLink> Links
        {
            get
            {
                foreach (var point in _adjacencyList)
                    foreach (var link in point.Value)
                        yield return link;
            }
        }

        public virtual IEnumerable<WeightedLink> IncomingLinks(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException("Point doesn't belong to graph.");

            var predicate = new Predicate<WeightedLink>((link) => link.Destination == point);

            foreach (var adjacent in _adjacencyList.Keys)
            {
                WeightedLink incomingLink = null;

                if (_adjacencyList[adjacent].TryFindFirst(predicate, out incomingLink))
                    yield return incomingLink;
            }//end-foreach
        }

        public virtual IEnumerable<WeightedLink> OutgoingLinks(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            foreach (var link in _adjacencyList[point])
                yield return link;
        }

        [Obsolete("Use the AddEdge method with the weight parameter.")]
        public bool AddLink(string source, string destination)
        {
            throw new NotImplementedException();
        }

        public bool AddLink(string source, string destination, long weight)
        {
            // Check existence of nodes, the validity of the weight value, and the non-existence of edge
            // Check existence of nodes, the validity of the weight value, and the non-existence of edge
            if (weight == EMPTY_LINK_VALUE)
                return false;
            if (!HasPoint(source) || !HasPoint(destination))
                return false;
            if (_doesEdgeExist(source, destination))
                return false;

            // Add edge from source to destination
            var link = new WeightedLink(source, destination, weight);
            _adjacencyList[source].AddLast(link);

            // Increment edges count
            ++_linksCount;

            return true;
        }

        public virtual bool RemoveLink(string source, string destination)
        {
            // Check existence of nodes and non-existence of edge
            if (!HasPoint(source) || !HasPoint(destination))
                return false;

            // Try get edge
            var link = _tryGetLink(source, destination);

            // Return false if edge doesn't exists
            if (link == null)
                return false;

            // Remove edge from source to destination
            _adjacencyList[source].Remove(link);

            // Decrement the edges count
            --_linksCount;

            return true;
        }

        public bool UpdateLinkWeight(string source, string destination, long weight)
        {
            // Check existence of vertices and validity of the weight value
            if (weight == EMPTY_LINK_VALUE)
                return false;
            if (!HasPoint(source) || !HasPoint(destination))
                return false;

            foreach (var link in _adjacencyList[source])
            {
                if (link.Destination == destination)
                {
                    link.Weight = weight;
                    return true;
                }
            }

            return false;
        }

        public virtual WeightedLink GetLink(string source, string destination)
        {
            if (!HasPoint(source) || !HasPoint(destination))
                throw new KeyNotFoundException("Either one of the vertices or both of them don't exist.");

            var link = _tryGetLink(source, destination);

            // Check the existence of edge
            if (link == null)
                throw new Exception("Edge doesn't exist.");

            // Try get edge
            return link;
        }

        public virtual long GetLinkWeight(string source, string destination)
        {
            return GetLink(source, destination).Weight;
        }

        public virtual void AddPoints(IList<string> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            foreach (var point in collection)
                AddPoint(point);
        }

        public virtual bool AddPoint(string point)
        {
            if (_adjacencyList.ContainsKey(point))
                return false;

            if (_adjacencyList.Count == 0)
                _firstInsertedNode = point;

            _adjacencyList.Add(point, new LinkedList<WeightedLink>());

            return true;
        }

        public virtual bool RemovePoint(string point)
        {
            // Check existence of vertex
            if (!_adjacencyList.ContainsKey(point))
                return false;

            // Subtract the number of edges for this vertex from the total edges count
            _linksCount = _linksCount - _adjacencyList[point].Count;

            // Remove vertex from graph
            _adjacencyList.Remove(point);

            // Remove destination edges to this vertex
            foreach (var adjacent in _adjacencyList)
            {
                var link = _tryGetLink(adjacent.Key, point);

                if (link != null)
                {
                    adjacent.Value.Remove(link);

                    // Decrement the edges count.
                    --_linksCount;
                }
            }

            return true;
        }

        public virtual bool HasLink(string source, string destination)
        {
            return (_adjacencyList.ContainsKey(source) && _adjacencyList.ContainsKey(destination) && _doesEdgeExist(source, destination));
        }

        public virtual bool HasPoint(string point)
        {
            return _adjacencyList.ContainsKey(point);
        }

        public virtual LinkedList<string> Neighbours(string point)
        {
            if (!HasPoint(point))
                return null;

            var neighbors = new LinkedList<string>();
            var adjacents = _adjacencyList[point];

            foreach (var adjacent in adjacents)
                neighbors.AddLast(adjacent.Destination);

            return neighbors;
        }

        public Dictionary<string, long> NeighboursMap(string point)
        {
            if (!HasPoint(point))
                return null;

            var neighbors = _adjacencyList[point];
            var map = new Dictionary<string, long>(neighbors.Count);

            foreach (var adjacent in neighbors)
                map.Add(adjacent.Destination, adjacent.Weight);

            return map;
        }

        public virtual int Degree(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException();

            return _adjacencyList[point].Count;
        }

        public virtual string ToReadable()
        {
            string output = string.Empty;

            foreach (var node in _adjacencyList)
            {
                var adjacents = string.Empty;

                output = String.Format("{0}\r\n{1}: [", output, node.Key);

                foreach (var adjacentNode in node.Value)
                    adjacents = String.Format("{0}{1}({2}), ", adjacents, adjacentNode.Destination, adjacentNode.Weight);

                if (adjacents.Length > 0)
                    adjacents = adjacents.TrimEnd(new char[] { ',', ' ' });

                output = String.Format("{0}{1}]", output, adjacents);
            }

            return output;
        }

        public virtual void Clear()
        {
            _linksCount = 0;
            _adjacencyList.Clear();
        }
    }
}
