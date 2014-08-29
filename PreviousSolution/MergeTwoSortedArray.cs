using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class MergeTwoSortedArray
    {
        int[] temp ={ };
        
        public int[] MergeTwoSortedArr(int[] arr1, int[] arr2)
        {
            int len1 = arr1.Length;
            int len2 = arr2.Length;

            temp=new int[len1+len2];

            int i = 0, j = 0, k=0;

            while (k<temp.Length)
            {
                if (i == len1 && j < len2)
                {
                    temp[k] = arr2[j];
                    ++k; ++j;
                    if (i == len1 && j == len2)
                        break;
                    continue;
                }

                else if (j == len2 && i < len1)
                {
                    temp[k] = arr1[i];
                    ++k; ++i;
                    if (i == len1 && j == len2)
                        break;
                    continue;
                }
                
                else{
                    if (arr1[i] < arr2[j])
                    {
                        temp[k] = arr1[i];
                        ++k; ++i;
                    }
                    else if (arr1[i] > arr2[j])
                    {
                        temp[k] = arr2[j];
                        ++k; ++j;
                    }
                    else if (arr1[i] == arr2[j])
                    {
                        temp[k] = arr1[i]; 
                        ++k; ++i;
                        temp[k] = arr2[j];
                        ++k; ++j;
                    }
                }
                
            }
            return temp;
        }
       
        public void PrintSortedArr()
        {
            for (int i = 0; i < temp.Length; ++i)
            {
                Console.Write(temp[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
