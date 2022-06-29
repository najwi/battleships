using System;
using Battleships.Boards;

namespace Battleships
{
    internal class Game
    {
        private Player _player1;
        private Player _player2;
        private int _boardSize;

        public Game(int boardSize)
        {
            _player1 = new Player(boardSize, "Player 1");
            _player2 = new Player(boardSize, "Player 2");
            _boardSize = boardSize;
        }

        public void Start()
        {
            bool run = true;
            while (run)
            {
                PrintBoards(_player1);
                PlayerAttack(_player1, _player2);

                PrintBoards(_player2);
                PlayerAttack(_player2, _player1);

                if (!_player1.GameBoard.AnyShipsLeft() && !_player2.GameBoard.AnyShipsLeft())
                {
                    Console.WriteLine("It's a tie.");
                    run = false;
                }else if (!_player1.GameBoard.AnyShipsLeft())
                {
                    Console.WriteLine($"{_player2.Name} won!");
                    run = false;
                }
                else if (!_player2.GameBoard.AnyShipsLeft())
                {
                    Console.WriteLine($"{_player1.Name} won!");
                    run = false;
                }
            }
        }

        /// <summary>
        /// Player1 is attacking Player2
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        private void PlayerAttack(Player player1, Player player2)
        {
            var (x, y) = FindField(player2.GameBoard);
            Field type = player2.GameBoard.Strike(x, y);
            Console.WriteLine($"\n{player1.Name} strikes field ({x}, {y})...");
            if (type == Field.Miss)
            {
                player1.TrackingBoard.SetField(x, y, Field.Miss);
                Console.WriteLine("It's a miss.");
            }else if (type == Field.Hit)
            {
                player1.TrackingBoard.SetField(x, y, Field.Hit);
                Console.WriteLine("Something has been hit!");
            }
            else
            {
                player1.TrackingBoard.SetField(x, y, Field.Hit);
                Console.WriteLine($"{type} has been sunk!!");
            }
        }

        private (int, int) FindField(GameBoard board)
        {
            Random random = new Random();
            while (true)
            {
                int x = random.Next(0, board.GetBoard().GetLength(0));
                int y = random.Next(0, board.GetBoard().GetLength(1));

                if (board.TryStrike(x, y))
                {
                    return (x, y);
                }
            }
        }

        private void PrintBoards(Player player)
        {
            Field[,] gameBoard = player.GameBoard.GetBoard();
            Field[,] trackingBoard = player.TrackingBoard.GetBoard();

            Console.WriteLine($"{player.Name} game board \ttracking board");
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    switch (gameBoard[i, j])
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
                Console.Write("\t");
                for (int j = 0; j < trackingBoard.GetLength(1); j++)
                {
                    switch (trackingBoard[i, j])
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
