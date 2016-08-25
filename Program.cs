using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var p = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 3, 12};
            //Console.WriteLine (Sum3(p, 0));
            var arr = MoveZeroes (p);
            foreach (var item in arr)
            {
                Console.WriteLine (item);
            }
        }

        // https://leetcode.com/problems/move-zeroes/
        static int[] MoveZeroes(int[] nums)
        {   
            int firstZero = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (firstZero == -1)
                        firstZero = i;
                }
                else 
                {
                    if (firstZero != -1)
                    {
                        nums[firstZero] = nums[i];
                        nums[i] = 0;
                        firstZero ++;                        
                    }
                }
            }

            return nums;
        }

        // https://leetcode.com/problems/reverse-string/
        static string ReverseString(string s)
        {            
            char[] arr = s.ToCharArray ();
            Array.Reverse (arr);            
            return string.Join<Char> ("", arr);
        }

        static bool Sum3 (int[] A, int s)
        {
            Array.Sort (A);
            int sum = 0;

            for (int i = 0; i < A.Length - 2; i++)
            {
                int startIndex = i + 1;
                int endIndex = A.Length - 1;

                while (endIndex != startIndex)
                {
                    sum = A[i] + A[endIndex] + A[startIndex];

                    if (sum > s)
                        endIndex--;
                    else if (sum < s)
                        startIndex++;
                    else 
                        return true;                      
                }
            }

            return false;           
        }

        // http://blog.gainlo.co/index.php/2016/07/19/3sum/
        static bool Sum2 (int[] A, int s)
        {
            Array.Sort (A);
            int startIndex = 0;
            int endIndex = A.Length - 1;
            int sum = 0;

            while (endIndex != startIndex)
            {
                sum = A[endIndex] + A[startIndex];

                if (sum > s)
                    endIndex--;

                 else if (sum < s)
                    startIndex++;
                 else 
                    return true;      
            }

            return false;
        }

        static int MinAvgTwoSlice (int[] A)
        {
            int len = A.Length;
            double[] avlist = new double[len];
            double av = Convert.ToDouble (Int32.MaxValue);

            // prefix sum calculation.
            int[] pref = new int[len+ 1];

            for (int i = 1; i < pref.Length; i++)
            {                
                pref[i] = pref[i -1] + A[i - 1];
                
                for (int j = i - 2; j < i - 1; j++)
                {
                    double tmpAv = (pref[i] - pref[j]) * 1.0 / (i - j);
                    if (tmpAv < av)
                    {
                        avlist[j] = tmpAv; 
                        av = tmpAv;                 
                    }
                }
            }

            for (int i = 0; i < len; i++)
            {
                if (av == avlist[i])
                    return i;
            }

            return -1;
        }
        
        #region CutRod exercise (Dynamic programming)

        static int CutRodWithPricePerCut (int[] A, int N, int P)
        {
            int[] r = new int[N + 1];
            int[] s = new int[N + 1];

            for (int j = 1; j <= N; j++)
            {
                int q = Int32.MinValue;

                for (int i = 1; i <= j; i++)
                {
                    if (q < A[i] + r[j - i] - ((i -1) * P)) 
                    {
                        q = A[i] + r[j - i] - ((i -1) * P);
                        s[j] = i;
                    }                                  
                }

                r[j] = q;                         
            }    

            return r[N];        
        }

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
    }
}


