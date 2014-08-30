using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.BST
{
    class BST
    {
        Node root, temp;

        public BST()
        {
            root = null;
        }

        /// <summary>
        /// Find the depth of BST.
        /// Approach is to use Queue 
        /// </summary>
        /// <returns>The depth of a BST.</returns>
        public int FindTheHeight()
        {
            int height = 0;

            if (root == null)
            {
                Console.WriteLine("Empty BST.");
                return height;
            }

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);
            int numOfEleInQueue = 0;

            while (true)
            {
                numOfEleInQueue = queue.Count;

                if (numOfEleInQueue == 0)
                {
                    return height;
                }

                height++;

                // Dequeue the node and insert its childrens
                // Dequeur only the nodes in that leevl
                while (numOfEleInQueue > 0)
                {
                    // Remove the node
                    Node temp = queue.Dequeue();

                    // Add its childrens
                    if (temp.left != null)
                        queue.Enqueue(temp.left);

                    if (temp.right != null)
                        queue.Enqueue(temp.right);

                    numOfEleInQueue--;
                }
            }
            return height;
        }

        /// <summary>
        /// Copied the solution here: http://leetcode.com/2010/09/printing-binary-tree-in-level-order.html
        /// Level by level traversal is known as Breadth-first traversal. 
        /// Using a Queue is the proper way to do this. If you wanted to do a depth first traversal you would use a stack.
        /// The way you have it is not quite standard though. Here's how it should be.
        /// </summary>
        public void PrintLevelByLevel()
        {
            Queue<Node> queue = new Queue<Node>();

            if (IsEmpty())
            {
                Console.WriteLine("Empty BST");
                return;
            }
            Console.WriteLine("Printing Level-By-Level");

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                temp = queue.Dequeue();
                Console.Write(temp.data + " ");

                if (temp.left != null)
                    queue.Enqueue(temp.left);

                if (temp.right != null)
                    queue.Enqueue(temp.right);
            }

        }

        /// <summary>
        /// Copied the solution from: http://leetcode.com/2010/09/determine-if-binary-tree-is-binary.html
        ///     Solution is to do an in-order traversal of the binary tree, and verify that the previous value 
        ///     (can be passed into the recursive function as reference) is less than the current value. 
        ///     This works because when you do an in-order traversal on a BST, the elements must be strictly in increasing order. 
        ///     This method also runs in O(N) time and O(1) space.
        /// </summary>
        public void IsBST()
        {
            if (CheckBST(root, int.MinValue))
                Console.WriteLine("Valid BST!");
            else
                Console.WriteLine("Invalid BST!");
        }

        public bool CheckBST(Node n, int min)
        {
            if (n == null)
                return true;
            if (CheckBST(n.left, min))
            {
                if (n.data > min)
                {
                    min = n.data;
                    return CheckBST(n.right, min);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Find(int data)
        {
            Console.Write("\nLooking for " + data + " : ");

            if (IsEmpty())
            { return false; }

            temp = root;

            while (true)
            {
                if (temp.data == data)
                {
                    return true;
                }

                // Go left
                else if (data < temp.data)
                {
                    if (temp.left != null)
                    {
                        temp = temp.left;
                        continue;
                    }
                    return false;
                }

                // Go Right
                else
                {
                    if (temp.right != null)
                    {
                        temp = temp.right;
                        continue;
                    }
                    return false;
                }
            }
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("BST is Empty");
                return;
            }

            PrintRecursive(root);
            Console.WriteLine();
        }

        private void PrintRecursive(Node n)
        {
            if (n != null)
            {
                PrintRecursive(n.left);
                Console.Write(n.data + " ");
                PrintRecursive(n.right);
            }
        }

        public void Add(int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return;
            }

            temp = root;

            while (true)
            {
                if (temp.data == data)
                {
                    Console.WriteLine("Data already exist. Please enter another value.");
                    return;
                }
                // Go left
                else if (data < temp.data)
                {
                    if (temp.left == null)
                    {
                        temp.left = new Node(data);
                        return;
                    }
                    temp = temp.left;
                }
                // Go Right
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = new Node(data);
                        return;
                    }
                    temp = temp.right;
                }
            }
        }

        public bool IsEmpty()
        {
            if (root == null)
            {
                return true;
            }
            return false;
        }
    }

    class Node
    {
        public Node left;
        public int data;
        public Node right;

        public Node(int data)
        {
            this.left = null;
            this.data = data;
            this.right = null;
        }

        public Node(Node left, int data, Node right)
        {
            this.left = left;
            this.data = data;
            this.right = right;
        }
    }
}
