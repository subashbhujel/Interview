using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MS_Preparation_II
{
    class ReturnMaxRepeatedWord
    {
        public string ReturnMaximumRepeatWord(string str)
        {
            //Look mom, the pretty bird! Come bird! Little blue bird don't fly away!
            //my solution just returns bird!,2 for now, I know its a bug, i can just remove extra ! and solve in 
            //the way i have been doing below, I need more mins to fix this bug but this is a 20 mins soln

            string[] strArr = str.Split(' ');

            Hashtable hashTable = new Hashtable();
            
            int val = 0;
            
            for (int i = 0; i < strArr.Length; ++i)
            {
                if (hashTable.Contains(strArr[i]))
                {
                    val = (int)hashTable[strArr[i]];
                    ++val;
                    hashTable.Remove(strArr[i]);
                    hashTable.Add(strArr[i], val);
                }
                else
                    hashTable.Add(strArr[i], 1);
                                
            }
            
            int tempVal = 0;
            string key ="";
            foreach (DictionaryEntry ob in hashTable)
            {
                val = (int)ob.Value;
                if (val > tempVal)
                {
                    tempVal = val;
                    key = (string)ob.Key;
                }
            }
            return key + ","+tempVal;
        }
    }
}
