using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Arrays
    {  
        public Arrays ()
        {
            int[] arr = new int[] {2,1,3,1,1,2};
            int[] arr1 = new int[] {2,2};

            Console.WriteLine (SubArrayWithSum (arr, 5));
        }


        // http://blog.gainlo.co/index.php/2016/06/01/subarray-with-given-sum/
        static List<int> SubArrayWithSum (int[] nums, int s)
        {
            List<int> res = new List<int> ();
            int sum = 0;
            int p2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (sum >= s && p2 < nums.Length)
                {
                    if (sum == s)
                    {
                        Console.WriteLine ("do something!");
                        return res;
                    }

                    sum -= nums[p2];
                    p2 ++;
                }
            }

            return res;
        }

        // TODO. Wrong solution!
        // https://leetcode.com/problems/3sum/
        static IList<IList<int>> Sum3 (int[] nums)
        {
            Array.Sort (nums);
            int sum = 0;
            int s = 0;
            IList<IList<int>> res = new List<IList<int>> ();
            Dictionary<string, List<int>> hash = new Dictionary<string, List<int>> ();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int startIndex = i + 1;
                int endIndex = nums.Length - 1;

                while (endIndex != startIndex)
                {
                    sum = nums[i] + nums[endIndex] + nums[startIndex];
                   
                    if (sum > s)
                        endIndex--;
                    else if (sum < s)
                        startIndex++;
                    else
                    {
                        var list = new List<int> {nums[i], nums[endIndex], nums[startIndex]};
                        list.Sort ();
                        string key = "";
                        foreach (var item in list)
                            key += item;

                        if (!hash.ContainsKey (key))
                            hash.Add (key, list);

                        endIndex = startIndex;
                    }                       
                }
            }

            foreach (var item in hash)
                res.Add (item.Value);

            return res;          
        }

        // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        static int FindMin(int[] nums) 
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            return FindMinUtil (nums, 0, nums.Length - 1);
        }  

        static int FindMinUtil (int[] nums, int start, int end)
        {
            if (end - start == 1)
            {
                if (nums[end] < nums[start])
                {
                    return nums[end];
                }
                
                return nums[0];
            }

            int targetIndex = start + (end - start)/2;    

            if (nums[targetIndex] > nums[0])  
                return FindMinUtil (nums, targetIndex, end);
            else 
                return FindMinUtil (nums, start, targetIndex);            
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
                partialRes.Remove(candidates[i]); // Backtracking!   
            }
        }

        // https://leetcode.com/problems/minimum-size-subarray-sum/        
        static int MinSubArray (int s, int[] nums)
        {
            int p1 = 0;
            int sum = 0;
            int min = Int32.MaxValue;

            for (int p2 = 0; p2 < nums.Length; p2++)
            {
                sum += nums[p2];

                while (sum >= s && p1 < nums.Length)
                {
                    min = Math.Min (min, p2 - p1 + 1);                                    
                    sum -= nums[p1];
                    p1++;
                }
            }

            if (min == Int32.MaxValue)
                return 0;

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