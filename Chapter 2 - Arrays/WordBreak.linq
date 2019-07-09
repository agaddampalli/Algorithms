<Query Kind="Program" />

void Main()
{
	var wordDict = new List<string>() {"leet", "code"};
	
	WordBreak("leetcode", wordDict).Dump();
}

public bool WordBreak(string s, IList<string> wordDict)
{
	var hashSet = new HashSet<string>();
	foreach (var element in wordDict)
	{
		hashSet.Add(element);
	}
	
	var memo = new bool[s.Length];
	return FindWordBreak(s, hashSet, 0,memo);
}


public bool FindWordBreak(string s,HashSet<string> wordDict, int start, bool[] memo)
{
	if(start == s.Length)
	{
		return true;
	}
	
	if(memo[start])
	{
		return memo[start];
	}
	
	for (int i = start+1; i <= s.Length; i++)
	{
		var subString = s.Substring(start,i-start);
		
		if(wordDict.Contains(subString) && FindWordBreak(s, wordDict, i, memo))
		{
			memo[start] = true;
			return true;
		}
	}
	
	return false;
}