using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class CombinationOfChars
    {
        public void combineChars(String str)
        {
            char[] charArr = str.ToCharArray();
            int len = str.Length;
            char[] temp = new char[len+1];

            DoCombine(charArr,temp,len,0,0);

        }
        public void DoCombine(char[] inArr, char[] outArr, int length, int recurLen, int start) 
        {
            for (int i = start; i < length; i++)
            {
                outArr[recurLen] = inArr[i];
                outArr[recurLen+1]=' ';
                foreach (char c in outArr)
                    if (c != ' ')
                        Console.Write(c);
                    else
                        Console.WriteLine();
                if (i < recurLen - 1)
                    DoCombine(inArr, outArr, length, recurLen + 1, i + 1);
            }
        }
    }
}
