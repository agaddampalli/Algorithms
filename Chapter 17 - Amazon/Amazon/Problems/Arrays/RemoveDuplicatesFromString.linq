<Query Kind="Program" />

void Main()
{
	RemoveDuplicates("accaca").Dump();
}

//https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
public string RemoveDuplicates(string S)
{
	var stack = new Stack<char>();

	for (int i = 0; i < S.Length; i++)
	{
		if (stack.Any() && stack.Peek() == S[i])
		{
			stack.Pop();
		}
		else
		{
			stack.Push(S[i]);
		}
	}

	char[] result = new char[stack.Count];
	for (int i = stack.Count - 1; i >= 0; i--)
	{
		result[i] = stack.Pop();
	}
	return new string(result);
}
