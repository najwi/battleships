using Battleships.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Boards;

namespace Battleships
{
    internal class Game
    {
        private Player _player1;
        private Player _player2;

        public Game(int boardSize)
        {
            _player1 = new Player(boardSize);
            _player2 = new Player(boardSize);
            PrintBoard(_player1.GameBoard);
        }

        public void Start()
        {
            bool run = true;
            while (run)
            {

            }
        }

        private void PrintBoard(Board _board)
        {
            Field[,] board = _board.GetBoard();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    switch (board[i, j])
                    {
                        case Field.Empty: 
                            Console.Write("[ ]"); 
                            break;
                        case Field.Miss: 
                            Console.Write("[o]"); 
                            break;
                        case Field.Hit: 
                            Console.Write("[x]"); 
                            break;
                        default: 
                            Console.Write("[*]"); 
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
