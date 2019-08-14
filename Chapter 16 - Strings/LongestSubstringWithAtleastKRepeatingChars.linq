<Query Kind="Program" />

void Main()
{
	var s = "aaabb";
	
	LongestSubstringWithAtleastKRepeatingChars(s,2).Dump();
	maxSubString.Dump();
}

/* 
Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.

Input:
s = "aaabb", k = 3

Output:
3

The longest substring is "aaa", as 'a' is repeated 3 times.


Input:
s = "ababbc", k = 2

Output:
5

The longest substring is "ababb", as 'a' is repeated 2 times and 'b' is repeated 3 times.
*/

// bbabba
// abaccbb
//abacccbb
public string maxSubString = null;
public int maxLength = 0;
public int LongestSubstringWithAtleastKRepeatingChars(string s, int k)
{
	if(string.IsNullOrWhiteSpace(s) || k == 0)
	{
		return 0;
	}
	
	var chars = new int[26];
	
	for (int i = 0; i < s.Length; i++)
	{
		chars[s[i] - 'a']++;
	}

	if(CheckAtleast(chars, k))
	{
		maxSubString = s;
		return s.Length;
	}
	
	var subString = new StringBuilder();
	for (int i = 0; i < s.Length; i++)
	{
		if(chars[s[i] - 'a'] >= k)
		{
			subString.Append(s[i]);
		}
		else
		{
			var max = LongestSubstringWithAtleastKRepeatingChars(subString.ToString(), k);
			if(max >= k && maxLength < max)
			{
				maxLength = max;
				maxSubString = subString.ToString();
			}
			subString.Clear();
		}
	}
	
	if(subString.Length > 0)
	{
		var max = LongestSubstringWithAtleastKRepeatingChars(subString.ToString(), k);
		if (max >= k && maxLength < max)
		{
			maxLength = max;
			maxSubString = subString.ToString();
		}
	}

	return maxLength;
}

public bool CheckAtleast(int[] chars, int k)
{
	for (int i = 0; i < chars.Length; i++)
	{
		if(chars[i] > 0 && chars[i] < k)
		{
			return false;
		}
	}
	return true;
}