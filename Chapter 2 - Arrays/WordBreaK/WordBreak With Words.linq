<Query Kind="Program" />

void Main()
{
	var s = "aaaab";
	var words = new List<string> { "a", "aa", "aaa", "aaaa"};

	WordBreak(s, words).Dump();
}

public List<string> WordBreak(string s, List<string> wordDict)
{
	var dict = new HashSet<string>(wordDict);
	var memo = new bool?[s.Length];
	var res = new List<string>();
	FindWordBreak(s, dict, 0, memo, "",  res);
	return res;
}

public void FindWordBreak(string s, HashSet<string> dict, int start, bool?[] memo, string concat, List<string> res)
{
	if (start == s.Length)
	{
		res.Add(concat.Trim());
		return;
	}

	if (memo[start] != null)
	{
		return;
	}

	for (int i = start + 1; i <= s.Length; i++)
	{
		var temp = s.Substring(start, i - start);
		if (dict.Contains(temp))
		{
			FindWordBreak(s, dict, i, memo, $"{concat} {temp}",res);
			memo[start] = true;
		}
	}

	memo[start] = false;
}
