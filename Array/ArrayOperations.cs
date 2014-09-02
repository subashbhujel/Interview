﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.ArrayOp
{
    class ArrayOperations
    {

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
            // INCOMPLETE Has Bugs!!
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
                sortedArr[m++] = sortedArr2[j++];
            }

            if (i < len1 && j == len2)
            {
                sortedArr[m++] = sortedArr1[i++];
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
    }
}
