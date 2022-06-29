using Battleships.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
