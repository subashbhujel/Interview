using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MS_Preparation_II
{
    class ReverseString
    {
        /// <summary>
        /// Q. Original String : Subash is Reversing the String
        ///    Reversed String : String the Reversing is Subash
        /// </summary>

        //this is to store the final reversed string [word by word reverse]
        String result = "";

        #region String reverse
        /// <summary>
        /// This function reverses the string
        /// </summary>
        /// <param name="str">Original string</param>
        /// <returns>Reversed string</returns>
        public String DoReverse(String str)
        {
            //eg. "AB BC CD" = "CD BC AB"

            //prints the original string
            Console.WriteLine("Original String : " + str);

            //i is initialized to last index of the string so that loop runs from last to first
            int i = str.Length - 1;

            //this is to check if its the end of a word, ie it checks for " ", 
            //Case 1 : when it reaches to first word it won't find any spaces, so it just append the string from ith to kth index
            int k = 0;
            
            bool firstWord = true;
            
            //runs loop till it reaches to the 1 from str.length-1            
            while (i > 0)
            {
                //j = i;
                //Since " " [space] separates the word, it checks if its time to extract the word
                if (str[i].ToString().CompareTo(" ") == 0)
                {
                    //extracts the word of kth length, i+1 is done because i will be pointing to " "
                    //this condition is to check if its the first word or not, bug#earlier solution : didn't maintain spaces before
                    if (firstWord)
                    {
                        result += str.Substring(i + 1, k);
                        result += " ";
                        firstWord = false;
                    }
                    else
                        result += str.Substring(i + 1, k);
                    k = 0; //making it ready for next word
                }                
                --i; //looking for complete word
                ++k; //gathering complete word length
            }
            //handling case 1, for the first word in the original string
            if (i == 0)
            {
                //bug# earlier solution would left a char when single word is passed ie "Subash" = "Subas" , h is lost , Fixed, 
                //maintains trailing spaces and leading spaces ie "subash  " = "  Suabsh" or "  subash"="subash  "
                result += str.Substring(i, k+1);
            }

            //now final result is stored in result
            return "Reversed String : " + result;

            //stringbuilder class to append the string as extracted
        #endregion
        }


        #region REversing words using 
        public string ReverseSentencebywordUsingStringBuilder(string str)
        {
            Console.WriteLine("Original string :" + str);

            int len = str.Length;

            if (len <= 1) return str;
            else if (str == null) return null;
                        
            int i = 0; //index which runs to find out " " [word separation]
            int k = 1; //length of the word
            int j = 0; //starting index while extracting the word

            //String to hold the final reversed string
            StringBuilder strBldr = new StringBuilder();

            //running the loop from 0 to len-1
            while (i < len)
            {
                //checking if a complete word is found, 
                if (str[i].ToString().CompareTo(" ") == 0)
                {
                    //extracts the word of kth length, i+1 is done because i will be pointing to " "                    
                    strBldr.Insert(0, str.Substring(j, k));
                    k = 0;     //word length initialized to 0 for next word
                    j = i + 1; //index where next word starts
                }
                ++i; //looking for complete word again
                ++k; //gathering complete word length
            }

            //handling final word in a sentence
            if (i == len)
            {
                //appending final word
                strBldr.Insert(0, str.Substring(j, k - 1) + " ");
            }
                       
            return strBldr.ToString();

        }
        #endregion

    }
}
