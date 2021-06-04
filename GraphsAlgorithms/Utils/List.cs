using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsAlgorithms.Utils
{
    public static class List
    {
        public static bool TryFindFirst<T>(this LinkedList<T> list, Predicate<T> match, out T found)
        {
            // Initialize the output parameter
            found = default(T);

            if (list.Count == 0)
                return false;

            var currentNode = list.First;

            try
            {
                while (currentNode != null)
                {
                    if (match(currentNode.Value))
                    {
                        found = currentNode.Value;
                        return true;
                    }

                    currentNode = currentNode.Next;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
