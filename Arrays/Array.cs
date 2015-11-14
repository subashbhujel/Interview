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
        /// Swaps the array element
        /// </summary>
        /// <param name="arr">Array to be swapped</param>
        /// <param name="i">Swap value 1 </param>
        /// <param name="j">swap value 2</param>
        /// <returns>Array with swapped values.</returns>
        private int[] Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            return arr;
        }

        /// <summary>
        /// Prints an array
        /// </summary>
        /// <param name="arr">Array to be printed.</param>
        private void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Q. Sort an Array such that the odd numbers appear first followed by the even numbers . 
        ///     http://algorithms.tutorialhorizon.com/sort-an-array-such-that-the-odd-numbers-appear-first-followed-by-the-even-numbers-the-odd-numbers-in-ascending-order-and-the-even-numbers-in-descending-order/
        ///     Exam­ple:
        ///     Input Array : 1 2 3 4 5 6 7 8 9 10
        ///     Out­put : 1 3 5 7 9 10 8 6 4 2
        /// </summary>
        /// <param name="array">Unsorted Array.</param>
        public void ArrangeArrya(int[] array)
        {
            //int mid = array.Length % 10 == 0 ? array.Length / 2 - 1 : array.Length / 2;

            if (array.Length <= 1)
            {
                Console.WriteLine("Not enough items in an array");
                return;
            }

            Console.Write("Before: ");
            PrintArray(array);

            // You want to swap from beginning of an array to a very last item of an array
            int low = 0;
            int high = array.Length - 1;

            // Start a loop until low is smaller than high index
            while (low < high)
            {
                // Find the even value. Skip if its odd.
                while (array[low] % 2 != 0) low++;

                // Find the odd value. Skip if it's even.
                while (array[high] % 2 == 0) high--;

                // Swap only if low and high do not cross each other. 
                // Exit conditin.
                if (low < high)
                {
                    // Swap the values.
                    array = Swap(array, low, high);
                }
            }

            Console.Write("After: ");
            PrintArray(array);
        }

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
