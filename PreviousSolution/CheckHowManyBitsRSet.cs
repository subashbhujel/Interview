using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class CheckHowManyBitsRSet
    {
        public int CheckForSetBits(int a)
        {
            int count = 0,temp=0;
            for (int i = 0; i < 5; ++i)
            {                
                if ((a & 1 << i) != 0)
                    count++;
            }
            return count;
        }
    }
}
