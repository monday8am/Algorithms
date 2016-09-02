﻿using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var p = new int[] {2,5,10,20};
            Console.WriteLine (CoinChange (p, 100));
            //1 
            //1 2, 12
            //1 2 1, 12 1, 1 21
            //1 2 1 1, 12 1 1, 1 21 1, 1 2 11, 12 11


        }

        // http://www.programcreek.com/2015/04/leetcode-coin-change-java/
        // https://leetcode.com/problems/coin-change/
        static int CoinChange (int[] coins, int amount)
        {  
            long max = amount + 1;
            long[] dp = new long[max];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = max;
            }

            dp[0] = 0;
            for (int i = 0; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    if (i + coin <= amount)
                    {
                        if (dp[i] == max)
                        {
                            dp[i+coin] = dp[i+coin];
                        }
                        else
                        {
                            dp[i+coin] = Math.Min(dp[i+coin], dp[i]+1);
                        }
                    }
                }
            }

            return dp[amount] >= amount ? -1 : Convert.ToInt32 (dp[amount]);
        }

        // https://leetcode.com/problems/two-sum/
        static int[] TwoSum (int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<Int32, Int32> hash = new Dictionary<Int32, Int32> ();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hash.ContainsKey (nums[i]))
                {
                    result[0] = hash [nums[i]];
                    result[1] = i;
                    return result;
                }
                else if (!hash.ContainsKey(target - nums[i]))
                {
                    hash.Add (target - nums[i], i);
                }
            }
            return result;
        }

        // https://leetcode.com/problems/increasing-triplet-subsequence/
        static bool IncreasingTriplet (int[] nums)
        {
            int firstMin = Int32.MaxValue;
            int secondMin = Int32.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < firstMin)
                {
                    firstMin = nums [i];
                }
                else if (nums[i] > firstMin && nums[i] < secondMin)
                {
                    secondMin = nums[i];
                }   
                else if (nums[i] > secondMin)
                {
                    return true;
                }
            }

            return false;
        }

        // https://leetcode.com/problems/implement-strstr/
        static int FindStr (string haystack, string needle)
        {
            if (needle == "")
            {
                return 0;
            }

            int counter = 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack.Substring(i, 1) == needle.Substring (0, 1) && 
                    haystack.Length - i >= needle.Length)
                {
                    counter ++;

                    while (counter < needle.Length && counter > 0)
                    {
                        if (haystack.Substring(i + counter, 1) == needle.Substring (counter, 1))
                        {
                            counter++;
                        }   
                        else
                        {
                            counter = 0;
                        }                         
                    }
                    
                    if (counter == needle.Length)
                        return i;
                }
            }

            return -1;
        }

        // http://www.programcreek.com/2014/06/leetcode-decode-ways-java/
        // https://leetcode.com/problems/decode-ways/
        static int DecodeWays (string s)
        {
            if (s.Length == 0 || s.Substring (0, 1) == "0")
                return 0;

            if (s.Length == 1)
                return 1;    

            int[] comb = new int[s.Length]; comb[0] = 1;
            int num = Convert.ToInt32 (s.Substring (0, 2));

            if (num <= 26 && num >= 10)
            {
                if (s.Substring (1, 1) != "0")
                    comb[1] = 2;
                else
                    comb[1] = 1;    
            }
            else if (s.Substring (1,1) != "0")
            {
                comb[1] = 1;                
            }
            else
            {
                return 0;
            }

            for (int i = 2; i < s.Length; i++)
            {
                if (s.Substring (i, 1) != "0")
                {
                    comb[i] += comb[i - 1];
                }

                num = Convert.ToInt32 (s.Substring (i - 1, 2));
                if (num <= 26 && num >= 10)
                {
                    comb[i] += comb[i - 2];
                }
            }

            return comb[s.Length - 1];
        }

        // https://leetcode.com/problems/wiggle-subsequence/
        static int WiggleMaxLength (int[] nums)
        {
            if (nums.Length < 3)
                return nums.Length;    

            int prevdiff = nums[1] - nums[0];
            int count = prevdiff != 0 ? 2 : 1;
            for (int i = 2; i < nums.Length; i++) 
            {
                int diff = nums[i] - nums[i - 1];
                if ((diff > 0 && prevdiff <= 0) || (diff < 0 && prevdiff >= 0)) {
                    count++;
                    prevdiff = diff;
                }
            }
            return count;
        }


        // https://leetcode.com/problems/house-robber-ii/
        static int RobberI(int[] nums) 
        {
            int len = nums.Length;
            int evenMax = 0;
            int oddMax = 0;
            bool startRobbed = false;
            bool endRobbed = false;

            if (len == 1)
                return nums[0];

            if (len == 2)
                return 0;

            if (len == 3)
                return Math.Max (nums[0] + nums[2], nums[1]);    

            for (int i = 0; i < len; i++)
            {
                if (i % 2 == 0)
                    evenMax = Math.Max (oddMax, evenMax + nums[i]);
                else
                    oddMax = Math.Max (evenMax, oddMax + nums[i]);

                if (i == 0 && evenMax > oddMax)
                    startRobbed = true;

                if (i == len - 1 && Math.Abs (oddMax - evenMax) == nums[i])
                    endRobbed = true;
            }

            int prev = Math.Max (evenMax, oddMax);  

            if (endRobbed && startRobbed)
                return prev - Math.Max (nums[0], nums[len -1]);   

            return prev;      
        }

        // http://www.programcreek.com/2014/03/leetcode-maximum-product-subarray-java/
        static int MaxProduct_KadaneStyle (int[] nums)
        {
            int[] max = new int[nums.Length];
            int[] min = new int[nums.Length];
        
            max[0] = min[0] = nums[0];            
            int result = nums[0];
        
            for(int i=1; i<nums.Length; i++)
            {
                if (nums[i]>0)
                {
                    max[i]=Math.Max(nums[i], max[i-1]*nums[i]);
                    min[i]=Math.Min(nums[i], min[i-1]*nums[i]);
                } 
                else
                {
                    max[i]=Math.Max(nums[i], min[i-1]*nums[i]);
                    min[i]=Math.Min(nums[i], max[i-1]*nums[i]);
                }
            }    
        
            return result = Math.Max(result, max[nums.Length - 1]);         
        }

        // https://leetcode.com/problems/maximum-product-subarray/
        static int MaxProduct (int[] nums)
        {
            int maxProduct = nums[0];
            int currentMaxProduct = nums[0];
            int currentMinProduct = nums[0];
            int prevMinProduct = nums[0];
            int prevMaxProduct = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                // three elements comparison.
                currentMaxProduct = Math.Max (nums[i], Math.Max (prevMinProduct * nums[i], prevMaxProduct * nums[i]));
                currentMinProduct = Math.Min (nums[i], Math.Min (prevMinProduct * nums[i], prevMaxProduct * nums[i]));
                maxProduct = Math.Max (maxProduct, currentMaxProduct);
                
                // save to use in next iteration.
                prevMinProduct = currentMinProduct;
                prevMaxProduct = currentMaxProduct;
            }

            return maxProduct;
        }

        // https://leetcode.com/problems/house-robber/
        static int Robber(int[] nums) 
        {
            int evenMax = 0;
            int oddMax = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                    evenMax = Math.Max (oddMax, evenMax + nums[i]);
                else
                    oddMax = Math.Max (evenMax, oddMax + nums[i]);
            }

            return Math.Max (evenMax, oddMax);
        }        

        // https://leetcode.com/problems/climbing-stairs/
        static int ClimbingOneTwo (int N)
        {
            int[] count = new int[N + 1];
            count[0] = 1;
            count[1] = 1;

            for (int i = 2; i < count.Length; i++)
            {
                count[i] = count[i - 1] + count[i - 2];
            }

            return count[N];
        }

        // https://leetcode.com/problems/range-sum-query-immutable/
        static int RangeSumQuery (int[] nums, int A, int B)
        {
            int[] fetch = new int[nums.Length + 1];

            for (int i = 1; i < fetch.Length; i++)
            {
                fetch[i] = fetch[i - 1] + nums [i - 1];                 
            } 

            return fetch[B + 1] - fetch[A];
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        static int MaxProfit (int[] prices)
        {
            int maxEnding = 0;
            int maxProfit = 0;
            int len = prices.Length;
            int[] delta = new int[len];

            for (int i = 1; i < delta.Length; i++)
            {
                delta[i] = prices[i] - prices[i - 1]; 
            }

            foreach (int item in delta)
            {
                maxEnding = Math.Max (0, maxEnding + item);
                maxProfit = Math.Max (maxEnding, maxProfit);
            }

            return maxProfit;
        }

        // https://leetcode.com/problems/longest-increasing-subsequence/
        // http://www.geeksforgeeks.org/dynamic-programming-set-3-longest-increasing-subsequence/
        static int LISWithDP (int[] arr)
        {
            int n = arr.Length; 
            int[] lis = new int[n];
            int result = -1;

            for (int i = 0; i < n; i++)
            {
                lis[i] = 1;
            } 

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;       
                }                
            }

            for (int i = 0; i < n; i++ )
                result = Math.Max (result, lis[i]);

            return result;
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


