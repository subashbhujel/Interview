using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class SumOfTwoLargestNumInArray
    {
        public int CalculateSumOfTwo(int[] arr)
        {
            int firstLargest;
            int secondLargest;

            if (arr.Length == 0)
                return 0;

            else if (arr.Length == 1)
                return arr[0];

            else
            {
                firstLargest = arr[0];
                secondLargest = arr[1];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > firstLargest)
                    {
                        secondLargest = firstLargest;
                        firstLargest = arr[i];
                    }
                    else if (arr[i] > secondLargest)
                        secondLargest = arr[i];
                }
                Console.WriteLine("First : " + firstLargest + "\tSecond : " + secondLargest);
                return firstLargest + secondLargest;
            }
        }
    }
}
