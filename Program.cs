﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPreparation.BST;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Array

            ArrayOperatios array = new ArrayOperatios();

            int[,] array2D = { { 1, 2, 3 }, { 3, 4, 4 }, { 5, 6, 6 }, { 7, 8, 9 } };
            int[] array1D = { 1, -2, 3, 4, -5, 6, 7, -8, 9 };
            int[] a_sorted = { 1, 4, 5 };
            int[] b_sorted = { 10, 20, 40, 50 };
            int[] binaryArray = { 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1 };

            //array.FindNextGreaterNumber();
            //array.FindMinCombination(4006);
            //array.PrintTheClosestPair(a_sorted, b_sorted, 32);
            //array.PrintLargestSum(array1D);
            //array.PrintInSpiralOrder(array2D);
            //array.ArrangeArray(array1D);
            //array.FlipZeros(binaryArray, 2);

            #endregion

            #region Strings

            StringOperation strOpe = new StringOperation();
            //strOpe.TitleCapitalization("thERe iS A small bIg tREE IN THe  backYARD");
            //Console.WriteLine(strOpe.ReverseAStringOnly("a&bcd$#"));
            //strOpe.RemoveSpaces("g  eeks   for ge  eeks  ");
            //Console.WriteLine(strOpe.ArrangeStringUsingKeys("bana#na", "abc"));
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

            #region Stack

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

            LinkedList<int> linkedList = new LinkedList<int>(array1D);


            //LinkedList<string> str = ll.CreateALinkedList();
            //ll.Print(str);            
            //Console.WriteLine("\nThe Middle Element is : " + ll.FindMiddleElement(str));


            //strOpe.FindLongestNonrepeatingChars("abababdetest");
            //DoubleLL.DoublyLL Dll = new DoubleLL.DoublyLL();
            //Dll.Print();

            //LList ll = new LList();

            //ll.Add(1);
            //ll.Add(2);
            //ll.Add(3);
            //ll.Add(4);
            //ll.Add(5);
            //ll.Add(6);
            //Console.WriteLine(4 & 4);
            //ll.Print();
            //ll.Reverse(ll);
            //ll.RotateByCertainNumber(ll, 2);
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

            BST.BST bst = new BST.BST();
            bst.Add(21);
            bst.Add(10);
            bst.Add(15);
            bst.Add(45);
            bst.Add(22);
            bst.Add(90);
            bst.Add(48);
            bst.Add(50);
            //bst.PrintAncestors(bst.root,21);
            //bst.PrintLevelByLevel(bst.root);
            //bst.PrintLevelByLevelInSeparateLine(bst.root);
            //bst.Print(bst.root);

            //bst.FlattenABST(bst.root);
            //bst.PrintLinkedList();

            //Console.WriteLine(bst.FindRecursive(bst.root,15) ? "Found!" : "Not Found!");
            //Console.WriteLine(bst.FindRecursive(bst.root,48) ? "Found!" : "Not Found!");
            //Console.WriteLine(bst.FindRecursive(bst.root,190) ? "Found!" : "Not Found!");
            //bst.IsBST();
            //Console.WriteLine("Min Value is : "+bst.FindMin());
            //Console.WriteLine("Height of a BST is : " + bst.FindHeight());

            //Console.WriteLine("Number of nodes within the range : " + bst.CountNodesInARange(bst.root, -50,300));
            //Console.WriteLine();
            //bst.FindKthLargestElement(bst.root, 2);
            //bst.FindCommonAncestor(bst.root, 10, -15);
            //Console.WriteLine();
            //Console.WriteLine("Kth largest element : "+bst.FindKthLargestElement(bst.root, 2));

            #endregion

            #region Teaser

            Teaser teaser = new Teaser();
            //teaser.FindASmallestTwins(6, 17);
            //teaser.PrintPattern(10);

            //teaser.StockBuySell(new int[] { 100, 130, 260, 310, 40, 535, 695 });
            //teaser.SmallestSubWithSum(new int[] { 1, 4, 45, 6, 0, 19 }, 51);
            //teaser.PrintClosestPair(new int[] { 1, 3, 4, 7, 10 }, 15);
            //teaser.PrintClosestPair(new int[] { 10, 22, 28, 29, 30, 40 }, 54);
            #endregion

            #region Design Patters

            // Factory Pattern
            //Creator creator = new Creator();
            //creator.FacrotyMethod(VehicleType.TwoWheeler).PrintVehicle();
            //creator.FacrotyMethod(VehicleType.FourWheeler).PrintVehicle();
            //creator.FacrotyMethod(VehicleType.ThreeWheeler).PrintVehicle();

            // Factory Pattern
            //TicketCreator.FactoryMethod(TicketType.Bus).PrintTicket();
            //TicketCreator.FactoryMethod(TicketType.Train).PrintTicket();
            //TicketCreator.FactoryMethod(TicketType.Flight).PrintTicket();
            //TicketCreator.FactoryMethod(TicketType.Invalid).PrintTicket();

            // Strategy Pattern
            //new CalculateClient(new Add()).Calculate(10, 15);
            //new CalculateClient(new Minus()).Calculate(10, 15);
            //new CalculateClient(new Divide()).Calculate(10, 15);


            // Adaptor Pattern
            //User user = new User();
            //user.Create();

            //user = new Admin();
            //user.Create();

            #endregion
        }
    }
}
