using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    class LList
    {
        private Node head = null;
        private Node temp1 = null, temp2 = null, current = null;

        // Q http://www.geeksforgeeks.org/clone-linked-list-next-arbit-pointer-set-2/
        // Clone a linked list with next and random pointer | Set 2 January 5, 2015
        // We have already discussed 2 different ways to clone a linked list.
        // In this post, one more simple method to clone a linked list is discussed.

        /// <summary>
        ///  Find the length of a linked list which contains cycle.
        /// </summary>
        public void PrintTheLengthOfCyclicList()
        {
            if (IsListEmpty())
                return;

            int len = 0;

            Node slow = head, fast = head;

            while (true)
            {
                if (slow.next == null)
                {
                    Console.WriteLine("Not a cyclic list");
                    return;
                }

                //Fast travels twice the speed
                if (fast.next != null)
                    fast = fast.next;
                else
                    return;

                if (fast.next != null)
                    fast = fast.next;
                else
                    return;

                // Slow travesl one speed
                slow = slow.next;

                if (fast == slow)
                {
                    Console.WriteLine("Its a cyclic");
                    break;
                }
            }

            //temp1 = fast;
            while (fast.next != slow)
            {
                len++;
                fast = fast.next;
            }

            temp1 = head;
            while (temp1 != slow)
            {
                len++;
                temp1 = temp1.next;

            }

            // Incrementing by one again for the cyclic meet point node.
            len++;

            Console.WriteLine("Length of the list is: " + len);
        }

        /// <summary>
        ///  With a pointer to head node of a linked list as argument, write a function to swap the consecutive elements of the list and return the head node. 
        /// (Do note change values of any node, only change the links.)
        /// Example :- 1->2->3->4->5->6->7 
        ///            2->1->4->3->6->5->7
        /// </summary>
        public void SwapConsecutiveElements()
        {
            // Check for empty linked list.
            if (head == null)
            {
                Console.WriteLine("Empty linkedlist.");
                return;
            }

            current = head;

            // run a loop until end of the linkedlist
            while (current != null)
            {
                // If next element is null, in an odd number of elements, do not proceed.
                if (current.next == null) break;

                // Swap the values if not.
                int temp = current.val;
                current.val = current.next.val;
                current.next.val = temp;

                // Move current to 2 steps
                current = current.next.next;
            }

            Console.WriteLine("After swapping.");
            Print();

        }

        /// <summary>
        ///  Find if the list is cyclic
        ///  bool findCircular(Node *head)
        /// {
        ///   Node *slower, * faster;
        ///   slower = head;
        ///   faster = head->next; //start faster one node ahead
        ///   
        ///     while(true) {
        ///     
        ///     // if the faster pointer encounters a NULL element
        ///     if( !faster || !faster->next)
        ///       return false;
        ///    
        ///     //if faster pointer ever equals slower or faster's next
        ///    //pointer is ever equal to slow then it's a circular list
        ///     else if (faster == slower || faster->next == slower)
        ///        return true;
        ///     else{
        ///       // advance the pointers
        ///        slower = slower->next;
        ///        faster = faster->next->next;
        ///      }
        ///   }
        ///}
        /// </summary>
        /// <returns></returns>
        public bool FindIfCyclic()
        {
            if (IsListEmpty())
            {
                return false;
            }

            // Case 1: 1 node
            if (head.next == null)
            {
                if (head.next == head)
                    return true;
                return false;
            }

            //Case 2: 2 nodes
            else if (head.next.next == null)
            {
                temp1 = head;
                temp2 = temp1.next;

                if (temp1.next == temp1)
                { return true; }

                if (temp2.next == temp1)
                    return true;
            }

            // Case 3: 3 or more nodes
            else
            {
                temp1 = head;
                temp2 = temp1.next.next; ;

                while (temp2.next != null && temp2.next.next != null)
                {
                    if (temp2 == temp1)
                    {
                        return true;
                    }

                    temp2 = temp2.next;
                    temp1 = temp1.next;
                }
            }

            return false;
        }

        /// <summary>
        /// This function rotates a linked list counter-clockwise and updates the head.
        /// The function assumes that k is smaller than size of linked list. It doesn't
        /// modify the list if k is greater than or equal to size
        /// 
        /// For example, 
        ///     if the given linked list is 10->20->30->40->50->60 and k is 4, 
        ///     the list should be modified to 50->60->10->20->30->40. Assume that k is smaller than the count of nodes in linked list.
        /// </summary>
        /// <param name="linkedList">Linked list</param>
        /// <param name="rotateBy">Rotateby</param>
        public void RotateByCertainNumber(LList linkedList, int rotateBy)
        {
            if (head == null || rotateBy < 1) return;

            Console.WriteLine("Before::");
            Print();

            temp1 = head;
            temp2 = head;
            Node temp3 = head;

            // current will either point to kth or NULL after this loop.
            //  current will point to node 40 in the above example
            int count = 1;
            while (temp1 != null && count < rotateBy)
            {
                temp1 = temp1.next;
                count++;
            }

            // If current is NULL, k is greater than or equal to count
            // of nodes in linked list. Don't change the list in this case
            if (temp1 == null)
            { return; }

            // current points to kth node. Store it in a variable.
            // kthNode points to node 40 in the above example
            temp2 = temp1;

            // current will point to last node after this loop
            // current will point to node 60 in the above example
            while (temp1.next != null)
            {
                temp1 = temp1.next;
            }

            // stitching the nodes together
            temp1.next = head;
            head = temp2.next;
            temp2.next = null;

            Console.WriteLine("Before::");
            Print();

        }

        /// <summary>
        /// Q1.- Written exam (Amazon, Bangalore)
        /// Given a singly link list and a number 'K', swap the Kth node from the start with the Kth node from the last. Check all the edge cases.
        /// Sample Input: 1->2->3->4->5->6->7->8 and K = 3
        /// Sample Output : 1->2->6->4->5->3->7->8
        /// Sample Input: 1->2->3->4->5->6->7->8 and K = 10
        /// Sample Output: print error "LIST IS OF LESSER SIZE".
        /// </summary>
        /// <param name="pos"></param>
        public void SwapPosition(int pos)
        {
            Console.WriteLine("Swapping position " + pos + " from first and last.");

            if (IsListEmpty() || pos <= 0)
            {
                Console.WriteLine("List is EMPTY OR Invalid position entered.");
                return;
            }

            #region SOLUTION #1
            /*
            temp1 = head;
            temp2 = head;

            Node firstN;
            
            for (int i = 1; i < pos; i++)
            {
                //if(pos>totalEle)
                if (temp2.next == null)
                {
                    Console.WriteLine("Invalid Position.");
                    return;
                }
                temp2 = temp2.next;
            }
            
            firstN = temp2;

            while (temp2.next != null)
            {
                temp2 = temp2.next;
                temp1 = temp1.next;
            }
            
            int tempVal = temp1.val;
            temp1.val = firstN.val;
            firstN.val = tempVal;
             * */
            #endregion

            #region SOLUTION #2

            Node firstN = head, lastN = head, pointerNode;
            pointerNode = head;
            int count = 0;

            while (pointerNode != null)
            {
                count++;

                if (count == pos)
                {
                    firstN = pointerNode;
                    lastN = head;
                }
                else if (count > pos)
                {
                    lastN = lastN.next;
                }
                pointerNode = pointerNode.next;
            }

            if (count < pos)
            {
                Console.WriteLine("Invalid Position.");
                return;
            }

            else if (firstN != null && lastN != null)
            {
                int val = firstN.val;
                firstN.val = lastN.val;
                lastN.val = val;
                return;
            }

            return;

            #endregion
        }

        /// <summary>
        /// Reverses a linked list
        /// Approach: 
        ///     1. Use three pointers temp, pre and next
        ///     2. temp points to head of a LL
        ///     3. pre/next null
        ///     4. Move until temp reaches end of a LL
        ///     5. Change next to temp.next
        ///     6. temp.next to pre
        ///     7. Pre = temp;
        ///     8. When teamp reaches to end of the LL, point head to pre. Return.
        /// </summary>
        /// <param name="linkedList">Linked list</param>
        public void Reverse(LList linkedList)
        {
            Node temp = head;
            Node pre = null;
            Node next = null;

            if (temp == null)
            {
                Console.WriteLine(" Empty Linkedlist");
                return;
            }

            Console.WriteLine("Before::");
            Print();

            // Run a loop unti it reaches end of the linked list.
            while (temp != null)
            {
                next = temp.next;
                temp.next = pre;
                pre = temp;
                temp = next;
            }

            head = pre;
            Console.WriteLine("Before::");
            Print();
        }

        public void ReverseAList()
        {
            if (IsListEmpty())
            {
                Console.WriteLine("List is empty.");
                return;
            }

            // Case 1: List has only one node.
            if (head.next == null)
            {
                return;
            }
            else if (head.next.next == null)
            {
                temp1 = head;
                temp2 = temp1.next;
                temp2.next = temp1;
                temp1.next = null;
                head = temp2;
                return;
            }
            else
            {
                temp1 = head;
                temp2 = temp1.next;
                Node temp3 = temp2.next;

                // End of the list
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
                head = temp3;
            }
        }

        public void PrintNthPosition(int pos)
        {
            Console.WriteLine("Looking for element at " + pos + " position...");

            if (IsListEmpty() || pos <= 0)
            {
                Console.WriteLine("Invalid position.");
                return;
            }
            else
            {
                uint count = GetCount();

                if (pos > count)
                {
                    Console.WriteLine("Position doesn't exist.");
                    return;
                }
                temp1 = head;
                for (int i = 1; i < pos; i++)
                {
                    temp1 = temp1.next;
                }
                Console.WriteLine("Value at Position: " + pos + " is: " + temp1.val);
            }
        }

        public void ReturnNthPositionFromLast(int pos)
        {
            Console.WriteLine("Looking for position from last:" + pos);

            if (IsListEmpty() || pos <= 0)
            {
                Console.WriteLine("List is EMPTY OR Invalid position entered.");
                return;
            }

            temp1 = head;
            temp2 = head;

            for (int i = 1; i < pos; i++)
            {
                if (temp2.next == null)
                {
                    Console.WriteLine("Invalid Position.");
                    return;
                }
                temp2 = temp2.next;
            }

            while (temp2.next != null)
            {
                temp2 = temp2.next;
                temp1 = temp1.next;
            }

            Console.WriteLine("Value at position " + pos + " is: " + temp1.val);
        }

        public void delete(uint position)
        {
            Console.WriteLine("Delete Position: " + position);

            if (IsListEmpty() || position <= 0)
            {
                Console.WriteLine("List is Empty OR Invalid position.");
                return;
            }

            uint count = GetCount();

            if (position > count)
            {
                Console.WriteLine("Position doesn't exist.\n");
                return;
            }
            if (position == 1)
            {
                head = head.next;
                return;
            }
            else
            {
                temp1 = head;
                temp2 = temp1.next; ;

                for (int i = 2; i < position; i++)
                {
                    temp1 = temp1.next;
                    temp2 = temp2.next;
                }

                temp1.next = temp2.next;
            }
        }

        public void Add(int val)
        {
            Node newNode = new Node(head, val);
            head = newNode;
        }

        /// <summary>
        ///  Last node will point the node at Position 'pos'
        /// </summary>
        /// <param name="pos"></param>
        public void CreateACycle(int pos)
        {
            if (IsListEmpty())
            {
                Console.WriteLine("EMPTY List");
                return;
            }

            uint count = GetCount();

            if (pos > count || pos <= 0)
            {
                Console.WriteLine("Invalid Position");
                return;
            }

            Node last = head;

            while (last.next != null)
            { last = last.next; }

            temp1 = head;

            for (int i = 1; i <= count; i++)
            {
                if (i == pos)
                {
                    last.next = temp1;
                    return;
                }
                temp1 = temp1.next;
            }
        }

        public void Print()
        {
            if (IsListEmpty())
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                temp1 = head;//.next;
                Console.Write("HEAD -> ");

                while (temp1.next != null)
                {
                    Console.Write(temp1.val + " -> ");
                    temp1 = temp1.next;
                }
                Console.Write(temp1.val);
            }
            Console.Write("-> NULL\n");
        }

        private bool IsListEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }

        private uint GetCount()
        {
            if (IsListEmpty())
            {
                return 0;
            }

            uint count = 1;
            temp1 = head;

            while (temp1.next != null)
            {
                temp1 = temp1.next;
                count++;
            }

            return count;

        }
    }

    class Node
    {
        public int val;
        public Node next;

        public Node(Node node, int val)
        {
            this.val = val;
            this.next = node;
        }
    }
}
