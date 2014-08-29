using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class DoublyLinkedList
    {
        Node header,temp;
        int totNumNode;

        public void FindMidNode()
        { 
            Console.WriteLine("Finding mid-Node . . . ");
            if (header.next == null)
            {
                Console.WriteLine("Empty List !");
                return;
            }
            
            int count = 0;
            temp = header;
            
            while (temp.next != null)
            {
                temp = temp.next;
                ++count;
            }
            
            temp = header;
            
            if (count == 1)
            {
                Console.WriteLine("Only 1 node available.\n"+header.next.data);
            }
            int j;
            if (count % 2 == 0)
                j = (count / 2) -1;
            else
                j = count / 2;
            for (int i = 0; i <= j; i++)
            {
                temp = temp.next;
            }
            Console.WriteLine("Mid value is : "+temp.data);
        }

        public void DeleteNth(int position)
        {
            Console.WriteLine("Deleting . . . ");
            
            if (header.next == null)
            {
                Console.WriteLine("Empty List !");
                return;
            }

            temp = header;
            
            for (int i = 1; i < position; ++i)
            {
                temp = temp.next;
            }
            
            temp.next = temp.next.next;
            temp.next.next.pre = temp;
            
            Console.WriteLine("After deletion at " + position + "th position : ");
            PrintNode();
        }

        public void InsertAtNth(int position,int data)
        {
            Console.WriteLine("Inserting . . . ");
            Node newNode;
            if (header.next == null || position == 1 || position == 0)
            {
                if (position == 1)
                {
                    newNode = new Node(header, data, header.next);
                    header.next = newNode;
                    ++totNumNode;
                    PrintNode();
                    return;
                }
                else
                {
                    Console.WriteLine("Sorry, "+position+"th position NOT available !");
                    return;
                }
            }
            
            temp = header;

            for (int i = 1; i < position; ++i)
            {
                temp = temp.next;
            }

            newNode = new Node(temp, data, temp.next);
            if (temp.next == null)
            {
                temp.next = newNode;
            }
            else
            {
                temp.next.pre = newNode;
                temp.next = newNode;
            }
            Console.WriteLine("After insertion at " + position + "th position : ");
            PrintNode();
            ++totNumNode;
        }

        public DoublyLinkedList()
        {
            header = new Node(null,0,null);
            totNumNode = 0;
        }

        public void AddNode(int data)
        {
            Node newNode = new Node(header,data,header.next);
            header.next = newNode;
            ++totNumNode;
        }

        public void PrintFromLast()
        {
            Console.WriteLine("Reverse Printing . . . ");
            
            if (header.next == null)
            {
                Console.WriteLine("Empty List !");
                return;
            }
                        
            temp = header;
            
            Stack<int> stack = new Stack<int>();
            
            while(temp.next!=null)
            {
                temp = temp.next;
                stack.Push(temp.data);
            }
            
            while (stack.Count>0)
            {
                Console.Write(stack.Pop()+" ");
            }
            
            Console.WriteLine();
        }

        public void PrintNode()
        {
            if (header.next == null)
            {
                Console.WriteLine("Sorry, List is Empty !");
                return;
            }
            temp = header;
            while (temp.next != null)
            {
                temp = temp.next;
                Console.Write(temp.data+" ");                
            }
            Console.WriteLine();
        }

        public class Node
        {
            public Node pre;
            public Node next;
            public int data;

            public Node(Node pre,int data,Node next)
            {
                this.pre = pre;
                this.data = data;
                this.next = next;
            }
        }
    }
}
