using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    /// <summary>
    /// The interface for strategies. 
    /// </summary>
    public interface ICalculate
    {
        int Calculate(int a, int b);
    }

    /// <summary>
    /// strategies
    /// Strategy 1: Minus
    /// </summary>
    class Minus : ICalculate
    {
        public int Calculate(int a, int b)
        {
            return a - b;
        }
    }

    /// <summary>
    /// Strategy 3: Addition Strategy
    /// </summary>
    class Add : ICalculate
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    /// <summary>
    /// Strategy 3: Division Strategy
    /// </summary>
    class Divide : ICalculate
    {
        public int Calculate(int a, int b)
        {
            return a / b;
        }
    }

    /// <summary>
    /// The 'Context' Class. The Client.
    /// </summary>
    class CalculateClient
    {
        // Strategy instance
        private ICalculate calculateStrategy;

        // Constructor
        public CalculateClient(ICalculate strategy)
        {
            this.calculateStrategy = strategy;
        }

        /// <summary>
        /// Executes the Strategy.
        /// </summary>
        /// <param name="a">Value 1</param>
        /// <param name="b">Value 2</param>
        public void Calculate(int a, int b)
        {
            Console.WriteLine(this.calculateStrategy.Calculate(a, b));
        }
    }
}
