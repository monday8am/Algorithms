using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class BitManipulation
    {
        public BitManipulation ()
        {
            int[] nums = new int[] {1,3,4,5,5,6,6,1,3,5,4};
            int[] p = new int[] {0};
            int[] q = new int[] {0};

            Console.WriteLine ( PowerOfThree(19684));

        }

        // https://leetcode.com/problems/power-of-three/
        static bool PowerOfThree (int n)
        {
            if (n == 1)
                return true;

            while (n > 0)
            {
                int m = n % 3;
                if (m == 0)
                {
                    n = n / 3;
                    if (n == 1)
                        return true;
                }
                else
                {
                    return false;
                }

            }

            return false;
        }

        // http://www.programcreek.com/2012/12/leetcode-solution-of-single-number-in-java/
        static int SingleNumberBitwise (int[] nums)
        {
            int x = 0;

            foreach (var item in nums)
            {
                x = x ^ item;
            }

            return x;
        }

        // https://leetcode.com/problems/single-number/
        static int SingleNumber (int[] nums)
        {
            HashSet<int> hash = new HashSet<int> ();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hash.Contains (nums[i]))
                {
                    hash.Remove (nums[i]);
                }
                else
                {
                    hash.Add (nums[i]);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (hash.Contains (nums[i]))
                    return nums[i];
            }

            return -1;
        }



        // https://leetcode.com/problems/find-the-difference/
        static char FindTheDifference (string s, string t)
        {
            HashSet<string> hash = new HashSet<string> ();
            int[] sList = new int[26];
            int[] tList = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                char c = Convert.ToChar (s.Substring (i, 1));
                sList[(int)c - (int)'a'] += 1;
            }

            for (int i = 0; i < t.Length; i++)
            {
                char c = Convert.ToChar (t.Substring (i, 1));
                tList[(int)c - (int)'a'] += 1;
            }  

            for (int i = 0; i < sList.Length; i++)
            {
                if (sList[i] != tList[i])
                    return (char)(i + (int)'a');
            }

            return '1';
        }

        // https://leetcode.com/problems/sum-of-two-integers/
        static int GetSum(int a, int b)
        {
            while (b!=0) 
            {
                int c = a&b;
                a = a^b;
                b = c<<1;
            }
            
            return a;     
        }

        // https://leetcode.com/problems/power-of-four/
        static bool PowerOfFour (int n)
        {
            long v = Convert.ToInt64 (n);
            int count = 0;

            if (v == 0)
                return false;

            if ((v & (v - 1)) == 0) 
            {
                while (v != 0)
                {
                    count++;
                    v >>= 1;
                }
            }   

            return (count - 1) % 2 == 0;
        }

        // https://leetcode.com/problems/power-of-two/
        static bool PowerOfTwo (int n)
        {
            long v = Convert.ToInt64 (n);

            if (v == 0)
                return false;

            return (v & (v - 1)) == 0;
        }        

        static int CountBits(uint value)
        {
            int count = 0;
            while (value != 0)
            {
                count++;
                value &= value - 1;
            }
            return count;
        }        

        static uint ReverseBits1 (uint n)
        {
            int num = Convert.ToInt32 (n);
            for (int i = 0; i < 16; i++) 
            {
                int j = i - 32 - 1;
                int a = (num >> i) & 1;
                int b = (num >> j) & 1;
            
                if ((a ^ b) != 0) {
                    num ^= (1 << i) | (1 << j);
                }
            }
        
            return Convert.ToUInt32 (num);          
        }

        static int ReverseBits (uint i)
        {
            uint y = 0;

            for (int j = 0; j < 32; j++)
            {
                y <<= 1;
                y |= (i & 1);
                i >>= 1;
            }

            return (int)y;
        }
    }    
}    