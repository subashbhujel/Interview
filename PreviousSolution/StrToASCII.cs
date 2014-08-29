using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class StrToASCII
    {
        public void stringToASCII(String str) 
        {
            int val = 0, num = 0 ;

            foreach (char c in str) {
                num *= 10;
                val=System.Convert.ToInt32(c);
                num += val;
                Console.WriteLine(c+" : "+ val+" num :" + num);
            }
            Console.WriteLine("Final String to int ASCII value is :  " + num);
            Console.ReadLine();
        }
    }
}
