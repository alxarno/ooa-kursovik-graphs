using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using GraphsAlgorithms.Interfaces;
using GraphsAlgorithms.Utils;

namespace GraphsAlgorithms.Data
{
    public class UndirectedGraph : IGraph
    {
        protected const string EMPTY_POINT_SLOT = "";

        protected virtual int _linksCount { get; set; }
        protected virtual int _pointsCount { get; set; }
        protected virtual int _pointsCapacity { get; set; }
        protected virtual string[] _points { get; set; }
        protected virtual string _firstInsertedNode { get; set; }
        protected virtual bool[,] _adjacencyMatrix { get; set; }

        public UndirectedGraph(uint capacity = 10)
        {
            _linksCount = 0;
            _pointsCount = 0;
            _pointsCapacity = (int)capacity;

            _points = new string[capacity];
            _adjacencyMatrix = new bool[_pointsCapacity, _pointsCapacity];
            _adjacencyMatrix.Populate(rows: _pointsCapacity, columns: _pointsCapacity, defaultValue: false);
        }

        protected virtual bool _doesLinkExist(int index1, int index2)
        {
            return (_adjacencyMatrix[index1, index2] || _adjacencyMatrix[index2, index1]);
        }

        protected virtual bool _doesPointExist(string point)
        {
            var i = Array.IndexOf(_points, point);
            if (i >= 0) return true;
            return false;
        }

        public virtual bool IsDirected
        {
            get { return false; }
        }

        public virtual bool IsWeighted
        {
            get { return false; }
        }

        public virtual int PointsCount
        {
            get { return _pointsCount; }
        }

        public virtual int LinksCount
        {
            get { return _linksCount; }
        }

