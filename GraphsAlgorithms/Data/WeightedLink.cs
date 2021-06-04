using System;
using System.Collections.Generic;
using System.Text;
using GraphsAlgorithms.Interfaces;

namespace GraphsAlgorithms.Data
{
    public class WeightedLink : ILink
    {
         public string Source { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the weight of edge.
        /// </summary>
        /// <value>The weight.</value>
        public Int64 Weight { get; set; }

        /// <summary>
        /// Gets a value indicating whether this edge is weighted.
        /// </summary>
        public bool IsWeighted
        {
            get { return true; }
        }

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public WeightedLink(string src, string dst, Int64 weight)
        {
            Source = src;
            Destination = dst;
            Weight = weight;
        }


        public int CompareTo(ILink other)
        {
            if (other == null)
                return -1;

            bool areNodesEqual = Source == other.Source && Destination == other.Destination;

            if (!areNodesEqual)
                return -1;
            return Weight.CompareTo(other.Weight);
        }
    }
}