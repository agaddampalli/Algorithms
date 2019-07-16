<Query Kind="Program" />

void Main()
{
	CntSubstr("awaglknagawunagwkwagl", 4).Dump();
}

public IList<string> CntSubstr(string str, int k)
{
	int n = str.Length;

	int[] cnt = new int[26];
	
	var output = new HashSet<string>();
	
	for (int i = 0; i+k < n; i++)
	{
		Array.Clear(cnt, 0, cnt.Length);
		var temp = string.Empty;
		for (int j = i; j-i < k; j++)
		{
			if (cnt[str[j] - 'a'] == 0)
			{
			   temp = temp + str[j];
			}
			else
			{
				break;
			}
			
			// Increment count of current character 
			cnt[str[j] - 'a']++;

			// If distinct character count becomes k, 
			// then increment result. 
			if (temp.Length == k && !output.Contains(temp))
			{
				output.Add(temp);
			}
		}
	}

	return output.ToList();
}