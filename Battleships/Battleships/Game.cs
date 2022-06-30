using System;
using System.Text;
using Battleships.Boards;

namespace Battleships
{
    internal class Game
    {
        private readonly Player _player1;
        private readonly Player _player2;

        /// <summary>
        /// Initializes a new Game object with given board size.
        /// </summary>
        /// <param name="boardSize">Must be at least 5.</param>
        public Game(int boardSize)
        {
            _player1 = new Player(boardSize, "Player 1");
            _player2 = new Player(boardSize, "Player 2");
        }

        /// <summary>
        /// Main game loop. Call to start the game.
        /// </summary>
        public void Start()
        {
            var run = true;
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
            Console.WriteLine("GG");
        }

        /// <summary>
        /// Executes attack on player and prints results.
        /// </summary>
        /// <param name="player1">Attacker</param>
        /// <param name="player2">Defender</param>
        private void PlayerAttack(Player player1, Player player2)
        {
            var (x, y) = FindField(player2.GameBoard);
            Field type = player2.GameBoard.Strike(x, y);
            Console.WriteLine($"\n{player1.Name} strikes field ({x}, {y})...");
            switch (type)
            {
                case Field.Miss:
                    player1.TrackingBoard.SetField(x, y, Field.Miss);
                    Console.WriteLine("It's a miss.");
                    break;
                case Field.Hit:
                    player1.TrackingBoard.SetField(x, y, Field.Hit);
                    Console.WriteLine("Something has been hit!");
                    break;
                default:
                    player1.TrackingBoard.SetField(x, y, Field.Hit);
                    Console.WriteLine($"{type} has been sunk!!");
                    break;
            }
        }

        /// <summary>
        /// Randomly finds a field on given board that can be struck.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Prints both boards of the given player.
        /// </summary>
        /// <param name="player"></param>
        private void PrintBoards(Player player)
        {
            Field[,] gameBoard = player.GameBoard.GetBoard();
            Field[,] trackingBoard = player.TrackingBoard.GetBoard();

            Console.WriteLine($"\n{player.Name} Game board \t\tTracking board");
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                var line = new StringBuilder();
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    switch (gameBoard[i, j])
                    {
                        case Field.Empty: 
                            line.Append("[ ]"); 
                            break;
                        case Field.Miss:
                            line.Append("[o]");
                            break;
                        case Field.Hit:
                            line.Append("[x]");
                            break;
                        default:
                            line.Append("[*]");
                            break;
                    }
                }
                line.Append("\t");
                for (int j = 0; j < trackingBoard.GetLength(1); j++)
                {
                    switch (trackingBoard[i, j])
                    {
                        case Field.Empty:
                            line.Append("[ ]");
                            break;
                        case Field.Miss:
                            line.Append("[o]");
                            break;
                        case Field.Hit:
                            line.Append("[x]");
                            break;
                        default:
                            line.Append("[*]");
                            break;
                    }
                }
                Console.WriteLine(line);
            }
        }
    }
}
