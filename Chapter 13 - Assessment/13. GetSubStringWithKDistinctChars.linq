<Query Kind="Program" />

void Main()
{
	GetSubStringWithKDistinctChars("awaglknagawunagwkwagl",4).Dump();
}

// Time Complexity: O(N * K)
// Space complexity: O(N)
public List<string> GetSubStringWithKDistinctChars(string s, int k)
{
	var hashset = new HashSet<string>();
	
	for (int i = 0; i+k-1 < s.Length; i++)
	{
		var charArray = new int[26];
		for (int j = i; j < i+k; j++)
		{
			if(charArray[s[j] - 'a'] > 0)
			{
				break;
			}
			
			charArray[s[j]-'a']++;
			
			if(j-i +1 == k)
			{
				var temp = s.Substring(i, k);
				if(!hashset.Contains(temp))
				{
					hashset.Add(temp);
				}
			}
		}
	}
	
	return hashset.ToList();
}