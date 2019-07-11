<Query Kind="Program" />

void Main()
{
	var input = new char[] { 'h','a','n','n','a','H'};

	ReverseStringRecursive(input);
	ReverseString(input);
}

public void ReverseString(char[] s)
{

	int i = 0;
	int j = s.Length - 1;

	while (i < j)
	{
		var temp = s[i];
		s[i] = s[j];
		s[j] = temp;
		i++;
		j--;
	}
	
	s.Dump();
}

public void ReverseStringRecursive(char[] s)
{
	Reverse(s, 0, s.Length-1);
	
	s.Dump();
}

public void Reverse(char[] s, int start, int end)
{
	if(start < end)
	{
		var temp = s[start];
		s[start] = s[end];
		s[end] = temp;
		start++;
		end--;
		Reverse(s, start, end);
	}
}
