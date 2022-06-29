using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Boards
{
    internal class GameBoard : Board
    {
        // Dictionary of ships and their lengths.
        private Dictionary<Field, int> _ships;
        public GameBoard(int boardSize) : base(boardSize)
        {
            _ships = new Dictionary<Field, int>
            {
                { Field.Carrier, 5 },
                { Field.Battleship, 4 },
                { Field.Destroyer, 3 },
                { Field.Submarine, 3 },
                { Field.PatrolBoat, 2 }
            };

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

        /// <summary>
        /// Checks if there are any ships left on the board.
        /// </summary>
        /// <returns>True if there are</returns>
        public bool AnyShipsLeft()
        {
            return _ships.Values.Any(shipHealth => shipHealth > 0);
        }

        /// <summary>
        /// Checks if it is possible to strike given field.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if its possible, false otherwise.</returns>
        public bool TryStrike(int x, int y)
        {
            if (x >= _board.GetLength(0) || y >= _board.GetLength(1))
            {
                return false;
            }

            Field field = _board[x, y];

            return field is not (Field.Hit or Field.Miss);
        }

        /// <summary>
        /// Strikes given field.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Field type, Hit if the ship has not been sunk or ship type if it has been sunk with the strike.</returns>
        /// <exception cref="InvalidOperationException">If coordinates are out of range field can not be struck.</exception>
        public Field Strike(int x, int y)
        {
            if (!TryStrike(x, y))
            {
                throw new InvalidOperationException("Can't strike this field. It's out of board range or occupied");
            }

            Field field = _board[x, y];
            if (field == Field.Empty)
            {
                _board[x, y] = Field.Miss;
                return Field.Miss;
            }

            _board[x, y] = Field.Hit;
            _ships[field]--;
            if (_ships[field] == 0)
            {
                return field;
            }
            return Field.Hit;
        }
    }
}
