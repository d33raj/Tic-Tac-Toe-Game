using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
    internal class Game
    {
        public char[,] board;
        public char currentplayer;
        public char player1;
        public char player2;

        public Game(char Player1)
        {
            board = new char[3, 3]
            {
                {' ',' ',' ' },
                {' ',' ',' ' },
                {' ',' ',' ' }
            };
            player1 = Player1;
            player2 = (player1 == 'X') ? 'O' : 'X';
            currentplayer = player1;
        }

        public void PrintBoard()
        {
            Console.WriteLine("   0  1  2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("  ");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("  ----------");
            }
        }

        public bool BoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ') 
                        return false;
                }
            }
            return true;
        }

        public bool MarkOnBoard(int row, int column)
        {
            if (board[row, column] == ' ')
            {      
                board[row, column] = currentplayer;
                return true;
            }
            return false; 
        }

        public void ChangePlayer()
        {
            currentplayer= (currentplayer == player1) ? player2 : player1;
        }

        public bool GameWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if ( (board[i,0] == currentplayer &&  board[i,1]== currentplayer && board[i,2]== currentplayer) ||
                      (board[0,i]== currentplayer && board[1,i]== currentplayer && board[2,i]== currentplayer) )
                { return true; }
            }

            if( (board[0,0] == currentplayer && board[1,1]== currentplayer && board[2,2]== currentplayer) ||
                 (board[0,2]== currentplayer && board[1,1]== currentplayer && board[2,0]== currentplayer) )
                { return true; }

            return false;
        }

        public void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
            currentplayer = player1;
        }
    }
}
