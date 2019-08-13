<Query Kind="Program" />

void Main()
{
	var s = "ab";
	var t = "ba";
	
	IsOneEditDistance(s,t).Dump();
}

public bool IsOneEditDistance(string s, string t)
{
	if (s.Length > t.Length)
	{
		return IsOneEditDistance(t, s);
	}
	int m = s.Length;
	int n = t.Length;
	if (n - m > 1)
	{
		return false;
	}
	for (int i = 0; i < m; ++i)
	{
		if (s[i] != t[i])
		{
			if (m == n)
			{
				return s.Substring(i + 1).Equals(t.Substring(i + 1));
			}
			else
			{
				return s.Substring(i).Equals(t.Substring(i + 1));
			}
		}
	}
	
	return m != n;
}
