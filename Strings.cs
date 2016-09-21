using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Strings
    {
        public Strings ()
        {
            int[] arr = new int[] {7};
            Console.WriteLine (ReverseString (""));
        }

        // https://leetcode.com/problems/reverse-vowels-of-a-string/
        static string ReverseVowels (string s)
        {
            char[] arr = s.ToCharArray ();
            int p1 = 0;
            int p2 = s.Length - 1;
            
            while (p2 >= p1)
            {
                if (IsVowel (arr[p1]) && IsVowel (arr[p2]))
                {
                    char tmp = arr[p1];
                    arr[p1] = arr[p2];
                    arr[p2] = tmp;

                    p2 --;
                    p1++;
                }
                else if (IsVowel (arr[p1]) && !IsVowel (arr[p2]))
                {
                    p2 --;
                }
                else if (!IsVowel (arr[p1]) && IsVowel (arr[p2]))
                {
                    p1++;
                }
                else
                {
                    p1 ++;
                    p2 --;
                }
            }

            return new string (arr);
        }

        static bool IsVowel (char c)
        {
            if (c == 'a' || c == 'e' || c == 'i'
                || c == 'o' || c == 'u' )
                return true;
            else
                return false;    
        }

        // https://leetcode.com/problems/reverse-string/
        static string ReverseString (string s)
        {
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

            return new string (arr);
        }

        // https://leetcode.com/problems/zigzag-conversion/
        static string ZizagConversion (string s, int numRows) 
        {
            string r = "";
            int index = 0;
            string[] strings = new string[numRows];

            while (index < s.Length)
            {
                for (int i = 0; i < numRows; i++)
                {
                    if (index < s.Length)
                    {
                        strings[i] += s.Substring (index, 1);
                        index ++;
                    }
                }

                if (index < s.Length)
                    strings[numRows/2] += s.Substring (index, 1);

                index++;
            }

            foreach (var item in strings)
            {
                r = r + item;
            }
            
            return r;
        }

        // https://leetcode.com/problems/add-binary/
        static string AddBinary(string a, string b) 
        {
            int len = Math.Max (a.Length, b.Length) + 1;            
            string aZeros = "", bZeros = "";
            string r = "";

            for (int i = len - 1; i >= 0; i--)
            {
                if (a.Length - 1 < i)
                    aZeros = aZeros + "0";

                if (b.Length - 1 < i)
                    bZeros = bZeros + "0";                  
            }

            a = aZeros + a;
            b = bZeros + b;
            
            int carry = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                string s1 = a.Substring (i, 1);
                string s2 = b.Substring (i, 1);
                string r1 = "";

                if (s1 == "0" && s2 == "1" || s1 == "1" && s2 == "0")
                {
                    r1 = (carry == 1) ? "0" : "1";
                }
                else if (s1 == "0" && s2 == "0")
                {
                    r1 = (carry == 1) ? "1" : "0";
                    carry = 0;
                }
                else
                {
                    r1 = (carry == 1) ? "1" : "0";
                    carry = 1;
                }

                r = r1 + r;
            }

            if (r.Substring (0,1) == "0")
                r = r.Substring (1,r.Length - 1);

            return r;
        }

        // 

        static string Multiply(string num1, string num2) 
        {
            return "";
        }

        // https://leetcode.com/problems/plus-one/
        static int[] PlusOne(int[] digits) 
        {
            int carry = 1;
            for (int i = digits.Length - 1; i >=    0; i--)
            {
                int sum = digits[i] + carry;
                if (sum >= 10)
                {
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }

                digits [i] = sum % 10;
            }

            if (carry == 1)
            {
                int[] result = new int[digits.Length + 1];
                Array.Copy (digits, 0, result, 1, digits.Length);
                result[0] = 1;
                return result;
            }
            else
            {
                return digits;
            }
        }


        // https://leetcode.com/problems/remove-element/
        static int RemoveElement(int[] nums, int val) 
        {
            int p1 = 0;

            for (int i = 0; i < nums.Length; i++)
            {       
                if (nums[i] == val)
                {
                    p1++;
                } 
                else 
                {
                    nums[i - p1] = nums[i];
                }
            }

            return nums.Length - p1;
        }

        // https://leetcode.com/problems/rotate-function/
        static int MaxRotateFunction (int[] A)
        {
            long c = Int32.MinValue;
            int[] arr = new int[A.Length];
            Array.Copy (A, arr, A.Length);

            for (int i = 0; i < A.Length; i++)
            {
                long sum = 0;
                int last = arr[A.Length - 1];

                for (int j = A.Length - 1; j > 0; j--)
                {
                    sum += j * arr[j];
                    A[j] = A[j - 1];
                    Console.WriteLine (sum);
                }

                A[0] = last;
                               
                c = Math.Max (c, sum);           
                Array.Copy (A, arr, A.Length);
            }

            return Convert.ToInt32 (c);
        }

        // https://leetcode.com/problems/summary-ranges/
        static IList<string> SummaryRanges (int[] nums)
        {
            int p = -1;
            IList<string> result = new List<string> ();

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] - nums[i] > 1)
                {
                    if (p != -1)
                    {
                        result [result.Count - 1] =  result [result.Count - 1] + "->" + nums[p];
                    }    
                    result.Add (nums[i].ToString ());
                    p = i;                    
                }
            }
            
            return result;
        }


        // https://leetcode.com/problems/pascals-triangle/
        static IList<IList<int>> PascalTriangle(int numRows) 
        {
            IList<IList<int>> t = new List<IList<int>> ();

            for (int i = 0; i < numRows; i++)
            {
                int[] l = new int[i + 1];
                l[0] = 1;
                l[i] = 1;
                
                for (int j = 1; j < i; j++)
                {
                    l[j] = t[i - 1][j - 1] + t[i - 1][j]; 
                }

                t.Add ((IList<int>)new List<int> (l));
            }

            return t;
        }

        // https://leetcode.com/problems/triangle/
        static int TriangleMinTotal (List<List<int>> triangle)
        {
            int[] dp = new int[triangle.Count + 1];

            for (int i = 1; i <= triangle.Count; i++)
            {
                int min = Int32.MaxValue;

                for (int j = 0; j < triangle[i - 1].Count; j++)
                {
                    min = Math.Min (min, triangle[i - 1][j]);
                }

                dp[i] = dp[i - 1] + min;
             }

            return dp[triangle.Count];
        }

        // https://leetcode.com/problems/find-peak-element/
        static int FindPeakElement (int[] nums)
        {
            for (int i = 0; i < nums.Length + 1; i++)
            {
                long left = i > 0 ? nums[i - 1] : Int64.MinValue;
                long right = i < nums.Length - 1 ? nums[i + 1] : Int64.MinValue;

                if (left < nums[i] && nums[i] > right)
                {
                    return i;
                }
            }
            return -1;
        }

        // https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        static int RemoveDuplicates (int[] nums)
        {
            int p1 = 0;
 
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    p1++;
                } 
                else
                {
                    nums[i - p1] = nums[i];
                }
            }

            return (nums.Length - p1);
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