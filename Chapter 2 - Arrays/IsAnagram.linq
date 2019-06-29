<Query Kind="Program" />

void Main()
{
	IsAnagram("a", "a").Dump();
}

public bool IsAnagram(string s, string t)
{
	if(s.Length != t.Length)
	{
		return false;
	}
	
	var hashset = new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199};
	
	int sSum = 0;
	for (int i = 0; i < s.Length; i++)
	{
		sSum += hashset[s[i] - 'a'];
	}


	int tSum = 0;
	for (int i = 0; i < s.Length; i++)
	{
		tSum += hashset[t[i] - 'a'];
	}
	
	return sSum == tSum;
}
