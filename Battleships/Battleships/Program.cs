using Battleships.Boards;
using Battleships.Ships;
using System;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 10;
            GameBoard b = new GameBoard(boardSize);
            b.PrintBoard();
            //Game game = new Game(boardSize, ships);
        }
    }
}
