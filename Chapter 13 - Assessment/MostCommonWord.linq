<Query Kind="Program" />

void Main()
{
	var paragraph = "Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball he hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit. ";
	var banned = new string[] { "hit" };

	MostCommonWord(paragraph, banned).Dump();
	GetWordsFromParagraph(paragraph).Dump();
}

public string MostCommonWord(string paragraph, string[] banned)
{
	if (string.IsNullOrWhiteSpace(paragraph))
	{
		return string.Empty;
	}

	var bannedwordDict = new HashSet<string>(banned);
	var commonwordDict = new Dictionary<string, int>();

	var commonwords = GetWordsFromParagraph(paragraph);
	int maxLength = 0;
	string maxOccuredWord = string.Empty;

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

private static bool IsChar(char ch)
{
	return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
}