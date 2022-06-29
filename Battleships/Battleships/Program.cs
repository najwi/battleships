using System;
using System.Collections.Generic;
using Battleships.Boards;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int boardSize = 10;
            //Game game = new Game(boardSize);
            Field[] f = new Field[1];
            f[0] = Field.Miss;
            Field field = f[0];
            Console.WriteLine(f[0]);
            field = Field.Hit;
            Console.WriteLine(f[0]);
        }
    }
}
