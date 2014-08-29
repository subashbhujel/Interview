using System;
using System.Collections.Generic;

using System.Text;

namespace MSFTPrep_Jan09
{
    class SinglylinkedList
    {
        Node header;
        Node temp;

        public SinglylinkedList()
        {
            header = new Node(null, -1); ;
        }

        //This is more efficient than the one below
        public int FindMidValueUsingDoublenodePointers()
        {            
            if (header.next == null)
            {
                Console.WriteLine("Empty Linked List!");
                return -1;   
            }
            Node temp1 = header, temp2 = header;

            while (temp2.next != null)
            {
                temp1 = temp1.next;  
                if (temp2.next.next == null || temp2.next==null) break;                              
                temp2 = temp2.next.next;
            }
            return temp1.data;
        }

        public int FindMidValue()
        {
            #region AdHoc method using count
            //checkign if list is empty
            if (header.next == null) { Console.WriteLine("Empty Link List!"); return -1; }

            int count = 0;
            temp = header.next;
            int midvalue = temp.data;

            while (temp.next != null)
            {
                count++;
                temp = temp.next;

                //for the last node
                if (temp.next == null) count++;
            }

            //reinitializing it to the header node back

            temp = header.next;

            for (int i = 1; i <= count / 2; ++i)
            {
                if (i == count / 2) 
                    midvalue = temp.data;
                else
                    temp = temp.next;
            }
            return midvalue;
            #endregion
        }

        public void AddNode(int value)
        {
            Node newNode = new Node(header.next, value);
            header.next = newNode;
        }

        public void printSinglyLL()
        {
            if (header.next == null)
            {
                Console.WriteLine("Empty Linked List!");
                return;
            }
            else
            {
                temp = header;

                while (temp.next != null)
                {
                    temp = temp.next;
                    Console.Write(temp.data + " ");                    
                }
            }
        }

        public void SortLinkedList()
        {
            Console.WriteLine("\nBefore sorting:");
            printSinglyLL();
            Console.WriteLine("\nAfer sorting:");
            
        }

        /// <summary>
        /// This function will reverses the SLL using 3 pointers and is very efficient
        /// </summary>
        public void ReverseTheList()
        {
            Console.WriteLine("After reversing...");

            if (header.next == null)
            {
                Console.WriteLine("List Empty!");
                return;
            }
            else if (header.next.next == null)
            {
                Console.WriteLine("Just a single node, nothing to reverse!");
                return;
            }
            else if (header.next.next.next == null)
            {
                Node temp4 = header, temp5 = temp4.next;                
                temp5.next = temp4;
                temp4.next = null;
                header.next = temp5;
                return;
            }
            else
            {
                Node temp1, temp2, temp3;
                temp1 = header.next;
                temp2 = temp1.next;
                temp3 = temp2.next;

                temp1.next = null;

                while (temp3.next != null)
                {
                    temp2.next = temp1;
                    temp1 = temp2;
                    temp2 = temp3;
                    temp3 = temp3.next;
                }
                temp2.next = temp1;
                temp3.next = temp2;
                header.next = temp3;
            }
        }

        private class Node
        {
            public Node next;
            public int data;

            public Node(Node node, int value)
            {
                this.next = node;
                this.data = value;
            }
        }
    }
}
