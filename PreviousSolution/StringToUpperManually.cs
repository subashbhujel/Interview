using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class StringToUpperManually
    {
        public string ToUpper(string str)
        {
            char[] chrArr = str.ToCharArray();
            
            StringBuilder newStr = new StringBuilder();
            char c;
            
            for (int i = 0; i < chrArr.Length; ++i)
            {
                if (chrArr[i] >= 'a' && chrArr[i] <= 'z')
                {
                    c = (char)(chrArr[i] - 32);
                    //Console.Write(c);

                    newStr.Append(c);
                }
                else //if (chrArr[i] >= 'A' && chrArr[i] <= 'Z')
                {
                    newStr.Append(chrArr[i]);
                }
            }
            return newStr.ToString();
        }
    }
}
