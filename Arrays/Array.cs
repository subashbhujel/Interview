using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    public class ArrayOperatios
    {

        /// <summary>
        /// Next Greater Element
        /// Given an array, print the Next Greater Element (NGE) for every element. The Next greater Element for an element x is the first greater element on the right side of x in array. Elements for which no greater element exist, consider next greater element as -1.
        /// 
        /// Examples:
        /// a) For any array, rightmost element always has next greater element as -1.
        /// b) For an array which is sorted in decreasing order, all elements have next greater element as -1.
        /// c) For the input array [4, 5, 2, 25}, the next greater elements for each element are as follows.
        /// Element       NGE
        /// 4      -->   5
        /// 5      -->   25
        /// 2      -->   25
        /// 25     -->   -1
        /// 
        /// Ref: http://www.geeksforgeeks.org/next-greater-element/
        /// 
        /// APPROACH:
        /// Obvious solution is to run two loops.
        /// 
        /// Here's one using Stack:
        /// 1) Push the first element to stack.
        /// 2) Pick rest of the elements one by one and follow following steps in loop.
        /// ….a) Mark the current element as next.
        /// ….b) If stack is not empty, then pop an element from stack and compare it with next.
        /// ….c) If next is greater than the popped element, then next is the next greater element for the popped element.
        /// ….d) Keep popping from the stack while the popped element is smaller than next. next becomes the next greater element for all such popped elements
        /// ….g) If next is smaller than the popped element, then push the popped element back.
        /// 3) After the loop in step 2 is over, pop all the elements from stack and print -1 as next element for them.
        /// </summary>
        internal void FindNextGreaterNumber()
        {
            int[] a = { 4, 5, 2, 25, 1 };

            Stack<int> s = new Stack<int>();
            
            // Push the first element to a stack
            s.Push(a[0]);

            // iterate for rest of the elements
            for (int i = 1; i < a.Length; i++)
            {
                // Get the next element
                int next = a[i];

                // Stack empty?
                if (s.Count > 0)
                {
                    // Pop an element
                    int element = s.Pop();

                    // Popped element is smaller than next element. Print them.
                    while (element < next)
                    {
                        Console.WriteLine("{0} -> {1}", element, next);
                     
                        // If stack if empty, break. Pop otherwise.
                        if (s.Count() == 0) break;
                        element = s.Pop();
                    }

                    // Element is greater than the next element, push it back. So you can find it's next greater element later.
                    if (element > next)
                    {
                        s.Push(element);
                    }
                }

                // Push the next element so you can look for it's NGN later.
                s.Push(next);
            }

            // Rest of the stack element doesn't have next greater number. Print -1 for all of them.
            while (s.Count != 0)
            {
                Console.WriteLine("{0} -> {1}", s.Pop(), -1);
            }
        }

        /// <summary>
        /// The longest Increasing Subsequence (LIS) problem is to find the length of the longest 
        /// subsequence of a given sequence such that all elements of the subsequence are sorted in 
        /// increasing order. For example, length of LIS for { 10, 22, 9, 33, 21, 50, 41, 60, 80 }
        /// is 6 and LIS is {10, 22, 33, 50, 60, 80}. 
        /// REf: geeks for geeks.
        /// 
        /// NOTE: NOT solved yet.
        /// </summary>
        internal void FindLongestIncreasingSequence()
        {
            int[] a = { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            List<int> list = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                int v = a[i];

                if (list.Count == 0) list.Add(v);
                else
                {
                    int l = list.Last();
                    if (v < l)
                    {
                        //list.RemoveAt(list.Last);
                    }

                }

            }
        }

        /// <summary>
        ///Greedy Algorithm to find Minimum number of Coins
        ///Given a value V, if we want to make change for V Rs, and we have infinite supply of each of the denominations in Indian currency, 
        ///i.e., we have infinite supply of { 1, 2, 5, 10, 20, 50, 100, 500, 1000} valued coins/notes, what is the minimum number of coins 
        ///and/or notes needed to make the change?
        ///
        /// Examples:
        ///     Input: V = 70
        ///     Output: 2
        ///         We need a 50 Rs note and a 20 Rs note.
        ///
        ///     Input: V = 121
        ///     Output: 3
        ///         We need a 100 Rs note, a 20 Rs note and a 1 Rs coin. 
        ///
        /// APPROACH:
        /// The idea is simple Greedy Algorithm. Start from largest possible denomination and keep adding denominations while remaining value is greater than 0. 
        /// 
        /// Below is complete algorithm.
        ///     1) Initialize result as empty.
        ///     2) find the largest denomination that is smaller than V.
        ///     3) Add found denomination to result. Subtract value of found denomination from V.
        ///     4) If V becomes 0, then print result.  Else repeat steps 2 and 3 for new value of V
        /// </summary>
        /// <param name="a"></param>
        internal void FindMinCombination(int n)
        {
            // Available coins
            int[] coins = { 1, 5, 10, 20, 50, 100, 500, 1000 };

            // Stores the result ie the number of different denominations needed to make n
            Stack<int> result = new Stack<int>();

            // Run a loop from last to first
            for (int i = coins.Length - 1; i >= 0; i--)
            {
                // Check if coins is less than or equal to n
                if (coins[i] <= n)
                {
                    // Push the result
                    result.Push(coins[i]);

                    // deduct the value from n and continue
                    n -= coins[i];

                    // Increase the value of i because, you want to start from where it found 
                    // a value that is less than or equal to cause you may need same denomination again.
                    // Also because loop will decrement its value again.
                    i++;
                }

                // If n is Zero, that means you found all the denominations. Exit.
                if (n == 0) break;
            }

            // Print the result.
            while (result.Count > 0)
            {
                Console.WriteLine(result.Pop());
            }
        }

        /// <summary>
        /// Q. Find the closest pair from two sorted arrays
        /// Given two sorted arrays and a number x, find the pair whose sum is 
        /// closest to x and the pair has an element from each array.
        /// We are given two arrays ar1[0…m-1] and ar2[0..n-1] and a number x,
        /// we need to find the pair ar1[i] + ar2[j] such that absolute value of (ar1[i] + ar2[j] – x) is minimum.
        /// 
        /// Examples:
        /// Input:  ar1[] = {1, 4, 5, 7};
        ///         ar2[] = {10, 20, 30, 40};
        ///         x = 32      
        ///         Output:  1 and 30
        /// 
        /// Input:  ar1[] = {1, 4, 5, 7};
        ///         ar2[] = {10, 20, 30, 40};
        ///         x = 50      
        ///         Output:  7 and 40
        /// 
        /// APPROACH:
        /// Can we do it in a single pass and O(1) extra space?
        /// 
        /// The idea is to start from left side of one array and right side of another array, 
        /// and use the algorithm same as step 2 of above approach. 
        /// 
        /// Following is detailed algorithm.
        ///     1) Initialize a variable diff as infinite (Diff is used to store the difference between pair and x). 
        ///         We need to find the minimum diff.
        ///     2) Initialize two index variables l and r in the given sorted array.
        ///         (a) Initialize first to the leftmost index in ar1:  l = 0
        ///         (b) Initialize second  the rightmost index in ar2:  r = n-1
        ///     3) Loop while l < m and r >= 0
        ///         (a) If  abs(ar1[l] + ar2[r] - sum) < diff  then update diff and result 
        ///         (b) Else if(ar1[l] + ar2[r] <  sum )  then l++
        ///         (c) Else r--    
        ///     4) Print the result. 
        /// </summary>
        /// <param name="a"></param>
        internal void PrintTheClosestPair(int[] a, int[] b, int x)
        {
            int len1 = a.Length;
            int len2 = b.Length;

            // Empty array
            if (len1 == 0 && len2 == 0) { return; }

            // Initialize the diff between pair sum and x.
            int diff = int.MaxValue;

            // The two closest pair that is less than x
            int t1 = int.MinValue, t2 = int.MinValue;

            // LEft and right runner for loop.
            int left = 0, right = len2 - 1;

            //  Run a loop from left ro right on array 1 and righ to left on array 2
            while (left < len1 && right >= 0)
            {
                // Update the diff and pairs if it's less than the current diff
                if (Math.Abs(x - a[left] + b[right]) < diff)
                {
                    diff = Math.Abs(x - a[left] + b[right]);
                    t1 = a[left];
                    t2 = b[right];
                }

                // If value is greater than x, go to the smaller side
                if (a[left] + b[right] > x)
                {
                    right--;
                }
                // If lesser, go to the bigger side
                else { left++; }
            }

            // The final pairs that is closest to X
            Console.WriteLine("{0} : {1},{2}", x, t1, t2);
        }

        /// <summary>
        /// Q. Print the largest sum that you can form from the given array.
        ///     Array is not sorted and can have negative or positive numbers.
        /// Example: {5,10,-7,5,10,-8,100}
        /// Output:  107 ie sum of {5, 10, -8, 100}
        /// 
        /// Interview Q in Azure - PowerBI
        /// </summary>
        /// <param name="a"></param>
        internal void PrintLargestSum(int[] a)
        {
            int len = a.Length;
            if (len < 0) return;
            if (len == 1)
            {
                Console.WriteLine(a[0]); return;
            }

            // Initialize the sum to be the first element
            int sum = a[0];

            // Temp to store current sum
            int temp = 0;

            // loop until the end of the array
            for (int i = 0; i < len; i++)
            {
                // Add temp with the array value
                temp += a[i];

                // If temp is greater than the sum, Update sum.
                if (temp > sum) sum = temp;

                // If temp is less than Zero, reset temp. 
                if (temp < 0) temp = 0;
            }

            // the max sum is in your 'sum' variable
            Console.WriteLine("The max sum is : {0}", sum);
        }

        /// <summary>
        /// Swaps the array element
        /// </summary>
        /// <param name="arr">Array to be swapped</param>
        /// <param name="i">Swap value 1 </param>
        /// <param name="j">swap value 2</param>
        /// <returns>Array with swapped values.</returns>
        private int[] Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            return arr;
        }

        /// <summary>
        /// Prints an array
        /// </summary>
        /// <param name="arr">Array to be printed.</param>
        private void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Q. Find zeroes to be flipped so that number of consecutive 1’s is maximized
        /// Example: 
        ///     Input:   arr[] = {1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1}
        ///     m = 2
        ///     Output:  5 7
        ///     We are allowed to flip maximum 2 zeroes. If we flip
        ///     arr[5] and arr[7], we get 8 consecutive 1's which is
        ///     maximum possible under given constraints
        ///     
        ///  Approach:
        ///     An Efficient Solution can solve the problem in O(n) time and O(1) space. 
        ///     The idea is to use Sliding Window for the given array. The solution is taken from here.
        ///     Let us use a window covering from index wL to index wR. Let the number of zeros inside the window be zeroCount. 
        ///     We maintain the window with at most m zeros inside.
        ///     The main steps are:
        ///         – While zeroCount is no more than m: expand the window to the right (wR++) and update the count zeroCount.
        ///         - WWhile zeroCount exceeds m, shrink the window from left (wL++), update zeroCount;
        ///         – Update the widest window along the way. The positions of output zeros are inside the best window.
        /// </summary>
        /// <param name="array">Array that needs flipping</param>
        /// <param name="count">Number of Zeros you can flip withing an array</param>
        public void FlipZeros(int[] array, int count)
        {
            // left and right indexes of the widest window
            int wLeft = 0, wRight = 0;

            // Count of zeros in the current window
            int nZero = 0;

            // left & right index and the size of the widest window
            int bestWindowWidth = 0;
            int bestWLeft = 0, bestWRight = 0;

            // While right boundary of current window doesn't cross
            // Right end
            while (wRight < array.Length)
            {
                // If zero count of current window is less than the count
                if (nZero <= count)
                {
                    if (array[wRight] == 0)
                        nZero++;
                    wRight++;
                }
                // If zero count of current window is more than the count
                if (nZero > count)
                {
                    if (array[wLeft] == 0)
                        nZero--;
                    wLeft++;
                }

                // Update the widest window if this window size is more
                if (wRight - wLeft > bestWindowWidth)
                {
                    bestWindowWidth = wRight - wLeft;
                    bestWLeft = wLeft;
                    bestWRight = wRight;
                }
            }

            // Print the positions of zeros in the widest window
            for (int i = 0; i < bestWindowWidth; i++)
            {
                if (array[bestWLeft + i] == 0)
                {
                    Console.WriteLine(bestWLeft + i);
                }
            }
        }

        /// <summary>
        /// Q. Sort an Array such that the odd numbers appear first followed by the even numbers . 
        ///     http://algorithms.tutorialhorizon.com/sort-an-array-such-that-the-odd-numbers-appear-first-followed-by-the-even-numbers-the-odd-numbers-in-ascending-order-and-the-even-numbers-in-descending-order/
        ///     Exam­ple:
        ///     Input Array : 1 2 3 4 5 6 7 8 9 10
        ///     Out­put : 1 3 5 7 9 10 8 6 4 2
        /// </summary>
        /// <param name="array">Unsorted Array.</param>
        public void ArrangeArray(int[] array)
        {
            //int mid = array.Length % 10 == 0 ? array.Length / 2 - 1 : array.Length / 2;

            if (array.Length <= 1)
            {
                Console.WriteLine("Not enough items in an array");
                return;
            }

            Console.Write("Before: ");
            PrintArray(array);

            // You want to swap from beginning of an array to a very last item of an array
            int low = 0;
            int high = array.Length - 1;

            // Start a loop until low is smaller than high index
            while (low < high)
            {
                // Find the even value. Skip if its odd.
                while (array[low] % 2 != 0) low++;

                // Find the odd value. Skip if it's even.
                while (array[high] % 2 == 0) high--;

                // Swap only if low and high do not cross each other. 
                // Exit conditin.
                if (low < high)
                {
                    // Swap the values.
                    array = Swap(array, low, high);
                }
            }

            Console.Write("After: ");
            PrintArray(array);
        }

        /// <summary>
        /// Solution: http://stackoverflow.com/questions/726756/print-two-dimensional-array-in-spiral-order
        ///     The idea is to treat the matrix as a series of layers, top-right layers and bottom-left layers. 
        ///     To print the matrix spirally we can peel layers from these matrix, print the peeled part and recursively call the print on the left over part. 
        ///     The recursion terminates when we don't have any more layers to print.
        /// </summary>
        /// <param name="matrix">Matrix</param>
        public void PrintInSpiralOrder(int[,] matrix)
        {
            // The 0,0 is the starting index
            // The 3, 2 is the max number of rows and columns in the matrix
            PrintTopRightLayer(matrix, 0, 0, 3, 2);//matrix.Length, matrix[0].Length);
            Console.WriteLine();
        }

        /// <summary>
        /// This prints the top right layer.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="x1">Start index</param>
        /// <param name="y1">Start index</param>
        /// <param name="row">Max row left to print</param>
        /// <param name="col">max col left to print</param>
        private void PrintTopRightLayer(int[,] matrix, int x1, int y1, int row, int col)
        {
            int i = 0, j = 0;

            // Print top row. Direction top left -> bottom right
            for (i = y1; i <= col; i++)
            {
                Console.Write(matrix[x1, i] + " ");
            }

            // Print right column. Direction top -> bottom
            for (j = x1 + 1; j <= row; j++)
            {
                Console.Write(matrix[j, col] + " ");
            }

            // Check if there's more items to print. If there's no columns left. We printed them all.
            if (col - y1 > 0)
                PrintBottomLeftLayer(matrix, x1 + 1, y1, row, col - 1);
        }

        /// <summary>
        /// This prints the bottom left layer
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="x1">Start index</param>
        /// <param name="y1">Start index</param>
        /// <param name="row">Max row left to print</param>
        /// <param name="col">max col left to print</param>
        private void PrintBottomLeftLayer(int[,] matrix, int x1, int y1, int row, int col)
        {
            int i = 0, j = 0;

            // Print the bottom row. Direction bottom right -> bottom left
            for (i = col; i >= y1; i--)
            {
                Console.Write(matrix[row, i] + " ");
            }

            // Print the leftmost column. Direction bottom left -> top left 
            for (j = row - 1; j >= x1; j--)
            {
                Console.Write(matrix[j, y1] + " ");
            }

            // Check if there's more items to print. If there's no columns left. We printed them all.
            if ((col - y1) > 0)
            {
                PrintTopRightLayer(matrix, x1, y1 + 1, row - 1, col);
            }
        }
    }
}
