using System;
using System.Collections.Generic;
using System.Text;
using GraphsAlgorithms.Interfaces;

namespace GraphsAlgorithms.Algorithms
{
    public class BreadthFirstSearcher
    {
        public static List<string> PrintAll(IGraph Graph, string startPoint)
        {
            var logs = new List<string> { };
            // Проверяем что граф не пустой
            if (Graph.PointsCount == 0)
                throw new Exception("Граф пуст!");

            // Проверяем стартовую вершину
            if (!Graph.HasPoint(startPoint))
                throw new Exception("Стартовая вершина не принадлежит графу.");

            var visited = new HashSet<string>();
            var queue = new Queue<string>(Graph.PointsCount);

            queue.Enqueue(startPoint);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                logs.Add(String.Format("Посищена веришна {0}", current));
                logs.Add("Получение ближайших вершин");
                foreach (var adjacent in Graph.Neighbours(current))
                {
                    if (!visited.Contains(adjacent))
                    {
                        logs.Add(String.Format("Посищена веришна {0} из вершины {1}", adjacent, current));
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                    }
                }
            }
            return logs;
        }

        /// <summary>
        /// Обходит все узлы графа, начиная с определенного узла, применяя переданное действие к каждому узлу.
        /// </summary>
        public static void VisitAll(ref IGraph Graph, string startPoint, Action<string> Action)
        {
            if (Graph.PointsCount == 0)
                throw new Exception("Graph is empty!");

            if (!Graph.HasPoint(startPoint))
                throw new Exception("Starting point doesn't belong to graph.");

            int level = 0;													
            var frontiers = new List<string>();									// keeps track of previous levels, i - 1
            var levels = new Dictionary<string, int>(Graph.PointsCount);		// keeps track of visited nodes and their distances
            var parents = new Dictionary<string, object>(Graph.PointsCount);	// keeps track of tree-nodes

            frontiers.Add(startPoint);
            levels.Add(startPoint, 0);
            parents.Add(startPoint, null);

            Action(startPoint);

            // TRAVERSE GRAPH
            while (frontiers.Count > 0)
            {
                var next = new List<string>();									// keeps track of the current level, i

                foreach (var node in frontiers)
                {
                    foreach (var adjacent in Graph.Neighbours(node))
                    {
                        if (!levels.ContainsKey(adjacent)) 				// not visited yet
                        {
                            // BFS VISIT NODE STEP
                            Action(adjacent);

                            levels.Add(adjacent, level);					// level[node] + 1
                            parents.Add(adjacent, node);
                            next.Add(adjacent);
                        }
                    }
                }

                frontiers = next;
                level = level + 1;
            }
        }

        /// <summary>
        /// Учитывая предикатную функцию и начальный узел, эта функция ищет в узлах графа первое совпадение.
        /// </summary>
        public static string FindFirstMatch(IGraph Graph, string startPoint, Predicate<string> Match)
        {
            // Check if graph is empty
            if (Graph.PointsCount == 0)
                throw new Exception("Graph is empty!");

            // Check if graph has the starting vertex
            if (!Graph.HasPoint(startPoint))
                throw new Exception("Starting vertex doesn't belong to graph.");

            int level = 0;													    // keeps track of levels
            var frontiers = new List<string>();									// keeps track of previous levels, i - 1
            var levels = new Dictionary<string, int>(Graph.PointsCount);		// keeps track of visited nodes and their distances
            var parents = new Dictionary<string, object>(Graph.PointsCount);	// keeps track of tree-nodes

            frontiers.Add(startPoint);
            levels.Add(startPoint, 0);
            parents.Add(startPoint, null);

            // BFS VISIT CURRENT NODE
            if (Match(startPoint))
                return startPoint;

            // TRAVERSE GRAPH
            while (frontiers.Count > 0)
            {
                var next = new List<string>();									// keeps track of the current level, i

                foreach (var node in frontiers)
                {
                    foreach (var adjacent in Graph.Neighbours(node))
                    {
                        if (!levels.ContainsKey(adjacent)) 				// not visited yet
                        {
                            // BFS VISIT NODE STEP
                            if (Match(adjacent))
                                return adjacent;

                            levels.Add(adjacent, level);					// level[node] + 1
                            parents.Add(adjacent, node);
                            next.Add(adjacent);
                        }
                    }
                }

                frontiers = next;
                level = level + 1;
            }

            throw new Exception("Item was not found!");
        }
    }
}
