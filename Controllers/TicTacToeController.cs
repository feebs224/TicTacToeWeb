using Microsoft.AspNetCore.Mvc;
using TicTacToeWeb.Models;

namespace TicTacToeWeb.Controllers
{
    public class TicTacToeController : Controller
    {
        private static TicTacToe game;
        private static TicTacToeAI ai;

        public TicTacToeController()
        {
            if (game == null)
            {
                game = new TicTacToe();
                ai = new TicTacToeAI(game);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(game);
        }

        [HttpPost]
        public IActionResult MakeMove(int position)
        {
            if (game.MakeMove(position, 'X'))
            {
                game.SwitchPlayer();
                if (game.CheckWin() == ' ' && !game.IsBoardFull())
                {
                    int aiMove = ai.GetBestMove();
                    game.MakeMove(aiMove, 'O');
                    game.SwitchPlayer();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reset()
        {
            game = new TicTacToe();
            ai = new TicTacToeAI(game);
            return RedirectToAction("Index");
        }
    }
}
