using System;
using System.Collections.Generic;

using System.Text;

namespace MSFTPrep_Jan09
{
    class MergeTwoSortedArrays
    {
        public int[] DoAMergeTwoSortedArrays(int[] arr1, int[] arr2)
        {
            #region VARIABLES DECLARATION AND INITIALIZATION
            int len1 = arr1.Length;
            int len2 = arr2.Length;
            int k = 0, j = 0,i=0;
            int[] newArr = new int[len1 + len2];
            #endregion

            //for (int i = 0; i < len1; ++i)
            while (k < newArr.Length)
            {
                //CASE I : {}{1,2,3}
                if (i == len1 && j < len2)
                {
                    while (true)
                    {
                        newArr[k] = arr2[j];
                        ++j; ++k;
                        if (j == len2) break;
                    }
                    if (j == len2) break;
                }//if ends

                //CASE II : {1,2,3}{}
                else if (i < len1 && j == len2)
                {
                    while (true)
                    {
                        newArr[k] = arr1[i];
                        ++i; ++k;
                        if (i == len1) break;
                    }
                    if (i == len1) break;
                }
                //CASE III : {1,2,3}{1,2,3}
                else
                {
                    if (arr1[i] < arr2[j])
                    {
                        newArr[k] = arr1[i];
                        ++i; ++k;
                        continue;
                    }
                    else if (arr1[i] > arr2[j])
                    {
                        newArr[k] = arr2[j];
                        ++j; ++k;
                        continue;
                    }
                    else if (arr1[i] == arr2[j])
                    {
                        newArr[k] = arr1[i];
                        ++k;
                        newArr[k] = arr2[j];
                        ++k;
                        i++; j++;
                        continue;
                    }
                }//else ends
            }//while ends
            return newArr;
        }
        
        public void PrintSortedArr(int[] toBePrinted)
        {
            Console.WriteLine("After Two arrays being sorted : ");
            for (int i = 0; i < toBePrinted.Length; ++i)
            {
                Console.Write(toBePrinted[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
