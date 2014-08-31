using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MS_Preparation_II
{
    class PhoneDictionery
    {
        public void GenerateStringValOfPhNumber(int[] phNumbers)
        {
            //2260006
            Hashtable hashTable = new Hashtable();
            hashTable.Add(2, "ABC");
            hashTable.Add(3, "DEF");
            hashTable.Add(4, "GHI");
            hashTable.Add(5, "JKL");
            hashTable.Add(6, "MNO");
            hashTable.Add(7, "PRS");
            hashTable.Add(8, "TUV");
            hashTable.Add(9, "WXY");            
            
            Random ranNum = new Random();
            String str;
            //Console.WriteLine(phNumbers.GetValue);
            foreach (int i in phNumbers)
            {
                int num;

                if (i != 0 && i != 1)
                {
                    num = ranNum.Next(0, 3);
                    //Console.WriteLine(num);
                    str = (String)hashTable[i];
                    //Console.WriteLine(str+" : "+str.Length);
                   Console.Write(str[num]);
                }
                else
                    Console.Write(i);
            }
            
        }
    }
}
