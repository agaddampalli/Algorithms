<Query Kind="Program" />

void Main()
{
	var wordList = new List<string> { "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye"};

	FindLadders("qa", "sq", wordList).Dump();
}

public IList<IList<string>> FindLadders(string beginWord, string endWord, List<string> wordList)
{
	var output = new List<IList<string>>();
	if (wordList.Count == 0)
	{
		return output;
	}

	Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
	
	HashSet<string> wordSet = new HashSet<string>();
	foreach (var element in wordList)
	{
		wordSet.Add(element);
	}
	
	var queue = new Queue<string>();
	queue.Enqueue(beginWord);
	
	var visitedList = new HashSet<string>();
	
	while(queue.Count != 0)
	{
		var vertex = queue.Dequeue();

		if (!vertex.Equals(endWord))
		{
			wordSet.Remove(vertex);
		}
		
		for (int j = 0; j < vertex.Length; j++)
		{
			var vertexChars = vertex.ToCharArray();
			for (char k = 'a'; k < 'z'; k++)
			{
				vertexChars[j] = k;
				var newVertex = new String(vertexChars);
				if(wordSet.Contains(newVertex) && !vertex.Equals(endWord))
				{
					if(!graph.ContainsKey(vertex))
					{
						graph.Add(vertex, new List<string> ());
					}
					
					graph[vertex].Add(newVertex);
					if(!visitedList.Contains(newVertex))
					{
						visitedList.Add(newVertex);
						queue.Enqueue(newVertex);
					}
				}
			}
		}
	}

	graph.Dump();
	DFS(beginWord, endWord, new HashSet<string>(), new List<string> {beginWord}, output, graph);
	
	var minLength = int.MaxValue;
	foreach (var element in output)
	{
		if(element.Count < minLength)
		{
			minLength = element.Count;
		}
	}
	
	var result = new List<IList<string>>();
	foreach (var element in output)
	{
		if(element.Count <= minLength)
		{
			result.Add(element);
		}
	}
	
	return result;
}

public void DFS(string src, string dest, HashSet<string> visited, List<string> currentList, List<IList<string>> result,Dictionary<string, List<string>> graph)
{
	
	if (src.Equals(dest))
	{
		var clonedList = Clone(currentList);
		result.Add(clonedList);
	}
	else
	{
		visited.Add(src);
		if(graph.ContainsKey(src))
		{
			foreach (var element in graph[src])
			{
				if (!visited.Contains(element))
				{
					currentList.Add(element);
					DFS(element, dest, visited, currentList, result, graph);
				}
			}
		}
	}

	visited.Remove(src);
	currentList.Remove(src);
}

public IList<string> Clone(IList<string> listToClone)
{
	return listToClone.Select(item => (string)item).ToList();
}
