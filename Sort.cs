using System;

namespace ConsoleApplication
{
    public class Sort
    {
        public Sort ()
        {
            var nums = new int[] {2,1,2,4,6,8};
            QuickSort (nums, 0, nums.Length - 1);
            Console.WriteLine ("");
        }

        // Insertion sort.


        // Heapsort.


        // Quicksort.
        static void QuickSort (int[] nums, int first, int last)
        {
            int i = first, j = last;
            int p = nums[(first + last)/2];
            int tmp;

            do
            {
                while (nums[i] < p) i++;
                while (nums[j] > p) j--;
                
                if (i <= j)
                {
                    tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (first < j) QuickSort (nums, first, j);
            if (i < last) QuickSort (nums, i, last);
        }

        // Mergesort.
    }
}    