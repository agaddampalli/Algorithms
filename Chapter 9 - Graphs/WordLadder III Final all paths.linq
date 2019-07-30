<Query Kind="Program" />

void Main()
{
	var wordList = new List<string> { "a", "b", "c", "lot", "log", "cog" };


	FindLadders("a", "c", wordList).Dump();
}

public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
{
	var output = new List<IList<string>>();
	var dictionary = new Dictionary<string, HashSet<string>>();
	var hashSet = new HashSet<string>(wordList);

	if (hashSet.Contains(beginWord))
	{
		hashSet.Remove(beginWord);
	}

	if (!hashSet.Contains(endWord))
	{
		return output;
	}

	var queue = new Queue<string>();
	queue.Enqueue(beginWord);
	while (queue.Count != 0)
	{
		var size = queue.Count;
		for (int k = 0; k < size; k++)
		{
			var currentWord = queue.Dequeue();
			var currentWordArray = currentWord.ToCharArray();
			for (int i = 0; i < currentWordArray.Length; i++)
			{
				var currentChar = currentWordArray[i];
				for (char j = 'a'; j <= 'z'; j++)
				{
					currentWordArray[i] = j;

					var temp = new String(currentWordArray);

					if (hashSet.Contains(temp) && currentWord != temp)
					{
						if (temp != endWord)
						{
							queue.Enqueue(temp);
							hashSet.Remove(temp);
						}

						if (!dictionary.ContainsKey(currentWord))
						{
							dictionary.Add(currentWord, new HashSet<string>());
						}

						dictionary[currentWord].Add(temp);
					}
				}

				currentWordArray[i] = currentChar;
			}
		}
	}

	DFS(beginWord, endWord, new List<string>(), output, dictionary);

	return output;
}

public void DFS(string beginWord, string endWord, List<string> temp, List<IList<string>> output, Dictionary<string, HashSet<string>> graph)
{
	if (beginWord == endWord)
	{
		temp.Add(endWord);
		output.Add(new List<string>(temp));
		temp.Remove(endWord);
		return;
	}

	var list = graph[beginWord].ToList();
	for (int i = 0; i < list.Count; i++)
	{
		temp.Add(beginWord);
		DFS(list[i], endWord, temp, output, graph);
		temp.Remove(beginWord);
	}
}
