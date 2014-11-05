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
            return goal <= (small + (big * 5)) && big % 5 <= small;
        }


        /// <summary>
        /// Variation II:
        /// There is an island which is represented by square matrix NxN.
        /// A person on the island is standing at any given co-ordinates(x, y). 
        /// He can move in straight line up, down, right or left on the island.
        /// If he steps outside the island, he dies. 
        /// Let island is represented as (0,0) to(N-1, N-1) (i.e NxN matrix) & person is standing at given co-ordinates(x, y). 
        /// He is allowed to move n steps on the island (along the matrix). 
        /// 
        /// Q. What is the probability that he is alive after making n moves?
        /// </summary>
        public bool Matrix2(int islandM, int islandN, int personX, int personY, int moves)
        {
            int[,] island = CreateanIsland(islandM, islandN);

            // Direction : Up
            // Idea: only x axis changes, decrement the moves with X and then compare if it reaches the 0th row. 
            // If it get past it already, then he dies. X coordinate MUST be >=0
            if ((personX - moves) < 0)
            {
                return false;
            }

            // Direction : Down
            // Idea: only x axis changes, add the # of moves with X and then compare if it reaches the Mth row. 
            // If it get past M already, then he dies. X coordinate MUST be <= mth row
            // Note: I'm checking >= below because for 4x4 island, max coordinate is (0,0) and (3,3). ie (0,4) is OUTSIDE the island.
            if ((personX + moves) >= islandM)
            {
                return false;
            }

            //Right
            if ((personY + moves) >= islandN)
                return false;

            // Left
            if ((personY - moves) < 0)
                return false;

            // He'll survive if he makes n moves in either direction.
            return true;
        }

        /// <summary>
        /// There is an island which is represented by square matrix NxN.
        /// A person on the island is standing at any given co-ordinates(x, y). 
        /// He can move in any direction one step right, left, up, down on the island.
        /// If he steps outside the island, he dies. 
        /// Let island is represented as (0,0) to(N-1, N-1) (i.e NxN matrix) & person is standing at given co-ordinates(x, y). 
        /// He is allowed to move n steps on the island(along the matrix). 
        /// 
        /// Q. What is the probability that he is alive after he walks n steps on the island?
        /// Q. Write a psuedocode & then full code for function 
        ///    "float probabilityofalive(int x,int y, int n) ".
        /// </summary>
        public void Matrix(int islandM, int islandN, int personX, int personY, int moves)
        {
            int[,] island = CreateanIsland(islandM, islandN);

            int probability = moves;

            //person 
            int x = 1, y = 1;
            Console.WriteLine(string.Format("Person is at [{0}][{1}]\n", x, y));
            int person = island[x, y];

            // Up
            if (!MovePossible(island, x - 1, y))
            { probability--; }

            //Down
            if (!MovePossible(island, x + 1, y))
            { probability--; }

            //Right
            if (!MovePossible(island, x, y + 1))
            { probability--; }

            //Left
            if (!MovePossible(island, x, y - 1))
            { probability--; }

            Console.WriteLine("Probability of a man getting out alive is :" + probability * 25 + "%");
        }

        private bool MovePossible(int[,] island, int m, int n)
        {
            try
            {
                Console.Write(string.Format("[{0}][{1}]", m, n));
                int temp = island[m, n];
            }
            catch (Exception)
            {
                Console.WriteLine(" - Dead! \n");
                return false;
            }
            Console.WriteLine("- Alive! \n");
            return true;
        }

        public static int[,] CreateanIsland(int m, int n)
        {
            int[,] island = new int[m, n];
            int val = 1;
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    island[row, col] = val++;
                }
            }

            return island;
        }

        public void PrintAMatrix(int row, int col)
        {
            int[,] matrix = CreateanIsland(row, col);
        }
    }
}
