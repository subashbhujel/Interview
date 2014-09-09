using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewPreparation.Tic_Tac_Toe
{
    class TicTacToe
    {
        /// <summary>
        /// Tic-Tac-Toe board default size
        /// </summary>
        private const int BOARD_SIZE = 3;

        /// <summary>
        /// Tic-Tac-Toe board
        /// </summary>
        private Board board;

        /// <summary>
        /// Player 
        /// </summary>
        private Player player;

        public TicTacToe()
        {
            this.board = new Board(BOARD_SIZE);
            this.player = new Player();
        }

        public TicTacToe(int size)
        {
            this.board = new Board(BOARD_SIZE);
        }

        public TicTacToe(string PlayerName)
        {
            this.board = new Board(BOARD_SIZE);
            this.player = new Player(PlayerName);
        }

        public TicTacToe(int size, string PlayerName)
        {
            this.board = new Board(size);
            this.player = new Player(PlayerName);
        }

        /// <summary>
        /// Start playing.
        /// </summary>
        public void Play()
        {
            bool IsItPlayersMove = true;

            while (true)
            {
                if (IsGameOver())
                {
                    Console.WriteLine("Game Over!");
                    break;
                }
                if (IsItPlayersMove)
                {
                    PlayerMove();
                    IsItPlayersMove = false;
                    this.board.Print();
                }
                else
                {
                    ComputerMove();
                    IsItPlayersMove = true;
                    this.board.Print();
                }
            }
        }

        /// <summary>
        /// Human's move
        /// </summary>
        /// <returns>True after a succesful move.</returns>
        private bool PlayerMove()
        {
            int i, j;
            Console.WriteLine(string.Format("\n{0}'s Move: ", this.player.Name));

            while (true)
            {
                Console.Write("Row: ");
                i = Convert.ToInt32(Console.ReadLine());

                Console.Write("Col: ");
                j = Convert.ToInt32(Console.ReadLine());

                if (i < 0 || i >= this.board.size || j < 0 || j >= this.board.size)
                {
                    Console.WriteLine("\nMove NOT possible.Enter a different value");
                    continue;
                }

                if (this.board.IsSlotTaken(i, j))
                {
                    Console.WriteLine("\nMove NOT possible.Enter a different value");
                }
                else
                {
                    this.board.board[i, j] = "O";
                    return true;
                }
            }
        }

        /// <summary>
        /// Computer's move
        /// </summary>
        /// <returns>True after a successful move</returns>
        private bool ComputerMove()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("\nComputer's Move - ");

            Random random = new Random();
            int i, j;

            bool isboardFull = this.board.IsBoardFull();

            while (!isboardFull)
            {
                i = random.Next(3);
                j = random.Next(3);

                if (!this.board.IsSlotTaken(i, j))
                {
                    this.board.board[i, j] = "X";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if Game is over.
        /// </summary>
        /// <returns></returns>
        private bool IsGameOver()
        {
            string curEle = string.Empty;
            string preEle = string.Empty;

            bool isBoardFull = this.board.IsBoardFull();
            bool gameOver = false;

            // Board is full. No move possible.
            if (isBoardFull)
                return true;

            // Check Rows
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    preEle = curEle;
                    curEle = this.board.board[i, j];

                    if (j > 0)
                    {
                        if (curEle != preEle)
                        {
                            gameOver = false;
                            preEle = string.Empty;
                            curEle = string.Empty;
                            break;
                        }
                        else if (curEle == preEle && curEle != ".")
                        {
                            gameOver = true;
                        }
                    }
                }
                if (gameOver)
                    return gameOver;
            }

            // Check Column
            preEle = string.Empty;
            curEle = string.Empty;

            for (int j = 0; j < board.size; j++)
            {
                for (int i = 0; i < board.size; i++)
                {
                    preEle = curEle;
                    curEle = this.board.board[i, j];

                    if (i > 0)
                    {
                        if (curEle != preEle)
                        {
                            gameOver = false;
                            preEle = string.Empty;
                            curEle = string.Empty;
                            break;
                        }
                        else if (curEle == preEle && curEle != ".")
                        {
                            gameOver = true;
                        }
                    }
                }
                if (gameOver)
                    return gameOver;
            }
            // Check diagonal
            if (this.board.board[0, 0] == this.board.board[1, 1]
                && this.board.board[1, 1] == this.board.board[2, 2]
                && this.board.board[2, 2] != ".")
            {
                return true;
            }
            if (this.board.board[2, 0] == this.board.board[1, 1]
                && this.board.board[1, 1] == this.board.board[0, 2]
                && this.board.board[0, 2] != ".")
            {
                return true;
            }

            return gameOver;
        }
    }
}
