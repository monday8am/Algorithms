using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Arrays
    {  
        public Arrays ()
        {
            int[] arr = new int[] {2, 3, 6, 7};
            int[] arr1 = new int[] {2,2};
            Console.WriteLine (CombinationSum (arr, 7));
        }

        // https://leetcode.com/problems/combination-sum/
        static IList<IList<int>> CombinationSum (int[] candidates, int target)
        {
            List<IList<int>> res = new List<IList<int>> ();
            Array.Sort (candidates);

            CombinationSumUtil (candidates, target, 0, new List<int> (), res);

            return res;
        }

        // http://www.programcreek.com/2014/02/leetcode-combination-sum-java/
        // https://leetcode.com/problems/combination-sum/
        static void CombinationSumUtil (int[] candidates, int target, int index, List<int> partialRes, 
                                                    IList<IList<int>> res)
        {
            if (target == 0)
            {
                res.Add (new List<int> (partialRes));
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (target < candidates[i])
                    return;
                partialRes.Add (candidates[i]);     
                CombinationSumUtil (candidates, target - candidates [i], i, partialRes, res);
                partialRes.Remove(candidates[i]);    
            }
        }

        // https://leetcode.com/problems/minimum-size-subarray-sum/
        static int MinSubArrayLen (int s, int[] nums) 
        {
            int min = Int32.MaxValue;
            int total = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
            }

            if (total < s)
                return 0;

            int p1 = 0;
            int p2 = nums.Length - 1;

            while (total >= s)
            {
                min = Math.Min (min, p2 - p1 + 1);
                total -= nums [p1++];
                Console.WriteLine (total + " > " + s);
            }  

            return min;  
        }

        // https://leetcode.com/problems/intersection-of-two-arrays/
        static int[] Intersection(int[] nums1, int[] nums2) 
        {
            HashSet<int> hash = new HashSet<int> ();
            HashSet<int> result = new HashSet<int> ();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!hash.Contains (nums1[i]))
                    hash.Add (nums1[i]);
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                int v = nums2[i];
                if (hash.Contains (v) && !result.Contains (v))
                {
                    result.Add (v);
                }
            }

            int[] arr = new int[result.Count];
            result.CopyTo (arr); 

            return arr;
        }


         static int SearchInsertPos (int[] nums, int target) 
        {
            if (target <= nums[0])
                return 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (target > nums[i - 1] && target <= nums[i])
                    return i;
            }

            return nums.Length;
        }    
    }
}            