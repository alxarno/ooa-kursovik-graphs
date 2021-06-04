using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsAlgorithms.Interfaces
{
    public interface IGraph
    {
        bool IsDirected { get; }

        bool IsWeighted { get; }

        int PointsCount { get; }

        int LinksCount { get; }

        /// <summary>
        /// Returns the list of Vertices.
        /// </summary>
        IEnumerable<string> Points { get; }

        /// <summary>
        /// An enumerable collection of edges.
        /// </summary>
        IEnumerable<ILink> Links { get; }

        /// <summary>
        /// Get all incoming edges from vertex
        /// </summary>
        IEnumerable<ILink> IncomingLinks(string P);

        /// <summary>
        /// Get all outgoing edges from vertex
        /// </summary>
        IEnumerable<ILink> OutgoingLinks(string P);

        /// <summary>
        /// Connects two vertices together.
        /// </summary>
        bool AddLink(string first , string second);
        bool AddLink(string source, string destination, long weight);

        /// <summary>
        /// Deletes an edge, if exists, between two vertices.
        /// </summary>
        bool RemoveLink(string first, string second);

        /// <summary>
        /// Adds a list of vertices to the graph.
        /// </summary>
        void AddPoints(IList<string> collection);

        /// <summary>
        /// Adds a new vertex to graph.
        /// </summary>
        bool AddPoint(string point);

        /// <summary>
        /// Removes the specified vertex from graph.
        /// </summary>
        bool RemovePoint(string point);

        /// <summary>
        /// Checks whether two vertices are connected (there is an edge between firstVertex & secondVertex)
        /// </summary>
        bool HasLink(string firstPoint, string secondPoint);

        /// <summary>
        /// Determines whether this graph has the specified Point.
        /// </summary>
        bool HasPoint(string point);

        /// <summary>
        /// Returns the neighbours doubly-linked list for the specified vertex.
        /// </summary>
        LinkedList<string> Neighbours(string point);

        /// <summary>
        /// Returns the degree of the specified vertex.
        /// </summary>
        int Degree(string point);

        /// <summary>
        /// Returns a human-readable string of the graph.
        /// </summary>
        string ToReadable();

        /// <summary>
        /// Clear this graph.
        /// </summary>
        void Clear();
    }
}
