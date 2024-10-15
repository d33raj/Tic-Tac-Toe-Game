using TicTacToeGame.Models;

namespace TicTacToeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe Game!");
            Console.WriteLine("=================================");
            GameController controller = new GameController();
            controller.StartGame();
            Console.WriteLine("Thank You For Playing Tic Tac Toe Game!");
            
        }
    }
}
