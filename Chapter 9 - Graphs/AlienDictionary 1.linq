<Query Kind="Program" />

void Main()
{
	var words = new string[] { "wrt", "wrf", "er", "ett", "rftt" };

	AlienOrder(words).Dump();
}

public string AlienOrder(string[] words)
{
	if (words.Length == 0)
	{
		return "";
	}

	if (words.Length == 1)
	{
		return words[0];
	}

	Dictionary<char, HashSet<char>> ordering = new Dictionary<char, HashSet<char>>();
	for (int i = 0; i < words.Length - 1; i++)
	{
		String word1 = words[i];
		String word2 = words[i + 1];
		int start = 0;
		int end = Math.Min(word1.Length, word2.Length);
		for (int j = 0; j < word1.Length; j++)
		{
			if (!ordering.ContainsKey(word1[j]))
			{

				ordering.Add(word1[j], new HashSet<char>());
			}
		}

		for (int j = 0; j < word2.Length; j++)
		{
			if (!ordering.ContainsKey(word2[j]))
			{

				ordering.Add(word2[j], new HashSet<char>());
			}
		}

		while (start < end)
		{
			if (word1[start] != word2[start])
			{
				ordering[word2[start]].Add(word1[start]);
				break;
			}
			start++;
		}
	}

	ordering.Dump();
	//HashSet<char> seen = new HashSet<char>();
	StringBuilder sb = new StringBuilder();
	Queue<char> q = new Queue<char>();
	List<char> rem = new List<char>();
	foreach (KeyValuePair<char, HashSet<char>> kv in ordering)
	{
		if (kv.Value.Count == 0)
		{
			q.Enqueue(kv.Key);
			rem.Add(kv.Key);
		}
	}

	foreach (char c in rem)
	{
		ordering.Remove(c);
	}

	while (q.Count > 0)
	{

		rem = new List<char>();
		char temp = q.Dequeue();


		sb.Append(temp);

		foreach (char c in ordering.Keys)
		{
			ordering[c].Remove(temp);
			if (ordering[c].Count == 0)
			{
				rem.Add(c);
				q.Enqueue(c);
			}
		}

		foreach (char c in rem)
		{
			ordering.Remove(c);
		}

	}

	return ordering.Count > 0 ? "" : sb.ToString(); //not all letters used;
}
