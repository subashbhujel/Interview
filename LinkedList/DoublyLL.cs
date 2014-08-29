using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DoubleLL
{
    class DoublyLL
    {
        Node head,temp1,temp2,temp3;

        public DoublyLL()
        {
            head = null;
        }

        public void Add(int val)
        {
            Node newNode = new Node(this.head.pre, val, this.head.next);
            head.next = newNode;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List Is Empty.");
                return;
            }

            temp1=head;
            while (temp1.next != null)
            {
                Console.Write(temp1.val+" ");
            }
            Console.WriteLine();
        }
        private bool IsEmpty()
        {
            if (head == null)
                return true;

            return false;
        }
    }

    class Node
    {
        public Node next;
        public Node pre;
        public int val;

        public Node(Node pre, int val, Node next)
        {
            this.pre = pre;
            this.val = val;
            this.next = next;
        }
    }
}
