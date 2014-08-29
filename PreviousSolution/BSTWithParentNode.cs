using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Preparation_II
{
    class BSTWithParentNode
    {
        Node root;
        Node temp;
        
        public BSTWithParentNode() { root = null; }

        public void DeleteNode(int data)
        {
            if (root == null) return;

            Console.WriteLine("Deleting "+data+" . . . ");
            temp = root;

            Node dataNode = FindNode(data);
            
            temp = dataNode;
            
            if (temp != null)
            {                
                #region Case-I : Node to remove is a leaf Node
                if (temp.left == null && temp.right == null)
                { 
                    //If that node is a root node
                    if (temp.parent == null)
                    {
                        root = null;
                        return;
                    }
                    if (temp.parent.left == temp)
                    {
                        temp.parent.left = null;
                        return;
                    }
                    //if its a right node
                    else
                    {
                        temp.parent.right = null;
                        return;
                    }
                }
                #endregion 

                #region Case-II : Node to be removed has only one child
                //if its a left child
                else if (temp.left != null && temp.right == null)
                {
                    temp.parent.left = temp.left;
                    return;
                }
                //right child
                else if (temp.right != null && temp.left == null)
                {
                    temp.parent.right = temp.right;
                    return;
                }
                #endregion
                
                #region Case-III : Node to be romoved has two childrens
                else //if (temp.left != null && temp.right != null)
                { 
                    Node leftmostNode = temp.right;
                    
                    while (leftmostNode.left != null) leftmostNode = leftmostNode.left;
                    
                    //if node to be removed is in the left side of its parent
                    
                    if (temp.parent.left == temp)
                    {
                        temp.data = leftmostNode.data;

                        if (leftmostNode.right != null)                 
                            temp.right = leftmostNode.right;
                        else
                            temp.right = null;
                    }
                    else 
                    {
                        temp.data = leftmostNode.data;

                        if (leftmostNode.right != null)
                            leftmostNode.parent.left = leftmostNode.right;
                        else
                            leftmostNode.parent.left = null;                        
                    }
                }
                #endregion
            }
        }

        public int FindRank(int data)
        {
            Console.Write("\nRank of "+data+" is : ");
            
            int rank = 0;

            if (root == null) return rank;
            
            temp = root;
            Node temp2;
            
            Stack<Node> stackOfData=new Stack<Node>();
            
            stackOfData.Push(temp);
           // ++rank;

            while(true)
            {

                if (temp.left != null)
                {
                    temp = temp.left;
                    stackOfData.Push(temp);                 
                }
                else 
                {
                    temp2 = stackOfData.Pop();
                    ++rank;
                    if (stackOfData.Count == 0) return 0;
                    if (temp2.data == data) return rank;

                    if (temp2.right != null)
                    {
                        temp = temp2.right;
                        stackOfData.Push(temp);
                    }
                }
            }
        }

        public int FindSecondLargestNumNode(Node node)
        {            
            if (node.left == null && node.right == null && node.parent.right.data == node.data)
            {
                while (node.parent.right.data == node.data) { node = node.parent; }
                
                if (node.parent.left.data == node.data) return node.parent.data;
                
                Console.WriteLine("Not found !");
            }
            else if (node.right != null)
            {
                node = node.right;
                while (node.left != null)
                {
                    node = node.left;
                }
                return node.data;
            }
            
            else if (node.right == null && node.parent.left.data == node.data)
               return node.parent.data;
           return -09090909;
        }

        public int FindSecondLargestNum(int first)
        {
            Console.WriteLine("Finding Next largest number than "+first+" . . . ");

            Node nextNode=FindNode(first);

            if (nextNode != null)
                return FindSecondLargestNumNode(nextNode);
                //return bvh(nextNode);
            return -09090909;
        }

        public Node FindNode(int data)
        {   
            if (root == null) return null;
            
            temp = root;

            while (true)
            {
                if (data == temp.data) return temp;
                else if (data < temp.data)
                {
                    if (temp.left == null) return null;
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null) return null;
                    temp = temp.right;
                }
            }            
        }
                
        public void IterativeInsertion(int data)
        {
            if (root==null) 
            {
                root = new Node(data); 
                return; 
            }
            
            temp = root;
            
            while (true)
            {
                if (data < temp.data)
                {
                    if (temp.left == null)
                    {
                        temp.left = new Node(null, data, null, temp); 
                        break; 
                    }
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = new Node(null, data, null, temp);
                        break;
                    }
                    temp = temp.right;
                }                
            }
        }

        public void IterativePrint()
        {
            if (root == null) 
            {
                Console.WriteLine("Empty Tree !");
                return; 
            }

            Console.Write("Original Tree : ");
            temp = root;
            Node temp2;

            Stack<Node> stackOfNode = new Stack<Node>();

            stackOfNode.Push(temp);
            
            do
            {
                if (temp.left != null)
                {                    
                    temp = temp.left;
                    stackOfNode.Push(temp);
                }
                else
                {
                    temp2 = stackOfNode.Pop();

                    Console.Write(temp2.data + " ");

                    if (temp2.right != null)
                    {
                        temp = temp2.right;
                        stackOfNode.Push(temp);
                    }
                }
            } while (stackOfNode.Count != 0);
            Console.WriteLine();
        }

        public void RecurPrint()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is Empty !");
                return;
            }
            RecursivePrintBSTII(root);
            Console.WriteLine();
        }
       
        public void RecursivePrintBSTII(Node node)
        {
            if (node != null)
            {
                RecursivePrintBSTII(node.left);
                Console.Write(node.data + " ");
                RecursivePrintBSTII(node.right);
            }
        }
        
        public class Node
        {
            public Node left;
            public int data;
            public Node right;
            public Node parent;

            public Node(int data)
            {
                this.left = null;
                this.data = data;
                this.right = null;
                this.parent = null;
            }

            public Node(Node left, int data, Node right,Node parent)
            {
                this.left = left;
                this.data = data;
                this.right = right;
                this.parent = parent;
            }
        }
    }
}
