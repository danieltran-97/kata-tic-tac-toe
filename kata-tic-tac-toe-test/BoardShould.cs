using System;
using System.Collections.Generic;
using Xunit;

namespace kata_tic_tac_toe
{
    public class BoardShould
    {
        [Fact]
        public void InitializeBoardTest()
        {
            var newBoard = Board.InitializeBoard();

            Assert.Equal( new char[3,3] {{'.','.','.'},{'.','.','.'},{'.','.','.'}}, newBoard);
        }
    }
}