using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.BST
{
    class Node2
    {
        /// <summary>
        /// Stores the parent info
        /// </summary>
        public Node2 parent;

        /// <summary>
        /// Stores the next sibling info.
        /// </summary>
        public Node2 sibling;

        /// <summary>
        /// Stores the firstChild info
        /// </summary>
        public Node2 firstChild;

        /// <summary>
        /// Stores the status ie disabled or not.
        /// </summary>
        public bool disabled;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Node</param>
        /// <param name="sibling">Sibling node</param>
        /// <param name="firstChild">FirstChild</param>
        public Node2(Node2 parent, Node2 sibling, Node2 firstChild)
            : this(parent, sibling, firstChild, false)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Node</param>
        /// <param name="sibling">Sibling node</param>
        /// <param name="firstChild">FirstChild</param>
        public Node2(Node2 parent, Node2 sibling, Node2 firstChild, bool status)
        {
            this.parent = parent;
            this.sibling = sibling;
            this.firstChild = firstChild;
            this.disabled = status;
        }
    }
}
