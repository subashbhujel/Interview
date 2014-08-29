using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class ShiftArray
    {
        public int[] FindSortedArrayRotation(int[] inputArr, int rotateBy)
        {
            //input ={ 1, 2, 3, 4, 5 };
            //rotateBy = 16; returned array :{5,1,2,3,4}

            if (rotateBy >= inputArr.Length)
            {
                rotateBy = rotateBy % inputArr.Length;
            }
            int temp;

            for (int i = 1; i <= rotateBy; i++)
            {
                temp = inputArr[inputArr.Length - 1];
                for (int j = inputArr.Length - 2; j >= 0; j--)
                    inputArr[j + 1] = inputArr[j];
                inputArr[0] = temp;
            }

            return inputArr;
        } 
    }
}
