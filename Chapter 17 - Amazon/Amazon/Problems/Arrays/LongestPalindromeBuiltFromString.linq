<Query Kind="Program" />

void Main()
{
	LongestPalindrome("aaaaa").Dump();
}

//https://leetcode.com/problems/longest-palindrome/
public int LongestPalindrome(string s)
{
	var temp = new int[128];
	
	for (int i = 0; i < s.Length; i++)
	{
		temp[s[i]]++;
	}
	
	bool foundOne = false;
	int count = 0;
	for (int i = 0; i < temp.Length; i++)
	{
		if(!foundOne && temp[i] == 1)
		{
			foundOne = true;
			count++;
		}
		else if(temp[i] % 2 == 0)
		{
			count += temp[i];
		}
		else if(temp[i] > 1)
		{
			count += (temp[i]/2) * 2;
			
			if(!foundOne)
			{
				foundOne = true;
				count++;
			}
		}
	}
	
	return count;
}
