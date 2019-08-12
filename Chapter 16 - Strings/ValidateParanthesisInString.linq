<Query Kind="Program" />

void Main()
{
	CheckValidString("(((******)))").Dump();
	checkValidString("(*()").Dump();
}

public bool CheckValidString(string s)
{
	int lo = 0, hi = 0;

	for (int i = 0; i < s.Length; i++)
	{
		lo += s[i] == '(' ? 1 : -1;
		hi += s[i] != ')' ? 1 : -1;
		if (hi < 0) break;
		lo = Math.Max(lo, 0);
	}

	return lo == 0;
}

public bool checkValidString(String s)
{
	int leftBalance = 0;
	for (int i = 0; i < s.Length; i++)
	{
		if ((s[i] == '(') || (s[i] == '*'))
			leftBalance++;
		else
			leftBalance--;

		if (leftBalance < 0) return false; 
	}


	if (leftBalance == 0) return true;

	int rightBalance = 0;
	for (int i = s.Length - 1; i >= 0; i--)
	{
		if ((s[i] == ')') || (s[i] == '*'))
			rightBalance++;
		else
			rightBalance--;

		if (rightBalance < 0) return false;
	}

	return true;
}