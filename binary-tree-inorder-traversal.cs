// https://leetcode.cn/problems/binary-tree-inorder-traversal/description/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        if (root == null) return result;  // NOTE: Object can be null.
        if (root.left != null) {
            result.AddRange(InorderTraversal(root.left));
        }
        result.Add(root.val);
        if (root.right != null) {
            result.AddRange(InorderTraversal(root.right));
        }
        return result;
    }
}
