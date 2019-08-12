<Query Kind="Program" />

void Main()
{
	RegularExpressionMatching("aaaba", "a*ba").Dump();
	isMatch("aaaba", "a*ba").Dump();
}

/* 

Time Complexity: Let T, PT,P be the Lengths of the text and the pattern respectively. In the worst case, a call to match(text[i:], pattern[2j:]) will be made \binom{i+j}{i}(i i+j times, 
and strings of the order O(T - i)O(T−i) and O(P - 2*j)O(P−2∗j) will be made. Thus, the complexity has the order \sum_{i = 0}^T \sum_{j = 0}^{P/2} \binom{i+j}{i} O(T+P-i-2j)
∑i=0T​∑ j=0P/2​(i i+j)O(T+P−i−2j). With some effort outside the scope of this article, we can show this is bounded by O\big((T+P)2^{T + \frac{P}{2}}\big)O((T+P)2 ^T+ P/2).

*/

public bool RegularExpressionMatching(string str, string pattern)
{
	if(string.IsNullOrWhiteSpace(pattern))
	{
		return string.IsNullOrWhiteSpace(str);
	}
	
	var firstMatch = !string.IsNullOrWhiteSpace(pattern) && !string.IsNullOrWhiteSpace(str) && (str[0] ==pattern[0] || pattern[0] == '*');
	
	if(pattern.Length >= 2 && pattern[1] == '*')
	{
		return RegularExpressionMatching(str , pattern.Substring(2)) || (firstMatch && RegularExpressionMatching(str.Substring(1) , pattern));
	}
	else
	{
		return firstMatch && RegularExpressionMatching(str.Substring(1), pattern.Substring(1));
	}
}

public bool isMatch(String text, String pattern)
{
	var dp = new bool[text.Length + 1, pattern.Length + 1];
	dp[text.Length,pattern.Length] = true;

	for (int i = text.Length; i >= 0; i--)
	{
		for (int j = pattern.Length - 1; j >= 0; j--)
		{
			bool first_match = (i < text.Length &&
								   (pattern[j] == text[i] ||
									pattern[j] == '.'));
			if (j + 1 < pattern.Length && pattern[j + 1] == '*')
			{
				dp[i, j] = dp[i, j + 2] || first_match && dp[i + 1, j];
			}
			else
			{
				dp[i, j] = first_match && dp[i + 1, j + 1];
			}
		}
	}
	return dp[0,0];
}