using System;

namespace Battleships.Boards
{
    /// <summary>
    /// Possible field states on board.
    /// </summary>
    public enum Field
    {
        Empty = 0,
        Carrier,
        Battleship,
        Destroyer,
        Submarine,
        PatrolBoat,
        Hit,
        Miss
    }

    internal class Board
    {
        protected Field[,] _board;

        /// <summary>
        /// Initializes new Board object with given board size.
        /// </summary>
        /// <param name="boardSize">Must be at least 5</param>
        /// <exception cref="ArgumentException">Thrown when board size is less then 5</exception>
        public Board(int boardSize)
        {
            if (boardSize < 5)
            {
                throw new ArgumentException("Board size must be at least 5");
            }

            // All fields are defaulted to Empty.
            _board = new Field[boardSize, boardSize];
        }

        /// <summary>
        /// Gets board array.
        /// </summary>
        /// <returns></returns>
        public Field[,] GetBoard()
        {
            return _board;
        }
    }
}
