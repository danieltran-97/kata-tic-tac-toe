using System;

namespace kata_tic_tac_toe
{
    public class Game
    {
        private char _playerX = 'X';

        private char _playerO = 'O';

        public void Play()
        {
            NewGame();
            
            _placeMove(_playerX);
            _placeMove(_playerO);
            _placeMove(_playerX);
            _placeMove(_playerO);
            _placeMove(_playerX);
            _placeMove(_playerO);
            _placeMove(_playerX);
            _placeMove(_playerO);
            _placeMove(_playerX);
            
            Console.WriteLine("Game over");
        }

        private void NewGame()
        {
            Board.InitializeBoard();
            Board.PrintBoard();
        }

        private void _placeMove(char player)
        {
            var success = false;
            var xAxis = 0;
            var yAxis = 0;
            
            while (!success)
            {
                var coordinates = GetCoordinateFromConsole($"Player {(player == 'X' ? '1' : '2')} enter a coord x,y to place your {player} or enter 'q' to give up:  ");
                xAxis = int.Parse(coordinates[0]) - 1;
                yAxis = int.Parse(coordinates[1]) - 1;
                success = Board.BoardMatrix[xAxis, yAxis] == '.';
                
                if (!success)
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                }
            }
            
            Board.BoardMatrix[xAxis, yAxis] = player;
            Console.WriteLine("Move accepted, here's the current board:");
            Board.PrintBoard();
        }

        private string[] GetCoordinateFromConsole(string message)
        {
            Console.Write(message);
            return Console.ReadLine().Split(",");
        }
    }
}