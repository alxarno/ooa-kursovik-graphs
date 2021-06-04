using System;
using System.Collections.Generic;
using System.Text;
using GraphsAlgorithms.Interfaces;

namespace GraphsAlgorithms.Algorithms
{
    public class CyclesDetector
    {
        /// Вспомогательная функция, используемая для определения того, содержит ли граф, исследуемый из определенной вершины, цикл.
        private static bool _isUndirectedCyclic(IGraph graph, string source, string parent, ref HashSet<string> visited, ref List<string> logs)
        {
            if (!visited.Contains(source))
            {
                // Отечаем что вершина была посищена
                visited.Add(source);
                logs.Add(string.Format("Посищена вершина {0}", source));

                logs.Add("Получение соседних веришн");
                // Обходим все соседние вершины
                foreach (var adjacent in graph.Neighbours(source))
                {
                    // Если соседняя вершина ещё не была посищена, проверяем что у соседней вершины не будет циклов
                    if (!visited.Contains(adjacent) && _isUndirectedCyclic(graph, adjacent, source, ref visited, ref logs)) {
                        logs.Add(string.Format("Вершина {0} не была посищена и имеет циклы дальше", adjacent));
                        return true;
                    }

                    // Если соседняя вершина была посещена и не является предыдущей 
                    if (parent != (object)null && adjacent != parent) {
                        logs.Add(string.Format("Вершина {0} уже была посищена и не является предыдущей {1}", adjacent, parent));
                        return true;
                    }
                        
                }
            }
            logs.Add(string.Format("Вершина уже была посищена {0}", source));
            return false;
        }

        /// Вспомогательная функция, используемая для определения того, содержит ли граф, исследуемый из определенной вершины, цикл.
        private static bool _isDirectedCyclic(IGraph graph, string source, ref HashSet<string> visited, ref HashSet<string> recursionStack, ref List<string> logs)
        {
            if (!visited.Contains(source))
            {
                logs.Add(string.Format("Посищена вершина {0}", source));
                // Отмчечаем что вершина уже была посищена и добавляем в стэк
                visited.Add(source);
                recursionStack.Add(source);

                logs.Add("Получение соседних веришн");

                foreach (var adjacent in graph.Neighbours(source))
                {
                    if (!visited.Contains(adjacent) && _isDirectedCyclic(graph, adjacent, ref visited, ref recursionStack, ref logs)) {
                        logs.Add(string.Format("Вершина {0} не была посищена и имеет циклы дальше", adjacent));
                        return true;
                    }

                    // Если соседняя вершина была посищена и не находится в стэке
                    if (recursionStack.Contains(adjacent))
                    {
                        logs.Add(string.Format("Вершина {0} уже была посищена и находится в стеке", adjacent));
                        return true;
                    }
                }
            }

            // Удаляем текущую вершину из стэка
            recursionStack.Remove(source);
            logs.Add(string.Format("Вершина {0} уже была посищена", source));
            return false;
        }


        /// Возвращает true, если граф имеет цикл.
        public static (bool, List<string>) IsCyclic(IGraph Graph)
        {
            var logs = new List<string>();
            if (Graph == null)
                throw new ArgumentNullException();

            var visited = new HashSet<string>();
            var recursionStack = new HashSet<string>();

            if (Graph.IsDirected)
            {
                logs.Add("Граф является направленым");
                foreach (var point in Graph.Points)
                    if (_isDirectedCyclic(Graph, point, ref visited, ref recursionStack, ref logs))
                        return (true, logs);
            }
            else
            {
                logs.Add("Граф является ненаправленым");
                foreach (var point in Graph.Points)
                    if (_isUndirectedCyclic(Graph, point, null, ref visited, ref logs))
                        return (true, logs);
            }

            return (false, logs);
        }
    }
}
