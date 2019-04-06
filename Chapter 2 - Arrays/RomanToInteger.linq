<Query Kind="Program" />

void Main()
{
	RomanToInt("XXVII").Dump();
}

public int RomanToInt(string s)
{
	if(string.IsNullOrWhiteSpace(s))
	{
		return 0;
	}

	var romanDictionary = new Dictionary<string, int>{
		{"I", 1},
		{"V", 5},
		{"X", 10},
		{"L", 50},
		{"C", 100},
		{"D", 500},
		{"M", 1000},
		{"IV", 4},
		{"IX", 9},
		{"XL", 40},
		{"XC", 90},
		{"CD", 400},
		{"CM", 900},
	};

	int output = 0;
	int i =0;
	while(i < s.Length)
	{
		if(s[i] == 'I' || s[i] == 'X' || s[i] == 'C')
		{
			var subString = i+1 < s.Length ? s.Substring(i,2) : null;
			if(subString != null && romanDictionary.ContainsKey(subString))
			{
				output = output + romanDictionary[subString];
				i++;
			}
			else
			{
				output = output + romanDictionary[s[i].ToString()];
			}
		}
		else
		{
			output = output + romanDictionary[s[i].ToString()];
		}
		
		i++;
	}
	
	return output;
}
