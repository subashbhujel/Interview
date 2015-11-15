using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{

    /// <summary>
    /// Linked List
    /// </summary>
    public class LinkedList
    {
        /// <summary>
        /// Rotates a linked list
        /// </summary>
        /// <param name="linkedList">Linked List</param>
        /// <returns>Rotated linked list</returns>
        public LinkedListNode<int> Rotate(LinkedList<int> linkedList)
        {
            LinkedListNode<int> head = linkedList.First;
            LinkedListNode<int> pre = null;
            LinkedListNode<int> next = null;

            if (head == null)
            {
                Console.WriteLine(" Empty Linkedlist");
                return null;
            }

            while (head != null)
            {
                //head.Next = pre;
                pre = head;
                head = head.Next;
                next = head;
            }
            return head;

        }

        /// <summary>
        /// Creates a linked list
        /// </summary>
        /// <returns>Linkedlist</returns>
        public LinkedList<string> CreateALinkedList()
        {
            string[] words = { "the", "fox", "jumped", "over", "the", "dog" };

            LinkedList<string> sentence = new LinkedList<string>(words);
            //Display(sentence, "The linked list values:");

            FindMiddleElement(sentence);
            //Display(sentence, "The linked list values:");
            return sentence;
        }

        /// <summary>
        /// Q. How do you find the middle item in a linked list?
        /// Solution: Use two pointers - slow and fast
        /// 1. Slow pointer moves 1 pointer while Fast moves 2 pointer
        /// 2. When Fast reaches end, Slow pointer will reach the middle of the LL
        /// </summary>
        /// <param name="linkedList"></param>
        /// <returns></returns>
        public string FindMiddleElement(LinkedList<string> linkedList)
        {
            LinkedListNode<string> Head = linkedList.First;
            LinkedListNode<string> slow = Head, fast = Head;

            if (Head != null)
            {
                while (fast != null && fast.Next != null)
                {
                    slow = slow.Next;
                    fast = fast.Next.Next;
                }
                return slow.Value;
            }
            return "Invalid LinkedList";
        }

        public void Print(LinkedList<string> linkedList)
        {
            LinkedListNode<string> head = linkedList.First;

            while (head != null)
            {
                Console.Write(head.Value + " ");
                head = head.Next;
            }
        }
    }
}