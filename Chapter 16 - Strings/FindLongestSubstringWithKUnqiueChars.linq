<Query Kind="Program" />

void Main()
{
	var str = "abcbbbbcccbdddadddddddd";
	
	FindLongestSubstringWithKUnqiueChars(str, 2).Dump();
	
}

public string FindLongestSubstringWithKUnqiueChars(string s, int k)
{
	int start = 0;
	int index = 0;
	int startIndex = start;
	int maxLength = int.MinValue;
	var hashset = new Dictionary<char, int>();
	
	while(index < s.Length)
	{
		if(!hashset.ContainsKey(s[index]) && hashset.Count == k)
		{
			if(maxLength < index - start + 1)
			{
				maxLength = index-start+1;
				startIndex = start;
			}
			
			var currentIndex = hashset[s[start]];
			while(start != currentIndex+1)
			{
				if(hashset.ContainsKey(s[start]))
				{
					hashset.Remove(s[start]);
				}
				else
				{
					start = currentIndex+1;
					break;
				}
				start++;
			}
		}
		else
		{
			if(!hashset.ContainsKey(s[index]))
			{
				hashset.Add(s[index], index);
			}
			else
			{
				hashset[s[index]]= index;
			}
			
			index++;
		}
	}
	
	if(maxLength < index - start + 1)
	{
		maxLength = index - start + 1;
		startIndex = start;
	}
	
	return s.Substring(startIndex, maxLength - 1);
}
