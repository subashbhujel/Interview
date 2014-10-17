namespace InterviewPreparation
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// All numeric, array and string operations
    /// </summary>
    class StringOperation
    {
        /// <summary>
        /// string x = "1..5,8,11..14,18,20,26..29" 
        ///         string y = "1,2,3,4,5,8,11,12,13,14,18,20,26,27,28,29"
        /// Write a program to expand a given string x to y.
        /// </summary>
        /// <param name="str"></param>
        public void ExpandTheString(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || str == string.Empty)
            {
                Console.WriteLine("Invalid String.");
                return;
            }

            Console.WriteLine("Original String: " + str);

            // Split the string with '.' character that will give something
            // Note: After you split you get an empty element. My guess its for the element between ..
            string[] strArr = str.Split('.');

            int pre = int.MinValue;

            foreach (string s in strArr)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n*************");

            foreach (string s in strArr)
            {
                // check if its NOT an empty 
                if (s != string.Empty)
                {
                    if (s.Contains(","))
                    {
                        string[] arr2 = s.Split(',');

                        for (int i = pre + 1; i <= Convert.ToInt32(arr2[0]); i++)
                        {
                            Console.WriteLine(i);
                        }
                        for (int i = 0; i < arr2.Length; i++)
                        {
                            if (i == 0) continue;
                            Console.WriteLine(arr2[i]);
                        }
                        pre = Convert.ToInt32(arr2[arr2.Length - 1]);
                    }
                    else
                    {
                        Console.WriteLine(s);
                        pre = Convert.ToInt32(s);
                    }
                }
            }
        }

        /// <summary>
        /// "Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?"
        /// For eg: "ABCDEF" = True
        ///  ABCDEFA = FALSE
        ///  ACBDEFF = FALSE
        ///  SUBAH= True
        /// </summary>
        /// <param name="str"></param>
        public bool FindIfStringHAsUniqueChars(string str)
        {
            // Its a tricky solution:
            // Check if the position of each character of string is the last position of that string. If not, that string does NOT have unique chars
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || str == string.Empty)
            {
                Console.WriteLine("Invalid String.");
                return false;
            }

            bool isUnique = false;

            foreach (char c in str)
            {
                if (str.IndexOf(c) == str.LastIndexOf(c))
                {
                    isUnique = true;
                    continue;
                }
                else
                {
                    isUnique = false;
                    break;
                }
            }
            return isUnique;
        }

        /// <summary>
        /// Rearrange an array using swap with 0. 
        /// You have two arrays src, tgt, containing two permutations of the numbers 0..n-1. 
        /// You would like to rearrange src so that it equals tgt. The only allowed operations is “swap a number with 0”, e.g. {1,0,2,3} -> {1,3,2,0} (“swap 3 with 0”). 
        /// Write a program that prints to stdout the list of required operations.
        /// Practical application: Imagine you have a parking place with n slots and n-1 cars numbered from 1..n-1. 
        /// The free slot is represented by 0 in the problem. If you want to rearrange the cars, you can only move one car at a time into the empty slot, which is equivalent to “swap a number with 0”.
        /// Example: src={1,0,2,3}; tgt={0,2,3,1};
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void RearrangeArrayBySwappingWithZero(int[] source, int[] destination)
        {
            // Example: src={1,0,2,3}; tgt={2,1,3,0};           
            // Approach : 
            //            The question does not require the minimum swap number.
            //  So, an easy way to do is, find the index of first does not match (except ZERO),
            //  then swap ZERO with it, then swap ZERO with the tgt value of that index.
            //  Just loop for all positions. Then, it is done.
            //  eg. {0, 1, 2} -> {0, 2, 1}
            //  first does not match index is 1, and tgt value is 2.
            //  So, {0, 1, 2}-> {1, 0, 2}->{1, 2, 0}
            //If it require the minimum swap number, then, shortest path algorithm will resolve it.
            //Every permutation is one node, and all possible links are just a swap of ZERO.
            //For performance improvement, A* can be used.
            //So, never swap ZERO with any value that matched already.
            //And it is better to generate nodes in run time.

            if (source == null || destination == null)
                return;

            int len1 = source.Length, len2 = destination.Length;

            if (len1 <= 0 || len2 <= 0)
            {
                Console.WriteLine("Invalid Input.");
                return;
            }

            //Find an index of Zero in Source
            int indexOf0 = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == 0)
                {
                    indexOf0 = i;
                    break;
                }

            }
            Console.WriteLine("Source Array: ");
            Print(source);

            Console.WriteLine("Desrination Array: ");
            Print(destination);

            Queue<string> operations = new Queue<string>();

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != destination[i] && destination[i] != 0)
                {
                    // Swap with Zero
                    operations.Enqueue(string.Format("Swap {0} with 0", source[i]));
                    source = Swap(source, i, indexOf0);
                    indexOf0 = i;

                    // Swap with target value                    
                    int targetValueIndexInSource = FindTargetIndex(source, destination[i]);

                    operations.Enqueue(string.Format("Swap {0} with 0", source[targetValueIndexInSource]));
                    source = Swap(source, indexOf0, targetValueIndexInSource);
                    indexOf0 = targetValueIndexInSource;
                }
            }

            while (operations.Count != 0)
            {
                Console.WriteLine(operations.Dequeue());
            }

            Print(source);
        }

        /// <summary>
        /// Swap the value in a given range
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int[] Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            return arr;
        }

        private int FindTargetIndex(int[] arr, int n)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == n)
                { return i; }
            }
            return -1;
        }

        public void FindASqRoot(float num)
        {
            if (num <= 0)
            {
                Console.WriteLine("Invalid input. Please enter non-negative number.");
                return;
            }

            float result = 1;

            while ((result * result - num) > 0.000001 || (num - result * result) > 0.000001)
            {
                result = (result + num / result) / 2;
                Console.WriteLine("New value: " + result);
            }

            Console.WriteLine(string.Format("Square root of {0} is : {1}", num, result));
        }

        /// <summary>
        /// you are given n-strings 1you have to find whether a chain can be termed with all the strings given number n? 
        /// A chain can be formed b/w strings if last char of the 1st string matches with 1st char of second string. 
        /// For example you are given
        ///         number of strings = 3
        ///     first string=sdfg
        ///     second string=dfgs
        ///     third string=ghjhk
        ///     they can be concatenated as ->
        ///     second first third
        ///     dfgs sdfg ghjhk(characters at concatenation points are same)
        ///     so concatenated string is-dfgsdfghjhk
        /// 
        /// Assumptions:
        ///     1. As soon as "nuber of Strings" is satisfied, program exits. ie it doesn't bother checking mroe string in an array.
        /// 
        /// // NOT SOLVED YET!!
        /// </summary>
        public string ConcatSrting(string[] strArr, int numOfStrings)
        {
            if (null == strArr || strArr.Length < 1 || numOfStrings <= 0)
            {
                return null;
            }

            int len = strArr.Length;

            if (len == 1 || numOfStrings == 1)
            {
                return strArr[0];
            }

            char startingChar, endingChar;

            // Storing the final strings to be concatenated
            Queue<string> list = new Queue<string>();

            for (int i = 0; i < strArr.Length; i++)
            {
                startingChar = strArr[i][0];
                endingChar = strArr[i][strArr[i].Length - 1];

                list.Enqueue(strArr[i]);

                for (int j = i + 1; j < strArr.Length; j++)
                {
                    if (endingChar == strArr[j][0])
                    {
                        list.Enqueue(strArr[j]);
                    }
                }

                if (strArr[i] != string.Empty)
                {
                    list.Enqueue(strArr[i]);
                    strArr[i] = string.Empty;
                }
            }

            //char[] startingChars = new char[len];
            //char[] endingChars = new char[len];

            //Dictionary<char, char> startEndChars = new Dictionary<char, char>();

            //for (int i = 0; i < len; i++)
            //{
            //    startingChars[i] = strArr[i][0];
            //    endingChars[i] = strArr[i][strArr[i].Length - 1];

            //    startEndChars.Add(startingChars[i], endingChars[i]);
            //}
            string concatStr = string.Empty;

            return concatStr;
        }

        /// <summary>
        /// NOT SOLVED YET!!
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int CompareTwoIntWithBitwiseOpe(int a, int b)
        {
            int diff = a - b;

            //if ((diff 0) == 0)
            //{

            //}

            return 1;
        }

        /// <summary>
        /// Find the median of 3 numbers. for eg: 3, 2, -1 = 2; 10,0,15 = 10;etc
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int FindMedianOf3Nums(int a, int b, int c)
        {
            if (a == b && b == c)
                return a;

            int[] arr = new int[3];

            // Assigning 1st value to the first slot of an array 
            arr[0] = a;

            // for swapping the value
            int temp = 0;

            // Second number is Greater than or equals to the first. for eg. {2, 3, -1} or {3, 3, -1}
            if (b >= arr[0])
            {
                arr[1] = b;
            }
            // second number is Greater than the first. for eg. {3, 2, -1}
            else if (b < arr[0])
            {
                arr[0] = b;
                arr[1] = a;
            }

            // Third number is Greater than the second. for eg. {3, 2, 5}. 
            // NOte: No need to check if its greater than first because first two are already sorted!
            if (c > arr[1])
            {
                arr[2] = c;
            }
            // Checking if third number is LESS than the first. for eg. {3, 2, -1}. 
            // NOte: No need to check if its greater than SECOND because first two are already sorted!
            else if (c < arr[0])
            {
                temp = arr[0];
                arr[0] = c;
                arr[2] = arr[1];
                arr[1] = temp;
            }
            // Checking if third number is GREATER or EQUAL than the first & LESS or EQUAL than the second. For eg. {3, 1, 2}. 
            // Also handles these cases {2, 1, 1} and {2, 1, 2}
            else if ((c > arr[0] && c < arr[1]) || c == arr[0] || c == arr[1])
            {
                temp = arr[1];
                arr[1] = c;
                arr[2] = temp;
            }

            // Your mid number is always in the center 
            return arr[1];
        }

        /// <summary>
        /// {1 2 3 4 5} -> {3 4 5 1 2} rotated by 2
        /// </summary>
        /// <param name="arr"></param>
        public void RotateAnArray(int[] arr, int rotateBy)
        {
            // Pseudo code:
            // A = 1 2 3 4 5 , rotateBy = 2
            // A' = 5 4 3 2 1 = B
            // B' (0, a.length - rotateBy) = 3 4 5 2 1 = C
            // C' (a.length - rotateBy, rotateBy) = {3 4 5 1 2}  
            // Return

            if (arr == null || rotateBy <= 0 || rotateBy > arr.Length || arr.Length <= 1)
            {
                Console.WriteLine("Invalid Input. Please try again with different value.");
                return;
            }

            int len = arr.Length;

            arr = ReverseCertainPosition(arr, 0, arr.Length - 1);
            arr = ReverseCertainPosition(arr, 0, (arr.Length - 1) - rotateBy);
            arr = ReverseCertainPosition(arr, arr.Length - rotateBy, arr.Length - 1);

            Print(arr);
        }

        /// <summary>
        /// Helper method for the reversing certain position of an array
        /// </summary>
        /// <param name="arr">Array to be reversed</param>
        /// <param name="start">Starting index for reversal</param>
        /// <param name="end">Ending index for reversal</param>
        /// <returns></returns>
        public int[] ReverseCertainPosition(int[] arr, int start, int end)
        {
            int temp;

            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }

            return arr;
        }

        /// <summary>
        /// Q : Reverse a string 
        /// </summary>
        /// <param name="word">String to be reversed.</param>
        /// <returns>Reversed string</returns>
        public string ReverseString(string word)
        {
            if (word == string.Empty || word == null)
                return string.Empty;

            int strLen = word.Length;

            Console.Write("Before: ");
            Print(word.ToCharArray());
            Console.Write("After: ");

            char[] reversedStr = null;

            if (strLen == 1)
            {
                Print(word.ToCharArray());
            }
            else
            {
                int midLen = 0;

                bool isEven = (strLen % 2 == 0) ? true : false;
                midLen = isEven ? (strLen / 2) - 1 : strLen / 2;

                int i = 0;
                int j = strLen - 1;

                char temp;

                reversedStr = word.ToCharArray();

                for (i = 0; i < midLen; ++i)
                {
                    if (j >= midLen)
                    {
                        temp = reversedStr[i];
                        reversedStr[i] = reversedStr[j];
                        reversedStr[j] = temp;
                        --j;
                    }
                }

                if (strLen % 2 == 0)
                {
                    temp = reversedStr[i];
                    reversedStr[i] = reversedStr[j];
                    reversedStr[j] = temp;
                }

                Print(reversedStr);
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < reversedStr.Length; i++)
            {
                sb.Append(reversedStr[i].ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        ///  Prints a Char array
        /// </summary>
        /// <param name="arr"></param>
        public void Print(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints an integer array
        /// </summary>
        /// <param name="arr"></param>
        public void Print(int[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(string.Format("[{0}] - {1}", i, arr[i]));
            }

        }

        /// <summary>
        /// Given s string, Find max size of a sub-string, in which no duplicate chars present.
        /// </summary>
        /// <param name="str"></param>
        public void FindLongestNonrepeatingChars(string str)
        {
            // DOESN'T WORK!!!

            if (str == null || string.IsNullOrEmpty(str))
            { return; }

            str = str.Trim();
            str = str.ToLower();

            if (str.Length == 1)
            {
                Console.WriteLine("Longest non repeating char is:" + str);
                return;
            }

            string longestSoFar = string.Empty;
            string longestSubString = string.Empty;

            Dictionary<char, int> d = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (longestSoFar.IndexOf(c) == -1)
                {
                    if (!d.ContainsKey(c))
                    {
                        d.Add(c, i);
                    }
                    longestSoFar = longestSoFar + c;
                }
                else
                {
                    longestSoFar = str.Substring(d[c] + 1, i + 1);
                    d.Add(c, i);
                }

                if (longestSoFar.Length > longestSubString.Length)
                    longestSubString = longestSoFar;
            }

            Console.WriteLine("Longest non repeating char is:" + longestSubString);
        }

        /// <summary>
        /// Q. Return a sorted string with non-repeated characters from a given array of strings
        /// eg . {"and","dan","tar"} => "adnrt"
        /// Solution below doesn't sort the characters right now.
        /// </summary>
        /// <param name="str"></param>
        public void SortAString(string[] str)
        {
            string[] temp = str;
            string element = string.Empty;
            char[] arr;
            int count = 0;

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < temp.Length; i++)
            {
                arr = temp[i].ToCharArray();

                for (int j = 0; j < arr.Length; j++)
                {
                    if (dictionary.ContainsKey(arr[j]))
                    {
                        count = ++dictionary[arr[j]];
                        dictionary.Remove(arr[j]);
                        dictionary.Add(arr[j], count);
                    }
                    else
                    {
                        dictionary.Add(arr[j], 1);
                    }
                }
            }


            foreach (KeyValuePair<char, int> ele in dictionary)
            {
                Console.WriteLine(ele.Key + " : " + ele.Value);
            }


        }

        /// <summary>
        /// Q. Input is any number like 1001, return it as "One Thousand and one"
        /// </summary>
        /// <param name="number"></param>
        public string NumberToWord(int number)
        {
            /// Limitation: 
            /// 1. This resolves only up to Million. 
            ///     If you want Billion then int has to be converted to double type 
            /// 2. This doesn't solves the decimal numbers
            string[] ones = { " ", " One ", " two ", " Three ", " four ", " five ", " six ", " seven ", " eight ", " nine ", " ten ", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { " ", " ten ", " twenty ", " thirty ", " fourty ", " fifty ", " sixty ", " seventy ", " eighty ", " ninety " };
            string[] thousand = { " thousand ", " Million " };

            if (number == 0) return ones[0];

            //Taking care of negative number
            bool isNegative = false;

            if (number < 0)
            {
                number *= -1;
                isNegative = true;
            }

            // Pseudo COode:
            // a. Split numbers into 3 digit sections
            // b. Give it a word
            // c. Add billion, million or thousands depending on which level its on
            // d. Iterate

            int[] numSplit = { 0, 0, 0, 0 };
            numSplit[2] = number / 1000000;
            numSplit[1] = (number % 1000000) / 1000;
            numSplit[0] = number % 1000;

            string finalWord = string.Empty;
            Console.WriteLine("Input : " + number);

            for (int i = numSplit.Length - 1; i >= 0; i--)
            {
                if (numSplit[i] == 0) continue;

                //Console.WriteLine(string.Format("[{0}] = {1}", i, numSplit[i]));

                int hundred = numSplit[i] / 100;
                int ten = (numSplit[i] % 100) / 10;
                int one = numSplit[i] % 10;

                bool oneDone = false;

                if (hundred != 0)
                {
                    finalWord += ones[hundred] + " hundred ";
                }
                if (ten > 0)
                {
                    if (ten < 2)
                    {
                        if (one > 0)
                            finalWord += ones[10 + one];
                        else if (one == 0)
                            finalWord += ones[10];
                        oneDone = true;
                    }
                    else
                        finalWord += tens[ten];
                }
                if (one > 0 && !oneDone)
                {
                    finalWord += ones[one];
                }
                if (i > 0)
                {
                    if (i == 2)
                        finalWord += thousand[1];
                    else if (i == 1)
                        finalWord += thousand[0];
                }
                //Console.WriteLine(string.Format(" hundred: {0} ten: {1} one: {2}", hundred, ten, one));
            }

            if (isNegative)
                return "Minus " + finalWord;

            return finalWord;

        }

        /// <summary>
        /// Q. In an array with integers between 1 and 1,000,000, only one value is in the array twice. How do you determine which one?  
        /// </summary>
        /// <param name="arr"></param>
        public void FindADuplicateNumber()
        {
            int[] arr = CreateAnArray(50);
            Print(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        Console.WriteLine("\nPosition " + i + " and " + j);
                        Console.WriteLine("\nThe Duplicate Value is: " + arr[i]);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Creates an array
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private int[] CreateAnArray(int size)
        {
            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                //Sleeoing for split of a second because it was returning same random number everytime.
                Thread.Sleep(TimeSpan.FromMilliseconds(1));

                arr[i] = new Random().Next(1000000);
            }

            arr[size - new Random().Next(size / 2)] = arr[size - new Random().Next(size / 3)];
            return arr;
        }

        /// <summary>
        ///  There is an island which is represented by square matrix NxN.
        /// A person on the island is standing at any given co-ordinates(x, y). He can move in any direction one step right, left, up, down on the island.If he steps outside the island, he dies. 
        /// Let island is represented as (0,0) to(N-1, N-1) (i.e NxN matrix) & person is standing at given co-ordinates(x, y). He is allowed to move n steps on the island(along the matrix). 
        /// What is the probability that he is alive after he walks n steps on the island?
        /// Write a psuedocode & then full code for function 
        /// " float probabilityofalive(int x,int y, int n) ".
        /// </summary>
        public void Matrix()
        {
            int[,] island = CreateanIsland(3, 3);

            int probability = 4;

            //person 
            int x = 1, y = 1;
            Console.WriteLine(string.Format("Person is at [{0}][{1}]\n", x, y));
            int person = island[x, y];

            // Up
            if (!MovePossible(island, x - 1, y))
            { probability--; }

            //Down
            if (!MovePossible(island, x + 1, y))
            { probability--; }

            //Right
            if (!MovePossible(island, x, y + 1))
            { probability--; }

            //Left
            if (!MovePossible(island, x, y - 1))
            { probability--; }

            Console.WriteLine("Probability of a man getting out alive is :" + probability * 25 + "%");
        }

        private bool MovePossible(int[,] island, int m, int n)
        {
            try
            {
                Console.Write(string.Format("[{0}][{1}]", m, n));
                int temp = island[m, n];
            }
            catch (Exception)
            {
                Console.WriteLine(" - Dead! \n");
                return false;
            }
            Console.WriteLine("- Alive! \n");
            return true;
        }

        private int[,] CreateanIsland(int m, int n)
        {
            int[,] island = new int[m, n];
            int val = 1;
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    island[row, col] = val++;
                }
            }

            return island;
        }

        public void PrintAMatrix(int row, int col)
        {
            int[,] matrix = CreateanIsland(row, col);
        }

        public void FindUniqueChars(string str)
        {
            // "aabccdeeffgggggghhijkkkkl"
            // String has to be sorted or have them sorted
            char[] a = str.ToCharArray();
            Array.Sort(a);

            Console.WriteLine("Original String: " + str);

            char[] temp = a;
            int i = 0, j = i + 1;

            while (j < temp.Length)
            {
                if (temp[i] != temp[j])
                {
                    ++i;
                    temp[i] = temp[j];
                }
                j++;
            }

            for (j = 0; j <= i; j++)
            {
                Console.WriteLine(a[j]);
            }
        }

        public bool IsPalindrome(string str)
        {
            if (str == null || string.IsNullOrEmpty(str))
            { return false; }

            str = str.Trim();
            str = str.ToLower();

            Console.WriteLine(str);
            int len = str.Length;

            if (len == 1)
                return true;
            Array.Reverse(str.ToCharArray());

            foreach (char c in str)
                Console.WriteLine(c);

            int mid = len / 2;
            int j = len - 1;

            int loop = len % 2 == 0 ? mid : mid - 1;

            for (int i = 0; i < loop; i++)
            {
                if (str[i] != str[j])
                    return false;
                --j;
            }
            return true;
        }

        public string FindLongestPalindrome(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            { throw new InvalidOperationException(); }

            string longestPalin = str[0].ToString();

            string reveredStr = ReverseString(str);

            if (str == reveredStr || str.Length == 1)
                return reveredStr;

            StringBuilder temp = new StringBuilder();
            string temp2 = string.Empty;
            bool flag = false;
            int subStrlen = 2, j = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                while (j < reveredStr.Length - 1)
                {
                    if (str.Substring(i, subStrlen) == reveredStr.Substring(j, subStrlen))
                    {
                        temp2 = str.Substring(i, subStrlen);
                        subStrlen++;
                        flag = true;
                        continue;
                    }

                    if (IsPalindrome(temp2) && flag == true)
                    {
                        if (temp2.Length > longestPalin.Length)
                            longestPalin = temp2;
                    }
                    if (!flag)
                    {
                        j++;
                    }
                    else
                    {
                        j = 0;
                        subStrlen = 2;
                        flag = false;
                        break;
                    }
                }

            }
            return longestPalin;
        }
    }

}
