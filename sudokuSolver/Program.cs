using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] puzzle = {
    { 0, 1, 0, 0, 8, 0, 0, 0, 0 },
    { 0, 0, 3, 0, 0, 1, 4, 0, 0 },
    { 9, 0, 0, 6, 0, 7, 0, 0, 3 },
    { 0, 0, 7, 0, 0, 9, 6, 0, 4 },
    { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
    { 1, 0, 9, 8, 0, 0, 2, 0, 0 },
    { 5, 0, 0, 1, 0, 3, 0, 0, 8 },
    { 0, 0, 1, 4, 0, 0, 3, 0, 0 },
    { 0, 0, 0, 0, 2, 0, 0, 9, 0 }
};

            if (SolveBoard(puzzle, 0, 0))
                PrintBoard(puzzle);
        }

        public static void PrintBoard(int[,] board)
        {
            Console.WriteLine("+-----+-----+-----+");

            for (int i = 1; i < 10; ++i)
            {
                for (int j = 1; j < 10; ++j)
                    Console.Write("|{0}", board[i - 1, j - 1]);

                Console.WriteLine("|");
                if (i % 3 == 0) Console.WriteLine("+-----+-----+-----+");
            }


        }

        public static bool SolveBoard(int[,] board, int row, int col)
        {
            if (row < 9 && col < 9)
            {
                if (board[row, col] != 0)
                {
                    if (col + 1 < 9) return SolveBoard(board, row, col + 1);
                    else if (row + 1 < 9) return SolveBoard(board, row + 1, 0);
                    else return true;
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (IsOpen(board, row, col, i + 1))
                        {
                            board[row, col] = i + 1;
                            if ((col + 1) < 9)
                            {
                                if (SolveBoard(board, row, col + 1)) return true;
                                else board[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (SolveBoard(board, row + 1, 0)) return true;
                                else board[row, col] = 0;
                            }
                            else return true;
                        }

                    }
                }
                return false;
            }
            else return true;
        }



        

        public static bool IsOpen(int[,] board, int row, int col, int num)
        {
            
            int columnStart = (col / 3) * 3;
            int rowStart = (row / 3) * 3;
           
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num) return false;
                if (board[i, col] == num) return false;
                if (board[rowStart + (i % 3), columnStart + (i / 3)] == num) return false;

            }
            return true;

        }
    }
}
