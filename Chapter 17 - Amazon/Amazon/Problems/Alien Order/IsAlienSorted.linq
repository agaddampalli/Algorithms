<Query Kind="Program" />

void Main()
{
	
}

//Time Complexity: O(length of words array * sum of length of each word)
public bool IsAlienSorted(string[] words, string order)
{
	var orderArray = new int[26];
	for (int i = 0; i < order.Length; i++)
	{
		orderArray[order[i]-'a'] = i;
	}
	
	if(words.Length == 1)
	{
		return true;
	}
	
	for (int i = 0; i < words.Length-1; i++)
	{
		var word1 = words[i];
		var word2 = words[i+1];
		
		var length = Math.Min(word1.Length, word2.Length);
		
		for (int j = 0; j < length; j++)
		{
			if(word1[i] != word2[i])
			{
				var ch1 = word1[i] - 'a';
				var ch2 = word2[i] - 'a';
				
				if(orderArray[ch1] > orderArray[ch2])
				{
					return false;
				}
				
				continue;
			}
			
			if(word1.Length > word2.Length)
			{
				return false;
			}
		}
	}
	
	return true;
}
