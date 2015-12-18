using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    // ADAPTOR STRATEGY PATTERN:
    // The adapter pattern is a structural design pattern that allows you to repurpose a class with a different interface, 
    // allowing it to be used by a system which uses different calling methods. 

    /// <summary>
    /// User class. The 'Target' Class.
    /// </summary>
    class User
    {
        /// <summary>
        /// Creates a user. Overridable.
        /// </summary>
        public virtual void Create()
        {
            Console.WriteLine("Username Created.");
        }
    }

    /// <summary>
    /// Admin class. The 'Adaptor' Class.
    /// </summary>
    class Admin : User
    {
        // The 'Adaptee' class object.
        Privilidges privilidges = new Privilidges();

        /// <summary>
        /// Overriding base create()
        /// </summary>
        public override void Create()
        {
            base.Create();
            privilidges.Add();
        }
    }

    /// <summary>
    /// // The 'Adaptee' class object.
    /// </summary>
    class Privilidges
    {
        /// <summary>
        /// Adaptee method.
        /// </summary>
        public void Add()
        {
            Console.WriteLine("Admin previlidges added.");
        }
    }
}
