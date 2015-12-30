using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.BST
{
    /// <summary>
    /// Tree class
    /// </summary>
    class Tree
    {
        /// <summary>
        /// Team: PowerBI, Microsoft Corp
        /// Q. Given a tree with following characteristics:
        ///     - It's not a binary tree and it's not sorted
        ///     - Each node has - a link to it's parent node, it's first child and it's sibling.
        ///     - The tree is complete in each level except the last level. ie 
        ///                                 1
        ///                         2               3
        ///                     4   5   6               7
        ///                     8   9   10              11
        /// In given tree above, here's the behaviour:
        ///     Input: 1, return: null
        ///     Input: 2, return: 3
        ///     Input: 3, return: null
        ///     Input: 4, return 5
        ///     Input: 6, return 7
        ///     Input: 10, return: 11
        /// 
        /// Twist I:
        ///     For the rightmost node, return it's leftmost sibling ie:
        ///     Input: 1, return: null
        ///     Input: 3, return: 2
        ///     Input: 7, return: 4
        ///     Input: 11, return 8
        ///     
        /// 
        /// Twist II:
        ///     What is Node2 is modified to have a status ie each node can be 'disabled'
        ///     So, if a returned node is disabled, return it's next sibling.
        ///         if a returned node is disabled, and all of it's siblings are disabled then return it's leftmost node. Like twist I above.
        ///         
        /// Note: Disabled status affect only at the lowest level ie 8,9,10,11 so if 6 is disabled, you can still use it to traverse
        ///         to get it's parent and it's siblings.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node2 FindNextSibling(Node2 node)
        {
            // Solution to Original question ie without any twist.
            //                              1
            ///                         2               3
            ///                     4   5   6               7
            ///                     8   9   10              11
            // Check for null node
            if (node == null)
            { return null; }

            // If it has sibling, you are lucky. Just return it.
            if (node.sibling != null)
            { return node.sibling; }

            // If passed node is a root node, return null;
            if (node.parent == null) return null;

            // Stores the level it has to go through to get the sibling.
            int level = 0;

            // Loop until you reach to a node that has sibling.
            while (node.sibling == null)
            {
                // If parent node is null, there's no sibling. Return null.
                if (node.parent == null)
                {
                    return null;

                    // Twist I: Solution.
                    // Instead of returning null here. We want to return it's leftmost sibling.
                    // Comment the return null line above and replace it with :
                    // break;
                    // You can also use some kind of flag to indicate you found the rightmost node and 
                    //      you have to return the leftmost sibling.

                    // What this does is breaks the flow here and moves on with loop below ie while(level>0).
                    // It will return the leftmost sibling.
                }

                // Move up
                node = node.parent;

                // Increment the level
                level++;

                // Note: To solve the twist - I. Else you can move this outside of while loop.
                if (node.sibling != null) node = node.sibling;
            }

            while (level > 0)
            {
                if (node.firstChild != null)
                {
                    node = node.firstChild;
                }
                else
                {
                    // BUG: Tree is supposed to be complete in each level
                    Console.WriteLine("Invlid Tree. Please fix the tree.");
                    return null;
                }
                level--;
            }

            return node;

            //Twist II: solution.
            // Approach:
            //  Move two while loop to separate method: FindSibling(Node2 node)
            //  call until returned node is NOT disabled.
            //  Done.

            //do
            //{
            //    node = FindSibling(node);

            //} while (node.disabled);

            //return node;
        }

        /// <summary>
        /// Finds a sibling when a node is disabled. 
        /// Twist II from above problem
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Node</returns>
        public Node2 FindSibling(Node2 node)
        {
            // Stores the level it has to go through to get the sibling.
            int level = 0;

            // Loop until you reach to a node that has sibling.
            while (node.sibling == null)
            {
                // If parent node is null, there's no sibling. Return null.
                if (node.parent == null)
                {
                    // Twist I: Solution.
                    break;
                }

                // Move up
                node = node.parent;

                // Increment the level
                level++;

                // Note: To solve the twist - I. Else you can move this outside of while loop.
                if (node.sibling != null) node = node.sibling;
            }

            while (level > 0)
            {
                if (node.firstChild != null)
                {
                    node = node.firstChild;
                }
                else
                {
                    // BUG: Tree is supposed to be complete in each level
                    Console.WriteLine("Invlid Tree. Please fix the tree.");
                    return null;
                }
                level--;
            }

            return node;
        }

        /// <summary>
        /// The root node
        /// </summary>
        public Node2 root;

        /// <summary>
        /// A temporary node
        /// </summary>
        public Node2 temp;

        /// <summary>
        /// Constructor
        /// </summary>
        public Tree()
        {
            this.root = null;
        }

        public void Add(Node2 parent, Node2 sibling, Node2 firstChild)
        {
            if (this.root == null)
            {
                this.root = new Node2(parent, sibling, firstChild);
                return;
            }

            while (true)
            {
                //TODO: implement a way to add a special tree
                break;
            }
        }
    }
}
