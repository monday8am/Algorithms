using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Greedy
    {
        public Greedy ()
        {
          var A  =  new int [] {1, 3, 7, 9, 9};
          var B =  new int[]  {5, 6, 8, 9, 10};
          var arr =  new int[]  {1,2,3,4,1,1,3};
          
          Console.WriteLine (MaxNonoverlappingSegments (A, B));
        }

        

        // https://codility.com/programmers/task/max_nonoverlapping_segments/
        static int MaxNonoverlappingSegments (int[] A, int[] B)
        {
            if (A.Length == 0)
                return 0;

            int res = 1;
            int lastEnd = B[0];

            for (int i = 1; i < B.Length; i++)
            {
                if (lastEnd < A[i])
                {
                    res++;
                    lastEnd = B[i];
                }
            }
            
            return res;
        }

        // https://codility.com/programmers/task/tie_ropes/
        static int TieRopes (int K, int[] A)
        {
            long sum = 0;
            int res = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= K || 
                   sum + A[i] >= K
                   )
                {
                    res++;
                    sum = 0;
                }
                else
                {
                    sum += A[i];
                }
            }

            return res;
        }


        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
        // http://www.programcreek.com/2014/02/leetcode-best-time-to-buy-and-sell-stock-ii-java/
        static int BuySellStock2 (int[] stock)
        {
            int profit = 0;

            for(int i=1; i < stock.Length; i++)
            {
                int diff = stock[i] - stock[i-1];
                if (diff > 0)
                {
                    profit += diff;
                }
            }
            return profit;
        }

        // http://www.programcreek.com/2014/03/leetcode-gas-station-java/
        // https://leetcode.com/problems/gas-station/
        static int GasStation (int[] gas, int[] cost) 
        {
            int candidate = 0;
            int total = 0;
            int sumRemaining = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                int remaining = gas[i] - cost[i];
                if (sumRemaining >= 0)
                {
                    sumRemaining += remaining;
                }
                else
                {
                    sumRemaining = remaining;
                    candidate  = i;
                }
                total += remaining;
            }

            if (total >= 0)
                return candidate;
            else
                return -1;    
        }

        // http://www.programcreek.com/2014/03/leetcode-jump-game-java/
        // https://leetcode.com/problems/jump-game/
        static bool CanJump(int[] nums) 
        {
            if (nums.Length <= 1)
                return true;

            int max = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (max <= i && nums[i] == 0)
                    return false;

                if(i + nums[i] > max)
                    max = i + nums[i];

                if (max >= nums.Length - 1) 
                    return true;     
            }


            return false;
        } 

        // http://www.geeksforgeeks.org/greedy-algorithms-set-1-activity-selection-problem/
        static int ActivitySelection (int[] start, int[] finish)
        {
            // "end" should be sortered
            // from less to more.
            int r  = 1;
            int lastEnd = finish[0];

            for (int i = 1; i < start.Length; i++)
            {
                if (start[i] >= lastEnd)
                {
                    lastEnd = finish[i];
                    r = r + 1;
                }    
            }

            return r; 
        }
    }
}        