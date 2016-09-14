using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class BitManipulation
    {
        public BitManipulation ()
        {
            int[] nums = new int[] {1,2};
            int[] p = new int[] {0};
            int[] q = new int[] {0};

            Console.WriteLine (PrintBinary (5));

        }

        // http://www.geeksforgeeks.org/binary-representation-of-a-given-number/
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

        // http://www.geeksforgeeks.org/swap-all-odd-and-even-bits/
        static uint SwapEvenOddBits (uint n)
        {
            // Get all even bits of x
            uint even_bits = n & 0xAAAAAAAA; 
        
            // Get all odd bits of x
            uint odd_bits  = n & 0x55555555; 
        
            even_bits >>= 1;  // Right shift even bits
            odd_bits <<= 1;   // Left shift odd bits
        
            return (even_bits | odd_bits); // Combine even and odd bits
        }


        // http://www.geeksforgeeks.org/sum-of-bit-differences-among-all-pairs/
        static int SumBitDifferences (int[] nums)
        {
            int r = 0;

            for (int i = 0; i < 32; i++)
            {
                int count = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if ((nums[j] & (1 << i)) > 0)
                    {
                        count++;
                    }
                }

                r += (count * (nums.Length - count) * 2);
            }

            return r;
        }


        // http://www.geeksforgeeks.org/find-nth-magic-number/
        // 001, 010, 011
        // magic number = 0*pow(5,3) + 0*pow(5,2) + 1*pow(5,1)
        static int FindMagicNumber (int n)
        {
            int pow = 1;
            int answer = 0;

            while (n > 0)
            {
                pow = pow * 5;

                if ((n & 1) == 1)
                    answer += pow;

                n >>= 1;
            }

            return answer;
        }

        static int SingleNumber2 (int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary <int, int> ();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey (nums[i]))
                {
                    dict[nums[i]] += 1;
                }
                else
                {
                    dict.Add (nums[i], 1);
                }
            }

            foreach (var item in dict)
            {
                if (item.Value != 3)
                    return item.Key;
            }            

            return -1;
        }


        // Don't ask me why :P
        // https://leetcode.com/problems/missing-number/
        static int MissingNumber (int[] nums)
        {
            int miss=0;
            for(int i=0; i<nums.Length; i++){
                miss ^= (i+1) ^nums[i];
            }
        
            return miss;           
        }

        // http://math.stackexchange.com/questions/2260/proof-for-formula-for-sum-of-sequence-123-ldotsn
        // http://math.stackexchange.com/questions/50485/sum-of-n-consecutive-numbers
        static int MissingNumber1(int[] nums) 
        {
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            
            // theorical sum of all nums
            int len = nums.Length + 1;
            int t = len * (len + 1) / 2 - sum; 
            return Math.Abs (t);
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