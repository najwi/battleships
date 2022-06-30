# Battleships recruiment task
## Task
Based on the rules of Battleship board game (https://en.wikipedia.org/wiki/Battleship_(game)) implement a program which randomly places ships on two boards and simulates the gameplay between 2 players.

## Gameplay
Battleships is a strategy type guessing game for two players. It is played on ruled grids on which each player's fleet of warships are marked. The locations of the fleets are concealed from the other player. Players alternate turns calling "shots" at the other player's ships, and the objective of the game is to destroy the opposing player's fleet. <br>
The board is usually 10x10, but I have given the user option to conigure a custom sized board. Before the game begins each player randomly places 5 ships:
|No.|Ship class|Size|
|---|---|---|
|1|Carrier|5|
|2|Battleship|4|
|3|Destroyer|3|
|4|Submarine|3|
|5|Patrol Boat|2|

After the ships have been positioned, the game proceeds in a series of rounds. In each round, each player takes a turn to announce a target square in the opponent's grid which is to be shot at. The opponent announces whether or not the square is occupied by a ship. If it is a "hit", the player who is hit marks this on their own Game Board. The attacking player marks the hit or miss on their own Tracking Board ("o" - miss, "x" - hit) in order to build up a picture of the opponent's fleet.<br>
When all of the squares of a ship have been hit, the ship's owner announces the sinking of the Carrier, Submarine, Destroyer, Patrol Boat, or the titular Battleship. If all of a player's ships have been sunk, the game is over and their opponent wins. If all ships of both players are sunk by the end of the round, the game is a draw.

## Implementation
The game has been implemented with object oriented programming in mind. Boards are implemented with 2d Arrays. Field type enum is used for storing information about fields on boards. Ships position and rotation are genereted randomly. Players are making random guesses of fields to strike, this algorithm is naive and could be upgraded with some AI. Game ends when one of the players has no ships left on board, if both players run out of ships in the same turn the game ends with a draw.
