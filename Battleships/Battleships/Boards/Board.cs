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

        public Board(int boardSize)
        {
            // All fields are defaulted to Empty.
            _board = new Field[boardSize, boardSize];
        }

        public Field[,] GetBoard()
        {
            return _board;
        }
    }
}
