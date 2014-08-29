using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class BST
    {
        Node root;
        Node temp;
        
        public BST()
        {
            root = null;
        }

        public int FindNextBiggestNode(int value)
        {
            return 0;
            /*
            Console.WriteLine("Finding next biggest value of : "+value+" . . . .");
            
            Boolean found = FindNode(value);
            
            int nextNum = -1;
            
            if (found)
            {
                if (temp.right != null)
                    nextNum = FindLeftmostNode(temp.right);
                else 
                {
                    nextNum = 999999999;
                    return nextNum;
                }
                //return nextNum;
            }            
            return nextNum;*/
        }

        private int FindLeftmostNode(Node node)
        {
            temp = node;
            
            while (true)
            {
                if (temp.left == null) return temp.data;
                temp = temp.left;
            }
        }

        public bool FindNode(int data)
        {
            Console.WriteLine("Finding "+data+" . . . ");
            
            if (root == null) return false;
            
            temp = root;

            while (true)
            {
                if (data == temp.data) return true;
                else if (data < temp.data)
                {
                    if (temp.left == null) return false;
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null) return false;
                    temp = temp.right;
                }
            }
        }
        
        public void IterativeNodeAddition(int data)
        {
            if (root == null) root = new Node(data);
            
            else
            {
                temp = root;

                while (true)
                {
                    if (data < temp.data)
                    {
                        if (temp.left == null)
                        {
                            temp.left = new Node(data);
                            break;
                        } 
                        temp = temp.left;
                    }
                    else
                    {
                        if (temp.right == null)
                        {
                            temp.right = new Node(data);
                            break;
                        }
                        temp = temp.right;
                    }
                }
            }
        }

        public void AddNode(int data)
        {
            if (root == null) root = new Node(data);
            else 
                AddWhenNotNull(data,root);
        }

        private void AddWhenNotNull(int data,Node node)
        {
            if (data < node.data)
            {
                if (node.left == null)
                    node.left = new Node(data);
                else
                    AddWhenNotNull(data, node.left);
            }
            else if (data > node.data)
            {
                if (node.right == null)
                    node.right = new Node(data);
                else
                    AddWhenNotNull(data, node.right);
                //node.Right = new Node(null, data, null);
            }
            //else if()
        }

        public void PrintBSTUsingStack()
        {
            if (root == null) return;
            
            Node temp = root;
            Stack<int> stackTree = new Stack<int>();

            while(true)
            {
                if (temp.left != null)
                {
                    temp = temp.left;
                }
                //else if (temp.right)
                //{ }
                return;
            }
        }
        
        public void PrintBST()
        {
            if (root==null)
            {
                Console.WriteLine("Tree is Empty !");
                return;
            }
            RecursivePrintBSTII(root);
            Console.WriteLine();
        }

        private void RecursivePrintBSTII(Node root)
        {
            if (root != null)
            {
                RecursivePrintBSTII(root.left);
                Console.Write(root.data+" ");
                RecursivePrintBSTII(root.right);
            }
        }
        
        public void DeleteNode(int data)
        {
        }
        
        public class Node
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
}
