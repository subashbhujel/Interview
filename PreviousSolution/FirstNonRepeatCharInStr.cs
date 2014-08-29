using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class FirstNonRepeatCharInStr
    {
        public char FindNoneRepeatChar(String str)
        {
            Char[] charArr = str.ToCharArray();
            int i = 0, j = 0 ;
            //Console.WriteLine(charArr[2]);
            while (i < charArr.Length)
            {
                if (i == 0 && j == 0) ++j;
                //if(charArr.GetValue(i).Equals(charArr.GetValue(j)) && i!=j)
                if (charArr[i]==charArr[j] && i != j)
                {
                    ++i; 
                    j=0;
                    continue;
                }
                if(j == charArr.Length-1) return (char)charArr.GetValue(i);
                ++j;
            }
            Console.WriteLine("No matches Found ! !");
            return ' ';
        }
    }
}
