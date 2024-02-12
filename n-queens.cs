// https://leetcode.cn/problems/n-queens/
// Spent quite some time debugging due to a typo where I called List.Append instead of List.Add.
public class Solution {
  public IList<IList<string>> SolveNQueens(int n) {
    var solutions = new List<List<int>>();
    var stack = new List<int>();
    FindSolutions(0, n, ref stack, ref solutions);
    var ret = new List<IList<string>>();
    for (int i = 0; i < solutions.Count; ++i) {
      var solution = solutions[i];
      var matrix = new List<string>();
      foreach(var pos in solution) {
        var sb = new StringBuilder();
        for (int j = 0; j < n; ++j) {
          sb.Append(j == pos ? 'Q' : '.');
        }
        matrix.Add(sb.ToString());
      }
      ret.Add(matrix);
    }
    return ret;
  }

  private void FindSolutions(int line, int n, ref List<int> stack, ref List<List<int>> solutions) {
    if (line >= n) {
      solutions.Add(new List<int>(stack));
      return;
    }
    for (int i = 0; i < n; ++i) {
      bool canPlace = true;
      for (int j = 0; j < stack.Count; ++j) {
        var k = stack[j];
        if (i == k || i - line == k - j || i + line == k + j) {
          canPlace = false;
          break;
        }
      }
      if (canPlace) {
        stack.Add(i);
        FindSolutions(line + 1, n, ref stack, ref solutions);
        stack.RemoveAt(stack.Count - 1);
      }
    }
  }
}
