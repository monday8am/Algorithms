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

            int c = board.GetUpperBound (0); 
            int c1 = board.GetUpperBound (1);                  
                             
            Console.WriteLine (WordSearch (board, "BC"));                  
        }

        // http://www.programcreek.com/2014/06/leetcode-word-search-java/
        // https://leetcode.com/problems/word-search/
        static bool WordSearch (char[,] board, string word)
        {
            return WordSearchUtil (-1, 0, board, word);
        }

        static bool WordSearchUtil (int previousX, int previousY, char[,] board, string word)
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
        
        public bool DFS (char[,] board, String word, int i, int j, int k)
        {
            int m = board.GetUpperBound (0);
            int n = board.GetUpperBound (1);
        
            if (i < 0 || j < 0 || i > m || j > n)
            {
                return false;
            }
            
            if (board[i,j] == word.(k))
            {
                char temp = board[i][j];
                board[i][j]='#';
                if(k==word.length()-1){
                    return true;
                }else if(dfs(board, word, i-1, j, k+1)
                ||dfs(board, word, i+1, j, k+1)
                ||dfs(board, word, i, j-1, k+1)
                ||dfs(board, word, i, j+1, k+1)){
                    return true;
                }
                board[i][j]=temp;
            }
        
            return false;
        }
    }
}        