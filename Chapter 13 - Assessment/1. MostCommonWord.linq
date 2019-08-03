<Query Kind="Program" />

void Main()
{
	var paragraph = "Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball he hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit. ";
	var banned = new string[] { "hit" };

	MostCommonWord(paragraph, banned).Dump();
//	GetWordsFromParagraph(paragraph).Dump();
	GetWordsFromParagraph1(paragraph, new HashSet<string>(banned)).Dump();
}

// Time Complexity: O(P+B)
// Space complexity: O(P+B)
public string MostCommonWord(string paragraph, string[] banned)
{
	if (string.IsNullOrWhiteSpace(paragraph))
	{
		return string.Empty;
	}

	// Building a hashset, to check if the string is present or not will happen in O(1)
	var bannedwordDict = new HashSet<string>(banned); // O(b)
	var commonwordDict = new Dictionary<string, int>();

	var commonwords = GetWordsFromParagraph(paragraph); // O(p)
	int maxLength = 0;
	string maxOccuredWord = string.Empty;

	//O(p)
	foreach (var word in commonwords)
	{
		var lowerCaseWord = word.ToLower();
		if (bannedwordDict.Contains(lowerCaseWord))
		{
			continue;
		}

		if (commonwordDict.ContainsKey(lowerCaseWord))
		{
			commonwordDict[lowerCaseWord]++;
		}
		else
		{
			commonwordDict.Add(lowerCaseWord, 1);
		}

		if (commonwordDict[lowerCaseWord] > maxLength)
		{
			maxLength = commonwordDict[lowerCaseWord];
			maxOccuredWord = lowerCaseWord;
		}
	}

	return maxOccuredWord;
}

private static IEnumerable<string> GetWordsFromParagraph(string paragraph)
{
	var words = new List<string>();
	int startIndex = 0;
	for (int i = 0; i < paragraph.Length; i++)
	{
		if (IsChar(paragraph[i]))
		{
			continue;
		}
		else
		{
			var temp = paragraph.Substring(startIndex, i - startIndex);

			if (!string.IsNullOrWhiteSpace(temp))
			{
				words.Add(temp);
			}
			startIndex = i + 1;
		}
	}

	return words;

}

private static IEnumerable<string> GetWordsFromParagraph1(string paragraph, HashSet<string> bannedWords)
{
	var words = new List<string>();
	var commonwordDict = new Dictionary<string, int>();
	int startIndex = 0;
	int maxLength = 0;
	string maxOccuredWord = string.Empty;
	
	for (int i = 0; i < paragraph.Length; i++)
	{
		if (IsChar(paragraph[i]))
		{
			continue;
		}
		else
		{
			var word = paragraph.Substring(startIndex, i - startIndex);
			var lowerCaseWord = word.ToLower();
			if (!string.IsNullOrWhiteSpace(word) && !bannedWords.Contains(lowerCaseWord) )
			{
				if (commonwordDict.ContainsKey(lowerCaseWord))
				{
					commonwordDict[lowerCaseWord]++;
				}
				else
				{
					commonwordDict.Add(lowerCaseWord, 1);
				}

				if (commonwordDict[lowerCaseWord] > maxLength)
				{
					maxLength = commonwordDict[lowerCaseWord];
					maxOccuredWord = lowerCaseWord;
				}
			}
			startIndex = i + 1;
		}
	}
	
	maxLength.Dump();
	maxOccuredWord.Dump();
	return words;
}

private static bool IsChar(char ch)
{
	return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
}