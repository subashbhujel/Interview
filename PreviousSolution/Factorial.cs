using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class Factorial
    {
        //int sum = 0;
        public int findFactorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return findFactorial(n - 1) * n;
        }
    }
}
