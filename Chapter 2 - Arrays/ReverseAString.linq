<Query Kind="Program" />

void Main()
{
	var input = new char[] { 'h','a','n','n','a','H'};
	
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