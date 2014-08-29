using System;
using System.Collections.Generic;

using System.Text;

namespace MSFTPrep_Jan09
{
    class BinarySrchTree
    {
        Node root;
        Node temp;

        public BinarySrchTree() { root = null; }

        //Adding nodes to BST
        public void AddNode(int newValue)
        {
            if (root == null)
                root = new Node(newValue);
            else
                AddWhenNotNull(root, newValue);
        }

        public void AddWhenNotNull(Node root, int newValue)
        {
            if (newValue < root.value)
            {
                if (root.left == null)
                    root.left = new Node(newValue);
                else
                    AddWhenNotNull(root.left, newValue);
            }
            else if (newValue > root.value)
            {
                if (root.right == null)
                    root.right = new Node(newValue);
                else
                    AddWhenNotNull(root.right, newValue);
            }
        }

        //Iterative Node addition
        public void iterativeNodeAddition(int addThisValue)
        {
            if (root == null) root = new Node(addThisValue);

            else
            {
                temp = root;

                while (true)
                {
                    if (addThisValue < temp.value)
                    {
                        if (temp.left == null) { temp.left = new Node(addThisValue); break; }
                        else
                            temp = temp.left;
                    }
                    else
                    {
                        if (temp.right == null) { temp.right = new Node(addThisValue); break; }
                        else
                            temp = temp.right;
                    }
                }
            }
        }

        //Traversing The BST
        public bool TraverseTheBST(int LookAtThisVal)
        {
            //Checking if BST is Empty.
            if (root == null) { Console.WriteLine("Empty BST!"); return false; }

            temp = root;

            while (true)
            {
                //Value exists!
                if (temp.value == LookAtThisVal) return true;

                //The value is less than the value in current node, traverse left
                else if (LookAtThisVal<temp.value)
                {
                    //value doesn't exist
                    if (temp.left == null) return false;
                    temp = temp.left;
                }

                ////The value is greater than the value in current node, traverse right.
                else
                {
                    //value doesn't exist
                    if (temp.right == null) return false;
                    temp = temp.right;                    
                }
            }
        }

        public class Node
        {
            public Node right;
            public int value;
            public Node left;

            public Node(int data)
            {
                this.left = null;
                this.value = data;
                this.right = null;
            }
            public Node(Node left, int data, Node right)
            {
                this.left = left;
                this.value = data;
                this.right = right;
            }
        }

    }
}
