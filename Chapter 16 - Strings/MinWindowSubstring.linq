<Query Kind="Program" />

void Main()
{
	var s =  "ADOBECODEBANC";
	var t = "ABC";
	
	MinWindow(s,t).Dump();
}

// ACDBACTG
public string MinWindow(string s, string t)
{
	s = s.ToLower();
	t = t.ToLower();
	
	var chars = new int[26];
	
	for (int i = 0; i < t.Length; i++)
	{
		chars[t[i] - 'a']++;
	}
	
	var start = 0;
	var index = 0;
	var minLength = int.MaxValue;
	var count  = 0;
	var result = string.Empty;
	while(index < s.Length)
	{
		if(--chars[s[index] - 'a'] >= 0)
		{
			count++;
		}
		
		while(count == t.Length)
		{
			if(minLength > index-start+1)
			{
				minLength = index-start+1;
				result = s.Substring(start, minLength);
			}
			
			if(++chars[s[start] - 'a'] > 0)
			{
				--count;
			}

			++start;
		}

		index++;
	}

	return result;
}