        public virtual IEnumerable<string> Points
        {
            get
            {
                foreach (var item in _points)
                    if (item != null)
                        yield return (string)item;
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

        public virtual IEnumerable<UnweightedLink> Links
        {
            get
            {
                var seen = new HashSet<KeyValuePair<string, string>>();

                foreach (var point in _points)
                {
                    int source = Array.IndexOf(_points, point);

                    for (int adjacent = 0; adjacent < _points.Length; ++adjacent)
                    {
                        if (_points[adjacent] != null && _doesLinkExist(source, adjacent))
                        {
                            var neighbor = (string)_points[adjacent];

                            var outgoingLink = new KeyValuePair<string, string>((string)point, neighbor);
                            var incomingLink = new KeyValuePair<string, string>(neighbor, (string)point);

                            if (seen.Contains(incomingLink) || seen.Contains(outgoingLink))
                                continue;
                            seen.Add(outgoingLink);

                            yield return new UnweightedLink(outgoingLink.Key, outgoingLink.Value);
                        }
                    }
                }
            }
        }

        public IEnumerable<UnweightedLink> IncomingLinks(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            int source = Array.IndexOf(_points, point);

            for (int adjacent = 0; adjacent < _points.Length; ++adjacent)
            {
                if (_points[adjacent] != null && _doesLinkExist(source, adjacent))
                {
                    yield return (new UnweightedLink(
                        (string)_points[adjacent], // from
                        point                  // to
                    ));
                }
            }//end-for
        }

        public IEnumerable<UnweightedLink> OutgoingLinks(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            int source = Array.IndexOf(_points, point);

            for (int adjacent = 0; adjacent < _points.Length; ++adjacent)
            {
                if (_points[adjacent] != null && _doesLinkExist(source, adjacent))
                {
                    yield return (new UnweightedLink(
                        point,                 // from
                        (string)_points[adjacent]  // to
                    ));
                }
            }//end-for
        }

        [Obsolete("Use the AddLink method without the weight parameter.")]
        public virtual bool AddLink(string source, string destination, long weight)
        {
            throw new NotImplementedException();
        }
        public virtual bool AddLink(string firstPoint, string secondPoint)
        {
            int indexOfFirst = Array.IndexOf(_points, firstPoint);
            int indexOfSecond = Array.IndexOf(_points, secondPoint);

            if (indexOfFirst == -1 || indexOfSecond == -1)
                return false;
            if (_doesLinkExist(indexOfFirst, indexOfSecond))
                return false;

            _adjacencyMatrix[indexOfFirst, indexOfSecond] = true;
            _adjacencyMatrix[indexOfSecond, indexOfFirst] = true;

            ++_linksCount;

            return true;
        }

        public virtual bool RemoveLink(string firstPoint, string secondPoint)
        {
            int indexOfFirst = Array.IndexOf(_points, firstPoint);
            int indexOfSecond = Array.IndexOf(_points, secondPoint);

            if (indexOfFirst == -1 || indexOfSecond == -1)
                return false;
            if (!_doesLinkExist(indexOfFirst, indexOfSecond))
                return false;

            _adjacencyMatrix[indexOfFirst, indexOfSecond] = false;
            _adjacencyMatrix[indexOfSecond, indexOfFirst] = false;

            --_linksCount;

            return true;
        }

        public virtual void AddPoints(IList<string> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            foreach (var item in collection)
                this.AddPoint(item);
        }

        public virtual bool AddPoint(string point)
        {
            // Return if graph reached it's maximum capacity
            if (_pointsCount >= _pointsCapacity)
                return false;

            // Return if vertex exists
            if (_doesPointExist(point))
                return false;

            // Initialize first inserted node
            if (_pointsCount == 0)
                _firstInsertedNode = point;

            // stringry inserting vertex at previously lazy-deleted slot
            int indexOfDeleted = Array.IndexOf(_points, EMPTY_POINT_SLOT);

            if (indexOfDeleted != -1)
                _points[indexOfDeleted] = point;
            else
                _points[_pointsCount] = point;

            // Increment the vertices count
            ++_pointsCount;

            return true;
        }

        public virtual bool RemovePoint(string point)
        {
            // Return if graph is empty
            if (_pointsCount == 0)
                return false;

            // Get index of vertex
            int index = Array.IndexOf(_points, point);

            // Return if vertex doesn't exists
            if (index == -1)
                return false;

            // Lazy-delete the vertex from graph
            //_points.Remove (vertex);
            _points[index] = EMPTY_POINT_SLOT;

            // Decrement the vertices count
            --_pointsCount;

            // Delete the links
            for (int i = 0; i < _pointsCapacity; ++i)
            {
                if (_doesLinkExist(index, i))
                {
                    _adjacencyMatrix[index, i] = false;
                    _adjacencyMatrix[i, index] = false;

                    // Decrement the links count
                    --_linksCount;
                }
            }

            return true;
        }

        public virtual bool HasLink(string firstPoint, string secondPoint)
        {
            int indexOfFirst = Array.IndexOf(_points, firstPoint);
            int indexOfSecond = Array.IndexOf(_points, secondPoint);

            // Check the existence of vertices and the directed edge
            return (indexOfFirst != -1 && indexOfSecond != -1 && _doesLinkExist(indexOfFirst, indexOfSecond) == true);
        }

        public virtual bool HasPoint(string point)
        {
            var i = Array.IndexOf(_points, point);
            if (i >= 0) return true;
            return false;
        }

        public virtual LinkedList<string> Neighbours(string point)
        {
            var neighbours = new LinkedList<string>();
            int source = Array.IndexOf(_points, point);

            if (source != -1)
                for (int adjacent = 0; adjacent < _points.Length; ++adjacent)
                    if (_points[adjacent] != null && _doesLinkExist(source, adjacent))
                        neighbours.AddLast(_points[adjacent]);

            return neighbours;
        }

        public virtual int Degree(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException();

            return Neighbours(point).Count;
        }

        public virtual string ToReadable()
        {
            string output = string.Empty;

            for (int i = 0; i < _points.Length; ++i)
            {
                if (_points[i] == null)
                    continue;

                var node = _points[i];
                var adjacents = string.Empty;

                output = String.Format("{0}\r\n{1}: [", output, node);

                foreach (var adjacentNode in Neighbours(node))
                    adjacents = String.Format("{0}{1},", adjacents, adjacentNode);

                if (adjacents.Length > 0)
                    adjacents = adjacents.TrimEnd(new char[] { ',', ' ' });

                output = String.Format("{0}{1}]", output, adjacents);
            }

            return output;
        }

        public virtual void Clear()
        {
            _linksCount = 0;
            _pointsCount = 0;
            _adjacencyMatrix = new bool[_pointsCapacity, _pointsCapacity];
            _adjacencyMatrix.Populate(rows: _pointsCapacity, columns: _pointsCapacity, defaultValue: false);
        }
    }
}
