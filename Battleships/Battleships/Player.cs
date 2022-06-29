using Battleships.Boards;
using Battleships.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Player
    {
        /// <summary>
        /// Board for tracking other player's ships.
        /// </summary>
        public TrackingBoard TrackingBoard { get; }

        /// <summary>
        /// Board for this player's ships.
        /// </summary>
        public GameBoard GameBoard { get; } 

        public Player(int boardSize)
        {
            TrackingBoard = new TrackingBoard(boardSize);
            GameBoard = new GameBoard(boardSize);
        }
    }
}
