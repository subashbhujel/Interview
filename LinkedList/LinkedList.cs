using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    // Q. How do you find the middle item in a linked list?
    public class LinkedList
    {
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
        public void Display(LinkedList<string> linkedList)
        {
            LinkedListNode<string> head = linkedList.First;

            while (head!=null)
            {
                Console.Write(head.Value+" ");
                head = head.Next;
            }
        }
    }
}