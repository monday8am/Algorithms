using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class DandC
    {
        public DandC ()
        {
            Console.WriteLine (CanWinNim (8));
        }

        // https://leetcode.com/problems/nim-game/
        static bool CanWinNim (int n) 
        {
            return !(n % 4 == 0);
        }
    }
}    
