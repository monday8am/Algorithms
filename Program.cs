using System;
using System.Collections.Generic;

namespace ConsoleApplication
{

    public class Program
    {
        public static void Main(string[] args)
        {   
            var p = new int[]{0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30};
            Console.WriteLine (BottomUpCutRod(p, 3));
        }

        #region CutRod exercise (Dynamic programming)

        static int BottomUpCutRod (int[] A, int N)
        {
            int[] r = new int[N + 1];

            for (int j = 1; j <= N; j++)
            {
                int q = Int32.MinValue;

                for (int i = 1; i <= j; i++)
                {
                    q = Math.Max (q, A[i] + r[j - i]);                                      
                }

                r[j] = q;                         
            }    

            return r[N];        
        }

        static int MemoizedCutRod (int[] A, int N)
        {
            int[] r = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                r[i] = Int32.MinValue;            
            }

            return MemoizedCutRodAux (r, A, N);
        }

        static int MemoizedCutRodAux (int[] r, int[] A, int N)
        {
            if (r[N] >= 0)
            {
                return r[N];
            }

            if (N == 0) 
            {            
                return 0;                
            }

            int q = Int32.MinValue;  

            for (int i = 1; i <= N; i++)
            {
                q = Math.Max (q, A[i] + MemoizedCutRodAux (r, A, N - i)); 
            }

            r[N] = q;

            return q;
        }        

        static int CutRod (int[] A, int N)
        {
            if (N == 0) 
            {            
                return 0;                
            }

            int q = Int16.MinValue;  

            for (int i = 1; i <= N; i++)
            {
                q = Math.Max (q, A[i] + CutRod (A, N - i)); 
            }

            return q;
        }

        #endregion

        static int MinAvgTwoSlice (int[] A)
        {
            return 0;
        }
    }
}


