using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsAlgorithms.Utils
{
    static class Matrix
    {
        public static void Populate<T>(this T[,] array, int rows, int columns, T defaultValue = default(T))
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    array[i, j] = defaultValue;
                }
            }
        }
    }
}
