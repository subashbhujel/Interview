using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MS_Preparation_II
{
    class FindUniqCharsFromTwoArr
    {
        Hashtable hastable = new Hashtable();


        public void FindUniqCharsFromBothArrs(char[] arr1, char[] arr2)
        {
            //char[] charArr1 ={ 'a', 'e', 'c', 'a', 'c', 'e' ,'f','x','x','y'};
            //char[] charArr2 ={ 'a', 'x', 'a', 's', 'c', 'z' };

            int len1 = arr1.Length;
            int len2 = arr2.Length;
            char c;
            int value;

            for (int i = 0; i < len1; ++i)
            {
                c = arr1[i];
                if (hastable.Contains(c))
                {
                    value = (int)hastable[c];
                    value++;
                    hastable.Remove(c);
                    hastable.Add(c, value);
                }
                else
                    hastable.Add(c, 1);
            }
            for (int j = 0; j < len2; ++j)
            {
                c = arr2[j];
                if (hastable.Contains(c))
                {
                    value = (int)hastable[c];
                    --value;
                    hastable.Remove(c);
                    hastable.Add(c, value);
                }
                else
                    hastable.Add(c, -1);
            }


            IDictionaryEnumerator enume = hastable.GetEnumerator();

            Console.WriteLine();

            while (enume.MoveNext())
            {
                if ((int)enume.Value == 0)
                    Console.WriteLine(enume.Key + " : 1/2");
                else if ((int)enume.Value < 0)
                    Console.WriteLine(enume.Key + " : 2");
                else if ((int)enume.Value > 0)
                    Console.WriteLine(enume.Key + " : 1");
            }
        }

        public char[] FindUniqChars(char[] arr1, char[] arr2)
        {

            int len1 = arr1.Length;
            int len2 = arr2.Length;

            char[] rs = new char[len1 + len2];
            int rsIndex = 0;
            int j = 1;

            for (int i = 0; i < len1; ++i)
            {
                //getting the duplicated chars out from the first array
                j = i + 1;
                while (j < len1 && j != i)
                {
                    if (arr1[i] == ' ')
                    { ++j; continue; }
                    else if (arr1[i] == arr1[j])
                    {
                        arr1[j] = ' ';
                    }
                    ++j;
                }
                rs[rsIndex] = arr1[i]; ++rsIndex;
                //checking for the duplicated from the second array
                for (int k = 0; k < len2 && arr1[i] != ' '; ++k)
                {
                    if (arr1[i] == arr2[k])
                        arr2[k] = ' ';
                    //else if(arr2[k]==' ')
                }

            }
            for (int l = 0; l < len2; ++l)
            {
                if (arr2[l] != ' ')
                {
                    rs[rsIndex] = arr2[l];
                    ++rsIndex;
                }
            }
            Console.WriteLine("\n");
            PrintCharArr(rs);
            return rs;
        }

        public void PrintCharArr(char[] temp)
        {
            for (int i = 0; i < temp.Length; ++i)
            {
                Console.Write(temp[i] + " ");
            }
        }
    }
}
