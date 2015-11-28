using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.BST
{
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

