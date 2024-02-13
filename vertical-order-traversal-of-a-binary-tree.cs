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
  public IList<IList<int>> VerticalTraversal(TreeNode root) {
    var valuesByOrder = new SortedDictionary<int, List<Tuple<int, int>>>();
    PreOrderTraverse(root, 0, 0, ref valuesByOrder);
    var ret = new List<IList<int>>();
    foreach (var kvp in valuesByOrder) {
      kvp.Value.Sort();
      var list = new List<int>();
      foreach (var t in kvp.Value) {
        list.Add(t.Item2);
      }
      ret.Add(list);
    }
    return ret;
  }

  private void PreOrderTraverse(TreeNode node, int depth, int order, ref SortedDictionary<int, List<Tuple<int, int>>> valuesByOrder) {
    if (node == null) return;
    if (!valuesByOrder.ContainsKey(order)) {
      valuesByOrder[order] = new List<Tuple<int, int>>();
    }
    valuesByOrder[order].Add(Tuple.Create(depth, node.val));
    PreOrderTraverse(node.left, depth + 1, order - 1, ref valuesByOrder);
    PreOrderTraverse(node.right, depth + 1, order + 1, ref valuesByOrder);
  }
}
