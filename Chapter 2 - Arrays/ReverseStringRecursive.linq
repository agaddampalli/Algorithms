<Query Kind="Program" />

void Main()
{
	var input = new char[]{'a', 'b', 'c'};
	
	ReverseString(input);
	
	input.Dump();
	
	helper(0, input.Length-1, input);
	
	input.Dump();
}

public void ReverseString(char[] s)
{
	Reverse(s, s.Length-1);
}

private void Reverse(char[] s, int index)
{
	if(index < 0)
	{
		return;
	}
	
	var value = s[index--];
	Reverse(s, index);
	++index;
	s[s.Length - 1- index] = value;
}

private void helper(int start, int end, char[] s)
{
	if (start >= end)
	{
		return;
	}
	// swap between the first and the last elements.
	char tmp = s[start];
	s[start] = s[end];
	s[end] = tmp;

	helper(start + 1, end - 1, s);
}