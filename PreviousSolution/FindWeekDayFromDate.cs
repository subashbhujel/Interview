using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MS_Preparation_II
{
    class FindWeekDayFromDate
    {
        //if 3=monday, what is 25? on same month?
        public string FindWkDayFromDate(int givenday, string weekday, int findDay)
        {
            int index = givenday % 7;

            Hashtable hashTable = new Hashtable();
            hashTable.Add(1, "Monday");
            hashTable.Add(2, "Tuesday");
            hashTable.Add(3, "Wednesday");
            hashTable.Add(4, "Thursday");
            hashTable.Add(5, "Friday");
            hashTable.Add(6, "Saturday");
            hashTable.Add(7, "Sunday");

            int loop = (findDay - givenday) % 7;
            
            int j = 0;
            
            for (int i = 0; i < loop; ++i)
            {
                j = ++index;
                if (j > 7)
                    j = 1;                
            }
            return hashTable[j].ToString();
        }
    }
}
