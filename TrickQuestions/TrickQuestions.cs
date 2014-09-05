using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.TrickQuestions
{
    class TrickQuestions
    {
        /// <summary>
        /// We want to make a row of bricks that is goal inches long. We have a number of small bricks (1 inch each) and big bricks (5 inches each). 
        /// Return true if it is possible to make the goal by choosing from the given bricks
        ///     Examples:
        ///         makeBricks(3, 1, 8) → true, 5+3=8
        ///         makeBricks(3, 1, 9) → false, 5+3!=9
        ///         makeBricks(3, 2, 10) → true, 5+5=9
        ///         makeBricks(2, 4, 8) → false, 5+2!=8
        /// </summary>
        /// <param name="small">Small Brick</param>
        /// <param name="big">Big Brick</param>
        /// <param name="goal">Goal brick</param>
        /// <returns></returns>
        public bool MakeBricks(int small, int big, int goal)
        {
            return goal <= small + big * 5 && big % 5 <= small;
        }
    }
}
