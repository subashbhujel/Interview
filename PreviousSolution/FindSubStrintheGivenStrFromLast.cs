using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class FindSubStrintheGivenStrFromLast
    {
        public int FindPositionOfSubStr(string strToFind)
        {
            //string str="aabcd abc xabcz";
            string str = "a";
            //char c=strToFind[strToFind.Length-1];
            
            int len = str.Length;
            
            for (int i = str.Length - strToFind.Length; i >= 0; --i)//i = i - strToFind.Length)
            { 
                if(strToFind.Equals(str.Substring(i,strToFind.Length)))
                    return i;
            }
            /*
            for (int i = len - 1; i >= 0; --i)
            {
                if (c == str[i])
                {
                    if (str.Substring(i - strToFind.Length + 1, strToFind.Length).Equals(strToFind))
                    {
                        //int rs = i - strToFind.Length + 1;
                        return i - strToFind.Length + 1; ;
                    }
                }
            }*/
            return -1;
        }
    }
}
