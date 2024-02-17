// https://leetcode.cn/problems/longest-word-lcci/

public class Trie {
  public bool isLeaf = false;
  public Dictionary<char, Trie> children = new();
  public void Add(string s) {
    if (s.Length == 0) {
      this.isLeaf = true;
      return;
    }
    if (!this.children.ContainsKey(s[0])) {
      this.children[s[0]] = new Trie();
    }
    this.children[s[0]].Add(s.Substring(1));
  }
}

public class Solution {
  public string LongestWord(string[] words) {
    Trie root = new();
    foreach (string word in words) root.Add(word);
    string longestWord = "";
    foreach (string word in words) {
      HashSet<Trie> set = new();
      set.Add(root);
      bool lastAddSuccess = false;
      foreach (char c in word) {
        HashSet<Trie> newSet = new();
        foreach (Trie trie in set) {
          if (trie.children.ContainsKey(c)) {
            newSet.Add(trie.children[c]);
            if (trie.children[c].isLeaf) {
              lastAddSuccess = newSet.Add(root);
            }
          }
          set = newSet;
        } 
      }
      if (set.Contains(root) && !lastAddSuccess) {
        if (word.Length > longestWord.Length || (word.Length == longestWord.Length && String.Compare(word, longestWord) < 0)) {
          longestWord = word;
        }
      }
    }
    return longestWord;
  }
}
