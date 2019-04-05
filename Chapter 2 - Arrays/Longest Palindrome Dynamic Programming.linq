<Query Kind="Program" />

void Main()
{
	LongestPalindrome("ccc").Dump();
}

public string LongestPalindrome(string s)
{
	if (string.IsNullOrEmpty(s)) return String.Empty;
	var res = string.Empty;
	var maxLength = 0;
	var booleanArray = new bool[s.Length, s.Length];

	maxLength = 1;
	for (int i = 0; i < s.Length; i++)
	{
		booleanArray[i,i] = true;
	}

	int startIndex = 0;
	for (int i = 0; i < s.Length-1; i++)
	{
		if(s[i] == s[i+1])
		{
			booleanArray[i, i+1] = true;
			maxLength = 2;
			startIndex = i;
		}
	}
	
	//abbaaaaa
	for (int k = 2; k < s.Length; k++)
	{
		for (int i = 0; i+k < s.Length; i++)
		{
			int j = i + k; 
			if( s[i] == s[j] && booleanArray[i+1, j-1])
			{
				booleanArray[i,j] = true;
				if(k>=maxLength)
				{
					maxLength = k + 1;
					startIndex = i;
				}
			}
		}
	}
	
	booleanArray.Dump();
	maxLength.Dump();
	
	return s.Substring(startIndex, maxLength);
}