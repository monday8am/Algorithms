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

        // https://leetcode.com/problems/valid-anagram/
        static bool IsAnagram(string s, string t) 
        {
            if (s.Length != t.Length)
                return false;

            if (s.Length == 0)
                return true;

            Dictionary<string, int> h = new Dictionary<string, int> ();

            for (int i = 0; i < s.Length; i++)
            {
                string c = s.Substring (i,1);                
                if (h.ContainsKey(c))
                    h[c] ++;
                else    
                    h.Add (c, 1);
            }

            for (int i = 0; i < t.Length; i++)
            {
                string c = t.Substring (i, 1);
                if (h.ContainsKey(c))
                {
                    if (h[c] == 1)
                        h.Remove (c);
                    else    
                        h[c] --;
                }
                else
                    return false;
            }

            return true;       
        }

        // https://leetcode.com/problems/first-unique-character-in-a-string/
        static int FirstUniqChar(string s) 
        {
            Dictionary<string, int> hash = new Dictionary<string, int> ();
            Dictionary<string, int> pos = new Dictionary<string, int> ();

            for (int i = 0; i < s.Length; i++)
            {
                string c = s.Substring (i, 1);
                if (hash.ContainsKey (c))
                    hash[c] ++;
                else
                {
                    hash.Add (c, 1);
                    pos.Add (c,i);
                }    
            }

            foreach (var item in hash)
            {
                if (item.Value == 1)
                    return pos[item.Key];
            }

            return -1;
        }

        // https://leetcode.com/problems/ransom-note/
        static bool RansomNote (string ransomNote, string magazine) 
        {
            Dictionary<string, int> hash = new Dictionary<string, int> ();

            for (int i = 0; i < magazine.Length; i++)
            {
                string c = magazine.Substring (i, 1);
                if (hash.ContainsKey (c))
                    hash[c] ++;
                else
                    hash.Add (c, 1);
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                string c = ransomNote.Substring (i, 1);
                if (hash.ContainsKey(c))
                {
                    if (hash[c] == 1)
                        hash.Remove (c);
                    else    
                        hash[c] --;
                }
                else
                    return false;
            }

            return true;
        }

        // https://leetcode.com/problems/longest-palindrome/
        static int LongestPalindrome(string s) 
        {
            int res = 0;
            HashSet<string> hash = new HashSet<string> ();

            for (int i = 0; i < s.Length; i++)
            {
                string c = s.Substring (i, 1);
                if (hash.Contains (c))
                {
                    res += 2;
                    hash.Remove (c);
                }
                else
                {
                    hash.Add (c);
                }
            }

            return res + (hash.Count >= 1 ? 1 : 0);
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
    }
}    