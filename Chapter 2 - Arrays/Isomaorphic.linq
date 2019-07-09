<Query Kind="Program" />

void Main()
{
	IsIsomorphic("egg", "add").Dump();
}

public bool IsIsomorphic(string s, string t)
{
	int n = s.Length;
	int[] s1 = new int[256];
	int[] s2 = new int[256];
	for (int i = 0; i < n; i++)
	{
		if (s1[s[i]] != s2[t[i]])
			return false;
		s1[s[i]] = i + 1;
		s2[t[i]] = i + 1;
	}
	return true;
}
