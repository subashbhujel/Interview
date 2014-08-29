using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MS_Preparation_II
{
    class ReadNWriteTxtFile
    {
        public void ReadFile(String fileName)
        {
            //TextWriter tw = new StreamWriter(fileName);
            //tr.Write("asdf");

            //TextReader tr = new StreamReader(fileName);
           
            StreamReader sr = File.OpenText(fileName);
            Console.WriteLine("Reading from a text file . . . ");
            string str = null;
            while ((str=sr.ReadLine()) != null)
            {
                Console.WriteLine(str);
            }
            //tw.Close();
            sr.Close();
        }
    }
}
