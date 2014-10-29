using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.ArrayOp
{
    class ArrayOperations
    {
        /// <summary>
        /// Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column is set to 0  
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeros(int[,] matrix, int m, int n)
        {
            // APPROACH:
            //  At first glance, this problem seems easy: just iterate through the matrix and every time we see a 0, set that row and column to 0   
            //  There’s one problem with that solution though: 
            //      we will “recognize” those 0s later on in our iteration and then set their row and column to zero Pretty soon, 
            //      our entire matrix is 0s!
            //      
            //  One way around this is to keep a second matrix which flags the 0 locations. 
            //  We would then do a second pass through the matrix to set the zeros. 
            //  This would take O(MN) space. Do we really need O(MN)space ? No
            //  
            //  Since we’re going to set the entire row and column to zero, do we really need to track which cell in a row is zero ? No    
            //  We only need to know that row 2, for example, has a zero   
            //  The code below implement this algorithm. We keep track in two arrays all the rows with zeros and all the columns with zeros    
            //  We then make a second pass of the matrix and set a cell to zero if its row or column is zero

            // Setting Zeros at random locations.
            matrix[m - 1, n - 1] = 0;
            matrix[0,0] = 0;
            matrix[1, 2] = 0;

            Console.WriteLine("Original Array:");
            Print(matrix,m,n);

            int[] row = new int[m];
            int[] col = new int[n];
            
            // Find the occurance of 0 and mark row and column arrays
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = 1;
                        col[j] = 1;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (row[i] == 1 || col[j] == 1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            Console.WriteLine("Processed Array:");
            Print(matrix,m,n);
        }
        /// <summary>
        /// Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees.
        ///  Can you do this in place?
        /// </summary>
        /// <param name="image"></param>
        /// <param name="n"></param>
        public void RotateAnImageBy90Degree(int[,] matrix, int n)
        {
            // APPROACH:
            //    The rotation can be performed in layers, where you perform a cyclic swap on the edges on each layer
            //    In the first for loop, we rotate the first layer(outermost edges)   
            //    We rotate the edges by doing a four - way swap first on the corners, then on the element clockwise from the edges, 
            //    then on the element three steps away  
            //    Once the exterior elements are rotated, we then rotate the interior region’s edges

        }

        /// <summary>
        /// Transform an array - Row -> Col & Col -> Row
        /// </summary>
        /// <param name="arr"></param>
        public void ConvertRowintoCol(int[,] arr)
        {

        }

        /// <summary>
        /// Move all zeroes to end of array
        /// Given an array of random numbers, Push all the zero’s of a given array to the end of the array. 
        /// For example, if the given arrays is {1, 9, 8, 4, 0, 0, 2, 7, 0, 6, 0}, it should be changed to {1, 9, 8, 4, 2, 7, 6, 0, 0, 0, 0}. 
        /// The order of all other elements should be same. Expected time complexity is O(n) and extra space is O(1).
        /// 
        /// Approach:
        ///     There can be many ways to solve this problem. Following is a simple and interesting way to solve this problem.
        ///     Traverse the given array ‘arr’ from left to right. While traversing, maintain count of non-zero elements in array. 
        ///     Let the count be ‘count’. For every non-zero element arr[i], put the element at ‘arr[count]‘ and increment ‘count’. 
        ///     After complete traversal, all non-zero elements have already been shifted to front end and ‘count’ is set as index of first 0. 
        ///     Now all we need to do is that run a loop which makes all elements zero from ‘count’ till end of the array.        ///     
        /// http://www.geeksforgeeks.org/move-zeroes-end-array/
        /// </summary>
        /// <param name="arr">Array</param>
        /// <returns>Sorted array with zeros at the end of an array</returns>
        public int[] MoveAllZeroesToEndOfArray(int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Invaid (null) Array.");
                return null;
            }

            int len = arr.Length - 1;

            if (len < 1)
            {
                return arr;
            }

            int count = 0;

            // Find the non-zero numbers and start adding from starting of the array.
            for (int i = 0; i < len; i++)
            {
                if (arr[i] != 0)
                {
                    arr[count++] = arr[i];
                }
            }

            // Now you have added all the non-zero numbers to an array.
            // total length - Count = number of Zero's in an array.
            // Now add it to an array from count index until the end
            while (count < len)
            {
                arr[count++] = 0;
            }

            Print(arr);

            return arr;
        }

        /// <summary>
        /// Determine minimum sequence of adjacent values in the input parameter array that is greater than input parameter sum.
        /// Eg Array 2,1,1,4,3,6. and Sum is 8
        /// Answer is 2, because 3,6 is minimum sequence greater than 8.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int FindMinSequence(int[] arr, int sum)
        {
            // INCOMPLETE. Has Bugs!!
            if (arr == null)
            {
                Console.WriteLine("Invaid (null) Array.");
                return int.MinValue;
            }

            int len = arr.Length;

            if (len < 1)
            {
                Console.WriteLine("Invalid array.");
                return int.MinValue;
            }

            int aggSum = 0;
            int minlen = int.MaxValue;

            List<int> sliding_window = new List<int>();

            for (int i = 0; i < len; i++)
            {
                aggSum += arr[i];
                //sliding_window.Add(arr[i]);

                if (aggSum > sum)
                {
                    continue;
                }
                else
                {
                    sliding_window.Add(arr[i]);
                    for (int j = i + 1; j < len; j++)
                    {
                        //templen++;
                        aggSum += arr[j];
                        if (aggSum > sum)
                        {
                            if (sliding_window.Count < minlen)
                                minlen = sliding_window.Count;
                            else
                            {
                                sliding_window.Clear();
                            }
                            aggSum = 0;
                            break;
                        }
                    }
                }
            }

            return minlen;
        }

        /// <summary>
        ///  Given two sorted array in ascending order with same length N, calculate the Kth min a[i]+b[j]. 
        ///  Time complexty O(N).
        ///  Array #1 : {1,6,13,20}
        ///  Array #2 : {2,6,20,50}
        ///  Find 3rd minimum value. Ans: 6
        ///  Find 4th minimum value. Ans: 13
        /// Assumption: Both array is of equal length (irrelavant). Array is of equal length.
        /// </summary>
        /// <param name="sortedArr1">First sorted array.</param>
        /// <param name="sortedArr2">Second sorted array.</param>
        /// <param name="k">Kth minum value to find.</param>
        public int FindTheKthElement(int[] sortedArr1, int[] sortedArr2, int k)
        {
            if (sortedArr1 == null || sortedArr2 == null)
            {
                Console.WriteLine("Invaid (null) Array.");
                return int.MinValue;
            }

            int len1 = sortedArr1.Length;
            int len2 = sortedArr2.Length;

            if (len1 < 1 && len2 < 1 || (k > (len1 + len2)) || k == 0)
            {
                return int.MinValue;
            }

            Print(sortedArr1);
            Print(sortedArr2);

            // i = Array #1 iterator
            // j = Array #2 iterator

            int i = 0, j = 0;
            int m = 0;
            int numOfElementAdded = 0;

            // Construct a new sorted array
            int[] sortedArr = new int[len1 + len2];

            while (i < len1 && j < len2)
            {
                if (sortedArr1[i] < sortedArr2[j])
                {
                    sortedArr[m++] = sortedArr1[i++];
                }
                else if (sortedArr1[i] > sortedArr2[j])
                {
                    sortedArr[m++] = sortedArr2[j++];
                }
                // Adding only one of the duplicate value
                else if (sortedArr1[i] == sortedArr2[j])
                {
                    sortedArr[m++] = sortedArr1[i++];
                    j++;
                }

                numOfElementAdded++;
            }

            if (i == len1 && j < len2)
            {
                while (j < len2)
                {
                    sortedArr[m++] = sortedArr2[j++];
                    numOfElementAdded++;
                }
            }

            if (i < len1 && j == len2)
            {
                while (i < len1)
                {
                    sortedArr[m++] = sortedArr1[i++];
                    numOfElementAdded++;
                }
            }

            // Final combined sorted array ie array #1 + array #2
            Print(sortedArr);
            Console.WriteLine("item added:" + numOfElementAdded);

            if ((k - 1) > numOfElementAdded)
            {
                return int.MinValue;
            }

            return sortedArr[k - 1];
        }

        /// <summary>
        /// Prints an integer array
        /// </summary>
        /// <param name="arr"></param>
        public void Print(int[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(string.Format("[{0}] - {1}", i, arr[i]));
            }
        }

        /// <summary>
        /// Prints an integer array
        /// </summary>
        /// <param name="arr"></param>
        public void Print(int[,] arr,int m,int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i,j]+"\t");
                }
                Console.WriteLine();
            }
        }
    }
}
