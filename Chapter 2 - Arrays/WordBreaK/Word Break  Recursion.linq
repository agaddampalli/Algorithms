<Query Kind="Program" />

void Main()
{
	var s = "aaaab";
	var words = new List<string> {"a", "aa", "aaa", "aaaa"};
	
	WordBreak(s, words).Dump();
}

public bool WordBreak(string s, List<string> wordDict)
{
	var dict = new HashSet<string>(wordDict);
	var memo = new bool?[s.Length];
	return FindWordBreak(s, dict, 0, memo);
}

public bool FindWordBreak(string s, HashSet<string> dict, int start, bool?[] memo)
{
	if(start == s.Length)
	{
		return true;
	}
	
	if(memo[start] != null)
	{
		return memo[start].Value;
	}
	
	for (int i = start+1; i <= s.Length; i++)
	{
		var temp = s.Substring(start, i - start);
		if(dict.Contains(temp) && FindWordBreak(s, dict, i, memo))
		{
			memo[start] = true;
			return true;
		}
	}
	
	memo[start] = false;
	return false;
}
