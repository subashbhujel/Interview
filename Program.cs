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

            //strOpe.FindASqRoot(1f);
            // strOpe.RearrangeArrayBySwappingWithZero(new int[] { 0, 1, 2, 3,5 }, new int[] { 0, 5,1, 2, 3 });
            //Console.WriteLine(strOpe.FindIfStringHAsUniqueChars(""));

            //strOpe.ConcatSrting(new string[] { "ABC", "DEF", "CAD" }, 3);

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
            //ll.RotateTheList(6);
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

            //Console.WriteLine("The Height of BST is: " + bst.FindTheHeight());

            //Console.WriteLine(bst.Find(15) ? "Found!" : "Not Found!");

            //bst.PrintLevelByLevel();
            //bst.IsBST();

            #endregion

            #region Array

            ArrayOp.ArrayOperations arrayOperations = new ArrayOp.ArrayOperations();

            //arrayOperations.MoveAllZeroesToEndOfArray(new int[] { 1, 9, 0, 0, 2, 1, 0, 3, 0 });

            //Console.WriteLine(arrayOperations.FindMinSequence(new int[] { 2,1,3,2,7,1 }, 10));

            /// <summary>
            ///  Q. Given two sorted array in ascending order with same length N, calculate the Kth min a[i]+b[j]. 
            ///  Time complexty O(N).
            ///  Array #1 : {1,6,13,20}
            ///  Array #2 : {2,6,20,50}
            ///  Find 3rd minimum value. Ans: 6
            ///  Find 4th minimum value. Ans: 13
            /// Assumption: Both array is of equal length (irrelavant). Array is of equal length.
            /// </summary>            
            //int k = 3;
            //int min = arrayOperations.FindTheKthElement(new int[] { 1, 6, 13, 20 }, new int[] { 2, 6, 20, 60 }, k);
            //Console.WriteLine(min == int.MinValue ? k + "th value doesn't exist" : "Minimun value is: " + min);

            #endregion

            #region TRICK QUESTIONS
            
            TrickQuestions.TrickQuestions trickQ = new TrickQuestions.TrickQuestions();
            
            Console.WriteLine(trickQ.MakeBricks(2, 1, 7));
            Console.WriteLine(trickQ.MakeBricks(2, 5, 9));
            Console.WriteLine(trickQ.MakeBricks(10, 1, 11));
            Console.WriteLine(trickQ.MakeBricks(2, 1,9 ));

            #endregion
        }
    }
}
