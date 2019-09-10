<Query Kind="Program" />

void Main()
{
	var words = new string[] { "z", "z"};

	AlienOrder(words).Dump();
}

public string AlienOrder(string[] words)
{
	if(words == null || !words.Any())
	{
		return string.Empty;
	}
	
	if(words.Length == 1)
	{
		return words[0];
	}
	
	var degree = new Dictionary<char, int>();
	for (int i = 0; i < words.Length; i++)
	{
		for (int j = 0; j < words[i].Length; j++)
		{
			if(!degree.ContainsKey(words[i][j]))
			{
				degree.Add(words[i][j], 0);
			}
		}
	}
	
	var edges = new Dictionary<char, HashSet<char>>();
	for (int i = 0; i < words.Length-1; i++)
	{
		var word1 = words[i];
		var word2 = words[i+1];
		
		var length = Math.Min(word1.Length, word2.Length);
		
		int j = 0;
		for (; j < length; j++)
		{
			if(word1[j] != word2[j])
			{
				break;
			}
		}
		
		if(j < length)
		{
			if (!edges.ContainsKey(word1[j]))
			{
				edges.Add(word1[j], new HashSet<char>());
			}

			if (!edges[word1[j]].Contains(word2[j]))
			{
				edges[word1[j]].Add(word2[j]);
				degree[word2[j]]++;
			}
		}
	}
	
	var queue = new Queue<char>();
	foreach (var element in degree)
	{
		if(element.Value == 0)
		{
			queue.Enqueue(element.Key);
		}
	}
	
	var result = new StringBuilder();
	
	while(queue.Any())
	{
		var top = queue.Dequeue();
		result.Append(top);
		
		if(edges.ContainsKey(top))
		{
			var neighbors = edges[top];
			foreach (var neighbor in neighbors)
			{
				degree[neighbor]--;

				if (degree[neighbor] == 0)
				{
					queue.Enqueue(neighbor);
				}
			}
		}
	}
	
	return result.Length == degree.Count ? result.ToString() : string.Empty;
}