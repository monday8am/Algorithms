using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class MathProblems
    {
        public MathProblems ()
        {
           Console.WriteLine (ChocolatesByNumbers (10, 4));           
        }

        // https://codility.com/programmers/lessons/12-euclidean_algorithm/chocolates_by_numbers/
        static int ChocolatesByNumbers (int N, int M) 
        {
            // write your code in Java SE 8
            return N / (ChocolatesByNumbersUtil (M, N));
        }

        static int ChocolatesByNumbersUtil (int a, int b)
        {
            if (a % b == 0)
                return b;
            else
                return ChocolatesByNumbersUtil (b, a % b);
        }        

        // https://leetcode.com/problems/divide-two-integers/
        // http://www.programcreek.com/2014/05/leetcode-divide-two-integers-java/
        static int DivideIntegers (int dividend, int divisor) 
        {
            //handle special cases
            if (divisor == 0) 
                return Int32.MaxValue;
            
            if (divisor == -1 && dividend == Int32.MinValue)
                return Int32.MaxValue;

            //get positive values
            long pDividend = Math.Abs((long)dividend);
            long pDivisor = Math.Abs((long)divisor);   

            int res = 0;

            while (pDividend >= pDivisor)
            {
                // Calculate the number of left shifts.
                int numShift = 0;
                while (pDividend >= (pDivisor << numShift))
                {
                    numShift++;
                }

                //dividend minus the largest shifted divisor.
                res += 1 << (numShift - 1);
                pDividend -= (pDivisor << (numShift-1));
            } 

            // handle result sign.
            if ((dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0))
                return res;
            else
                return -res;
        }


        // https://leetcode.com/problems/reverse-integer/
        static int ReverseInteger (int n)
        {
            long l = Convert.ToInt64 (n);
            int negative = l < 0 ? -1 : 1;
            string s = Convert.ToString (Math.Abs (l));
            
            char[] arr = s.ToCharArray ();
            int p1 = 0;
            int p2 = s.Length - 1;

            while (p2 >= p1)
            {
                char tmp = arr[p1];
                arr[p1] = arr[p2];
                arr[p2] = tmp;

                p2 --;
                p1++;
            }

            s = new string (arr);
            l = Int64.Parse (s);

            if (l > Int32.MaxValue)
                return 0;

            return negative * Convert.ToInt32 (l);
        }

        // https://leetcode.com/problems/integer-replacement/
        static int IntegerReplacement(int n) 
        {
            if (n == 0)
                return -1;
            return IntegerReplacementUtil (n, 0);
        }

        static int IntegerReplacementUtil (long n, int res) 
        {
            if (n == 1)
                return res;
            
            res++;

            if (n % 2 == 0)
                return IntegerReplacementUtil (n/2, res);
            else
                return Math.Min (IntegerReplacementUtil (n + 1, res), IntegerReplacementUtil (n - 1, res));           
        }


        //https://leetcode.com/problems/happy-number/
        static bool HappyNumber (int num)
        {
            return HappyNumberUtil (num, new HashSet<long> ());
        }

        static bool HappyNumberUtil (int num, HashSet<long> hash)
        {
            long sum = 0;      

            while (num != 0) 
            {
                sum += Pow (num % 10, 2);
                num /= 10;
            }

            if (sum == 1)
                return true;
            else if (hash.Contains(sum))
                return false;
            else 
                hash.Add (sum);

            return HappyNumberUtil (Convert.ToInt32 (sum), hash);    
        }

        // https://leetcode.com/problems/add-digits/
        static int DigitalRoot (int n)
        {
            // https://en.wikipedia.org/wiki/Digital_root#Significance_and_formula_of_the_digital_root
            return n - 9 * ((n - 1)/9);
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