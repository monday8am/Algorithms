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
            Console.WriteLine (ValidParentesis ("()[]{}"));
        }

        // https://leetcode.com/problems/valid-parentheses/
        static bool ValidParentesis (string s)
        {
            Stack<Char> stack = new Stack<Char> ();
            Char c, p;

            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if (c == '{' || 
                    c == '(' || 
                    c == '[')
                    {
                        stack.Push (c);
                    }
                    else
                    {
                       if (stack.Count == 0)
                          return false;

                       p = stack.Pop ();
                       if ((p == '{' && c != '}') || 
                           (p == '[' && c != ']') ||
                           (p == '(' && c != ')'))
                            {
                                return false;
                            } 
                    }    
            }

            return stack.Count == 0;            
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