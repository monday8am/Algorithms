using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Arrays
    {  
        public Arrays ()
        {
            int[] arr = new int[] {1,2,2,1};
            int[] arr1 = new int[] {2,2};
            Console.WriteLine (SearchInsertPos (arr, 0));
            Intersection (arr, arr1);
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