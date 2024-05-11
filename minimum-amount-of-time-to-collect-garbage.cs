public class Solution {
  public int GarbageCollection(string[] garbage, int[] travel) {
    return garbage.Sum(s => s.Length) + "MPG".Select(c => garbage.ToList().FindLastIndex(s => s.Contains(c))).Where(i => i > 0).Select(i => travel.ToList().GetRange(0, i).Sum()).Sum();
  }
}
