using System;

namespace kata_tic_tac_toe
{
    public static class Board
    {
        public static char[,] BoardMatrix = new char[3,3];
        public static char[,] InitializeBoard()
        {
            BoardMatrix = new char[3,3] {
                {'.','.','.'},
                {'.','.','.'},
                {'.','.','.'}
            };

            return BoardMatrix;
        }

        public static void PrintBoard()
        {
            var rowLength = BoardMatrix.GetLength(0);
            var colLength = BoardMatrix.GetLength(1);

            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < colLength; j++)
                {
                    Console.Write("{0}  ", BoardMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}