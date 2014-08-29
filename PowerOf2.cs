using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation1
{
    // Q : How do you find out if a number is a power of 2? And how do you know if it is an odd number? 
    class PowerOf2
    {
        public bool IsANumberPowerOf2(ulong x)
        {
            //return (x != 0) && ((x & (x - 1) == 0));
            return (x & (x - 1)) == 0;
        }
    }
}
