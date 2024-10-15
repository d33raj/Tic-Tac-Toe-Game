using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
    internal class GameController
    {
        public void StartGame()
        {
            bool playAfterDraw = true;
            while (playAfterDraw)
            {
                Console.WriteLine("Player 1 Select Symbol 'X' or 'O'.");
                char symbol = Char.ToUpper(Console.ReadLine()[0]);

                while (symbol != 'X' && symbol != 'O')
                {
                    Console.Write("Invalid Symbol, Select from X & O. ");
                    symbol = Char.ToUpper(Console.ReadLine()[0]);
                }

                Game game = new Game(symbol);
                Console.WriteLine("\nCurrent Board Status");
                bool gameWon= PlayGame(game);

                if (gameWon)
                { playAfterDraw = false; }

                else
                {
                    Console.WriteLine("Do you want to Play Again, Y or N ");
                    char choice = char.Parse(Console.ReadLine());
                    if (choice == 'Y' || choice == 'y')
                        playAfterDraw = true;
                    else
                        playAfterDraw = false;
                }
            }
        }


        public bool PlayGame(Game game)
        {
            bool gameOver = false;

            while (!gameOver && !game.BoardFull())
            {
                game.PrintBoard();
                Console.WriteLine($"\nPlayer {game.currentplayer}'s turn.");
                Console.WriteLine("Enter Row Number:");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Column Number:");
                int column = Convert.ToInt32(Console.ReadLine());

                gameOver = ProcessMove(game, row, column);

                if (gameOver && game.GameWon())
                    return true;
            }

            if (!gameOver)
            {
                game.PrintBoard();
                Console.WriteLine("\nThe Game is Drawn");
            }
            return false;
        }


       public  bool ProcessMove(Game game, int row, int column)
        {
            if (game.MarkOnBoard(row, column))
            {
                if (game.GameWon())
                {
                    game.PrintBoard();
                    Console.WriteLine($"\nPlayer {game.currentplayer} has won the Game.");
                    return true;
                }
                else
                    game.ChangePlayer();
            }
            else
                Console.WriteLine("Invalid move\n");
            return false;
        }
    }
}
