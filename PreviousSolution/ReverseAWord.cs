using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class ReverseAWord
    {
        /// <summary>
        /// This program 
        /// </summary>
        char[] charArr =new char[0];

        public void DoReverse(String word)
        {
            int len=word.Length;

            if(len == 0) return;
            if (len == 1)
            {
                charArr = word.ToCharArray();
                return;
            }
            
            int i = 0;
            int j = len-1;
            this.charArr = word.ToCharArray();
            
            while (i < j)
            {   
                Swap(i,j);
                ++i; --j;             
            }
            //return charArr;
        }

        public void Swap(int i,int j)
        {
            char temp;
            temp=charArr[i];
            charArr[i]=charArr[j];
            charArr[j]=temp;
        }

        public void PrintWord()
        {
            if (charArr.Length==0) return;
            Console.Write("Reversed Word : ");
            for (int i = 0; i < charArr.Length; ++i)
            {
                Console.Write(charArr[i]);
            }        
        }
    }
}
