<Query Kind="Program" />

void Main()
{
	StringCompression("qwertyuuuiop").Dump();
	
	var chars = new char[] {'a','a','a','b','b', 'a'};
	
	Compress(chars).Dump();
	
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

public int Compress(char[] chars)
{
	int i = 0;
	int j = 0;
	
	int count = 0;
	int currentChar = chars[0];
	while(i<chars.Length)
	{
		if(chars[i] == currentChar)
		{
			count++;
		}
		else
		{
			chars[j++] = (char)currentChar;
			if(count > 1)
			{
				var countString = count.ToString();
				for (int x = 0; x < countString.Length; x++)
				{
					chars[j++] = countString[x];
				}
			}
			
			currentChar = chars[i];
			count = 1;
		}
	
		i++;
	}

	chars[j++] = (char)currentChar;
	if (count > 1 && j < chars.Length)
	{
		var countString = count.ToString();
		for (int x = 0; x < countString.Length; x++)
		{
			chars[j++] = countString[x];
		}
	}
	
	chars.Dump();
	return j;
}