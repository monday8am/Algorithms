using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Heap
    {
        public Heap ()
        {
            int[] nums1 = new int[] {1,2,3};
            int[] nums2 = new int[] {3,4,6};
            
            Console.WriteLine (FindSmallestSum (nums1, nums2, 6));
        }


        // TODO Not finished!
        static int SuperUglyNumber (int n, int[] primes)
        {
            int[] p = new int[primes.Length + 1];
            p[0] = 1;

            for (int i = 1; i < p.Length; i++)
            {
                p[i] = primes[i - 1];
            }
            HashSet<int> heap = new HashSet<int> ();

            if (n == 0)
                return 0;

            while (n > 0)
            {

                n --;
            }

            return 0;
        }

        // https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
        static IList<int []> FindSmallestSum (int[] nums1, int[] nums2, int k)
        {
            List<int []> result = new List<int []> (); 
            // Use thi array as Hash?    
            int[] idx = new int[nums1.Length];

            k = Math.Min (k, nums1.Length * nums2.Length);
            if (k == 0)
                return result;

            while (k > 0)
            {
                int min = Int32.MaxValue;
                int t = 0;

                for (int i = 0; i < nums1.Length; i++)
                {
                    if (idx[i] < nums2.Length && nums1[i] + nums2[idx[i]] < min)
                    {
                        t = i;
                        min = nums1[i] + nums2[idx[i]];
                    }
                }

                result.Add (new int [2] {nums1[t], nums2[idx[t]]});
                idx[t]++;
                k --;
            }

            return result;
        }
    }
}    
