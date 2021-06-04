using System;
using System.Collections.Generic;
using System.Text;
using GraphsAlgorithms.Interfaces;

namespace GraphsAlgorithms.Data
{
    public class DirectedGraph : IGraph
    {
        protected virtual int _linksCount { get; set; }
        protected virtual string _firstInsertedNode { get; set; }
        protected virtual Dictionary<string, LinkedList<string>> _adjacencyList { get; set; }

        public DirectedGraph() : this(10) { }

        public DirectedGraph(uint initialCapacity)
        {
            _linksCount = 0;
            _adjacencyList = new Dictionary<string, LinkedList<string>>((int)initialCapacity);
        }


        /// Проверка на присутствии ребра в графе
        protected virtual bool _doesLinkExist(string point1, string point2)
        {
            return (_adjacencyList[point1].Contains(point2));
        }

        public virtual bool IsDirected
        {
            get { return true; }
        }

        public virtual bool IsWeighted
        {
            get { return false; }
        }

        public virtual int PointsCount
        {
            get { return _adjacencyList.Count; }
        }

        public virtual int LinksCount
        {
            get { return _linksCount; }
        }

        public virtual IEnumerable<string> Points
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

        public virtual IEnumerable<UnweightedLink> Links
        {
            get
            {
                foreach (var point in _adjacencyList)
                    foreach (var adjacent in point.Value)
                        yield return (new UnweightedLink(
                            point.Key,   // from
                            adjacent      // to
                        ));
            }
        }

        IEnumerable<ILink> IGraph.IncomingLinks(string point)
        {
            return this.IncomingLinks(point);
        }

        IEnumerable<ILink> IGraph.OutgoingLinks(string point)
        {
            return this.OutgoingLinks(point);
        }

        /// Получить все входящие направленые не взвешенные ребра в вершину
        public virtual IEnumerable<UnweightedLink> IncomingLinks(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException("point doesn't belong to graph.");

            foreach (var adjacent in _adjacencyList.Keys)
            {
                if (_adjacencyList[adjacent].Contains(point))
                    yield return (new UnweightedLink(
                        adjacent,   // from
                        point      // to
                    ));
            }//end-foreach
        }

        /// Получить все исходящие направленые не взвешенные ребра из вершины
        public virtual IEnumerable<UnweightedLink> OutgoingLinks(string point)
        {
            if (!HasPoint(point))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            foreach (var adjacent in _adjacencyList[point])
                yield return (new UnweightedLink(
                    point,     // from
                    adjacent    // to
                ));
        }

        [Obsolete("Use the AddLink method without the weight parameter.")]
        public virtual bool AddLink(string source, string destination, long weight)
        {
            throw new NotImplementedException();
        }

        /// Добавить ребро между двумя веришнами
        public virtual bool AddLink(string source, string destination)
        {
            if (!HasPoint(source) || !HasPoint(destination))
                return false;
            if (_doesLinkExist(source, destination))
                return false;

            _adjacencyList[source].AddLast(destination);

            ++_linksCount;

            return true;
        }

        /// Удалить ребро
        public virtual bool RemoveLink(string source, string destination)
        {
            if (!HasPoint(source) || !HasPoint(destination))
                return false;
            if (!_doesLinkExist(source, destination))
                return false;

            _adjacencyList[source].Remove(destination);

            --_linksCount;

            return true;
        }

        /// Добавить коллекцию вершин в граф
        public virtual void AddPoints(IList<string> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            foreach (var point in collection)
                AddPoint(point);
        }

        /// Добавить вершину в граф
        public virtual bool AddPoint(string point)
        {
            if (HasPoint(point))
                return false;

            if (_adjacencyList.Count == 0)
                _firstInsertedNode = point;

            _adjacencyList.Add(point, new LinkedList<string>());

            return true;
        }

        /// Удалить вершину из графа
        public virtual bool RemovePoint(string point)
        {
            if (!HasPoint(point))
                return false;


            _linksCount = _linksCount - _adjacencyList[point].Count;

            _adjacencyList.Remove(point);

            foreach (var adjacent in _adjacencyList)
            {
                if (adjacent.Value.Contains(point))
                {
                    adjacent.Value.Remove(point);

                    --_linksCount;
                }
            }

            return true;
        }

        public virtual bool HasLink(string source, string destination)
        {
            return (_adjacencyList.ContainsKey(source) && _adjacencyList.ContainsKey(destination) && _doesLinkExist(source, destination));
        }

        public virtual bool HasPoint(string point)
        {
            return _adjacencyList.ContainsKey(point);
        }

        /// Получить двух-связныый список соседей вершины
        public virtual LinkedList<string> Neighbours(string point)
        {
            if (!HasPoint(point))
                return null;

            return _adjacencyList[point];
        }

        /// Вернуть количество ребер вершины
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
            _adjacencyList.Clear();
        }
    }
}
