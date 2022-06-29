using System;

namespace Battleships.Boards
{
    internal class TrackingBoard : Board
    {
        public TrackingBoard(int boardSize) : base(boardSize)
        {
        }

        /// <summary>
        /// Sets given field to a specified Field type
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="field"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void SetField(int x, int y, Field field)
        {
            if (x >= _board.GetLength(0) || y >= _board.GetLength(1))
            {
                throw new IndexOutOfRangeException();
            }

            _board[x, y] = field;
        }
    }
}
