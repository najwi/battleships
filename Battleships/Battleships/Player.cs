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

        /// <summary>
        /// Player's name, used for prints.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new Player object with given board size and name.
        /// </summary>
        /// <param name="boardSize">Must be at least 5.</param>
        /// <param name="name"></param>
        public Player(int boardSize, string name)
        {
            TrackingBoard = new TrackingBoard(boardSize);
            GameBoard = new GameBoard(boardSize);
            Name = name;
        }


    }
}
