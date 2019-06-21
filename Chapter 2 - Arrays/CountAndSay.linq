<Query Kind="Program" />

void Main()
{
	CountAndSayIterative(6).Dump();
}

public string CountAndSay(int n)
{
	if(n == 1)
	{
		return "1";
	}
	else if(n == 2)
	{
		return "11";
	}

	string output = CountAndSay(n-1);

	var count = 1;
	var currentChar = output[0];
	var result = string.Empty;
	for (int j = 1; j < output.Length; j++)
	{
		if(output[j] == currentChar)
		{
			count++;
		}
		else
		{
			result = result + count.ToString() + currentChar.ToString();
			currentChar = output[j];
			count = 1;
		}
	}

	result = result + count.ToString() + currentChar.ToString();
	
	return result;
}

public string CountAndSayIterative(int n)
{
	if (n == 1)
	{
		return "1";
	}

	int j = 2;
	var output = "1";
	while (j <=n)
	{
		var result = new StringBuilder();
		var count = 1;
		var currentChar = output[0];
		for (int i = 1; i < output.Length; i++)
		{
			if (output[i] == currentChar)
			{
				count++;
			}
			else
			{
				result.Append(count.ToString() + currentChar.ToString());
				currentChar = output[i];
				count = 1;
			}
		}
		result.Append(count.ToString() + currentChar.ToString());
		
		output = result.ToString();
		j++;
	}

	return output;
}
