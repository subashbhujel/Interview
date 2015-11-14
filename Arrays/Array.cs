using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    public class ArrayOperatios
    {
        /// <summary>
        /// Solution: http://stackoverflow.com/questions/726756/print-two-dimensional-array-in-spiral-order
        ///     The idea is to treat the matrix as a series of layers, top-right layers and bottom-left layers. 
        ///     To print the matrix spirally we can peel layers from these matrix, print the peeled part and recursively call the print on the left over part. 
        ///     The recursion terminates when we don't have any more layers to print.
        /// </summary>
        /// <param name="matrix">Matrix</param>
        public void PrintInSpiralOrder(int[,] matrix)
        {
            // The 0,0 is the starting index
            // The 3, 2 is the max number of rows and columns in the matrix
            PrintTopRightLayer(matrix, 0, 0, 3, 2);//matrix.Length, matrix[0].Length);
            Console.WriteLine();
        }

        /// <summary>
        /// This prints the top right layer.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="x1">Start index</param>
        /// <param name="y1">Start index</param>
        /// <param name="row">Max row left to print</param>
        /// <param name="col">max col left to print</param>
        private void PrintTopRightLayer(int[,] matrix, int x1, int y1, int row, int col)
        {
            int i = 0, j = 0;

            // Print top row. Direction top left -> bottom right
            for (i = y1; i <= col; i++)
            {
                Console.Write(matrix[x1, i] + " ");
            }

            // Print right column. Direction top -> bottom
            for (j = x1 + 1; j <= row; j++)
            {
                Console.Write(matrix[j, col] + " ");
            }

            // Check if there's more items to print. If there's no columns left. We printed them all.
            if (col - y1 > 0)
                PrintBottomLeftLayer(matrix, x1 + 1, y1, row, col - 1);
        }

        /// <summary>
        /// This prints the bottom left layer
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="x1">Start index</param>
        /// <param name="y1">Start index</param>
        /// <param name="row">Max row left to print</param>
        /// <param name="col">max col left to print</param>
        private void PrintBottomLeftLayer(int[,] matrix, int x1, int y1, int row, int col)
        {
            int i = 0, j = 0;

            // Print the bottom row. Direction bottom right -> bottom left
            for (i = col; i >= y1; i--)
            {
                Console.Write(matrix[row, i] + " ");
            }

            // Print the leftmost column. Direction bottom left -> top left 
            for (j = row - 1; j >= x1; j--)
            {
                Console.Write(matrix[j, y1] + " ");
            }

            // Check if there's more items to print. If there's no columns left. We printed them all.
            if ((col - y1) > 0)
            {
                PrintTopRightLayer(matrix, x1, y1 + 1, row - 1, col);
            }
        }
    }
}
