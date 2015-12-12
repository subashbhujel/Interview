using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPreparation.BrainTeaser;

namespace InterviewPreparation
{
    public class Teaser
    {

        /// <summary>
        /// Given a sorted array and a number x, find the pair in array whose sum is closest to x
        /// Examples:Input: arr[] = {10, 22, 28, 29, 30, 40}, x = 54
        /// Output: 22 and 30
        /// 
        /// Input: arr[] = {1, 3, 4, 7, 10}, x = 15
        /// Output: 4 and 10
        /// </summary>
        /// <param name="a"></param>
        /// <param name="sum"></param>
        public void PrintClosestPair(int[] a, int sum)
        {
            // Negative sum and empty array check.
            if (a.Length <= 1 || sum <= 0) return;

            // Low and high initialization
            int low = 0, high = a.Length - 1;

            // The diffeence init.
            int diff = int.MaxValue;

            // The final pair. The result.
            int x = int.MinValue, y = int.MinValue;

            // Loop until the end.
            while (low < high)
            {
                // The difference between pair is less than the diff
                if (Math.Abs(a[low] + a[high] - sum) < diff)
                {
                    // Update the diff & the resulting pairs
                    diff = Math.Abs(a[low] + a[high] - sum);
                    x = a[low];
                    y = a[high];
                }
                // Move towards the higher numbers. Remember, this array is sorted.
                else if (Math.Abs(a[low] + a[high]) < sum) low++;
                // Move towards the lower numbers.
                else high--;
            }

            // The result.
            if (x != int.MinValue && y != int.MinValue)
            {
                Console.WriteLine("Closed pair to {0} : {1},{2}", sum, x, y);
            }
        }

        /// <summary>
        /// Smallest subarray with sum greater than a given value
        /// Given an array of integers and a number x, find the smallest subarray with sum greater than the given value.
        /// Examples:
        ///     arr[] = {1, 4, 45, 6, 0, 19}
        ///     x  =  51
        /// Output: 3
        ///     Minimum length subarray is {4, 45, 6}
        /// REf: http://www.geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value/
        /// </summary>
        /// <param name="arr"></param>
        public void SmallestSubWithSum(int[] arr, int num)
        {
            int i = 0;

            if (num <= 0 || arr.Length <= 0) return;
            int sum = 0;

            // Stores the final result ie the subarray
            ArrayList result = new ArrayList();

            // Stores the remp result. Needed cause there may be multiple sub array that is greater than the num
            ArrayList temp = new ArrayList();

            // First loop until end of the array
            while (i < arr.Length - 1)
            {
                // Sum initializaton
                sum = arr[i];

                // Add the first element to temp array
                temp.Add(arr[i]);

                // Second loop, runs until end of the array to find the subarray.
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    // Update sum and form a sub array if num is still greater than the sum.
                    if (num > sum + arr[j])
                    {
                        temp.Add(arr[j]);
                        sum = sum + arr[j];
                    }
                    // We got our first sub array. Break.
                    else
                    {
                        temp.Add(arr[j]);
                        sum = sum + arr[j];
                        break;
                    }
                }

                // Update the result sub array
                if (sum > num)
                {
                    // Update result sub array for the first time
                    if (result.Count <= 0) result = temp;
                    // the smallest sub array is what we need. Updated.
                    else if (result.Count > temp.Count) result = temp;
                }

                // Re-set
                temp = new ArrayList();
                sum = 0;
                i++;
            }

            // Our final sub array.
            if (result.Count > 0)
            {
                Console.Write("Length: {0}.  SubArray: [", result.Count);
                foreach (int item in result)
                {
                    Console.Write("{0},", item);
                }
                Console.Write("]" + "\n");
            }
        }

        /// <summary>
        /// Stock Buy Sell to Maximize Profit
        /// The cost of a stock on each day is given in an array, find the max profit that you can make by buying and selling in those days. 
        /// For example, if the given array is {100, 180, 260, 310, 40, 535, 695}, the maximum profit can earned by buying on day 0, selling on day 3. 
        /// Again buy on day 4 and sell on day 6. If the given array of prices is sorted in decreasing order, then profit cannot be earned at all.
        /// If we are allowed to buy and sell only once, then we can use following algorithm. Maximum difference between two elements. 
        /// 
        /// Here we are allowed to buy and sell multiple times. Following is algorithm for this problem.
        /// 1. Find the local minima and store it as starting index. If not exists, return.
        /// 2. Find the local maxima. and store it as ending index. If we reach the end, set the end as ending index.
        /// 3. Update the solution (Increment count of buy sell pairs)
        /// 4. Repeat the above steps if end is not reached.
        /// </summary>
        /// <param name="stockPrice"></param>
        public void StockBuySell(int[] stockPrice)
        {
            List<Stock> list = new List<Stock>();
            Stock stock;

            int i = 0;
            int len = stockPrice.Length - 1;

            // No need to run if there's not two prices to compare.
            if (len <= 0) return;

            // Run until end of the stock prices
            while (i < len)
            {
                // Initialize the stock object
                stock = new Stock();

                // Check if it reached end of the array AND the first element is greater than the second element.
                while (i < len && stockPrice[i] > stockPrice[i + 1])
                {
                    i++;
                }

                // End of the array
                if (i == len) return;

                // Set minimum buying day and price
                stock.buy = i;
                stock.buyPrice = stockPrice[i];
                i++;

                // Check if it reached end of the array AND the first element is lesser than the second element.
                while (i < len && stockPrice[i] < stockPrice[i + 1]) { i++; }

                // Set the maximum sell price and day
                stock.sell = i;
                stock.sellPrice = stockPrice[i];
                i++;

                Console.WriteLine("Stock - buy on day {0} @ {2} and sell on day {1} @ {3}", stock.buy, stock.sell, stock.buyPrice, stock.sellPrice);
            }
        }

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
