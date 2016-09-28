using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class MathProblems
    {
        public MathProblems ()
        {
           Console.WriteLine (SQRt (16));           
        }

        // https://leetcode.com/problems/count-primes/
        static bool IsPrime (int n)
        {
            if (n <= 1) return false;

            // Loop's ending condition is i * i <= num instead of i <= sqrt(num)
            // to avoid repeatedly calling an expensive function sqrt().
            for (int i = 2; i * i <= n; i++) {
                if (n % i == 0) 
                    return false;
            }

            return true;            
        }

        // https://leetcode.com/problems/count-primes/
        // Sieve of Eratosthenes
        static int CountPrimes (int n)
        {
            bool[] isPrime = new bool[n];
            for (int i = 2; i < n; i++)
            {
                isPrime[i] = true;
            }
            
            for (int i = 0; i * i < n; i++)
            {
                if (!isPrime[i])
                    continue;

                for (int j = i * i; j < n; j+= i)
                {
                    isPrime[j] = false;
                }    
            }

            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (isPrime[i])
                    count ++;
            }

            return count;
        }

        // https://leetcode.com/problems/valid-perfect-square/
        static bool SQRt (int n)
        {
            if (n <= 1) return true;
            List<int> divs = new List<int> ();
            
            for (int i = 1; i * i <= n; i++) 
            {
                if (n % i == 0) 
                {
                    divs.Add (i);
                }
            }

            int pos = divs.Count / 2;

            return divs[pos] * divs[pos] == n;
        }


        static string PrintBinary (uint n)
        {
            string r = "";
            for (int i = 0; i < 32; i++)
            {
                int c = 1 << i;
                if ((n & c) > 0)
                    r = r.Insert (0, "1");
                else
                    r = r.Insert (0, "0");                    
            }

            return r;
        }

        // Fast exponential calculation x^y
        // O(log k)
        static int Pow (int mBase, int exp)
        {
            int result = 1;

            while (exp != 0)
            {
                if ((exp & 1) == 1)
                    result *= mBase;
                exp >>= 1;
                mBase *= mBase;
            }

            return result;
        }        
    }
}        