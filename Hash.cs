using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Hash
    {
        public Hash ()
        {
            var s = "rat";
            var t = "car";
            Console.WriteLine (IsAnagram (s, t));
        }

        // https://leetcode.com/problems/valid-anagram/
        static bool IsAnagram(string s, string t) 
        {
            if (s.Length != t.Length)
                return false;

            if (s.Length == 0)
                return true;

            HashSet<string> h = new HashSet<string> ();

            for (int i = 0; i < s.Length; i++)
            {
                h.Add (s.Substring (i, 1));
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!h.Contains (t.Substring (i, 1)))
                    return false;
            }

            return true;;
        }
    }
}    