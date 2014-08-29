using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class InorderQuickSort
    {
        int[] arr;
        
        public InorderQuickSort(int[] arr)
        {
            this.arr = arr;
        }
        
        public void Swap(int i, int j)
        { 
            int temp=this.arr[i];
            this.arr[i] = this.arr[j];
            this.arr[j] = temp;
        }
        
        public void PrintSortedArr()
        {
            Console.WriteLine("Printing Sorted Array . . . ");
            for (int k = 0; k < this.arr.Length; ++k)
            {
                Console.Write(this.arr[k]+" ");
            }
        }
        
        public void DoInorderQuickSort()
        { 
            if(arr.Length==0 ||arr.Length==1)
                return;

            int i = 0;
            int j = this.arr.Length - 1;
            while (i < j)
            {
                while (this.arr[i] < 0) ++i;
                while (this.arr[j] > 0) --j;

                if (this.arr[i] == 0 && this.arr[j] != 0)
                {
                    Swap(i, j);
                    ++i;
                }
                else if (this.arr[j] == 0 && this.arr[i] != 0)
                {
                    Swap(i, j);
                    --j;
                }
                else if (this.arr[i] == 0 && this.arr[j] == 0)
                {
                    int k = i;
                    int l = j;
                    
                    while (this.arr[k] == 0) ++k;
                    if (k >= j) break;
                    
                    while (this.arr[l] == 0) --l;
                    if (l <= i) break;
                    
                    Swap(i, k);
                    Swap(j, l);                     
                }
                else if(i<j)
                {
                    Swap(i, j);
                    ++i; --j;
                }
            }
        }
    
    }
}
