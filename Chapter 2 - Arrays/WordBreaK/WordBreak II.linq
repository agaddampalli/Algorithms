<Query Kind="Program" />

void Main()
{
	var wordDict = new List<string> { "cat", "cats", "and", "sand", "dog" };
	WordBreak("catsanddog", wordDict).Dump();
}

public IList<string> WordBreak(string s, IList<string> wordDict)
{
	var dict = new HashSet<string>(wordDict);
	bool[] visited = new bool[s.Length + 1];

	var queue = new Queue<int>();
	queue.Enqueue(0);

	visited[0] = true;

	for (int i = 1; i <= s.Length; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (visited[j] && dict.Contains(s.Substring(j, i - j)))
			{
				visited[i] = true;
				break;
			}
		}
	}

	if(!visited[s.Length])
	{
		return new List<string>();
	}
	
	var dp = new List<string>[s.Length+1];
	dp[0] = new List<string> {""};
	
	for (int i = 1; i <= s.Length; i++)
	{
		var list = new List<string>();
		for (int j = 0; j < i; j++)
		{
			var temp = s.Substring(j, i-j);
			if(dp[j].Any() && dict.Contains(temp))
			{
				var tempList = dp[j];
				
				foreach (var element in tempList)
				{
					var space = string.IsNullOrWhiteSpace(element) ? "" : " ";
					list.Add(element + space + s.Substring(j, i-j));
				}
			}
		}
		
		dp[i] = list;
	}
	
	
	return dp[s.Length];

}
