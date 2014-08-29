using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class StrToNum
    {
        public void ChangeStrToInt(string str)
        {
            int rs = 0,tmp=0;
            for (int i = 0; i < str.Length; ++i)
            {
                rs = rs * 10 + str[i] - '0';
            }
            Console.WriteLine("String str's int value is : "+rs);
        }
    }
}
