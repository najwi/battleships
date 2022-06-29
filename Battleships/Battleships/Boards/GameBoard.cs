using Battleships.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Boards
{
    internal class GameBoard : Board
    {
        // Dictionary of ships and their lengths.
        private Dictionary<Field, int> _ships;
        public GameBoard(int boardSize) : base(boardSize)
        {
            _ships = new Dictionary<Field, int>();
            _ships.Add(Field.Carrier, 5);
            _ships.Add(Field.Battleship, 4);
            _ships.Add(Field.Destroyer, 3);
            _ships.Add(Field.Submarine, 3);
            _ships.Add(Field.PatrolBoat, 2);

            // Position ships randomly.
            Random random = new Random();
            foreach(KeyValuePair<Field, int> pair in _ships)
            {
                bool placed = false;

                // Check for space.
                while(!placed)
                {
                    bool horizontal = random.Next(0, 2) == 0;
                    int xStart = random.Next(boardSize);
                    int yStart = random.Next(boardSize);
                    bool spaceCheck = true;
                    for(int i = 0; i < pair.Value; i++)
                    {
                        int x = horizontal ? xStart + i : xStart;
                        int y = horizontal ? yStart : yStart + i;
                        if (x >= boardSize || y >= boardSize || _board[x, y] != Field.Empty)
                        {
                            spaceCheck = false;
                        }
                    }

                    // Place ship if there is space.
                    if (spaceCheck)
                    {
                        placed = true;
                        for (int i = 0; i < pair.Value; i++)
                        {
                            int x = horizontal ? xStart + i : xStart;
                            int y = horizontal ? yStart : yStart + i;
                            _board[x, y] = pair.Key; 
                        }
                    }
                }
            }
        }

    }
}
