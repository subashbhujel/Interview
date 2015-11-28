using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.BST
{
    /// <summary>
    /// Binary Search Tree
    /// </summary>
    class BST
    {
        Node root, temp;

        /// <summary>
        /// Constructor
        /// </summary>
        public BST()
        {
            root = null;
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

        /// <summary>
        /// Finds an item in a BST recursive way
        /// </summary>
        /// <param name="data">Data to find</param>
        /// <returns>True or false</returns>
        public bool FindRecursive(int data)
        {
            temp = root;
            return FindRecursive_(temp, data);
        }

        /// <summary>
        /// Finds an item in a BST recursive way
        /// </summary>
        /// <param name="temp">Starting node</param>
        /// <param name="data">Data to find</param>
        /// <returns>True or false</returns>
        private bool FindRecursive_(Node temp, int data)
        {
            // Node is null. Data do not exist.
            if (temp == null) return false;

            return temp.data == data ||
                    FindRecursive_(temp.left, data) ||
                    FindRecursive_(temp.right, data);
        }

        /// <summary>
        /// Finds an item in a BST iterative way
        /// </summary>
        /// <param name="data">Data to find</param>
        /// <returns>True or false</returns>
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

        /// <summary>
        /// Prints a BST recursively.
        /// </summary>
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

        /// <summary>
        /// Prints a BST recursively
        /// </summary>
        /// <param name="n">Node to start printing.</param>
        private void PrintRecursive(Node n)
        {
            if (n != null)
            {
                PrintRecursive(n.left);
                Console.Write(n.data + " ");
                PrintRecursive(n.right);
            }
        }

        /// <summary>
        /// Adds an item to a BST
        /// </summary>
        /// <param name="data">Item to add.</param>
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

        /// <summary>
        /// Checks if BST is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (root == null)
            {
                return true;
            }
            return false;
        }
    }
}

