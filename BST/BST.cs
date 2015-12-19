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
        Node temp;
        LinkedList<int> linkedList;

        /// <summary>
        /// Print BST level by level separating each level by a line.
        /// Ref: http://stackoverflow.com/questions/2241513/java-printing-a-binary-tree-using-level-order-in-a-specific-format
        /// </summary>
        /// <param name="n">Root node</param>
        internal void PrintLevelByLevelInSeparateLine(Node n)
        {
            // Check for null
            if (n == null) return;

            // Use 2 Queues to store current level and next level
            Queue<Node> current = new Queue<Node>();
            Queue<Node> next = new Queue<Node>();

            // Enque the first node
            current.Enqueue(n);

            // Run until current Q is not empty
            while (current.Count > 0)
            {
                // Print a node and grab all of its children in next queue
                foreach (Node temp in current)
                {
                    Console.Write(temp.data + " ");
                    if (temp.left != null) next.Enqueue(temp.left);
                    if (temp.right != null) next.Enqueue(temp.right);
                }
                // Empty new line print to indicate it's a new line
                Console.WriteLine();

                // Current becomes next and rest Next.
                current = next;
                next = new Queue<Node>();
            }
        }

        /// <summary>
        /// Print a BST level by level ie breadth first search
        /// Note: This doesn't print level in a next line. See PrintLevelByLevelInSeparateLine()
        /// </summary>
        internal void PrintLevelByLevel(Node n)
        {
            // Check if node is null
            if (n == null) return;

            // Queue is used here to print level by level as we need FIFO DS
            Queue<Node> q = new Queue<Node>();

            // Enqueue the first node
            q.Enqueue(n);

            // Run until Q is empty
            while (q.Count() > 0)
            {
                // Dequeue and print
                Node temp = q.Dequeue();
                Console.WriteLine(temp.data);

                // Enqueue its left and right child, if exist.
                if (temp.left != null) q.Enqueue(temp.left);
                if (temp.right != null) q.Enqueue(temp.right);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BST()
        {
            this.root = null;
            this.linkedList = new LinkedList<int>();
        }

        public Node root { get; set; }

        /// <summary>
        /// Prints a linked list
        /// </summary>
        public void PrintLinkedList()
        {
            foreach (int item in this.linkedList)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Flatten Binary Tree to Linked List
        /// </summary>
        /// <param name="node">Node</param>
        public void FlattenABST(Node node)
        {
            if (node == null) return;

            linkedList.AddLast(node.data);
            FlattenABST(node.left);
            FlattenABST(node.right);
        }

        /// <summary>
        /// Finds a common ancestor of the given two nodes.
        /// </summary>
        /// <param name="temp">Root node</param>
        /// <param name="n1">Fist element</param>
        /// <param name="n2">Second Element</param>
        public void FindCommonAncestor(Node temp, int n1, int n2)
        {
            if (temp == null)
            {
                Console.WriteLine("No common Ancestor.");
                return;
            }

            // If both values are less than the temp, go left.
            if (n1 < temp.data && n2 < temp.data)
            {
                FindCommonAncestor(temp.left, n1, n2);
            }
            // If both n1 and n2 are greater than root, then LCA lies in right
            else if (n1 > temp.data && n2 > temp.data)
            {
                FindCommonAncestor(temp.right, n1, n2);
            }
            else
                Console.WriteLine("Common Ancestor of " + n1 + " & " + n2 + " : " + temp.data);

        }

        /// <summary>
        /// K’th Largest Element in BST when modification to BST is not allowed
        /// Given a Binary Search Tree (BST) and a positive integer k, find the k’th largest element in the Binary Search Tree.
        /// </summary>
        /// <param name="temp">Root node</param>
        /// <returns>Kth largest element</returns>
        public void FindKthLargestElement(Node temp, int k)//, ref int count)
        {
            // NOTE: NOT cpmletely solved. It prints more elements right now.
            if (temp != null || k < 0) return;

            FindKthLargestElement(temp.right, k);

            --k;

            if (k == 0)
            {
                Console.WriteLine(k + "th element is : " + temp.data);
                return;
            }

            FindKthLargestElement(temp.left, k);

            //if (temp == null && count >= k) return;

            //FindKthLargestElement_(temp.right, k, ref count);
            //count++;

            //if (count == k)
            //{
            //    Console.WriteLine(k + "th element is : " + temp.data);
            //    return;
            //}

            //FindKthLargestElement_(temp.left, k, ref count);
        }

        /// <summary>
        /// Count BST nodes that lie in a given range
        /// Given a Binary Search Tree (BST) and a range, count number of nodes that lie in the given range.
        /// </summary>
        /// <param name="low">Low value</param>
        /// <param name="high">Hight value</param>
        /// <returns>Count of nodes</returns>
        public int CountNodesInARange(Node temp, int low, int high)
        {
            // Null node, n return 0
            if (temp == null) return 0;

            // If data equals to both low and high. Edge case. This will increase efficiency.
            if (temp.data == low && temp.data == high) return 1;

            // data is in between low and high range
            if (temp.data >= low && temp.data <= high)
            {
                return 1 + CountNodesInARange(temp.left, low, high) + CountNodesInARange(temp.right, low, high);
            }

            // Data is less than the lower range. Go right.
            else if (temp.data < low)
            {
                return CountNodesInARange(temp.right, low, high);
            }
            else // Data is more than the higher range. Go left.
            {
                return CountNodesInARange(temp.left, low, high);
            }
        }

        /// <summary>
        /// Finds the height of a BST recursively
        /// </summary>
        /// <param name="temp">Node</param>
        /// <returns>Height of a BST</returns>
        public int FindHeight(Node temp)
        {
            if (temp == null) return -1;

            int leftHeight = FindHeight(temp.left);
            int rightHeight = FindHeight(temp.right);

            if (leftHeight > rightHeight)
                return leftHeight + 1;
            else
                return rightHeight + 1;
        }

        /// <summary>
        /// Finda a minimum value in a BST
        /// </summary>
        /// <returns>A minimum value.</returns>
        public int FindMin()
        {
            // BST is empty.
            if (IsEmpty())
            {
                Console.WriteLine("BST is empty.");
                return int.MinValue;
            }

            // Initialize a runner pointer
            temp = root;

            // Stores a minmum number
            int min = temp.data;

            // run a loop until you reach the leftmost node
            while (temp != null)
            {
                // Move to a left node cause that's where leftmost ie minimum value node is
                temp = temp.left;
                // Update a minimum value ONLY IF temp is NOT pointing to null
                if (temp != null) min = temp.data;
            }

            // Return minimum value.
            return min;
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
        /// <param name="temp">Starting node</param>
        /// <param name="data">Data to find</param>
        /// <returns>True or false</returns>
        private bool FindRecursive(Node temp, int data)
        {
            // Node is null. Data do not exist.
            if (temp == null) return false;

            return temp.data == data ||
                    FindRecursive(temp.left, data) ||
                    FindRecursive(temp.right, data);
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
        /// Prints a BST recursively
        /// </summary>
        /// <param name="n">Node to start printing.</param>
        public void Print(Node n)
        {
            if (n != null)
            {
                Print(n.left);
                Console.Write(n.data + " ");
                Print(n.right);
            }
            //Console.WriteLine();
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

