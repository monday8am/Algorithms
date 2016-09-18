using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class MathProblems
    {
        public MathProblems ()
        {
            Console.WriteLine (Pow (4, 4));
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