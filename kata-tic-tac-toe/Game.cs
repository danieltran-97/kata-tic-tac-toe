using System;
using System.Linq;

namespace kata_tic_tac_toe
{
    public class Game
    {
        private const char PlayerX = 'X';

        private const char PlayerO = 'O';

        private static bool _gameOver = false;
        
        public void Play()
        {
            NewGame();
            var player = PlayerX;
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

        private static void PlaceMove(char player)
        {
            var success = false;
            var xAxis = 0;
            var yAxis = 0;
            
            while (!success)
            {
                var coordinates = GetCoordinateFromConsole($"Player {(player == PlayerX ? '1' : '2')} enter a coord x,y to place your {player} or enter 'q' to give up:  ");
                xAxis = int.Parse(coordinates[0]) - 1;
                yAxis = int.Parse(coordinates[1]) - 1;
                success = Board.BoardMatrix[xAxis, yAxis] == '.';
                
                if (!success)
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                }
            }
            
            Board.BoardMatrix[xAxis, yAxis] = player;
            
            Console.WriteLine($"Move accepted, {(Winner(Board.BoardMatrix, player) ? "well done you've won the game!" : "here's the current board:")}");

            Board.PrintBoard();
        }

        private static char ChangeTurn(char currentPlayer)
        {
            if (currentPlayer == PlayerX)
            {
                return PlayerO;
            }
            else
            {
                return PlayerX;
            }
        }

        private static string[] GetCoordinateFromConsole(string message)
        {
            Console.Write(message);
            return Console.ReadLine().Split(",");
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