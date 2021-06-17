using System;

namespace kata_tic_tac_toe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Here's the current board:");
            
            var game = new Game();
            // game.NewGame();
            game.Play();
        }
    }
}