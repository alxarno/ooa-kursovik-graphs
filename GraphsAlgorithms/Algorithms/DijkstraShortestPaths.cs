using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphsAlgorithms.Interfaces;

namespace GraphsAlgorithms.Algorithms
{
    class GraphPointInfo
    {
        /// Вершина
        public string Point { get; set; }

        /// Не посещенная вершина
        public bool IsUnvisited { get; set; }

        /// Сумма весов ребер
        public long LinksWeightSum { get; set; }

        /// Предыдущая вершина
        public string PreviousPoint { get; set; }

        /// Конструктор
        public GraphPointInfo(string vertex)
        {
            Point = vertex;
            IsUnvisited = true;
            LinksWeightSum = long.MaxValue;
            PreviousPoint = null;
        }
    }
    public class DijkstraShortestPaths
    {
        IGraph graph;

        List<GraphPointInfo> infos;

        List<string> logs;

        public DijkstraShortestPaths(IGraph graph)
        {
            this.graph = graph;
        }

        /// Инициализация информации
       void InitInfo()
        {
            logs = new List<string>();
            infos = new List<GraphPointInfo>();
            foreach (var v in graph.Points)
            {
                infos.Add(new GraphPointInfo(v));
            }
        }

        /// Получение информации о вершине графа
        GraphPointInfo GetPointInfo(string v)
        {
            logs.Add("Получение информации о вершинах графа");
            foreach (var i in infos)
            {
                if (i.Point.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }

        /// Поиск непосещенной вершины с минимальным значением суммы
        private GraphPointInfo FindUnvisitedPointWithMinSum()
        {
            long minValue = long.MaxValue;
            GraphPointInfo minPointInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.LinksWeightSum < minValue)
                {
                    minPointInfo = i;
                    minValue = i.LinksWeightSum;
                }
            }
            if(minPointInfo != null)
                logs.Add(string.Format("Найдена непосещенная вершина {0} с минимальной суммой {1}", minPointInfo.Point, minPointInfo.LinksWeightSum));

            return minPointInfo;
        }

        /// Поиск кратчайшего пути по вершинам
        public (List<string>, List<string>) FindShortestPath(string startPoint, string finishPoint)
        {
            InitInfo();
            var first = GetPointInfo(startPoint);
            first.LinksWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedPointWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextPoint(current);
            }

            return GetPath(startPoint, finishPoint);
        }

        /// Вычисление суммы весов ребер для следующей вершины
        void SetSumToNextPoint(GraphPointInfo info)
        {
            info.IsUnvisited = false;
            logs.Add(string.Format("Получение суммы весов ребер вершины {0}, для следующей веришны", info.Point));
            foreach (var e in graph.OutgoingLinks(info.Point))
            {
                var nextInfo = GetPointInfo(e.Destination);
                var sum = info.LinksWeightSum + (graph.IsWeighted ? e.Weight : 1);
                logs.Add(string.Format("Сумма весов до вершины {0} = {1}", e.Destination, sum));
                if (sum < nextInfo.LinksWeightSum)
                {
                    nextInfo.LinksWeightSum = sum;
                    nextInfo.PreviousPoint = info.Point;
                }
            }
        }

        /// Формирование пути
        (List<string>, List<string>) GetPath(string startPoint, string endPoint)
        {
            var path = new List<string> { endPoint };
            logs.Add(string.Format("Формирование пути от {0} до {1}", startPoint, endPoint));
            while (startPoint != endPoint)
            {
                endPoint = GetPointInfo(endPoint).PreviousPoint;
                if (endPoint == null) return (null, logs);
                path.Add(endPoint);
            }
            path.Reverse();

            return (path, logs);
        }
    }
}
