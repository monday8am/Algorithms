using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Backtracking
    { 
        public Backtracking ()
        {
          
            char[,] board = {{'A','B','C','E'},
                              {'O','F','C','S'},
                              {'P','D','E','E'}};

            int[,] maze = { {1, 0, 0, 0},
                            {1, 0, 0, 1},
                            {1, 0, 0, 0},
                            {1, 1, 1, 1}
                        };                   
              
            var p = new RatMaze ();  
            Console.WriteLine (p.SolveMaze (maze));                  
        }


        // http://www.programcreek.com/2014/06/leetcode-word-search-java/
        // https://leetcode.com/problems/word-search/
        static bool WordSearch (char[,] board, string word)
        {
            int m = board.GetUpperBound (0);
            int n = board.GetUpperBound (1);
            bool res = false;

            for (int i = 0; i <= m; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    if( DFS (board, word, i, j, 0))
                    {
                        res = true;
                    }
                }
            }
        
            return res;
        }
        
        static bool DFS (char[,] board, String word, int i, int j, int k)
        {
            int m = board.GetUpperBound (0);
            int n = board.GetUpperBound (1);
        
            if (i < 0 || j < 0 || i > m || j > n)
            {
                return false;
            }
            
            char c = Convert.ToChar (word.Substring (k,1));

            if (board [i,j] == c)
            {
                char temp = board [i,j];
                board[i,j] ='#';

                if (k == word.Length - 1)
                {
                    return true;
                }
                else if (DFS (board, word, i-1, j, k+1) ||
                         DFS (board, word, i+1, j, k+1) ||
                         DFS (board, word, i, j-1, k+1) ||
                         DFS (board, word, i, j+1, k+1))
                {
                    return true;
                }

                board [i,j] = temp;
            }
        
            return false;
        }

        // http://www.geeksforgeeks.org/backtracking-set-3-n-queen-problem/
        private class NQueenProblem
        {
            int N = 4;


            void PrintSolution (int[,] board)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(" " + board [i,j] + " ");
                    Console.WriteLine();
                }
            }

            bool IsQueenSafe (int[,] board, int row, int col)
            {
                int i, j;
                /* Check this row on left side */
                for (i = 0; i < col; i++)
                    if (board[row,i] == 1)
                        return false;
        
                /* Check upper diagonal on left side */
                for (i = row, j = col; i >= 0 && j>= 0; i--, j--)
                    if (board[i,j] == 1)
                        return false;
        
                /* Check lower diagonal on left side */
                for (i = row, j = col; j>=0 && i<N; i++, j--)
                    if (board[i,j] == 1)
                        return false;

                return true;
            }

            bool SolveNQueenUtil(int[,] board, int col) 
            {
                /* base case: If all queens are placed
                then return true */
                if (col >= N)
                    return true;
        
                /* Consider this column and try placing
                this queen in all rows one by one */
                for (int i = 0; i < N; i++)
                {
                    /* Check if queen can be placed on
                    board[i,col] */
                    if (IsQueenSafe (board, i, col))
                    {
                        /* Place this queen in board[i,col] */
                        board[i, col] = 1;
        
                        /* recur to place rest of the queens */
                        if (SolveNQueenUtil(board, col + 1) == true)
                            return true;
        
                        /* If placing queen in board[i,col]
                        doesn't lead to a solution then
                        remove queen from board[i,col] */
                        board[i, col] = 0; // BACKTRACK
                    }
                }
        
                /* If queen can not be place in any row in
                this colum col, then return false */
                return false;                
            }

            public bool SolveNQueen()
            {
                int[,] board = {{0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}};
        
                if (!SolveNQueenUtil (board, 0))
                {
                    Console.WriteLine ("Solution does not exist");
                    return false;
                }
        
                PrintSolution (board);
                return true;
            }            
        }


        // http://www.geeksforgeeks.org/backtracking-set-1-the-knights-tour-problem/
        private class KnightTour
        {
            private int N = 8;

            bool IsSafePosition (int x, int y, int[,] board)
            {
                return (x >= 0 && x < N && y >= 0 &&
                        y < N && board [x,y] == -1);
            }

            void PrintSolution (int[,] board)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(" " + board [i,j] + " ");
                    Console.WriteLine();
                }
            }

            /* A recursive utility function to solve Knight
            Tour problem */
            bool SolveKnightTourUtil (int x, int y, int moveIndex, int[,] board, int[] xMove, int[] yMove)
            {
                int next_x, next_y;

                // Base case!
                if (moveIndex == N * N)
                    return true;

                for (int k = 0; k < 8; k++)
                {
                    next_x = x + xMove[k];
                    next_y = y + yMove[k]; 

                    // Restric check only to safe positions.
                    if (IsSafePosition (next_x, next_y, board))
                    {
                        board [next_x, next_y] = moveIndex;
                        if (SolveKnightTourUtil (next_x, next_y, moveIndex + 1, board, xMove, yMove))
                        {
                            return true;
                        }

                        // Back to previous if arrive to this 
                        // point (aka backtracking)
                        board [next_x, next_y] = -1;
                    }
                }

                return false;    
            }

            public bool SolveKT () 
            {
                int[,] board = new int[8,8];

                /* Initialization of solution matrix */
                for (int x = 0; x < N; x++)
                    for (int y = 0; y < N; y++)
                        board[x, y] = -1;

                /* xMove[] and yMove[] define next move of Knight.
                xMove[] is for next value of x coordinate
                yMove[] is for next value of y coordinate */
                int[] xMove = {2, 1, -1, -2, -2, -1, 1, 2};
                int[] yMove = {1, 2, 2, 1, -1, -2, -2, -1};

                // Since the Knight is initially at the first block
                board [0,0] = 0;

                /* Start from 0,0 and explore all tours using
                solveKTUtil() */
                if (!SolveKnightTourUtil (0, 0, 1, board, xMove, yMove)) 
                {
                    Console.WriteLine ("Solution does not exist");
                    return false;
                } 
                else
                {
                    PrintSolution (board);
                }

                return true;
            }            
        }

        private class RatMaze
        {
            private int N = 4;

            void PrintSolution (int[,] maze)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(" " + maze [i,j] + " ");
                    Console.WriteLine();
                }
            }

            bool IsSafePosition (int x, int y, int[,] maze)
            {
                // Check here that maze[x,y] == 1 (not a wall)
                return (x >= 0 && x < N && y >= 0 &&
                        y < N && maze [x,y] == 1);
            }

            bool SolveMazeRateUtil (int[,] maze, int x, int y, int[,] sol)
            {
                // base case!
                if (x == N - 1 && y == N - 1)
                {
                    sol[x,y] = 1;
                    return true;
                }

                if (IsSafePosition (x, y, maze))
                {
                    sol[x, y] = 1;

                    if (SolveMazeRateUtil (maze, x + 1, y, sol) || 
                        SolveMazeRateUtil (maze, x, y + 1, sol))
                    {
                        return true;
                    }

                    // Usual backtrack operation!
                    sol[x, y] = 0;
                }

                return false;                
            }

            public bool SolveMaze (int[,] maze)
            {
                int[,] sol = {{0, 0, 0, 0},
                              {0, 0, 0, 0},
                              {0, 0, 0, 0},
                              {0, 0, 0, 0}};
        
                if (SolveMazeRateUtil(maze, 0, 0, sol) == false)
                {
                    Console.WriteLine ("Solution doesn't exist");
                    return false;
                }
        
                PrintSolution(sol);

                return true;
            }            
        }

        private class FillArrayProblem
        {
            void PrintResult (int[] arr)
            {
                foreach (var item in arr)
                    Console.Write (item + ", ");
            }

            public bool SolverFAUtil (int N, int[] res, int index)
            {
                if (N == 0)
                {
                    return true;
                }

                if (index + N + 1 <= res.Length - 1 && res[index] != 0)
                {
                    res[index] = N;
                    res[index + N + 1] = N;
                    
                    if (SolverFAUtil (N - 1, res, index - 1))
                    {
                        return true;
                    }

                    res[index] = 0;
                    res[index + N + 1] = 0;
                }

                return false;
            }

            public bool SolveFA (int N)
            {
                int[] res = new int[2 * N];
                return SolverFAUtil (N, res, 0);
            }
        }

    }
}        