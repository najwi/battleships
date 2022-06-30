
using System;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Battleships");
            var game = new Game(10);
            game.Start();
        }
    }
}
