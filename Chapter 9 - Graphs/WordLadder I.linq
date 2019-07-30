<Query Kind="Program" />

void Main()
{
	var wordList = new List<string> {"hot","dot","dog","lot","log","cog"};
	
	
	LadderLength("hit", "cog", wordList).Dump();
	
}

public int LadderLength(string beginWord, string endWord, IList<string> wordList)
{
	var hashSet = new HashSet<string>(wordList);

	if(hashSet.Contains(beginWord))
	{
		hashSet.Remove(beginWord);
	}

	if (!hashSet.Contains(endWord))
	{
		return 0;
	}

	var queue = new Queue<string>();
	queue.Enqueue(beginWord);
	int count = 1;
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
					
					if (temp == endWord)
					{
						return count+1;
					}
					
					if (hashSet.Contains(temp))
					{
						queue.Enqueue(temp);
						hashSet.Remove(temp);
					}
				}
				currentWordArray[i] = currentChar;
			}
		}
		
		count++;
	}

	return 0;
}
