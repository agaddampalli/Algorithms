<Query Kind="Program" />

void Main()
{
	ReorganizeString("aab").Dump();
}

public string ReorganizeString(string S)
{
	var counts = new int[26];
	
	for (int i = 0; i < S.Length; i++)
	{
		counts[S[i]-'a'] += 100;
	}
	
	for (int i = 0; i < counts.Length; i++)
	{
		counts[i] += i;
	}
	
//	Array.Sort(counts);
	
	var output = new char[S.Length];
	int index = 1;
	for (int i = 0; i < counts.Length; i++)
	{
		int chCount = counts[i]/100;
		
		if(chCount > (S.Length+1)/2)
		{
			return string.Empty;
		}
		
		char ch = (char)('a' + counts[i]%100);
		for (int j = 0; j < chCount; j++)
		{
			if(index >= S.Length)
			{
				index = 0;
			}
			
			output[index] = ch;
			index += 2;
		}
	}
	
	return new String(output);
}
