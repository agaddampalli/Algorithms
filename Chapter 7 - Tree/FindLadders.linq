<Query Kind="Program" />

void Main()
{
	var beginWord = "hit";
	var endWord = "cog";
	var wordList = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };

	FindLadders(beginWord, endWord, wordList).Dump();
}


public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
{
	var output = new List<IList<string>>();

	if (!wordList.Any())
	{
		return output;
	}

	var beginword = new char[128];
	for (int i = 0; i < beginWord.Length; i++)
	{
		(beginword[beginWord[i]])++;
	}
	
	var wordDictionary = new Dictionary<string, char[]>();
	wordDictionary = GenerateWordDictionary(wordList, wordDictionary);

	if (!wordDictionary.ContainsKey(endWord))
	{
		return output;
	}

	var hashMap = new Dictionary<string, List<string>>();
	while(wordDictionary.Count != 0)
	{
		var element = wordDictionary.First();
		hashMap.Add(element.Key, FindOneDifferenceWord(wordDictionary[element.Key], wordDictionary));
		wordDictionary.Remove(element.Key);
	}

hashMap.Dump();
	var temp = new List<string>() {beginWord};
	DFS(output, temp, beginWord, endWord, hashMap);

	return output;
}

public void DFS(List<IList<String>> result, List<String> temp, string start, string end, Dictionary<String, List<String>> hs)
{
	//we will use DFS, more specifically backtracking to build paths

	//boundary case
	if (start.Equals(end))
	{
		result.Add(new List<String>(temp));
		return;
	}

	//not each node in hs is valid node in shortest path, if we found current node does not have children node,
	//then it means it is not in shortest path
	if (!hs.ContainsKey(start))
	{
		return;
	}

	foreach (var element in hs)
	{
		temp.Add(element.Key);
		DFS(result, temp, element.Key, end, hs);
		temp.Remove(temp.Last());
	}
}

public List<string> FindOneDifferenceWord(char[] beginWord, Dictionary<string, char[]> wordDictionary)
{
	var output = new List<string>();

	foreach (var element in wordDictionary)
	{
		if (Compare(beginWord, element.Value))
		{
			output.Add(element.Key);
		}
	}

	return output;
}

public bool Compare(char[] beginWord, char[] endWord)
{
	int count = 0;
	for (int i = 0; i < beginWord.Length; i++)
	{
		if (beginWord[i] != endWord[i])
		{
			if (count < 3)
			{
				count++;
			}
			else
			{
				return false;
			}
		}
	}

	return count == 2;
}

public Dictionary<string, char[]> GenerateWordDictionary(IList<string> wordList, Dictionary<string, char[]> wordDictionary)
{
	for (int i = 0; i < wordList.Count; i++)
	{
		wordDictionary.Add(wordList[i], GenerateCharArray(wordList[i]));
	}

	return wordDictionary;
}

public char[] GenerateCharArray(string word)
{
	var wordArray = new char[128];
	for (int i = 0; i < word.Length; i++)
	{
		(wordArray[word[i]])++;
	}

	return wordArray;
}