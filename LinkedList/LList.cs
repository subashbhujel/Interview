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
        private Node temp1 = null, temp2 = null;

        /// <summary>
        /// Implement an algorithm to delete a node in the middle of a single linked list, given only access to that node  
        /// EXAMPLE 
        ///     Input: the node ‘c’ from the linked list a->b->c->d->e 
        ///     Result: nothing is returned, but the new linked list looks like a->b->d->e
        /// </summary>
        public void DeleteNodeInTheMiddleNode(Node n)
        {
            //  The solution to this is to simply copy the data from the next node into this node and then delete the next node  
            //  
            //  NOTE: 
            //      This problem can not be solved if the node to be deleted is the last node in the linked list   
            //      That’s ok—your interviewer wants to see you point that out   
            //      You could consider marking it as dummy in that case    
            //      This is an issue you should discuss with your interviewer  

            if (IsListEmpty() || head.next == null)
                return;

            temp1 = n.next;
            n.val = temp1.val;
            n.next = temp1.next;
        }

        /// <summary>
        /// Write code to remove duplicates from an unsorted linked list  FOLLOW UP How would you solve this problem if a temporary buffer is not allowed?
        /// </summary>
        /// <param name="list"></param>
        public void RemoveDuplicatesFromUnsortedList()
        {
            // APPROACH: 
            // 1. If we can use a buffer, we can keep track of elements in a hashtable and remove any dups.
            // 2. Without any buffer: 
            //      We can iterate with two pointers: “current” does a normal iteration, 
            //      while “runner” iterates through all prior nodes to check for dups    
            //      Runner will only see one dup per node, because if there were multiple duplicates they would have been removed already  

            if (IsListEmpty())
            {
                Console.WriteLine("Empty List.");
                return;
            }

            Node previous = head;
            Node current = previous.next;

            Print();

            // run until current reaches end of the list
            while (current != null)
            {
                // Always start runner from the beginning
                Node runner = head;

                // Run until runner meets current
                while (runner != current)
                {
                    // Check for duplicates value
                    if (runner.val == current.val)
                    {
                        // Remove duplicate 
                        temp1 = current.next;
                        previous.next = temp1;
                        current = temp1;
                        break;
                    }
                    // No duplicate. All unique so far. Continue with runner.
                    runner = runner.next;
                }

                // Check all elements from beginning (head) to current, now move forward the previous and current pointer.
                if (runner == current)
                {
                    previous = current;
                    current = current.next;
                }
            }

            Print();
        }

        /// <summary>
        /// METHOD 1 (Use a Stack)
        ///         A simple solution is to use a stack of list nodes.This mainly involves three steps.
        ///     1) Traverse the given list from head to tail and push every visited node to stack.
        ///     2) Traverse the list again.For every visited node, pop a node from stack and compare data of popped node with currently visited node.
        ///     3) If all nodes matched, then return true, else false.
        ///     Time complexity of above method is O(n), but it requires O(n) extra space.Following methods solve this with constant extra space.
        /// 
        /// METHOD 2 (By reversing the list)
        ///     This method takes O(n) time and O(1) extra space.
        ///     1) Get the middle of the linked list.
        ///     2) Reverse the second half of the linked list.
        ///     3) Check if the first half and second half are identical.
        ///     4) Construct the original linked list by reversing the second half again and attaching it back to the first half
        /// </summary>
        /// <returns></returns>
        public bool CheckIfListIsPalindrome()
        {
            bool isPalindrome = false;

            // Check if list is empty
            if (IsListEmpty())
            {
                return isPalindrome;
            }

            #region METHOD 1 : Use Stack!

            /*
            Stack<int> stack = new Stack<int>();

            temp1 = head;

            while (true)
            {
                stack.Push(temp1.val);
                temp1 = temp1.next;

                if (temp1 == null)
                    break;
            }

            temp1 = head;

            while (true)
            {
                if (stack.Pop() != temp1.val)
                {
                    return false;
                }

                temp1 = temp1.next;

                if (temp1 == null)
                    return true;

            }
            */

            #endregion

            #region Method 2 : Reverse the list

            temp1 = head;
            Node fastPointer = head, slowPointer = head;
            Node midNode = null;

            while (fastPointer != null && fastPointer.next != null)
            {
                fastPointer = fastPointer.next.next;

                slowPointer = slowPointer.next;
            }

            Console.WriteLine(slowPointer.val);

            return isPalindrome;

            #endregion
        }

        /// <summary>
        ///  Find the length of a linked list which contains cycle.
        /// Approach: Use Slow and Fast pointer
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
            Console.WriteLine("After swapping.");

        }

        /// <summary>
        /// Swap two nodes
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        private void Swap(Node n1, Node n2)
        {
            int val = n1.val;
            n1.val = n2.val;
            n2.val = val;
        }

        /// <summary>
        ///  Find if the list is cyclic
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
        /// Given a singly linked list, rotate the linked list counter-clockwise by k nodes. Where k is a given positive integer. 
        /// 
        /// Approach:
        ///     Assume that k is smaller than the count of nodes in linked list.
        ///     To  rotate the linked list, we need to change next of kth node to NULL, next of last node to previous head node, and finally change head to(k+1)th node.
        ///     So we need to get hold of three nodes: kth node, (k+1)th node and last node.
        ///     Traverse the list from beginning and stop at kth node.Store pointer to kth node. We can get (k+1)th node using kthNode->next.
        ///     Keep traversing till end and store pointer to last node also.Finally, change pointers as stated above.
        /// 
        /// For Eg:
        ///     input  : 10->20->30->40->50,
        ///     output : 30->40->50->10->20 (for num = 2) 
        /// </summary>
        /// <param name="num"></param>
        public void RotateTheList(int num)
        {
            if (IsListEmpty() || num <= 0)
            {
                Console.WriteLine("List is empty or Invalid number.");
                return;
            }

            Console.WriteLine("\nAttempting to rotate by " + num);
            int count = num;
            temp1 = head;

            while (count > 1)
            {
                if (temp1.next == null)
                {
                    Console.WriteLine("\nCANNOT rotate by " + num + "\n");
                    return;
                }
                temp1 = temp1.next;
                count--;
            }

            temp2 = temp1;

            // Find the last node
            while (temp2.next != null)
            {
                temp2 = temp2.next;
            }

            Node temp3 = head;

            while (temp3.next != temp1 && temp3 != temp1)
            {
                temp3 = temp3.next;
            }

            //Rotating
            temp2.next = head;
            head = temp1.next;
            temp1.next = null;

        }

        /// <summary>
        /// With a pointer to head node of a linked list as argument, write a function to swap the consecutive elements of the list and return the head node. 
        /// (Do note change values of any node, only change the links.)
        /// Example :-1->2->3->4->5->6->7
        ///         2->1->4->3->6->5->7
        /// </summary>
        public void SwapEvery2Nodes()
        {
            if (IsListEmpty())
            {
                Console.WriteLine("List is EMPTY");
                return;
            }

            // Case 1:  1 Node only
            if (head.next == null)
            {
                return;
            }
            else
            {
                temp1 = head;
                temp2 = temp1.next;

                while (temp2.next != null)
                {
                    Swap(temp1, temp2);

                    temp1 = temp2.next;
                    if (temp1.next == null)
                    {
                        return;
                    }
                    else
                        temp2 = temp1.next;
                }
                Swap(temp1, temp2);
            }

        }

        /// <summary>
        /// Q1.- Written exam (Amazon, Bangalore)
        /// Given a singly link list and a number 'K', swap the Kth node from the start with the Kth node from the last. Check all the edge cases.
        /// 
        /// For eg:
        ///     Input: 1->2->3->4->5->6->7->8 and K = 3
        ///     Output : 1->2->6->4->5->3->7->8
        /// 
        ///     Input: 1->2->3->4->5->6->7->8 and K = 10
        ///     Output: print error "LIST IS OF LESSER SIZE".
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
