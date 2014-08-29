using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MS_Preparation_II
{
    class FindStringInArrOfStringIfMatches
    {
        public string[] FindStrInArr(string[] strArr, string matchingStr)
        {
            int len = strArr.Length;
            int flag = 0;

            ArrayList finalStr = new ArrayList();

            //"*abd"
            if (matchingStr[0] == '*' && matchingStr[matchingStr.Length - 1] != '*')
                flag = 0;
            //"abc*"
            else if (matchingStr[0] != '*' && matchingStr[matchingStr.Length - 1] == '*')
                flag = 1;
            //*abc*
            else if (matchingStr[0] == '*' && matchingStr[matchingStr.Length - 1] == '*')
                flag = 2;

            string tempStr = "", tempStr2 = "";

            switch (flag)
            {
                case 0:
                    for (int i = 0; i < len; ++i)
                    {
                        tempStr = matchingStr.Substring(1, matchingStr.Length - 1);
                        tempStr2 = strArr[i].Substring(strArr[i].Length - (matchingStr.Length - 1));

                        if (tempStr == tempStr2)
                            finalStr.Add(strArr[i]);
                    }
                    break;
                case 1:
                    for (int i = 0; i < len; ++i)
                    {
                        tempStr = matchingStr.Substring(1, matchingStr.Length - 1);
                        tempStr2 = strArr[i].Substring(strArr[i].Length - (matchingStr.Length - 1));

                        if (tempStr == tempStr2)
                            finalStr.Add(strArr[i]);
                    }
                    break;

                case 2:
                    //.....
                    break;
                default:
                    break;
            }

            foreach (object ob in finalStr)
                Console.WriteLine(ob.ToString());
            return null;
        }
    }
}
