// https://leetcode.cn/problems/coin-lcci/
public class Solution {
  private int WaysToChange51(int n) {
    return n / 5 + 1;
  }
  private Dictionary<int, int> cache1051 = new();
  private int WaysToChange1051(int n) {
    int value = 0;
    if (cache1051.TryGetValue(n, out value)) return value;
    int ways = 0;
    for (int i = 0; i * 10 <= n; ++i) {
      ways += WaysToChange51(n % 10 + i * 10);
      ways %= 1000000007;
      cache1051[n % 10 + i * 10] = ways;
    }
    return ways;
  }

  public int WaysToChange(int n) {
    int ways = 0;
    for (int i = 0; i * 25 <= n; ++i) {
      ways += WaysToChange1051(n - i * 25);
      ways %= 1000000007;
    }
    return ways;
  }
}
