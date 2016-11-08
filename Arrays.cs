using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Arrays
    {
        public Arrays()
        {
            int[] arr = new int[] { 1, 2, 2 };
            int[] arr1 = new int[] { 2, 2 };

            Console.WriteLine (FrequencySort("tree"));
        }

        static int RemoveDuplicates(int[] nums) 
        {
            return 0;
        }

        // https://leetcode.com/problems/sort-characters-by-frequency/
        static string FrequencySort(string s) 
        {
            Dictionary<string, int> hash = new Dictionary<string, int> ();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s.Substring (i, 1);
                if (hash.ContainsKey (c))
                {
                    hash[c] ++;
                }
                else
                {
                    hash.Add (c, 1);
                }
            }

            string res = "";
            while (hash.Count > 0)
            {
                int max = Int32.MinValue;
                string c = "";
                foreach (var item in hash)
                {
                    if (item.Value > max)
                    {
                        max = item.Value;
                        c = item.Key;
                    }
                }

                for (int i = 0; i < max; i++)
                    res += c;

                hash.Remove (c);    
            }

            return res;
        }

        // https://leetcode.com/problems/4sum/
        static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (nums == null || nums.Length < 4)
                return res;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1])
                    continue;

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j != i + 1 && nums[j] == nums[j - 1])
                        continue;

                    int k = j + 1;
                    int l = nums.Length - 1;

                    while (k < l)
                    {
                        if (nums[i] + nums[j] + nums[k] + nums[l] < target)
                        {
                            k++;
                        }
                        else if (nums[i] + nums[j] + nums[k] + nums[l] > target)
                        {
                            l--;
                        }
                        else
                        {
                            List<int> t = new List<int>();
                            t.Add(nums[i]);
                            t.Add(nums[j]);
                            t.Add(nums[k]);
                            t.Add(nums[l]);
                            res.Add(t);

                            k++;
                            l--;

                            while (k < l && nums[l] == nums[l + 1])
                            {
                                l--;
                            }

                            while (k < l && nums[k] == nums[k - 1])
                            {
                                k++;
                            }
                        }


                    }
                }
            }

            return res;
        }

        // https://leetcode.com/problems/subsets-ii/
        static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            SubsetsWithDupUtil(nums, 0, new List<int>(), new HashSet<string>(), res);
            return res;
        }

        static void SubsetsWithDupUtil(int[] nums, int index, List<int> list, HashSet<string> hash, IList<IList<int>> res)
        {
            var str = "";
            foreach (var item in list)
                str += item;

            if (!hash.Contains(str))
            {
                hash.Add(str);
                res.Add(new List<int>(list));
            }

            for (int i = index; i < nums.Length; i++)
            {
                list.Add(nums[i]);
                SubsetsWithDupUtil(nums, i + 1, list, hash, res);
                list.Remove(nums[i]);
            }
        }

        // https://leetcode.com/problems/third-maximum-number/
        static int ThirdMax(int[] nums)
        {
            int[] pool = new int[3];

            for (int i = 0; i < 3; i++)
            {
                pool[i] = Int32.MinValue;

                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == 0)
                    {
                        pool[i] = Math.Max(pool[i], nums[j]);
                    }
                    else if (nums[j] < pool[i - 1])
                    {
                        pool[i] = Math.Max(pool[i], nums[j]);
                    }
                }
            }

            return pool[2] != Int32.MinValue ? pool[2] : pool[0];
        }

        // https://leetcode.com/problems/find-all-duplicates-in-an-array/
        static IList<int> FindDuplicates(int[] nums)
        {
            List<int> res = new List<int>();
            Dictionary<int, int> hash = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hash.ContainsKey(nums[i]))
                {
                    hash[nums[i]]++;
                }
                else
                {
                    hash.Add(nums[i], 1);
                }
            }

            foreach (var item in hash)
            {
                if (item.Value == 2)
                    res.Add(item.Key);
            }

            return res;
        }


        // https://leetcode.com/problems/intersection-of-two-arrays-ii/
        static int[] IntersectArray(int[] nums1, int[] nums2)
        {
            List<int> res = new List<int>();
            Dictionary<int, int> hash = new Dictionary<int, int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!hash.ContainsKey(nums1[i]))
                    hash.Add(nums1[i], 1);
                else
                    hash[nums1[i]]++;
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                int num = nums2[i];
                if (hash.ContainsKey(num))
                {
                    if (hash[num] > 1)
                        hash[num]--;
                    else
                        hash.Remove(num);

                    res.Add(num);
                }
            }

            return res.ToArray();
        }

        // https://leetcode.com/problems/3sum-closest/
        static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            long diff = Int32.MaxValue;
            long _target = Convert.ToInt64(target);
            long res = 0;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int p1 = i + 1;
                int p2 = nums.Length - 1;
                long sum = 0;

                while (p1 != p2)
                {
                    sum = nums[i] + nums[p1] + nums[p2];

                    if (sum > _target)
                        p2--;
                    else if (sum < _target)
                        p1++;
                    else
                    {
                        p2 = p1;
                    }

                    if (Math.Abs(_target - sum) < diff)
                    {
                        diff = Math.Abs(_target - sum);
                        res = sum;
                    }
                }
            }

            return Convert.ToInt32(res);
        }


        // http://blog.gainlo.co/index.php/2016/06/01/subarray-with-given-sum/
        static List<int> SubArrayWithSum(int[] nums, int s)
        {
            List<int> res = new List<int>();
            int sum = 0;
            int p2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (sum >= s && p2 < nums.Length)
                {
                    if (sum == s)
                    {
                        Console.WriteLine("do something!");
                        return res;
                    }

                    sum -= nums[p2];
                    p2++;
                }
            }

            return res;
        }

        // TODO. Wrong solution!
        // https://leetcode.com/problems/3sum/
        static IList<IList<int>> Sum3(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;
            int s = 0;
            IList<IList<int>> res = new List<IList<int>>();
            Dictionary<string, List<int>> hash = new Dictionary<string, List<int>>();

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
                        var list = new List<int> { nums[i], nums[endIndex], nums[startIndex] };
                        list.Sort();
                        string key = "";
                        foreach (var item in list)
                            key += item;

                        if (!hash.ContainsKey(key))
                            hash.Add(key, list);

                        endIndex = startIndex;
                    }
                }
            }

            foreach (var item in hash)
                res.Add(item.Value);

            return res;
        }

        // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        static int FindMin(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            return FindMinUtil(nums, 0, nums.Length - 1);
        }

        static int FindMinUtil(int[] nums, int start, int end)
        {
            if (end - start == 1)
            {
                if (nums[end] < nums[start])
                {
                    return nums[end];
                }

                return nums[0];
            }

            int targetIndex = start + (end - start) / 2;

            if (nums[targetIndex] > nums[0])
                return FindMinUtil(nums, targetIndex, end);
            else
                return FindMinUtil(nums, start, targetIndex);
        }

        // https://leetcode.com/problems/combination-sum/
        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(candidates);

            CombinationSumUtil(candidates, target, 0, new List<int>(), res);

            return res;
        }

        // http://www.programcreek.com/2014/02/leetcode-combination-sum-java/
        // https://leetcode.com/problems/combination-sum/
        static void CombinationSumUtil(int[] candidates, int target, int index, List<int> partialRes,
                                                    IList<IList<int>> res)
        {
            if (target == 0)
            {
                res.Add(new List<int>(partialRes));
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (target < candidates[i])
                    return;
                partialRes.Add(candidates[i]);
                CombinationSumUtil(candidates, target - candidates[i], i, partialRes, res);
                partialRes.Remove(candidates[i]); // Backtracking!   
            }
        }

        // https://leetcode.com/problems/minimum-size-subarray-sum/        
        static int MinSubArray(int s, int[] nums)
        {
            int p1 = 0;
            int sum = 0;
            int min = Int32.MaxValue;

            for (int p2 = 0; p2 < nums.Length; p2++)
            {
                sum += nums[p2];

                while (sum >= s && p1 < nums.Length)
                {
                    min = Math.Min(min, p2 - p1 + 1);
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
            HashSet<int> hash = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!hash.Contains(nums1[i]))
                    hash.Add(nums1[i]);
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                int v = nums2[i];
                if (hash.Contains(v) && !result.Contains(v))
                {
                    result.Add(v);
                }
            }

            int[] arr = new int[result.Count];
            result.CopyTo(arr);

            return arr;
        }


        static int SearchInsertPos(int[] nums, int target)
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