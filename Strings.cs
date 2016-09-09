using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Strings
    {
        public Strings ()
        {
            int[] arr = new int[] {1,2,4,0};
            int[] arr1 = new int[] {3};
            MergedSortedArraySimple (arr, 3, arr1, 1); 
        }

        // http://www.programcreek.com/2012/12/leetcode-merge-sorted-array-java/
        static void MergedSortedArraySimple (int[] nums1, int m, int[] nums2, int n)
        {
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[m + n - 1] = nums1[m - 1];
                    m --;
                }
                else 
                {
                    nums1[m + n - 1] = nums2[n -1];
                    n --;
                }
            }

            while (n > 0)
            {
                nums1[n + m - 1] = nums2[n - 1];
                n --;
            }
        }

        // https://leetcode.com/problems/merge-sorted-array/
        static void MergeSortedArray(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;

            if (m == 0)
            {
                Array.Resize (ref nums1, n);
                Array.Copy (nums2, nums1, n);
                return;
            }

            Queue<int> queue = new Queue<int> ();
            int start1 = 0, start2 = 0;            

            for (int i = m; i < m + n; i++)           
            {
                nums1[i] = Int32.MaxValue;
            }

            for (int i = 0; i < n + m; i++)
            {   
                int candidate = start2 < n ? nums2[start2] : Int32.MaxValue;

                if (queue.Count == 0)
                {
                    if (candidate < nums1[start1])
                    {
                        queue.Enqueue (nums1[start1]);
                        nums1[start1] = candidate;
                        start2 ++;
                    }
                }
                else if (queue.Peek () < candidate)
                {
                    if (queue.Peek () < nums1[start1])
                    {
                        queue.Enqueue (nums1[start1]);
                        nums1[start1] = queue.Dequeue ();
                    }                        
                }
                else if (candidate < nums1[start1])
                {
                    queue.Enqueue (nums1[start1]);
                    nums1[start1] = candidate;
                    start2 ++;
                } 
                else if (nums1[start1] < queue.Peek ())
                {
                    nums1[start1] = queue.Dequeue ();
                }                       

                start1++;
            }
        }

        // https://leetcode.com/problems/majority-element/
        static int MajorityElement(int[] nums)
        {
            Stack<int> stack = new Stack<int> ();

            // get leader or dominator
            foreach (var item in nums)
            {
                if (stack.Count == 0)
                {
                    stack.Push (item);
                }
                else 
                {
                    if (stack.Peek () != item)
                        stack.Pop ();
                    else
                        stack.Push (item);    
                }                      
            }

            if (stack.Count == 0)
                return -1;

            int candidate = stack.Pop ();
            int counter = 0;

            foreach (var item in nums)
            {
                if (item == candidate)
                    counter ++;
            }

            return counter > nums.Length / 2 ? candidate : -1;
        }

        // https://leetcode.com/problems/rotate-array/        
        static void Rotate (int[] nums, int k)
        {
            k = k % nums.Length;
            ReverseArray (nums, 0, nums.Length - 1);
            ReverseArray (nums, 0, k - 1);
            ReverseArray (nums, k, nums.Length - 1);            
        }

        static int[] ReverseArray (int[] arr, int start, int end)
        {
            while (start < end)
            {
                int tmp = arr[start];
                arr[start] = arr[end];
                arr[end] = tmp;
                end--;
                start++;
            }

            return arr;
        }

        // https://leetcode.com/problems/rotate-array/
        // Exeed time limit :(
        static void Rotate2(int[] nums, int k)
        {
            int len = nums.Length;

            for (int i = 0; i < k; i++)
            {
                int last = nums[len - 1];

                for (int j = len - 1; j >= 1; j--)
                {
                    nums[j] = nums[j - 1];
                }

                nums[0] = last;
            }
        }

        // https://leetcode.com/problems/contains-duplicate-ii/
        static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int> ();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey (nums[i]))
                {
                    if (i - dict[nums[i]] == k)
                        return true;
                }
                else
                {
                    dict.Add (nums[i], i);                    
                }
            }            
            return false;
        }

        // https://leetcode.com/problems/contains-duplicate/
        static bool ContainsDuplicate(int[] nums) 
        {
            HashSet<int> hash = new HashSet<int> ();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hash.Contains (nums[i]))
                    return true;
                hash.Add (nums[i]);    
            }
            return false;    
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

    }    
}    