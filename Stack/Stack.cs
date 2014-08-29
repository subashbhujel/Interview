using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Stack
{
    /// <summary>
    /// Q. Implement a stack data structure with push,pop,peek & getMax operations.
    /// </summary>
    class Stack
    {
        // Using Stack because resizing an array is expensive. And list has handy API for removing, adding, peeking, ...
        private List<int> list;

        public Stack()
        {
            this.list = new List<int>();
        }

        public void Push(int data)
        {
            list.Add(data);
        }

        public void Pop()
        {
            // Check if list is empty.
            if (list.Count > 0)
            {
                list.Last();
                list.Remove(list.Last());
            }
            else
            {
                Console.WriteLine("Empty Stack!");
            }
        }

        public bool Peek(int data)
        {
            return list.Contains(data);
        }

        public int GetMax()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Empty Stack!");
                // Throw a (custom) exception for empty stack and handle at the calling side. But I'm returning minvalue for ease here.
                return int.MinValue;
            }

            int max = list.First();

            foreach (int data in list)
            {
                if (data > max && data != max)
                {
                    max = data;
                }
            }
            return max;
        }

        public void Print()
        {
            Console.WriteLine();
            foreach (int d in list)
            {
                Console.Write(d + " ");
            }
            Console.WriteLine();
        }
    }
}
