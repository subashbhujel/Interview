using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class ReplaceStrWithoutAnyAPI
    {
        //replace is with are
        //"This is Sunday" = "Thare are sunday" 
        string finalStr;

        public string ReplacePartOfStringLiberal(string str, string replaceThis,string replaceWith)
        {
            int len = str.Length;

            if (len < 1 || len == 1)
                return str;
            
            int i = 0;
            string toCheck = "";
            this.finalStr = "";
            //for (i = 0; i < len; ++i)
            while(i<len)
            {
                //toCheck = str.Substring(i, 1);
                if (str[i] == replaceThis[0])
                {
                    if (replaceThis == str.Substring(i, replaceThis.Length))
                        finalStr += replaceWith;
                    i = i + replaceThis.Length;
                }
                else
                {
                    finalStr += str[i];
                    ++i;
                }
                if (i == len)
                    break;
            }
            return finalStr;
        }
        
        //can't use substring or any other API's
        public string ReplacePartOfString(string str, string replaceThis, string replaceWith)
        {
            int len = str.Length;

            if (len < 1 || len == 1)
                return str;

            int i = 0;
            
            string toCheck = "";
            
            string tmpStr;

            this.finalStr = "";
            
            while (i < len)
            {
                //toCheck = str.Substring(i, 1);
                if (str[i] == replaceThis[0])
                {
                    //j = i+1;
                    tmpStr = "";
                    tmpStr = str[i].ToString() + str[i + 1].ToString(); //to extract "is"

                    if (replaceThis == tmpStr)
                        this.finalStr += replaceWith;
                    i = i + replaceThis.Length;
                }
                else
                {
                    this.finalStr += str[i];
                    ++i;
                }
                if (i == len)
                    break;
            }
            return this.finalStr;
        }
    }
}
