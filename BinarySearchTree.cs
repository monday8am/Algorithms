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
            root.right = new TreeNode (3);                                 
            root.left.left = new TreeNode (4);
            root.left.right = new TreeNode (5);
            root.left.left.left = new TreeNode (6);

            Console.WriteLine (IsBalanced (root));
            Console.WriteLine (IsBalancedRecursive (root));
            
        }

        // https://leetcode.com/problems/symmetric-tree/
        

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

        static bool IsBalanced (TreeNode root)
        {
            if (root == null)
                return true;

            Queue<TreeNode> nodes = new Queue<TreeNode> ();
            Queue<int> counts = new Queue<int> ();
            
            nodes.Enqueue (root);
            counts.Enqueue (1);
            int count = 1;
            int max = Int32.MinValue;
            int min = Int32.MaxValue; 

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

                min = Math.Min (min, count);
                max = Math.Max (max, count);                              
            }   

            return (max - min) <= 1;    
        }

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
    

        static int CountTreeNodes (TreeNode root)
        {
            
            return 0;
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