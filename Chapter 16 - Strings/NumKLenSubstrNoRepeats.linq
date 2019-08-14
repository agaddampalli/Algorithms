<Query Kind="Program" />

void Main()
{
	NumKLenSubstrNoRepeats("home", 5).Dump();
}

public int NumKLenSubstrNoRepeats(string S, int K)
{	
	var output = new List<string>();
	
	for (int i = 0; i + K <= S.Length; i++)
	{
		var charArray = new int[26];
		
		for (int j = i; j-i < K; j++)
		{
			if(charArray[S[j] - 'a'] != 0)
			{
				break;
			}
			
			charArray[S[j] - 'a']++;
			
			if(j - i + 1 == K)
			{
				output.Add(S.Substring(i,j-i));
			}
		}
		
	}
	
	output.Dump();
	
	return output.Count;
}
