using Battleships.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Boards
{
    internal class Board
    {
        /// <summary>
        /// Possible field states on board.
        /// </summary>
        public enum Field{
            Empty = 0,
            Carrier,
            Battleship,
            Destroyer,
            Submarine,
            PatrolBoat,
            Hit,
            Miss
        }

        protected Field[,] _board;

        public Board(int boardSize)
        {
            // All fields are defaulted to Empty.
            _board = new Field[boardSize, boardSize];
        }

        public void PrintBoard()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    Console.Write(_board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
