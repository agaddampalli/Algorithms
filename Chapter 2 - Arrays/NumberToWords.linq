<Query Kind="Program" />

void Main()
{
	NumberToWords(123456).Dump();
}

public string NumberToWords(int num)
{
	var wordDictionary = new Dictionary<int, string>();
	wordDictionary.Add(1, "One");
	wordDictionary.Add(2, "Two");
	wordDictionary.Add(3, "Three");
	wordDictionary.Add(4, "Four");
	wordDictionary.Add(5, "Five");
	wordDictionary.Add(6, "Six");
	wordDictionary.Add(7, "Seven");
	wordDictionary.Add(8, "Eight");
	wordDictionary.Add(9, "Nine");
	wordDictionary.Add(10, "Ten");
	wordDictionary.Add(11, "Eleven");
	wordDictionary.Add(12, "Twleve");
	wordDictionary.Add(13, "Thirteen");
	wordDictionary.Add(14, "Fourteen");
	wordDictionary.Add(15, "Fifteen");
	wordDictionary.Add(16, "Sixteen");
	wordDictionary.Add(17, "Seventeen");
	wordDictionary.Add(18, "Eightteen");
	wordDictionary.Add(19, "Nineteen");
	wordDictionary.Add(20, "Twenty");
	wordDictionary.Add(30, "Thirty");
	wordDictionary.Add(40, "Fourty");
	wordDictionary.Add(50, "Fifty");
	wordDictionary.Add(60, "Sixty");
	wordDictionary.Add(70, "Sixty");
	wordDictionary.Add(80, "Seventy");
	wordDictionary.Add(90, "Ninety");
	wordDictionary.Add(100, "Hundred");
	wordDictionary.Add(1000, "Thousand");
	wordDictionary.Add(1000000, "Million");
	wordDictionary.Add(1000000000, "Billion");


	string output = null;
	var divider = 1;
	
	var multiplier = 1;
	while (num != 0)
	{
		if(wordDictionary.ContainsKey(num))
		{
			output = GetOutputString(wordDictionary, num, multiplier, output);
		}
		if(num < 99)
		{
			var outputNum = num % 10;
			output = GetOutputString(wordDictionary, outputNum, multiplier, output);
		}
		if (!wordDictionary.ContainsKey(num))
		{
			var outputNum = num % 10;
			output = GetOutputString(wordDictionary, outputNum, multiplier, output);
		}
		else
		{
			output = GetOutputString(wordDictionary, num, multiplier, output);
		}

		num = num / 10;
		multiplier = multiplier * 10;
	}

	return output.ToString();
}

private string GetOutputString(Dictionary<int, string> wordDictionary, int num, int multiplier, string output)
{
	if (wordDictionary.ContainsKey(num * multiplier))
	{
		return wordDictionary[num * multiplier] + " " + output;
	}
	else
	{
		return wordDictionary[num] + " " + wordDictionary[multiplier] + " " + output;
	}
}