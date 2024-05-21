using System;

namespace TicTacToeWeb.Models
{
    public class TicTacToeAI
    {
        private TicTacToe game;

        public TicTacToeAI(TicTacToe game)
        {
            this.game = game;
        }

        public int GetBestMove()
        {
            int bestScore = int.MinValue;
            int move = -1;

            for (int i = 0; i < 9; i++)
            {
                if (game.MakeMove(i, 'O'))
                {
                    int score = Minimax(game, false);
                    game.MakeMove(i, ' '); // Undo move

                    if (score > bestScore)
                    {
                        bestScore = score;
                        move = i;
                    }
                }
            }
            return move;
        }

        private int Minimax(TicTacToe game, bool isMaximizing)
        {
            char winner = game.CheckWin();
            if (winner == 'O') return 1;
            if (winner == 'X') return -1;
            if (game.IsBoardFull()) return 0;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < 9; i++)
                {
                    if (game.MakeMove(i, 'O'))
                    {
                        int score = Minimax(game, false);
                        game.MakeMove(i, ' '); // Undo move
                        bestScore = Math.Max(score, bestScore);
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < 9; i++)
                {
                    if (game.MakeMove(i, 'X'))
                    {
                        int score = Minimax(game, true);
                        game.MakeMove(i, ' '); // Undo move
                        bestScore = Math.Min(score, bestScore);
                    }
                }
                return bestScore;
            }
        }
    }
}

