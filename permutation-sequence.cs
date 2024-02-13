// https://leetcode.cn/problems/permutation-sequence/

public class Solution {
  public string GetPermutation(int n, int k) {
    if (n == 1) return "1";
    int f = Factorial(n - 1);
    char prefix = (char)((k - 1) / f + '1');
    string suffix = GetPermutation(n - 1, (k + f - 1) % f + 1);
    var sb = new StringBuilder();
    sb.Append(prefix);
    foreach (char c in suffix) {
      sb.Append(c >= prefix ? (char)(c + 1) : c);
    }
    return sb.ToString();
  }

  private int Factorial(int n) {
    int f = 1;
    for (int i = 2; i <= n; ++i) f *= i;
    return f;
  }
}
