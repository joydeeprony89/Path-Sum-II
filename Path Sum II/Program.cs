using System;
using System.Collections.Generic;

namespace Path_Sum_II
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(5);
      root.left = new TreeNode(4);
      root.left.left = new TreeNode(11);
      root.left.left.left = new TreeNode(7);
      root.left.left.right = new TreeNode(2);

      root.right = new TreeNode(8);
      root.right.left = new TreeNode(13);
      root.right.right = new TreeNode(4);
      root.right.right.left = new TreeNode(5);
      root.right.right.right = new TreeNode(1);

      Solution s = new Solution();
      var answer = s.PathSum(root, 22);
      foreach (var ans in answer)
        Console.WriteLine(string.Join(",", ans));
    }
  }

  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
      this.val = val;
      this.left = left;
      this.right = right;
    }
  }

  public class Solution
  {
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
      var result = new List<IList<int>>();
      Helper(root, targetSum, 0, new List<int>(), result);

      return result;
    }

    private void Helper(TreeNode root, int targetSum, int currentSum, List<int> temp, List<IList<int>> result)
    {
      // base condition
      if (root == null) return;
      temp.Add(root.val);
      currentSum += root.val;
      if (currentSum == targetSum)
        result.Add(new List<int>(temp));

      Helper(root.left, targetSum, currentSum, temp, result);
      Helper(root.right, targetSum, currentSum, temp, result);
      temp.RemoveAt(temp.Count - 1);
    }
  }
}
