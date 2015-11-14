using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayOperatios array = new ArrayOperatios();

            int[,] array2D = { { 1, 2, 3 }, { 3, 4, 4 }, { 5, 6, 6 }, { 7, 8, 9 } };
            int[] array1D = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //array.PrintInSpiralOrder(array2D);
            array.ArrangeArrya(array1D);

            #region String Operations
            StringOperation strOpe = new StringOperation();

            //Reverse A String
            //strOpe.ReverseString("1234567890");
            //strOpe.ReverseString("ABCDEFGHIJKLMNOPQRSTUVWXY");

            //strOpe.SortAString(new string[] { "subash", "bhujel" });//,"abc" });
            //Console.WriteLine("Is This number a Power Of 2? :" + new PowerOf2().IsANumberPowerOf2(68719476735));

            //Console.WriteLine(strOpe.NumberToWord(-003010010));
            //strOpe.FindADuplicateNumber();
            //strOpe.Matrix();
            //strOpe.PrintAMatrix(5,2);
            //strOpe.FindUniqueChars("aabccdeefasfsafgggsdfasdggghdhasdfijkksdfasdkkl");
            //Console.WriteLine(strOpe.IsPalindrome("acbnh") ? "Palindrome" : "Not Palindrome");
            //Console.WriteLine("Longest Palindrome is : "+strOpe.FindLongestPalindrome("ababbax"));

            //strOpe.RotateAnArray(new int[] { 1, 2, 3, 4, 5 }, 3);
            //Console.WriteLine(strOpe.FindMedianOf3Nums(3, 2, -1));

            //strOpe.ConcatSrting(new string[] { "ABC", "DEF", "CAD" }, 3);

            #endregion

            #region Stack Operations

            //Stack.Stack stack = new Stack.Stack();

            //stack.Push(11);
            //stack.Push(2);
            //stack.Push(93);
            //stack.Push(24);
            //stack.Push(5);
            //Console.WriteLine("Max: " + stack.GetMax());
            //stack.Print();

            //stack.Pop();
            //stack.Pop();
            //stack.Print();

            //Console.WriteLine("The max number is : " + stack.GetMax());

            #endregion
            #region Linked List

            /*
           LinkedList ll = new LinkedList();
           LinkedList<string> str = ll.CreateALinkedList();
           ll.Display(str);
           Console.WriteLine("\nThe Middle Element is : " + ll.FindMiddleElement(str));
           */

            //strOpe.FindLongestNonrepeatingChars("abababdetest");
            //DoubleLL.DoublyLL Dll = new DoubleLL.DoublyLL();
            //Dll.Print();
            //LList ll = new LList();
            //ll.Add(1);
            //ll.Add(2);
            //ll.Add(3);
            //ll.Add(4);
            //ll.Add(5);

            //Console.WriteLine(4 & 4);
            //ll.Print();

            //ll.SwapConsecutiveElements();
            //ll.Print();
            //ll.CreateACycle(2);
            // ll.PrintTheLengthOfCyclicList();
            //Console.WriteLine(ll.FindIfCyclic() ? "Yes its cyclic." : "No, Its not a cyclicc");

            //ll.ReverseAList();
            //ll.SwapPosition(0);

            // ll.delete(1);            
            //ll.Print();

            //ll.PrintNthPosition(2);

            //ll.ReturnNthPositionFromLast(2);
            #endregion

            #region BST

            //BST.BST bst = new BST.BST();
            //bst.Add(21);
            //bst.Add(10);
            //bst.Add(15);
            //bst.Add(45);
            //bst.Add(22);
            //bst.Add(90);
            //bst.Add(48);

            //bst.Print();

            //Console.WriteLine(bst.Find(15) ? "Found!" : "Not Found!");

            //bst.IsBST();

            #endregion
        }
    }
}
