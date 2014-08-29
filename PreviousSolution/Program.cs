using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class Program
    {
        public void QuickSort()
        {
            int[] arr ={ 0, 0, 0, 0, 0, -4, 0, 20, -5, 2, 0, 0, 0, 0, 0,7, 8, -12, -1, 0, 13, 0, 0, 0, 0, 0 };
            //int[] arr ={ 0, 0,-4, 0, 0,8, 9, -12, 0 };
            //int[] arr ={ -1, 3, -4, -30, 10, 8, 9, -12, 4 };
            InorderQuickSort QS = new InorderQuickSort(arr);
            QS.DoInorderQuickSort();
            QS.PrintSortedArr();
        }

        public void ReverseStr()
        {
            String str = "Subash is Reversing the String to work at Microsoft";
            //String str = "Subash       ";
            Console.WriteLine(new ReverseString().DoReverse(str));
            Console.WriteLine("Reversed String :"+new ReverseString().ReverseSentencebywordUsingStringBuilder(str)); ;
            //str += str.Substring(2,4);
           // Console.WriteLine(str);
        }

        public void LetsFindNonRepeatChar()
        {
            String str = "ABCDABCAAEAAABBBBCCDD";
            Console.WriteLine(new FirstNonRepeatCharInStr().FindNoneRepeatChar(str));
        }

        public void FindWordsInStatePreservedStr()
        {
            String str = "AB CD EFG HI JKL";
            StrStateDelimit stateStr = new StrStateDelimit();
            String rs1 = stateStr.FindNextWord(str, " ");
            String rs2 = stateStr.FindNextWord("Subash Bhujel At Microsoft", " ");
            String rs3 = stateStr.FindNextWord(null, " ");
            if (rs1 == null) rs1 = "NULL";
            Console.WriteLine(rs1);
            Console.WriteLine(rs2);
            Console.WriteLine(rs3);
        }

        public void DoWordReverse()
        {
            //string word = "MI";
            string word = "MICROSOFT";
            Console.WriteLine("Original String : "+word);
            ReverseAWord revWord = new ReverseAWord();
            revWord.DoReverse(word);
            revWord.PrintWord();
        }

        public void FindNthLargestValInArr()
        { 
            
        }

        public void LetsBST()
        {
            BST bst = new BST();
            bst.IterativeNodeAddition(55);
            bst.IterativeNodeAddition(20);
            bst.IterativeNodeAddition(100);
            bst.IterativeNodeAddition(25);
            bst.IterativeNodeAddition(56);
            bst.IterativeNodeAddition(60);
            bst.IterativeNodeAddition(15);
            bst.IterativeNodeAddition(5);
            bst.IterativeNodeAddition(9);
            bst.IterativeNodeAddition(77);
            bst.IterativeNodeAddition(-8);
            /*
             * Recursive Node insertion
            bst.AddNode(55);
            bst.AddNode(20);
            bst.AddNode(50);
            bst.AddNode(12);
            bst.AddNode(29);
            bst.AddNode(23);
            bst.AddNode(49);
            bst.AddNode(35);*/
            bst.PrintBST();
            //Console.WriteLine(bst.FindNode(9));
            //Console.WriteLine(bst.FindNode(98));
            //Console.WriteLine(bst.FindNode(55));
            int nextNum = bst.FindNextBiggestNode(56);
            Console.WriteLine("Next biggest number is : "+nextNum);
        }

        public void LetsBSTWithParent()
        {
            BSTWithParentNode bst = new BSTWithParentNode();
            bst.IterativeInsertion(45);
            bst.IterativeInsertion(55);
            bst.IterativeInsertion(20);
            bst.IterativeInsertion(100);
            bst.IterativeInsertion(25);
            bst.IterativeInsertion(56);
            bst.IterativeInsertion(60);
            bst.IterativeInsertion(15);
            bst.IterativeInsertion(5);
            bst.IterativeInsertion(9);
            bst.IterativeInsertion(61);
            bst.IterativeInsertion(110);
            bst.IterativeInsertion(50);
            bst.IterativeInsertion(26);
            
            bst.IterativePrint();
            //bst.RecurPrint();
            
            int rs=bst.FindSecondLargestNum(100);
            Console.Write("The next number is : ");
            
            if (rs == -09090909) Console.Write("Not Found !");
            else Console.Write(rs);
            Console.WriteLine(bst.FindRank(900));

            bst.DeleteNode(100);
            bst.IterativePrint();
        }

        public void MergeTwoSortedArr()
        {
            int[] arr1 ={ -6,1, 3, 5, 7, 9};
            int[] arr2 ={ -100, 2, 4, 5,6, 22, 34, 100};
            MergeTwoSortedArray mtsa = new MergeTwoSortedArray();
            mtsa.MergeTwoSortedArr(arr1, arr2);
            mtsa.PrintSortedArr();
        }

        public void StringBuilderTest()
        {
            StringBuilder str = new StringBuilder("Let me get into Microsoft ");
            str.Append(", God");            
            Console.WriteLine(str.ToString());
            str.Remove(3, 3); 
            str.Insert(0, "Gosh ! ");
            str.Replace("Microsoft", "Amazon");
            Console.WriteLine(str);
        }

        public void ToCharArr()
        {
            char[] charArr1 ={ 'a', 'e', 'c', 'a', 'c', 'e' ,'f','x','x','y'};
            //char[] charArr1 ={ 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' };
            //char[] charArr2 ={ 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' };
//            char[] charArr2 ={ 'a', 'e', 'c', 'a', 'c', 'e', 'f', 'x', 'x', 'y'};
            char[] charArr2 ={ 'a', 'x', 'a','s', 'c', 'c','z' };
            //char[] charArr2 ={};
            FindUniqCharsFromTwoArr ch = new FindUniqCharsFromTwoArr();
            Console.WriteLine();
            ch.PrintCharArr(charArr1);
            Console.WriteLine();
            ch.PrintCharArr(charArr2);
            ch.FindUniqCharsFromBothArrs(charArr1,charArr2);
            ch.FindUniqChars(charArr1, charArr2);
        }

        public void FindPosOfStrInStr()
        {
            FindSubStrintheGivenStrFromLast st = new FindSubStrintheGivenStrFromLast();
            Console.WriteLine(st.FindPositionOfSubStr("ab"));
        }

        public void ChangeStrToInt()
        {
            StrToNum sn = new StrToNum();
            sn.ChangeStrToInt("1234");
        }

        public void StrManipulation()
        {
            /*
            ConvertIntToStr cs = new ConvertIntToStr();
            
            Console.WriteLine(cs.ChangeToStr(-1234));
            try
            {
                Console.WriteLine(cs.ChangeToInt("-901234b"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */
            //-------------------------------
            StringToUpperManually s = new StringToUpperManually();
            string str = "asAdf23";
            Console.WriteLine(str + " : " + s.ToUpper(str));
        }

        public void CheckPalins()
        {
            string str = "Dad and I saw a raceCar";
            //string str = "";
            CheckNumOfPalinsInASentence chPalin=new CheckNumOfPalinsInASentence();
            Console.WriteLine("Number of Palindromes : "+chPalin.CountPalindromes(str));
        }

        public void CheckForBits()
        {
            CheckHowManyBitsRSet ch = new CheckHowManyBitsRSet();
            Console.WriteLine("Number of set bits are : "+ch.CheckForSetBits(11001));
        }

        public void SinglyLinkedLst()
        {
            //Singly Linked List
            SinglyLinkedList singlyLinkedList = new SinglyLinkedList();
            singlyLinkedList.AddNode(11);
            singlyLinkedList.AddNode(2);
            singlyLinkedList.AddNode(-3);
            singlyLinkedList.AddNode(-4);
            singlyLinkedList.AddNode(50);
            singlyLinkedList.AddNode(16);
            singlyLinkedList.AddNode(7);
            singlyLinkedList.AddNode(82);
            singlyLinkedList.AddNode(900); 
            singlyLinkedList.AddNode(10);            
            
            singlyLinkedList.printNode();

            singlyLinkedList.SortLinkedListInAscOrder();

            //singlyLinkedList.SwapEvery2Nodes();
            
            //singlyLinkedList.FindMidValue();
            
            //Q. Reverse the singly linked list            
             // * alternate Q. Print the singly linked from last without using temp list.
             //* ans : the only way to print it reverse is to first reverse the list and print
            //singlyLinkedList.ReverseList();
            
            //Q. Print Nth node from last 
            //singlyLinkedList.printNthNodeFromLast('$');
            
            //Q. Insert a node @ given position
            //singlyLinkedList.InsertAtNthPos(11,167);
            
            //Q. Remove Nth node
            //singlyLinkedList.DeleteNodeAtNthPos(1);
        }

        public delegate void ProcessNumber(int a);
                
        public void MultiplyNums(int a, int b, ProcessNumber p)
        {
            int rs = a * b;
            p(rs);            
        }

        public static void DisplayResult(int rs)
        {
            Console.WriteLine(rs);
        }
        
        public static void DisplayResultII(int rs)
        {
            Console.WriteLine(rs+5);
        }

        public void FileIO(String fileName)
        {
            ReadNWriteTxtFile rt = new ReadNWriteTxtFile();
            rt.ReadFile(fileName);
        }

        public void ReplacePartOfString()
        {
            ReplaceStrWithoutAnyAPI strReplace = new ReplaceStrWithoutAnyAPI();
            Console.WriteLine(strReplace.ReplacePartOfStringLiberal("This is Sumday", "is", "are"));
            Console.WriteLine(strReplace.ReplacePartOfString("This is Sumday", "is", "are"));
        }

        public void ReturnDayOfTheWeekFromDateGiven()
        {
            FindWeekDayFromDate findDay = new FindWeekDayFromDate();
            Console.WriteLine(findDay.FindWkDayFromDate(10, "Tuesday", 15));
        }

        public void ReturnMaxRepeatWord()
        {
            string str = "Look mom, the pretty bird! Come bird! Little blue bird don't fly away!";
            ReturnMaxRepeatedWord retMaxWord = new ReturnMaxRepeatedWord();
            Console.WriteLine(retMaxWord.ReturnMaximumRepeatWord(str));
        }

        public void ShiftArrAndRotate()
        {
            int[] input = {1,2,3,4,5};
            for (int i = 0; i < input.Length; ++i)
                Console.Write(input[i]);
            
            Console.WriteLine();
            
            ShiftArray shiftArr = new ShiftArray();
            
            int[] rs = shiftArr.FindSortedArrayRotation(input,16);
            for (int i = 0; i < input.Length; ++i)
                Console.Write(input[i]);
        }

        public void FindMatchingStrInArr()
        {
            string[] strArr = {"subashabc","bhujelabc"};
            FindStringInArrOfStringIfMatches findStr = new FindStringInArrOfStringIfMatches();
            findStr.FindStrInArr(strArr, "*abc");
        }

        public void FindSqRoot()
        {
            FindSqRoot findSqRoot = new FindSqRoot();
            
            //this will find out closest sq root
            Console.WriteLine("Solution 1: "+findSqRoot.Isqrt(89));
            
            Console.WriteLine();

            //perfect solution by guessting method
            Console.WriteLine("Soln 2 : "+findSqRoot.FindSquareRoot(49));
        }

        static void Main(string[] args)
        {
            Program pg = new Program();

            pg.FindSqRoot();
            
            //pg.FindMatchingStrInArr();

            //pg.ShiftArrAndRotate();
            
            //pg.ReturnMaxRepeatWord();

            //pg.ReturnDayOfTheWeekFromDateGiven();

            //pg.ReplacePartOfString();

            //pg.FileIO(@"E:\MicroSoft_Materials\C#Practice\MS_Preparation_II\MS_Preparation_II\Read.txt");

            //ProcessNumber pn = new ProcessNumber(DisplayResult);
            //pn += new ProcessNumber(DisplayResultII);
            //pg.MultiplyNums(5, 6, pn);
            
            //pg.StrManipulation();
            
            //pg.SinglyLinkedLst();

            //pg.CheckForBits();
            
            //pg.CheckPalins();
            
            //pg.StrIntManipulation();
            
            //pg.ChangeStrToInt();

            //pg.FindPosOfStrInStr();
            
            //pg.ToCharArr();

            //pg.StringBuilderTest();
            
            //pg.MergeTwoSortedArr();

            //pg.LetsBSTWithParent();
            
            //pg.LetsBST();

            //pg.DoWordReverse();
            
            //pg.FindWordsInStatePreservedStr();
            
            //pg.LetsFindNonRepeatChar();
            
            //pg.QuickSort();
            
            //pg.ReverseStr();
            
            /*
            //***********************************************************
            //Find the sum of two largest numbers in an array//
            SumOfTwoLargestNumInArray getSum = new SumOfTwoLargestNumInArray();
            int[] arr ={ 9, 5, 0, -1, 100, -4, 21, 11 ,64};
            int sum = getSum.CalculateSumOfTwo(arr);
            Console.WriteLine("Sum :"+sum);
            //*****************************************************************
             */
            /*
             * *******************************************
             * //DOUBLY LINKED LIST//
            DoublyLinkedList dll = new DoublyLinkedList();
            dll.AddNode(1);
            dll.AddNode(2);
            dll.AddNode(3);
            dll.AddNode(4);
            dll.AddNode(5);
            dll.AddNode(6);
            dll.AddNode(7);
            dll.AddNode(8);
            dll.AddNode(9);
            dll.AddNode(10);
            Console.WriteLine("Original List");
            dll.PrintNode();
            dll.InsertAtNth(9, 15);
            dll.PrintFromLast();
            dll.DeleteNth(6);
            dll.FindMidNode();
            ***************************************************
             */
            //*************************************************************
            
            
            
            //**************************************************************************


            //Combination Example ie Str1=12 and Str2=13 the final result is 123
            /*int[] phArr ={4,7,2,7,2,0,6};
            PhoneDictionery phDict = new PhoneDictionery();
            phDict.GenerateStringValOfPhNumber(phArr);
            */
            //finding Factorial Number
            /*Factorial fact = new Factorial();
            Console.WriteLine(fact.findFactorial(4));*/

            //changing the String to ASCII value 
            /*StrToASCII changeStr = new StrToASCII();
            changeStr.stringToASCII("732");
            */
            Console.ReadLine();
        }
    }
}
