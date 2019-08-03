<Query Kind="Program" />

void Main()
{
	GetMaxVowelString("aeibocu").Dump();
}

// Time Complexity: O(N)
// Space complexity: O(N)
public int GetMaxVowelString(string input)
{
	var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};
	
	var start = 0;
	var end = input.Length - 1;
	
	while(start < end)
	{
		if(vowels.Contains(input[start]))
		{
			++start;
		}
		else if(vowels.Contains(input[end]))
		{
			--end;
		}
		else
		{
			break;
		}
	}
	
	if(start >= end)
	{
		return input.Length;
	}
	
	var mid = 0;
	var midList = new List<int>();
	for (int i = start; i <= end; i++)
	{
		if(vowels.Contains(input[i]))
		{
			mid++;
		}
		else if(mid != 0)
		{
			midList.Add(mid);
			mid = 0;
		}
		
	}
	
	end = input.Length - end - 1;
	var result = -1;
	for (int i = 0; i < midList.Count; i++)
	{
		result = Math.Max(result, Math.Max(start+midList[i], end+midList[i]));
	}
	
	return result;
}
