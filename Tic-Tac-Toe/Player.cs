using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Tic_Tac_Toe
{
    class Player
    {
        /// <summary>
        /// Stores the name of a player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Stores the score of a player
        /// </summary>
        int score { get; set; }

        /// <summary>
        /// Creates a new player.
        /// </summary>
        public Player()
        {
            this.Name = "Unknown";
            this.score = 0;
        }

        /// <summary>
        /// Creates a new player.
        /// </summary>
        public Player(string name)
        {
            this.Name = name;
            this.score = 0;
        }

    }
}
