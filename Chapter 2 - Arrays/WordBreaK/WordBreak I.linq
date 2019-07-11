<Query Kind="Program" />

void Main()
{
	var wordDict = new List<string> { "cat", "cats", "and", "sand", "dog" };

	WordBreak("aaaaaaa", wordDict).Dump();
	WordBreakDP("catsanddog", wordDict).Dump();
}

// False False True True False False True False False True

public bool WordBreak(string s, IList<string> wordDict)
{
	var dict = new HashSet<string>(wordDict);
	int[] visited = new int[s.Length];

	var queue = new Queue<int>();
	queue.Enqueue(0);

	while (queue.Count != 0)
	{
		var start = queue.Dequeue();

		if (visited[start] == 0)
		{
			for (int i = start + 1; i <= s.Length; i++)
			{
				var temp = s.Substring(start, i - start);

				if (dict.Contains(temp))
				{
					if (i == s.Length)
					{
						return true;
					}

					queue.Enqueue(i);
				}
			}
			visited[start] = 1;
		}

	}

	return false;
}

public bool WordBreakDP(string s, IList<string> wordDict)
{
	var dict = new HashSet<string>(wordDict);
	bool[] visited = new bool[s.Length+1];

	var queue = new Queue<int>();
	queue.Enqueue(0);

	visited[0] = true;
	
	for (int i = 1; i <= s.Length; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if(visited[j] && dict.Contains(s.Substring(j, i-j)))
			{
				visited[i] = true;
				break;
			}
		}
	}

	visited.Dump();
	return visited[s.Length];
}
