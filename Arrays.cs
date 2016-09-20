using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Arrays
    {  
        public Arrays ()
        {
            int[] arr = new int[] {1,3,5,6};
            Console.WriteLine (SearchInsertPos (arr, 0));
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