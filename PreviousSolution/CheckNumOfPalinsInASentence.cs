using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class CheckNumOfPalinsInASentence
    {
        public int CountPalindromes(string sentence)
        {
            if (sentence.Length <= 1)// || sentence.Length == 1)
            {
                Console.WriteLine("Few or NO words !");
                return -1;
            }
            string tempStr =  sentence.ToLower(); // converting all to lowercase because 'D'=='d' is false !
            string[] strArr = tempStr.Split(' '); // changing sentence to string array separating with space
            
            int count = 0;//for number of palindrome in a sentence
            int j;
            int k;
            int flag; //to check if particular word is palindrome of not
            string str;
            
            for (int i = 0; i < strArr.Length; ++i)
            {
                str = strArr[i];
                k = str.Length - 1;

                j = 0;

                //Discarding word length of 1
                if (k+1 > 1)
                {
                    flag = 0;
                    //checking for particular word if its a palindrome
                    while(j<k)
                    {
                        if (str[j] != str[k]) // word is NOT a palindrome
                        {
                            flag = 0;
                            break;
                        }
                        else
                        {
                            --k; ++j;
                            flag = 1;
                        }
                    }
                    //Word is a palindrome !
                    if(flag==1) ++count;
                }
            }
            return count;
        }
    }
}
