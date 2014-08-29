using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class ConvertIntToStr
    {
        public int ChangeToInt(string str)
        {
            // "-123" = -123
            
            int result=0;
            int len = str.Length;
            int startIndex = 0;
            
            if(str[0]=='-')
                startIndex = 1;
            
            for (int i = startIndex; i < len; ++i)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    result = result * 10 + str[i] - '0';
                }
                else
                    throw new Exception("Exception Thrown !");
            }
            
            if (startIndex == 1)
                result *= (-1);

            return result;
        }

        public string ChangeToStr(int val)
        {
            StringBuilder str = new StringBuilder();
            
            int index = 0;
            int temp = val;            
            
            if (val < 0)
            {
                str.Insert(index,"-");
                index = 1;
            }

            while (true)
            {                
                str = str.Insert(index, Math.Abs(temp % 10));
                temp = temp / 10;
                if (temp == 0) break;
            }
            return str.ToString();
        }
    }
}
