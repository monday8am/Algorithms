using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class BinarySearchTree
    {  
        public BinarySearchTree ()
        {
            var root = new TreeNode (1);
            root.left = new TreeNode (2);
            root.right = new TreeNode (2);
            root.left.left = new TreeNode (5);
            root.left.right = new TreeNode (4);
            root.right.left = new TreeNode (4);
            root.right.right = new TreeNode (5);
                        
            /*
            var root = new TreeNode (5);
            InsertNode (root, new TreeNode (4));
            InsertNode (root, new TreeNode (8));
            InsertNode (root, new TreeNode (11));
            InsertNode (root, new TreeNode (13));
            InsertNode (root, new TreeNode (4));
            InsertNode (root, new TreeNode (7));
            InsertNode (root, new TreeNode (2));            
            InsertNode (root, new TreeNode (5));                                    
            InsertNode (root, new TreeNode (1)); 
            */                                   

            Console.WriteLine (IsSymmetric (root));       
        }

        // https://leetcode.com/problems/symmetric-tree/
        static bool IsSymmetric (TreeNode root)
        {
            if (root == null)
                return true;

            return AreNodeSymmetric (root, root);
        }

        static bool AreNodeSymmetric (TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;

            if (left.right != null && right.left != null)
            {
                if (left.right.val != right.left.val) 
                    return false;
            }
            else if (left.right != null || right.left != null)
            {
                return false;
            }

            if (left.left != null && right.right != null)
            {
                if (left.left.val != right.right.val)
                    return false;
            }
            else if (left.left != null || right.right != null)
            {
                return false;
            }

            return AreNodeSymmetric (left.left, right.right) && AreNodeSymmetric (left.right, right.left);
        }

        // https://leetcode.com/problems/same-tree/
        // http://www.programcreek.com/2012/12/check-if-two-trees-are-same-or-not/        
        static bool IsSameTreeRec (TreeNode p, TreeNode q) 
        {
            if (p==null && q==null)
            {
                return true;
            }
            else if (p==null || q==null)
            {
                return false;
            }
        
            if (p.val == q.val) 
            {
                return IsSameTreeRec (p.left, q.left) && IsSameTreeRec(p.right, q.right);
            }
            else
            {
                return false;
            }
        }

        // https://leetcode.com/problems/same-tree/
        static bool IsSameTree (TreeNode p, TreeNode q)
        {
           if (p == null || q == null)
           {
               return p == null && q == null;
           }

           Stack<TreeNode> stack1 = new Stack<TreeNode> ();
           Stack<TreeNode> stack2 = new Stack<TreeNode> ();
           
           stack1.Push (p);
           stack2.Push (q);

           while (stack1.Count > 0)
           {
                TreeNode current1 = stack1.Pop ();
                TreeNode current2 = stack2.Pop ();

                if ((current1.left == null && current2.left != null) ||
                    (current2.left == null && current1.left != null) || 
                    (current1.right == null && current2.right != null) || 
                    (current2.right == null && current1.right != null)
                    )
                {
                    return false;
                }

                if (current1 != null)
                {
                    if (current1.val != current2.val)
                        return false;
                }

                if (current1.left != null)
                {
                    stack1.Push (current1.left);
                    stack2.Push (current2.left);
                }    

                if (current1.right != null)
                {
                    stack1.Push (current1.right);
                    stack2.Push (current2.right);
                }  
 
           }

           if (stack2.Count > 0)
              return false;

           return true;            
        }


        // https://leetcode.com/problems/binary-tree-paths/
        static IList<string> BinaryTreePaths (TreeNode root)
        {
            IList<string> r = new List<string> ();
            if (root == null)
                return r;

            Queue<TreeNode> nodes = new Queue<TreeNode> ();
            Queue<string> paths = new Queue<string> ();

            nodes.Enqueue (root);
            paths.Enqueue (root.val.ToString ());

            while (!(nodes.Count == 0))
            {
                TreeNode curr = nodes.Dequeue ();
                string path = paths.Dequeue ();

                if (curr.left == null && curr.right == null)
                {
                    r.Add (path);
                }

                if (curr.left != null)
                {
                    nodes.Enqueue (curr.left);                    
                    string leftPath = path + "->" + curr.left.val.ToString ();
                    paths.Enqueue (leftPath);                      
                }    

                if (curr.right != null)
                {
                    nodes.Enqueue (curr.right);
                    string rightPath  = path + "->" + curr.right.val.ToString ();
                    paths.Enqueue (rightPath);                  
                }                
            }   

            return r;           
        }

        // https://leetcode.com/problems/path-sum-ii/
        static IList<IList<int>> HasPathSumI (TreeNode root, int sum)
        {
            IList<IList<int>> r = new List<IList<int>> ();
            if (root == null)
                return r;

            Queue<TreeNode> nodes = new Queue<TreeNode> ();
            Queue<int> values = new Queue<int> ();
            Queue<List<int>> arrays = new Queue<List<int>> ();

            nodes.Enqueue (root);
            values.Enqueue (root.val);
            arrays.Enqueue (new List<int> {root.val});
            int val = root.val;
            List<int> l;

            while (!(nodes.Count == 0))
            {
                TreeNode curr = nodes.Dequeue ();
                val = values.Dequeue ();
                l = arrays.Dequeue ();

                if (curr.left == null && curr.right == null)
                {
                    if (val == sum)
                        r.Add (new List<int> (l));
                }

                if (curr.left != null)
                {
                    nodes.Enqueue (curr.left);                    
                    values.Enqueue (val + curr.left.val);
                    List<int> newList = new List<int> (l);
                    newList.Add (curr.left.val);
                    arrays.Enqueue (newList);                      
                }    

                if (curr.right != null)
                {
                    nodes.Enqueue (curr.right);
                    values.Enqueue (val + curr.right.val);
                    l.Add (curr.right.val);
                    arrays.Enqueue (l);                
                }                
            }   

            return r;
        }

        // http://javabeat.net/binary-search-tree-traversal-java/
        static int FindMaximumValue (TreeNode root)
        {
            if (root == null)
                return 0;

            TreeNode current = root;
            while (current.right != null)
                current = current.right; 

            return current.val;       
        }

        // http://javabeat.net/binary-search-tree-traversal-java/
        static int FindMinimunValue (TreeNode root)
        {
            if (root == null)
                return 0;

            TreeNode current = root;
            while (current.left != null)
                current = current.left;

            return current.val;
        }

        // http://javabeat.net/binary-search-tree-traversal-java/
        static void InsertNode (TreeNode root, TreeNode node)
        {
            if (root == null)
            {
                root = node;
                return;
            }

            if (node.val > root.val)
            {
                if (root.right == null)
                    root.right = node;
                else
                    InsertNode (root.right, node);    
            }
            else
            {
                if (root.left == null)
                    root.left = node;
                else
                    InsertNode (root.left, node);   
            }
        }

        // http://www.programcreek.com/2012/12/leetcode-solution-of-iterative-binary-tree-postorder-traversal-in-java/
        static List<int> PostorderTraversal(TreeNode root)
        {
            List<int> r = new List<int> ();
            
            if (root == null)
                return r;

           Stack<TreeNode> stack = new Stack<TreeNode> ();
           stack.Push (root);


           while (stack.Count > 0)
           {
               TreeNode tmp = stack.Peek ();
               if (tmp.left == null && tmp.right == null)
               {
                   TreeNode pop = stack.Pop ();
                   r.Add (pop.val);
               }
               else 
               {
                   if (tmp.right != null)
                   {
                       stack.Push (tmp.right);
                       tmp.right = null;
                   }
                   
                   if (tmp.left != null)
                   {
                       stack.Push (tmp.left);
                       tmp.left = null;
                   }
               }
           }           

           return r;                
        }

        // http://www.programcreek.com/2012/12/leetcode-solution-of-binary-tree-inorder-traversal-in-java/
        static List<int> InOrderTraversal (TreeNode root)
        {
             List<int> r = new List<int> ();

           Stack<TreeNode> stack = new Stack<TreeNode> ();
           stack.Push (root);

           while (stack.Count > 0)
           {
                TreeNode top = stack.Peek ();

                if (top.left != null)
                {
                    stack.Push (top.left);
                    top.left = null;
                }  
                else 
                {
                    r.Add (top.val);
                    stack.Pop ();
                    if (top.right != null)
                        stack.Push (top.right);
                }           
           }

           return r;                     
        }

        // http://www.programcreek.com/2012/12/leetcode-solution-for-binary-tree-preorder-traversal-in-java/
        static List<int> PreorderTraversal (TreeNode root)
        {
           List<int> r = new List<int> ();

           Stack<TreeNode> stack = new Stack<TreeNode> ();
           stack.Push (root);

           while (stack.Count > 0)
           {
                TreeNode current = stack.Pop ();
                r.Add (current.val);

                if (current.right != null)
                {
                    stack.Push (current.right);
                }  

                if (current.left != null)
                {
                    stack.Push (current.left);
                }              
           }

           return r;
        }       

        // https://leetcode.com/problems/path-sum/
        static bool HasPathSum (TreeNode root, int sum)
        {
            if (root == null)
                return false;

            Queue<TreeNode> nodes = new Queue<TreeNode> ();
            Queue<int> values = new Queue<int> ();
            
            nodes.Enqueue (root);
            values.Enqueue (root.val);
            int val = root.val;

            while (!(nodes.Count == 0))
            {
                TreeNode curr = nodes.Dequeue ();
                val = values.Dequeue ();
               
               if (curr.left == null && curr.right == null && val == sum)
               {
                    return true;
               }

                if (curr.left != null)
                {
                    nodes.Enqueue (curr.left);                    
                    values.Enqueue (val + curr.left.val);
                }    

                if (curr.right != null)
                {
                    nodes.Enqueue (curr.right);
                    values.Enqueue (val + curr.right.val);
                }                
            }   

            return false;
        }
        
        // https://dzone.com/articles/depth-first-search-c
        static bool DepthFirstSearch (TreeNode node, int num)
        {
            Stack<TreeNode> stack = new Stack<TreeNode> ();
            stack.Push (node);
            TreeNode current;

            while (stack.Count > 0)
            {
                current = stack.Pop ();
                if (current.val == num)
                {
                    return true;
                }
                else
                {
                    if (current.left != null)
                        stack.Push(current.left);

                    if (current.right != null)    
                        stack.Push(current.right);
                }
            }
            return false;
        }

        // http://www.programcreek.com/2013/02/leetcode-balanced-binary-tree-java/
        static bool IsBalancedRecursive(TreeNode root) 
        {
            if (root == null)
                return true;
    
            if (getHeight(root) == -1)
                return false;
    
            return true;
	    }

        static int getHeight (TreeNode root)
        {
            if (root == null)
                return 0;
    
            int left = getHeight(root.left);
            int right = getHeight(root.right);
    
            if (left == -1 || right == -1)
                return -1;
    
            if (Math.Abs(left - right) > 1) {
                return -1;
            }
    
            return Math.Max(left, right) + 1;
        }

        // https://leetcode.com/problems/maximum-depth-of-binary-tree/
        static int MaxDepth (TreeNode root)
        {
            if (root == null)
                return 0;

            Queue<TreeNode> nodes = new Queue<TreeNode> ();
            Queue<int> counts = new Queue<int> ();
            
            nodes.Enqueue (root);
            counts.Enqueue (1);
            int count = 1;

            while (!(nodes.Count == 0))
            {
                TreeNode curr = nodes.Dequeue ();
                count = counts.Dequeue ();

                if (curr.left != null)
                {
                    nodes.Enqueue (curr.left);
                    counts.Enqueue (count + 1);
                }    

                if (curr.right != null)
                {
                    nodes.Enqueue (curr.right);
                    counts.Enqueue (count + 1);
                }                
            }   

            return count;
        }

        static int MinDepth (TreeNode root)
        {
            if (root == null)
                return 0;

            Queue<TreeNode> nodes = new Queue<TreeNode> ();
            Queue<int> counts = new Queue<int> ();

            nodes.Enqueue (root);
            counts.Enqueue (1);

            while (!(nodes.Count == 0))
            {
                TreeNode curr = nodes.Dequeue ();
                int count = counts.Dequeue ();

                if (curr.left == null && curr.right == null)
                    return count;

                if (curr.left != null)
                {
                    nodes.Enqueue (curr.left);
                    counts.Enqueue (count + 1);
                }    

                if (curr.right != null)
                {
                    nodes.Enqueue (curr.right);
                    counts.Enqueue (count + 1);
                }                
            }    

            return 0; 
        }

        static int FindMinimunDepth (TreeNode root)
        {
            if (root == null)
                return 0;

            if (root.left == null || root.right == null)
                return 1;

            if (root.left == null)
                return FindMinimunDepth (root.right) + 1;

            if (root.right == null)
                return FindMinimunDepth (root.left) + 1;

            return Math.Min (FindMinimunDepth (root.right), FindMinimunDepth(root.left)) + 1;                 
        }
    

        static List<List<int>> LevelOrder (TreeNode root)
        {
            List<List<int>> al = new List<List<int>>();
            List<int> nodeValues = new List<int>();

            if (root == null)
                return al;

            Queue<TreeNode> current = new Queue<TreeNode>();
            Queue<TreeNode> next = new Queue<TreeNode>();
            current.Enqueue(root);

            while(current.Count > 0) 
            {
                TreeNode node = current.Dequeue();

                if (node.left != null)
                    next.Enqueue(node.left);

                if (node.right != null)
                    next.Enqueue(node.right);

                nodeValues.Add(node.val);

                if(current.Count == 0){
                    current = next;
                    next = new Queue<TreeNode>();
                    al.Add (nodeValues);
                    nodeValues = new List<int>();
                }

            }

            return al;
        } 

        public class TreeNode 
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        } 

    }   
  
}    