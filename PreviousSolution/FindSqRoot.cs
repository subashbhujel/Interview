using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class FindSqRoot
    {
        // Finds the integer square root of a positive number
        public float Isqrt(int num)
        {
            if (0 == num || num < 0) { return 0; }  // Avoid zero divide and negative
            int n = (num / 2) + 1;       // Initial estimate, never low

            int n1 = (n + (num / n)) / 2;
            
            while (n1 < n)
            {
                n = n1;
                n1 = (n + (num / n)) / 2;            
            } // end while

            return n1;
        } // end Isqrt()

        public double FindSquareRoot(double n)
        {
            double approx, nextGuess, lastGuess, difference;

            /* Initialization of lastGuess */
            lastGuess = 1.0;

            nextGuess = (lastGuess + n / lastGuess)/2;
            difference = (nextGuess - lastGuess);
                        

            /* While Loop used to calculate the approximate sqrt*/
            while (difference > 0.000000000000000000000000000000000000005)
            {
                lastGuess = nextGuess;
                nextGuess = (lastGuess + n / lastGuess)/2;
                difference = (lastGuess - nextGuess);
            }

            approx = nextGuess;
            
            return (approx);
        }
    }
}
