using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var p = new int[] {3, 34, 4, 12, 5, 2};
            var grid = new char[,] {{'0', '1'}, {'1', '0'}};
            Console.WriteLine (MaximalSquare (grid));
        }

        /*
        // https://leetcode.com/problems/add-binary/
        static string AddBinary(string a, string b)
        {

        }
        */

        // https://leetcode.com/problems/maximal-square/
        static int MaximalSquare (char[,] matrix)
        {
            int result = 0;
            int m = matrix.GetUpperBound (0);
            int n = matrix.GetUpperBound (1);
            
            if (n == 0 && m == 0)
                return matrix[0,0] == '1' ? 1 : 0;

            if (n == 0)
            {
                for (int i = 0; i < m + 1; i++)
                {
                    if (matrix[i,0] == '1')
                        return 1;
                }
            }

            if (m == 0)
            {
                for (int i = 0; i < n + 1; i++)
                {
                    if (matrix[0,i] == '1')
                        return 1;
                }
            }            

            int[,] grid = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    grid[i,j] = Convert.ToInt32 (Char.GetNumericValue (matrix[i,j]));
                }
            }    

            int a, b, c, d;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // box:
                    // a b 
                    // c d
                    a = grid[i - 1, j - 1];
                    b = grid[i, j - 1];                    
                    c = grid[i - 1, j];
                    d = grid[i,j];
                    
                    if (a == 1 || b == 1 || c == 1 || d == 1)
                        if (result == 0)
                            result = 1;

                    if (a > 0 && b > 0 && c > 0 && d > 0)
                    {
                        if (b == c && a == b)
                        {
                            d = a + 1; 
                        }
                        else if (b > c || c > b)
                        {
                            d = Math.Max (b,c);
                        }

                        grid[i,j] = d;
                    }  

                    result = Math.Max (result, grid[i,j]);                  
                }
            }

            return result * result;
        }

        
   
    }
}


