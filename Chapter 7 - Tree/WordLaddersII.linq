<Query Kind="Program" />

void Main()
{
	var wordList = new List<string> {"hot","dot","dog","lot","log","cog"};
	
	FindLadders("hit", "cog", wordList).Dump();
}

public List<IList<string>> FindLadders(string start, string end, List<string> wordList)
{
	var output = new List<IList<string>>();
	if (wordList.Count == 0)
	{
		return output;
	}

	Dictionary<string, List<string>> prevNodes = new Dictionary<string, List<string>>();
	HashSet<string> wordSet = new HashSet<string>();
	foreach (var element in wordList)
	{
		wordSet.Add(element);
	}
	
	
	Queue<string> queue = new Queue<string>();
	queue.Enqueue(start);
	wordSet.Remove(start);
	bool found = false;

	while (queue.Any() && !found)
	{

		HashSet<string> visited = new HashSet<string>();
		int qSize = queue.Count();
		for (int i = 0; i < qSize; i++)
		{
			string str = queue.Dequeue();
			for (int j = 0; j < str.Length; j++)
			{
				char[] strArr = str.ToCharArray();
				for (char c = 'a'; c <= 'z'; c++)
				{
					strArr[j] = c;
					string nextStr = new String(strArr);

					if (wordSet.Contains(nextStr))
					{
						if (!prevNodes.ContainsKey(nextStr))
						{
							prevNodes.Add(nextStr, new List<string>());
						}
						prevNodes[nextStr].Add(str);

						if (visited.Add(nextStr))
						{
							queue.Enqueue(nextStr);
						}
					}

					if (nextStr.Equals(end))
					{
						found = true;
					}
				}
			}
		} // end of this level
		
		foreach (var element in visited)
		{
			wordSet.Remove(element);
		}
		
	} // end of BFS

	prevNodes.Dump();
	// BackTracing the path 
	dfs(start, end, new List<string> {}, prevNodes,  output);
	return output;
}

void dfs(String s, String e, List<string> cur, Dictionary<String, List<string>> next, List<IList<String>> res)
{
	cur.Add(s);
	if (s.Equals(e)) res.Add(cur);
	else
	{
		foreach (var element in next)
		{
			dfs(element.Key, e, cur, next, res);
		}
	}
	
	cur.RemoveAt(cur.Count() - 1);
}


private void helper(string start, string end, Dictionary<string, List<string>> prevNodes,
					List<string> path, List<IList<string>> ans)
{

	if (end.Equals(start))
	{
		ans.Add(path);
		return;
	}

	if (!prevNodes.ContainsKey(end))
	{
		return;
	}

	foreach (var element in prevNodes)
	{
		path.Add(element.Key);
		prevNodes.Remove(element.Key);
		helper(start, end, prevNodes, path, ans);
		path.RemoveAt(path.Count -1);
	}
}