using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GraphAlgorithmsTests
{
    [TestClass]
    public class UnitTestGraphs
    {
        [TestMethod]
        public void TestUndirectedGraph()
        {
            GraphsAlgorithms.Interfaces.IGraph graph = new GraphsAlgorithms.Data.UndirectedGraph(10);
            var verticesSet1 = new[] { "a", "z", "s", "x", "d", "c", "f", "v" };

            graph.AddPoints(verticesSet1);

            graph.AddLink("a", "s");
            graph.AddLink("a", "z");
            graph.AddLink("s", "x");
            graph.AddLink("x", "d");
            graph.AddLink("x", "c");
            graph.AddLink("d", "f");
            graph.AddLink("d", "c");
            graph.AddLink("c", "f");
            graph.AddLink("c", "v");
            graph.AddLink("v", "f");

            var allEdges = graph.Links.ToList();

            Assert.IsTrue(graph.PointsCount == 8, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 10, "Wrong edges count.");
            Assert.IsTrue(graph.LinksCount == allEdges.Count, "Wrong edges count.");

            Assert.IsTrue(graph.OutgoingLinks("a").ToList().Count == 2, "Wrong outgoing edges from 'a'.");
            Assert.IsTrue(graph.OutgoingLinks("s").ToList().Count == 2, "Wrong outgoing edges from 's'.");
            Assert.IsTrue(graph.OutgoingLinks("x").ToList().Count == 3, "Wrong outgoing edges from 'x'.");
            Assert.IsTrue(graph.OutgoingLinks("d").ToList().Count == 3, "Wrong outgoing edges from 'd'.");
            Assert.IsTrue(graph.OutgoingLinks("c").ToList().Count == 4, "Wrong outgoing edges from 'c'.");
            Assert.IsTrue(graph.OutgoingLinks("v").ToList().Count == 2, "Wrong outgoing edges from 'v'.");
            Assert.IsTrue(graph.OutgoingLinks("f").ToList().Count == 3, "Wrong outgoing edges from 'f'.");
            Assert.IsTrue(graph.OutgoingLinks("z").ToList().Count == 1, "Wrong outgoing edges from 'z'.");

            Assert.IsTrue(graph.IncomingLinks("a").ToList().Count == 2, "Wrong incoming edges from 'a'.");
            Assert.IsTrue(graph.IncomingLinks("s").ToList().Count == 2, "Wrong incoming edges from 's'.");
            Assert.IsTrue(graph.IncomingLinks("x").ToList().Count == 3, "Wrong incoming edges from 'x'.");
            Assert.IsTrue(graph.IncomingLinks("d").ToList().Count == 3, "Wrong incoming edges from 'd'.");
            Assert.IsTrue(graph.IncomingLinks("c").ToList().Count == 4, "Wrong incoming edges from 'c'.");
            Assert.IsTrue(graph.IncomingLinks("v").ToList().Count == 2, "Wrong incoming edges from 'v'.");
            Assert.IsTrue(graph.IncomingLinks("f").ToList().Count == 3, "Wrong incoming edges from 'f'.");
            Assert.IsTrue(graph.IncomingLinks("z").ToList().Count == 1, "Wrong incoming edges from 'z'.");

            graph.RemoveLink("d", "c");
            graph.RemoveLink("c", "v");
            graph.RemoveLink("a", "z");
            Assert.IsTrue(graph.PointsCount == 8, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 7, "Wrong edges count.");


            graph.RemovePoint("x");
            Assert.IsTrue(graph.PointsCount == 7, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 4, "Wrong edges count.");
        }

        [TestMethod]
        public void TestDirectedGraph()
        {
            GraphsAlgorithms.Interfaces.IGraph graph = new GraphsAlgorithms.Data.DirectedGraph(10);
            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v" };

            graph.AddPoints(verticesSet1);

            graph.AddLink("a", "s");
            graph.AddLink("a", "z");
            graph.AddLink("s", "x");
            graph.AddLink("x", "d");
            graph.AddLink("x", "c");
            graph.AddLink("x", "a");
            graph.AddLink("d", "f");
            graph.AddLink("d", "c");
            graph.AddLink("d", "s");
            graph.AddLink("c", "f");
            graph.AddLink("c", "v");
            graph.AddLink("c", "d");
            graph.AddLink("v", "f");
            graph.AddLink("f", "c");

            var allEdges = graph.Links.ToList();

            Assert.IsTrue(graph.PointsCount == 8, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 14, "Wrong edges count.");
            Assert.IsTrue(graph.LinksCount == allEdges.Count, "Wrong edges count.");

            Assert.IsTrue(graph.OutgoingLinks("a").ToList().Count == 2, "Wrong outgoing edges from 'a'.");
            Assert.IsTrue(graph.OutgoingLinks("s").ToList().Count == 1, "Wrong outgoing edges from 's'.");
            Assert.IsTrue(graph.OutgoingLinks("d").ToList().Count == 3, "Wrong outgoing edges from 'd'.");
            Assert.IsTrue(graph.OutgoingLinks("x").ToList().Count == 3, "Wrong outgoing edges from 'x'.");
            Assert.IsTrue(graph.OutgoingLinks("c").ToList().Count == 3, "Wrong outgoing edges from 'c'.");
            Assert.IsTrue(graph.OutgoingLinks("v").ToList().Count == 1, "Wrong outgoing edges from 'v'.");
            Assert.IsTrue(graph.OutgoingLinks("f").ToList().Count == 1, "Wrong outgoing edges from 'f'.");
            Assert.IsTrue(graph.OutgoingLinks("z").ToList().Count == 0, "Wrong outgoing edges from 'z'.");

            Assert.IsTrue(graph.IncomingLinks("a").ToList().Count == 1, "Wrong incoming edges from 'a'.");
            Assert.IsTrue(graph.IncomingLinks("s").ToList().Count == 2, "Wrong incoming edges from 's'.");
            Assert.IsTrue(graph.IncomingLinks("d").ToList().Count == 2, "Wrong incoming edges from 'd'.");
            Assert.IsTrue(graph.IncomingLinks("x").ToList().Count == 1, "Wrong incoming edges from 'x'.");
            Assert.IsTrue(graph.IncomingLinks("c").ToList().Count == 3, "Wrong incoming edges from 'c'.");
            Assert.IsTrue(graph.IncomingLinks("v").ToList().Count == 1, "Wrong incoming edges from 'v'.");
            Assert.IsTrue(graph.IncomingLinks("f").ToList().Count == 3, "Wrong incoming edges from 'f'.");
            Assert.IsTrue(graph.IncomingLinks("z").ToList().Count == 1, "Wrong incoming edges from 'z'.");

            graph.RemoveLink("d", "c");
            graph.RemoveLink("c", "v");
            graph.RemoveLink("a", "z");

            Assert.IsTrue(graph.PointsCount == 8, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 11, "Wrong edges count.");

            graph.RemovePoint("x");
            Assert.IsTrue(graph.PointsCount == 7, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 7, "Wrong edges count.");
        }

        [TestMethod]
        public void TestWeightedGraph()
        {
            GraphsAlgorithms.Data.WeightedGraph graph = new GraphsAlgorithms.Data.WeightedGraph(10);
            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v" };

            graph.AddPoints(verticesSet1);

            graph.AddLink("a", "s", 1);
            graph.AddLink("a", "z", 2);
            graph.AddLink("s", "x", 3);
            graph.AddLink("x", "d", 1);
            graph.AddLink("x", "c", 2);
            graph.AddLink("x", "a", 3);
            graph.AddLink("d", "f", 1);
            graph.AddLink("d", "c", 2);
            graph.AddLink("d", "s", 3);
            graph.AddLink("c", "f", 1);
            graph.AddLink("c", "v", 2);
            graph.AddLink("c", "d", 3);
            graph.AddLink("v", "f", 1);
            graph.AddLink("f", "c", 2);

            var allEdges = graph.Links.ToList();

            Assert.IsTrue(graph.PointsCount == 8, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 14, "Wrong edges count.");
            Assert.IsTrue(graph.LinksCount == allEdges.Count, "Wrong edges count.");

            Assert.IsTrue(graph.OutgoingLinks("a").ToList().Count == 2, "Wrong outgoing edges from 'a'.");
            Assert.IsTrue(graph.OutgoingLinks("s").ToList().Count == 1, "Wrong outgoing edges from 's'.");
            Assert.IsTrue(graph.OutgoingLinks("d").ToList().Count == 3, "Wrong outgoing edges from 'd'.");
            Assert.IsTrue(graph.OutgoingLinks("x").ToList().Count == 3, "Wrong outgoing edges from 'x'.");
            Assert.IsTrue(graph.OutgoingLinks("c").ToList().Count == 3, "Wrong outgoing edges from 'c'.");
            Assert.IsTrue(graph.OutgoingLinks("v").ToList().Count == 1, "Wrong outgoing edges from 'v'.");
            Assert.IsTrue(graph.OutgoingLinks("f").ToList().Count == 1, "Wrong outgoing edges from 'f'.");
            Assert.IsTrue(graph.OutgoingLinks("z").ToList().Count == 0, "Wrong outgoing edges from 'z'.");

            Assert.IsTrue(graph.IncomingLinks("a").ToList().Count == 1, "Wrong incoming edges from 'a'.");
            Assert.IsTrue(graph.IncomingLinks("s").ToList().Count == 2, "Wrong incoming edges from 's'.");
            Assert.IsTrue(graph.IncomingLinks("d").ToList().Count == 2, "Wrong incoming edges from 'd'.");
            Assert.IsTrue(graph.IncomingLinks("x").ToList().Count == 1, "Wrong incoming edges from 'x'.");
            Assert.IsTrue(graph.IncomingLinks("c").ToList().Count == 3, "Wrong incoming edges from 'c'.");
            Assert.IsTrue(graph.IncomingLinks("v").ToList().Count == 1, "Wrong incoming edges from 'v'.");
            Assert.IsTrue(graph.IncomingLinks("f").ToList().Count == 3, "Wrong incoming edges from 'f'.");
            Assert.IsTrue(graph.IncomingLinks("z").ToList().Count == 1, "Wrong incoming edges from 'z'.");

            // ASSERT RANDOMLY SELECTED EDGES
            var f_to_c = graph.HasLink("f", "c");
            var f_to_c_weight = graph.GetLinkWeight("f", "c");
            Assert.IsTrue(f_to_c, "Edge f->c doesn't exist.");
            Assert.IsTrue(f_to_c_weight == 2, "Edge f->c must have a weight of 2.");

            // ASSERT RANDOMLY SELECTED EDGES
            var d_to_s = graph.HasLink("d", "s");
            var d_to_s_weight = graph.GetLinkWeight("d", "s");
            Assert.IsTrue(d_to_s == true, "Edge d->s doesn't exist.");
            Assert.IsTrue(d_to_s_weight == 3, "Edge d->s must have a weight of 3.");

            // TRY ADDING DUPLICATE EDGES BUT WITH DIFFERENT WEIGHTS
            var add_d_to_s_status = graph.AddLink("d", "s", 6);
            Assert.IsTrue(add_d_to_s_status == false, "Error! Added a duplicate edge.");

            var add_c_to_f_status = graph.AddLink("c", "f", 12);
            Assert.IsTrue(add_c_to_f_status == false, "Error! Added a duplicate edge.");

            var add_s_to_x_status = graph.AddLink("s", "x", 123);
            Assert.IsTrue(add_s_to_x_status == false, "Error! Added a duplicate edge.");

            var add_x_to_d_status = graph.AddLink("x", "d", 34);
            Assert.IsTrue(add_x_to_d_status == false, "Error! Added a duplicate edge.");

            // TEST DELETING EDGES
            graph.RemoveLink("d", "c");
            Assert.IsTrue(graph.HasLink("d", "c") == false, "Error! The edge d->c was deleted.");

            graph.RemoveLink("c", "v");
            Assert.IsTrue(graph.HasLink("c", "v") == false, "Error! The edge c->v was deleted.");

            graph.RemoveLink("a", "z");
            Assert.IsTrue(graph.HasLink("a", "z") == false, "Error! The edge a->z was deleted.");

            // ASSERT VERTICES AND EDGES COUNT
            Assert.IsTrue(graph.PointsCount == 8, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 11, "Wrong edges count.");

            // TEST DELETING VERTICES
            graph.RemovePoint("x");
            Assert.IsTrue(graph.HasLink("x", "a") == false, "Error! The edge x->a was deleted because vertex x was deleted.");

            // ASSERT VERTICES AND EDGES COUNT
            Assert.IsTrue(graph.PointsCount == 7, "Wrong vertices count.");
            Assert.IsTrue(graph.LinksCount == 7, "Wrong edges count.");
        }

        [TestMethod]
        public void TestDijkstraShortestPaths()
        {
            var undirectedGraph = new GraphsAlgorithms.Data.UndirectedGraph();
            undirectedGraph.AddPoint("a");
            undirectedGraph.AddPoint("b");
            undirectedGraph.AddPoint("c");
            undirectedGraph.AddPoint("d");

            undirectedGraph.AddLink("a", "b");
            undirectedGraph.AddLink("b", "c");
            undirectedGraph.AddLink("c", "a");

            var dijkstra = new GraphsAlgorithms.Algorithms.DijkstraShortestPaths(undirectedGraph);
            Assert.AreEqual(null, dijkstra.FindShortestPath("a", "d").Item1);
            CollectionAssert.AreEqual(dijkstra.FindShortestPath("a", "c").Item1, new List<string> { "a", "c" });

            var directedGraph = new GraphsAlgorithms.Data.DirectedGraph();
            directedGraph.AddPoint("a");
            directedGraph.AddPoint("b");
            directedGraph.AddPoint("c");
            directedGraph.AddPoint("d");

            directedGraph.AddLink("a", "b");
            directedGraph.AddLink("b", "c");
            directedGraph.AddLink("c", "a");


            dijkstra = new GraphsAlgorithms.Algorithms.DijkstraShortestPaths(directedGraph);
            Assert.AreEqual(null, dijkstra.FindShortestPath("a", "d").Item1);
            CollectionAssert.AreEqual(dijkstra.FindShortestPath("a", "c").Item1, new List<string> { "a", "b", "c" });

            directedGraph.AddLink("a", "c");
            dijkstra = new GraphsAlgorithms.Algorithms.DijkstraShortestPaths(directedGraph);
            CollectionAssert.AreEqual(dijkstra.FindShortestPath("a", "c").Item1, new List<string> { "a", "c" });

            var weightedGraph = new GraphsAlgorithms.Data.WeightedGraph();
            weightedGraph.AddPoint("a");
            weightedGraph.AddPoint("b");
            weightedGraph.AddPoint("c");
            weightedGraph.AddPoint("d");

            weightedGraph.AddLink("a", "b", 1);
            weightedGraph.AddLink("b", "c", 1);

            dijkstra = new GraphsAlgorithms.Algorithms.DijkstraShortestPaths(weightedGraph);
            Assert.AreEqual(null, dijkstra.FindShortestPath("a", "d").Item1);
            CollectionAssert.AreEqual(dijkstra.FindShortestPath("a", "c").Item1, new List<string> { "a", "b", "c" });

            weightedGraph.AddLink("a", "c", 5);
            dijkstra = new GraphsAlgorithms.Algorithms.DijkstraShortestPaths(weightedGraph);
            CollectionAssert.AreEqual(dijkstra.FindShortestPath("a", "c").Item1, new List<string> { "a", "b", "c" });
            weightedGraph.RemoveLink("a", "c");
            weightedGraph.AddLink("a", "c", 1);
            dijkstra = new GraphsAlgorithms.Algorithms.DijkstraShortestPaths(weightedGraph);
            CollectionAssert.AreEqual(dijkstra.FindShortestPath("a", "c").Item1, new List<string> { "a", "c" });
        }

        [TestMethod]
        public void TestCyclesDetector()
        {
            var cyclicGraph = new GraphsAlgorithms.Data.UndirectedGraph();

            var v = new string[] { "A", "B", "C", "D", "E" };

            cyclicGraph.AddPoints(v);

            cyclicGraph.AddLink("A", "C");
            cyclicGraph.AddLink("B", "A");
            cyclicGraph.AddLink("B", "C");
            cyclicGraph.AddLink("C", "E");
            cyclicGraph.AddLink("C", "D");
            cyclicGraph.AddLink("D", "B");
            cyclicGraph.AddLink("E", "D");

            var isCyclic = GraphsAlgorithms.Algorithms.CyclesDetector.IsCyclic(cyclicGraph);
            Assert.IsTrue(isCyclic.Item1 == true, "Ошибка! Граф имеет цикл.");

            var dag = new GraphsAlgorithms.Data.DirectedGraph();

            v = new string[] { "A", "B", "C", "D", "E", "X" };

            dag.AddPoints(v);

            dag.AddLink("A", "B");
            dag.AddLink("A", "X");
            dag.AddLink("B", "C");
            dag.AddLink("C", "D");
            dag.AddLink("D", "E");
            dag.AddLink("E", "X");

            isCyclic = GraphsAlgorithms.Algorithms.CyclesDetector.IsCyclic(dag);
            Assert.IsTrue(isCyclic.Item1 == false, "Ошибка! Граф не имеет циклов.");
        }

        [TestMethod]
        public void TestBreadthFirstSearcher()
        {
            GraphsAlgorithms.Interfaces.IGraph graph = new GraphsAlgorithms.Data.UndirectedGraph();

            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v" };
            graph.AddPoints(verticesSet1);

            graph.AddLink("a", "s");
            graph.AddLink("a", "z");
            graph.AddLink("s", "x");
            graph.AddLink("x", "d");
            graph.AddLink("x", "c");
            graph.AddLink("d", "f");
            graph.AddLink("d", "c");
            graph.AddLink("c", "f");
            graph.AddLink("c", "v");
            graph.AddLink("v", "f");

            var result = GraphsAlgorithms.Algorithms.BreadthFirstSearcher.PrintAll(graph, "d");
            string searchResult = null;
            string startFromNode = "d";

            Action<string> writeToConsole = (node) => Console.Write(String.Format("({0}) ", node));
            Predicate<string> searchPredicate = (node) => node == "f" || node == "c";

            GraphsAlgorithms.Algorithms.BreadthFirstSearcher.VisitAll(ref graph, startFromNode, writeToConsole);

            try
            {
                searchResult = GraphsAlgorithms.Algorithms.BreadthFirstSearcher.FindFirstMatch(graph, startFromNode, searchPredicate);

                Assert.IsTrue(searchResult == "c" || searchResult == "f");
            }
            catch (Exception)
            {
                Console.WriteLine("Поиск не нашел ни одну вершину.");
            }
        }
    }
}


