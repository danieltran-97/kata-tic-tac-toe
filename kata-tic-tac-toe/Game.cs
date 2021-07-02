using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace kata_tic_tac_toe
{
    public class Game
    {
        private static Player _player1;

        private static Player _player2;

        private static bool _gameOver = false;

        public Game()
        {
            _player1 = new Player("Player 1", 'X');
            _player2 = new Player("Player 2 ", 'O');
        }
        public void Play()
        {
            NewGame();
            var player = _player1;
            var spotsFilled = 0;

            while (!_gameOver && spotsFilled < 9)
            {
                PlaceMove(player);
                spotsFilled++;
                player = ChangeTurn(player);
            }

            Console.WriteLine("Game over");
        }

        private static void NewGame()
        {
            Board.InitializeBoard();
            Board.PrintBoard();
        }

        private static void PlaceMove(Player player)
        {
            var success = false;
            var xAxis = 0;
            var yAxis = 0;
            
            while (!success)
            {
                var coordinates = GetCoordinateFromConsole($"{player.Name} enter a coord x,y to place your {player.Marker} or enter 'q' to give up:  ");
                xAxis = int.Parse(coordinates[0]) - 1;
                yAxis = int.Parse(coordinates[1]) - 1;
                success = Board.BoardMatrix[xAxis, yAxis] == '.';
                
                if (!success)
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                }
            }
            
            Board.BoardMatrix[xAxis, yAxis] = player.Marker;
            
            Console.WriteLine($"Move accepted, {(Winner(Board.BoardMatrix, player.Marker) ? "well done you've won the game!" : "here's the current board:")}");

            Board.PrintBoard();
        }

        private static Player ChangeTurn(Player currentPlayer)
        {
            if (currentPlayer == _player1)
            {
                return _player2;
            }
            else
            {
                return _player1;
            }
        }

        private static string[] GetCoordinateFromConsole(string message)
        {
            var success = false;
            var input = string.Empty;
            var reg = new Regex("^[1-3],[1-3]$");
            
            while (!success)
            {
                Console.Write(message);
                input = Console.ReadLine();
                success = reg.IsMatch(input);

                if (!success)
                {
                    Console.WriteLine("Please enter valid coordinates");
                }
            }
            
            return input.Split(",");
        }

        private static bool Winner(char[,] board, char player)
        {
            // Check to see if board[i,j] =  'X' or 'O'
            // See how to use linq here
            var win = (board[0,0] == player && board[0,0] == board [0,1] && board[0,0] == board [0,2]) ||
                      (board[0,0] == player && board[0,0] == board [1,1] && board[0,0] == board [2,2]) ||
                      (board[0,0] == player && board[0,0] == board [1,0] && board[0,0] == board [2,0]) ||
                      (board[2,0] == player && board[2,0] == board [2,1] && board[2,0] == board [2,2]) ||
                      (board[2,0] == player && board[2,0] == board [1,1] && board[2,0] == board [0,2]) ||
                      (board[0,2] == player && board[0,2] == board [1,2] && board[0,2] == board [2,2]) ||
                      (board[0,1] == player && board[0,1] == board [1,1] && board[0,1] == board [2,1]) ||
                      (board[1,0] == player && board[1,0] == board [1,1] && board[1,0] == board [1,2]);
            if (win)
            {
                _gameOver = true;
            }

            return win;
        }

    }
}