public class Solution {
  public int MinimumRounds(int[] tasks) {
    var counts = tasks.GroupBy(t => t).Select(g => g.Count());
    if (counts.Any(x => x == 1)) return -1;
    return counts.Sum(x => (int)((x + 2) / 3));
  }
}
