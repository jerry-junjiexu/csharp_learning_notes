// https://leetcode.cn/problems/text-justification/

public class Solution {
  public IList<string> FullJustify(string[] words, int maxWidth) {
    var result = new List<string>();
    var lineBuf = new List<string>();
    int minLineLength = 0;
    foreach (string word in words) {
      int newMinLineLength = minLineLength + word.Length + (lineBuf.Count == 0 ? 0 : 1);
      if (newMinLineLength > maxWidth) {
        result.Add(FormatLine(lineBuf, maxWidth, false));
        lineBuf.Clear();
        newMinLineLength = word.Length;
      }
      minLineLength = newMinLineLength;
      lineBuf.Add(word);
    }
    if (lineBuf.Count > 0) {
      result.Add(FormatLine(lineBuf, maxWidth, true));
    }
    return result;
  }

  private string FormatLine(List<string> words, int maxWidth, bool isLastLine) {
    var sb = new StringBuilder();
    if (isLastLine || words.Count == 1) {
      sb.Append(string.Join(' ', words));
      sb.Append(' ', maxWidth - sb.Length);
    } else {
      int nSeparators = words.Count - 1;
      int nSpaces = maxWidth - words.Aggregate(0,
                                              (sum, word) => sum + word.Length,
                                              sum => sum);
      foreach (string word in words) {
        sb.Append(word);
        if (nSeparators > 0) {
          int spacesToAppend = (nSpaces + nSeparators - 1) / nSeparators;
          sb.Append(' ', spacesToAppend);
          nSeparators -= 1;
          nSpaces -= spacesToAppend;
        }
      }
    }
    return sb.ToString();
  }
}
