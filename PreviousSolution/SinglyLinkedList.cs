using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class SinglyLinkedList
    {
        public Node header;
        int totalNumNode;
        Node temp;

        public void SwapEvery2Nodes()
        {
            Node temp1 = header.next;
            Node temp2 = header.next.next;
            if (header.next == null) return;        //header->null
            if (header.next.next == null) return;   //header->next->null

            Node pre = header;

            Swap(temp1, temp2, pre);

            Console.WriteLine("temp1=" + temp1.value + " temp2 = " + temp2.value);

            //printNode();
        }

        public void Swap(Node n1, Node n2, Node pre)
        {
            Node temp = n1;
            n1 = n2;
            n1.next = n2;
            n2 = temp;
            n2.next = n2;
            pre.next = n1;
        }

        public void FindMidValue()
        {
            Console.WriteLine("Finding mid value  . . . ");
            if (header.next == null)
            {
                Console.Write("Sorry, List is Empty !");
                return;
            }

            Node temp1, temp2;
            temp1 = header;
            temp2 = header;

            while (temp2.next != null)
            {
                temp1 = temp1.next;
                if (temp2.next.next == null)//&&temp2.next==null
                {
                    break;
                }
                temp2 = temp2.next.next;
            }
            Console.WriteLine("Mid value is :" + temp1.value);
        }

        public void DeleteNodeAtNthPos(int position)
        {
            Console.WriteLine("Deleting " + position + "th node . . . ");
            if (position > totalNumNode)
            {
                Console.WriteLine("Sorry, No such position available !");
                return;
            }
            else if (header.next == null)
            {
                Console.WriteLine("Sorry, Empty List !");
                return;
            }
            else if (position == 1)
            {
                header.next = header.next.next;
            }
            else
            {
                Node temp = header.next;
                for (int i = 2; i < position; ++i)
                {
                    temp = temp.next;
                    /*
                     * for (int i = 2; i <= position; ++i)
                        {
                    temp = temp.next;
                    if (temp == null)
                      {
                        Console.WriteLine("Invalid Position !");
                      break;
                      }}
                     */
                }
                temp.next = temp.next.next;
            }
            Console.WriteLine("List after deletion : ");
            printNode();
        }

        public void InsertAtNthPos(int position, int value)
        {
            Console.WriteLine("Trying to insert into " + position + "th position . . . ");
            if (position > totalNumNode)
            {
                Console.WriteLine("Sorry, No such position available !");
                return;
            }

            Node toBeInserted = new Node(null, value);
            temp = header.next;
            
            for (int i = 2; i < position; i++)
            {
                temp = temp.next;
            }
            
            toBeInserted.next = temp.next;
            temp.next = toBeInserted;
            
            printNode();
        }

        public SinglyLinkedList()
        {
            header = new Node(null, 0);
            totalNumNode = 0;
        }

        public void ReverseList()
        {
            Console.WriteLine("Trying to reverse the list . . . ");
            //Case 1 : If there is no node at all !
            if (header.next == null)
            {
                Console.WriteLine("Empty List !");
                return;
            }
            //Case 2 : If only one node available
            else if (header.next.next == null)
            {
                Console.WriteLine("Only one node available !\n" + header.next.value);
                return;
            }
            //Case 3 : If there is just 2 node
            else if (header.next.next.next == null)
            {
                Node temp4, temp5;
                temp4 = header.next;
                temp5 = temp4.next;
                temp5.next = temp4;
                header.next = temp5;
                temp4.next = null;
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
            Console.WriteLine("After reversing the list : ");
            printNode();
        }

        public Node ReturnNthNodeFromLast(int index)
        {
            if (index < 0)
                return null;

            if (header.next == null)
                return null;

            //using two node pointers
            Node n1 = header;
            Node n2 = header;

            //moving n2 to indexth time forward
            for (int i = 0; i < index; ++i)
            {
                n2 = n2.next;
                if (n2.next == null) // index exceeds list size
                    return null;     // No index position available
            }
            while (n2.next != null) // moving both nodes a step further until n2 points to the last node
            {
                n2 = n2.next;
                n1 = n1.next;
            }
            //when done n1 exactly points to the index position from the last !
            return n1;
        }

        public void printNthNodeFromLast(int position)
        {
            Console.WriteLine("Trying to print " + position + "th value from last . . . ");

            /*
            if (position > totalNumNode)
            {
                Console.WriteLine("Sorry, The " + position + "th Node value doesn't Exist !! ");
                return;
            }*/
            if (position < 1)
            {
                Console.WriteLine("No such Position avail !");
            }
            else
            {

                Node first = new Node(header.next, 0);
                Node second = new Node(header.next, 0);

                for (int i = 1; i < position; ++i)
                {
                    second = second.next;
                    if (second.next == null)
                    {
                        Console.WriteLine("No such Position avail !");
                        break;
                    }
                }
                while (second.next != null)
                {
                    second = second.next;
                    first = first.next;
                }

                Console.WriteLine("The " + position + "th Node value is : " + first.value);
            }
        }

        public void AddNode(int value)
        {
            Node newNode = new Node(header.next, value);
            header.next = newNode;
            ++totalNumNode;
        }

        public void SortLinkedListInAscOrder()
        {
            if (header.next == null)
            {
                Console.WriteLine("Empty List");
                return;
            }

            temp = header.next;

            //bool isFirstNode = true;

            int len = 1;

            while (temp.next != null) { ++len; temp = temp.next; }

            temp = header.next;

            //Node temp2;

            if (temp.next == null)
                return; //One node linked list

            Node temp2 = temp.next;
            Node pre = header;

            while (temp2.next != null)
            {
                if (temp.value > temp2.value)
                {
                    //Swap(temp, temp2);
                    temp.next = temp2.next;
                    temp2.next = temp;
                    pre.next = temp2;

                }
                temp2 = temp2.next;
                temp = temp.next;
                pre = pre.next;
            }

            Console.WriteLine(len);

            /*
            while (true)
            {
                while (temp.next != null)
                {
                    if (smallestVal > temp.next.value)// && isFirstNode)
                    {
                        smallestVal = temp.next.value;
                        smallestNode = temp.next;
                        //isFirstNode = false;
                    }
                    temp = temp.next;
                }
                smallestNode.next = indexNode;
                indexNode.next = smallestNode;                
            }
            */

            //Console.WriteLine(smallestVal +"; ");
            printNode();
        }
        
        public void printNode()
        {
            Console.WriteLine("Original list : ");

            if (header.next != null)
            {
                Node temp = header;

                while (temp.next != null)
                {
                    temp = temp.next;
                    Console.Write(temp.value + " ");
                }
            }
            else
                Console.WriteLine("List Empty !");
            Console.WriteLine();
            //Console.WriteLine("Total number of Nodes :"+totalNumNode);            
        }

        public class Node
        {
            public int value;
            public Node next;

            public Node(Node n, int val)
            {
                this.value = val;
                this.next = n;
            }
        }
    }
}
