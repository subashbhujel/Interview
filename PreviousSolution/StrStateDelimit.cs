using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class StrStateDelimit
    {
        //each call should return the next string 
        //eg "This is the string to be returned"
        //1st call = this , 2nd call : is , 3rd call = the
        //The function should know which was returned before, and second call may pass (null,"")
        
        string value = "";
        int from;
        
        public String FindNextWord(String str, String delimiter)
        {            
            this.value = str;

            if (str != null)
            {
                int i = 0;
                int j = i;
                while (i != str.Length - 1)
                {
                    if (str[i].ToString().CompareTo(" ")==0) 
                    {
                        //Console.WriteLine("Loop Executed !");
                        this.from = i;
                        return str.Substring(j, i); 
                    }
                    ++i;
                    if (i == str.Length - 1)
                        return str;
                }
            }
            else if (str == null)
            {
                if (value != "") return null;

                int i = from;
                int j = i;

                while(i != str.Length)
                {
                    if (str[i].Equals(delimiter))
                    {
                        this.from = i;
                        return str.Substring(j, i-j);
                    }
                    ++i;
                }
            }
            return null;            
        }
    }
}
