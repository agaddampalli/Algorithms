<Query Kind="Program" />

void Main()
{
	Urlify("abc def ", 7).Dump();
}

public string Urlify(string input, int length)
{
	if(string.IsNullOrWhiteSpace(input))
	{
		return string.Empty;
	}
	
	StringBuilder output = new StringBuilder();
	for (int i = 0; i < length; i++)
	{
		if(input[i] != 32)
		{
			output.Append(input[i]);
		}
		else
		{
			output.Append("%20");
		}
	}
	
	return output.ToString();
}