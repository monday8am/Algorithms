using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class BitManipulation
    {
        public BitManipulation ()
        {
            Console.WriteLine (ReverseBits1 (12));

        }

        static int ReverseBits1 (int n)
        {
            for (int i = 0; i < 16; i++) 
            {
                int j = i - 32 - 1;
                int a = (n >> i) & 1;
                int b = (n >> j) & 1;
            
                if ((a ^ b) != 0) {
                    n ^= (1 << i) | (1 << j);
                }
                //Console.WriteLine (n);
            }
        
            return (int)n;          
        }

        static int ReverseBits (uint i)
        {
            uint y = 0;

            for (int j = 0; j < 32; j++)
            {
                y <<= 1;
                y |= (i & 1);
                i >>= 1;
                Console.WriteLine (Convert.ToString (y, 2));
            }

            return (int)y;
        }

        static int ReverseBitsWrong (uint i)
        {
            char c;
            char[] binary = Convert.ToString(i, 2).ToCharArray ();
            int start = 0;
            int end = binary.Length - 1; 
            int offset = (binary.Length % 2 == 0) ? 1 : 0;

            while (start != end + offset)
            {
                c = binary[end];
                binary[end] = binary[start];
                binary[start] = c;
                start ++;
                end --;
            }
        
            return Convert.ToInt32 (new string (binary), 2);
        }
    }    
}    