using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    public class Teaser
    {

        /// <summary>
        /// Print a pattern without using any loop
        /// Given a number n, print following pattern without using any loop.
        ///     Input: n = 16
        ///     Output: 16, 11, 6, 1, -4, 1, 6, 11, 16
        /// 
        ///     Input: n = 10
        ///     Output: 10, 5, 0, 5, 10
        /// </summary>
        /// <param name="n"></param>
        public void PrintPattern(int n)
        {
            // Base case: If negative or 0, print and return.
            if (n <= 0)
            {
                Console.WriteLine(n);
                return;
            }

            // First, Print the decreasing order.
            Console.WriteLine(n);
            PrintPattern(n - 5);

            // Then Print the increasing order.
            // No need to do any magic as this is a recursive call, every return n goes back to what it was before substracting 5.
            // for n=10, here's the sequence:
            //  10
            //      5
            //          0
            //      5
            //  10
            Console.WriteLine(n);
        }

        /// <summary>
        /// Find the smallest twins in given range
        ///         Given a range[low..high], print the smallest twin numbers in given range(low and high inclusive). 
        ///         Two numbers are twins if they are primes and there difference is 2.
        /// Example:
        ///     Input:  low = 10,  high = 100
        ///     Output: Smallest twins in given range: (11, 13)
        ///     Both 11 and 13 are prime numbers and difference
        ///     between them is two, therefore twins.And these
        ///     are the smallest twins in [10..100]
        ///     
        ///     Input:  low = 50, high = 100
        ///     Output: Smallest twins in given range: (59, 61)
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public void FindASmallestTwins(int low, int high)
        {
            // Negative numbers
            if (low < 0 || high < 0) return;

            // Cause 1 is NOT a prime. 0 doesn't make sense. So initializing it to 2.
            if (low == 0 || low == 1) low = 2;

            // 'Low' cannot be higher than 'High'
            if (low > high) return;
            int i = 0;

            // Go until High-2 because we NEED the difference to be exactly 2! Read the requirement. 
            for (i = low; i < high - 2; i++)
            {
                bool x = IsPrime(i);
                // For efficiency. If x is NOT prime, no need to calculate below.
                if (!x) continue;

                bool y = IsPrime(i + 2);
                // For efficiency. If x is NOT prime, no need to calculate below.
                if (!y) continue;

                // Both values are prime and their differences is 2. 
                if (x && y && ((i + 2) - i == 2))
                {
                    Console.WriteLine("The smallest twins in a range {0} - {1} : {2},{3}", low, high, i, i + 2);
                    // No need to calculate more twims. 
                    // Note: There CAN BE more twims between the given range whose difference is 2. 
                    break;
                }
            }

            // No twims found *If* loop above went all the way up to the High-2. 
            if (i == high - 2)
            {
                Console.WriteLine("The smallest twins in a range {0} - {1} : None.", low, high);
            }
        }

        /// <summary>
        /// check if a given number is a Prime. 
        /// Prime number is divisible by 1 or itself. Only.
        /// </summary>
        /// <param name="x">Number</param>
        /// <returns>Bool</returns>
        private bool IsPrime(int x)
        {
            // Run a loop starting at 2 until x-1
            for (int i = 2; i < x - 1; i++)
            {
                // If it's divisible by i, then it's NOT a prime.
                if (x % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Given 1, 5, 10 and 25 cents, return/print all combination that adds up to 1 dollar.
        /// </summary>
        public void AllCombinationOfDollar()
        {

        }
    }
}
