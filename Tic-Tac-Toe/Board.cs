using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Tic_Tac_Toe
{
    class Board
    {
        /// <summary>
        /// Tic-Tac-Toe board
        /// </summary>
        public string[,] board;

        public int size { get; set; }

        //public int[,] GetBoard()
        //{
        //    return this.board;
        //}

        /// <summary>
        /// Creates the Tic-Tac-Toe board
        /// </summary>
        /// <param name="size">Size of a board</param>
        public Board(int size)
        {
            this.board = new string[size, size];
            this.size = size;
            Reset();
            Print();
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = ".";
                }
            }
        }

        /// <summary>
        /// Checks if Board is full or not.
        /// </summary>
        /// <returns></returns>
        public bool IsBoardFull()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == ".")
                        return false;
                }
            }
            return true;
        }

        public bool IsSlotTaken(int i, int j)
        {
            if (this.board[i, j] == ".")
                return false;
            return true;
        }

        /// <summary>
        /// Prints the board
        /// </summary>
        public void Print()
        {
            Console.WriteLine("\nBoard looks like:");
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
