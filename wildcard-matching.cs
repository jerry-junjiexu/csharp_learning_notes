// https://leetcode.cn/problems/wildcard-matching/
public class Solution {
    public bool IsMatch(string s, string p) {
        if (s.Length == 0) {
            return p.All(ch => ch == '*');
        }
        if (p.Length == 0) return false;
        List<int> lastMatchLengths = new List<int>(){0};
        for (int i = 0; i < p.Length; ++i) {
            List<int> newMatchLengths = new List<int>();
            foreach (var lastMatchLength in lastMatchLengths) {
                char pChar = p[i];
                if (pChar == '*') {
                    for (int j = lastMatchLength; j <= s.Length; ++j) {
                        newMatchLengths.Add(j);
                    }
                    break;
                } else if (lastMatchLength < s.Length && (pChar == '?' || pChar == s[lastMatchLength])) {
                    newMatchLengths.Add(lastMatchLength + 1);
                }
            }
            lastMatchLengths = newMatchLengths;
        }
        if (lastMatchLengths.Count == 0) return false;
        return lastMatchLengths[lastMatchLengths.Count - 1] == s.Length;
    }
}
