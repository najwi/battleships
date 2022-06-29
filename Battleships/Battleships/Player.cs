using Battleships.Boards;

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
        public string Name { get; }

        public Player(int boardSize, string name)
        {
            TrackingBoard = new TrackingBoard(boardSize);
            GameBoard = new GameBoard(boardSize);
            Name = name;
        }


    }
}
