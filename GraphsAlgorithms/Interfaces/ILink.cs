using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsAlgorithms.Interfaces
{
    public interface ILink
    {
        bool IsWeighted { get; }

        string Source { get; set; }

        string Destination { get; set; }

        Int64 Weight { get; set; }
    }
}
