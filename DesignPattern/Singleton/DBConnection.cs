using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DesignPattern.Singleton
{
    // Class is sealed to prevent derivation, which could add instances.
    public sealed class DBConnection
    {
        // Get the DBConnection Instance the first time any member of the class is referenced.
        private static readonly DBConnection instance = new DBConnection();

        private DBConnection() { }

        public static DBConnection Instance
        {
            get { return instance; }
        }

        // EXPLANATION:
        // Ref: https://msdn.microsoft.com/en-us/library/ff650316.aspx
        //  In this strategy, the instance is created the first time any member of the class is referenced. 
        //  The common language runtime takes care of the variable initialization. The class is marked sealed to prevent derivation, which could add instances. 
        //  For a discussion of the pros and cons of marking a class sealed, see [Sells03]. In addition, the variable is marked readonly, which means that it 
        //  can be assigned only during static initialization(which is shown here) or in a class constructor.

        //  This implementation is similar to the preceding example, except that it relies on the common language runtime to initialize the variable.It still
        //  addresses the two basic problems that the Singleton pattern is trying to solve: global access and instantiation control.The public static property 
        //  provides a global access point to the instance.Also, because the constructor is private, the Singleton class cannot be instantiated outside of the class itself; therefore, the variable refers to the only instance that can exist in the system.

        //  Because the Singleton instance is referenced by a private static member variable, the instantiation does not occur until the class is first 
        //  referenced by a call to the Instance property.This solution therefore implements a form of the lazy instantiation property, as in the Design 
        //  Patterns form of Singleton. The only potential downside of this approach is that you have less control over the mechanics of the instantiation.
        //  In the Design Patterns form, you were able to use a nondefault constructor or perform other tasks before the instantiation.Because the .NET Framework performs the initialization in this solution, you do not have these options. In most cases, static initialization is the preferred approach for implementing a Singleton in .NET.
    }
}
