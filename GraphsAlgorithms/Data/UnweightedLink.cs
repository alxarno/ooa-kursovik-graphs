using System;
using System.Collections.Generic;
using System.Text;
using GraphsAlgorithms.Interfaces;

namespace GraphsAlgorithms.Data
{
    public class UnweightedLink: ILink
    {
        /// Gets or sets the source vertex.
        public string Source { get; set; }

        /// Gets or sets the destination vertex.
        public string Destination { get; set; }

        public Int64 Weight
        {
            get { throw new NotImplementedException("Unweighted link don't have weights."); }
            set { throw new NotImplementedException("Unweighted link can't have weights."); }
        }

        /// Gets a value indicating whether this edge is weighted.
        public bool IsWeighted
        {
            get
            { return false; }
        }

        /// CONSTRUCTOR
        public UnweightedLink(string src, string dst)
        {
            Source = src;
            Destination = dst;
        }


        public int CompareTo(ILink other)
        {
            if (other == null)
                return -1;

            bool areNodesEqual = Source == other.Source && Destination == other.Destination;

            if (!areNodesEqual)
                return -1;
            return 0;
        }
    }
}
