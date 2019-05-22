<Query Kind="Program" />

void Main()
{
	var paragraph = "Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball he hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit.Bob hit a ball the hit BALL flew far after it was hit. ";
	var banned= new string[]{"hit"};
	
	MostCommonWord(paragraph, banned).Dump();
}

public string MostCommonWord(string paragraph, string[] banned)
{
	if (string.IsNullOrWhiteSpace(paragraph))
	{
		return string.Empty;
	}

	var punctuationSet = new HashSet<char> { '!', '?', '\'', ';', '.', ',' };
	var bannedwordDict = new HashSet<string>();
	for (int i = 0; i < banned.Length; i++)
	{
		bannedwordDict.Add(banned[i]);
	}

	var commonwordDict = new Dictionary<string, int>();
	var commonwordArray = paragraph.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
	int maxLength = 0;
	string maxOccuredWord = string.Empty;
	for (int i = 0; i < commonwordArray.Length; i++)
	{
		var word = commonwordArray[i].ToLower();
		if(punctuationSet.Contains(word[word.Length-1]))
		{
			word = word.Substring(0, word.Length-1);
		}
		
		if(!bannedwordDict.Contains(word))
		{
			if(commonwordDict.ContainsKey(word))
			{
				commonwordDict[word]++;
			}
			else
			{
				commonwordDict.Add(word, 1);
			}
			
				
			if(commonwordDict[word] > maxLength)
			{
				maxLength = commonwordDict[word];
				maxOccuredWord = word;
			}
		}
	}
	
	return maxOccuredWord;
}
