<Query Kind="Program" />

void Main()
{
	StringCompression("qwertyuuuiop").Dump();
}

public string StringCompression(string input)
{
	if (string.IsNullOrWhiteSpace(input))
	{
		return input;
	}

	StringBuilder output = new StringBuilder();
	bool hasCompressed = false;
	int count = 1;
	char currentChar = input[0];
	for (int i = 1; i < input.Length; i++)
	{
		if(input[i] == currentChar)
		{
			count++;
			hasCompressed = true;
		}
		else
		{
			output.Append(currentChar);
			output.Append(count);
			
			currentChar = input[i];
			count =1;
		}
	}

	output.Append(currentChar);
	output.Append(count);
	
	if(hasCompressed)
	{
		return output.ToString();
	}

	return input;
}