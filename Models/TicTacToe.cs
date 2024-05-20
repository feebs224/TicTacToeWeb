using System;

namespace TicTacToeWeb.Models
{
    public class TicTacToe
    {
        private char[] board;
        private char currentPlayer;

        public TicTacToe()
        {
            board = new char[9];
            for (int i = 0; i < 9; i++)
                board[i] = ' ';
            currentPlayer = 'X'; // Player starts first
        }

        public char[] Board => board;

        public bool IsBoardFull()
        {
            foreach (char c in board)
                if (c == ' ')
                    return false;
            return true;
        }

        public bool MakeMove(int position, char player)
        {
            if (position < 0 || position >= 9 || board[position] != ' ')
                return false;

            board[position] = player;
            return true;
        }

        public char CheckWin()
        {
            int[,] winPositions = {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Rows
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
                {0, 4, 8}, {2, 4, 6} // Diagonals
            };

            for (int i = 0; i < 8; i++)
            {
                if (board[winPositions[i, 0]] == board[winPositions[i, 1]] &&
                    board[winPositions[i, 1]] == board[winPositions[i, 2]] &&
                    board[winPositions[i, 0]] != ' ')
                {
                    return board[winPositions[i, 0]];
                }
            }

            return ' ';
        }

        public char CurrentPlayer => currentPlayer;

        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}
