<Query Kind="Program" />

void Main()
{
	MinWindow("AABDECAYBARCAABC", "AABC").Dump();
}

//ABDECAYBARTYABC
//ABC
public string MinWindow(string s, string t)
{
	if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
	{
		return string.Empty;
	}

	if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
	{
		return string.Empty;
	}

	string result = string.Empty;
	int minLen = int.MaxValue;
	int count = 0;
	int[] letterCount = new int[128];
	int left = 0;

	foreach (char c in t.ToCharArray())
	{
		letterCount[c]++;
	}

	for (int right = 0; right < s.Length; right++)
	{
		if (--letterCount[s[right]] >= 0)
		{
			++count;
		}

		while (count == t.Length)
		{
			if (minLen > right - left + 1)
			{
				minLen = right - left + 1;

				result = s.Substring(left, minLen);
			}

			if (++letterCount[s[left]] > 0)
			{
				--count;
			}
			++left;
		}
	}

	return result;
}