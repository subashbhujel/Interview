namespace InterviewPreparation
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;

    /// <summary>
    /// All numeric, array and string operations
    /// </summary>
    class StringOperation
    {
        /// <summary>
        /// Interview: MSFT, Order management service.
        /// Input: Bana#na
        /// Keys: abc
        /// Output: aaabn#n
        /// Note: Chars that are not keys, should be arranged after the ones that matches the key in order.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="keys">Keys</param>
        /// <returns>Sorted string</returns>
        public string ArrangeStringUsingKeys(string input, string keys)
        {
            StringBuilder result = new StringBuilder();

            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (string.IsNullOrEmpty(keys))
                return input;

            // Keep all keys here
            Hashtable keysHash = new Hashtable();

            //Keey all chars and it's number of occurances here from "input" string
            Hashtable hashtable = new Hashtable();

            // Stores all characters in order it appeared in input that is NOT a key
            Queue<char> q = new Queue<char>();

            // Keep all keys in hash
            foreach (char c in keys)
            {
                keysHash[c] = 0; // initialized to zero for no reason. No use of it in this program.
            }

            // run it through each character in an input string
            foreach (char c in input)
            {
                // Check if this character is a key! // Put it in a queue if it is.
                if (!keysHash.ContainsKey(c))
                {
                    q.Enqueue(c);
                }
                else // Put it in hashtable if it's a key.
                {
                    // If it was previously added, increment it's count that reflects its occurances.
                    if (hashtable.ContainsKey(c))
                    {
                        int count = Convert.ToInt32(hashtable[c]);
                        hashtable[c] = ++count;
                    }
                    else // Add it to the table if it doesn't already exist.
                    {
                        hashtable[c] = 1;
                    }
                }
            }

            // If there's nothing on the hashtable, no need to loop through.
            if (hashtable.Count > 0)
            {
                // Go thorugh each key, value in a hashtable that has key and its count ie the number of occurances
                foreach (DictionaryEntry entry in hashtable)
                {
                    // Add it to the result the number of time it occured in an input array.
                    for (int i = 0; i < Convert.ToInt32(entry.Value); i++)
                    {
                        result.Append(entry.Key);
                    }
                }
            }

            // Now add the remaining characters from the queue. Thse are those characters that didn't match the keys.
            if (q.Count > 0)
            {
                while (q.Count > 0)
                {
                    result.Append(q.Dequeue());
                }
            }

            // Return the result.
            return result.ToString();

        }

        /// <summary>
        /// you are given n-strings 
        ///     1. you have to find whether a chain can be termed with all the strings given number n? 
        ///         A chain can be formed b/w strings if last char of the 1st string matches with 1st char of second string. 
        /// 
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
        /// Q. In an array with integers between 1 and 1,000,000 one value is in the array twice. How do you determine which one?  
        /// http://stackoverflow.com/questions/7500974/in-an-array-with-integers-one-value-is-in-the-array-twice-how-do-you-determine
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
            catch (Exception e)
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

        /// <summary>
        /// Given a string, find the longest substring which is palindrome. For example, if the given string is “forgeeksskeegfor”, the output should be “geeksskeeg”.
        ///Method 1 ( Brute Force )
        /// The simple approach is to check each substring whether the substring is a palindrome or not. We can run three loops, 
        /// the outer two loops pick all substrings one by one by fixing the corner characters, the inner loop checks whether the picked substring is palindrome or not.
        /// Time complexity: O ( n^3 )
        /// Auxiliary complexity: O ( 1 )
        ///Method 2 ( Dynamic Programming )
        /// The time complexity can be reduced by storing results of subproblems. The idea is similar to this post. 
        /// We maintain a boolean table[n][n] that is filled in bottom up manner. The value of table[i][j] is true, if the substring is palindrome, otherwise false. 
        /// To calculate table[i][j], we first check the value of table[i+1][j-1], if the value is true and str[i] is same as str[j], then we make table[i][j] true. 
        /// Otherwise, the value of table[i][j] is made false.
        /// 
        /// http://www.geeksforgeeks.org/function-to-check-if-a-singly-linked-list-is-palindrome/
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
