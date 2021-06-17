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
            Console.Write($"Player {player} enter a coord x,y to place your {player}:  ");
            var coordinates = Console.ReadLine().Split(",");
            var xAxis = int.Parse(coordinates[0]) - 1;
            var yAxis = int.Parse(coordinates[1]) - 1;
            
            Board.BoardMatrix[xAxis, yAxis] = player;
            
            
            Board.PrintBoard();
        }
    }
}