<Query Kind="Program" />

void Main()
{
	NumberToWords(3200348).Dump();
}

public string NumberToWords(int num)
{
	if(num == 0)
	{
		return "Zero";
	}
	
	var wordDictionary = new Dictionary<int, string>();
	wordDictionary.Add(0, "Zero ");
	wordDictionary.Add(1, "One ");
	wordDictionary.Add(2, "Two ");
	wordDictionary.Add(3, "Three ");
	wordDictionary.Add(4, "Four ");
	wordDictionary.Add(5, "Five ");
	wordDictionary.Add(6, "Six ");
	wordDictionary.Add(7, "Seven ");
	wordDictionary.Add(8, "Eight ");
	wordDictionary.Add(9, "Nine ");
	wordDictionary.Add(10, "Ten ");
	wordDictionary.Add(11, "Eleven ");
	wordDictionary.Add(12, "Twleve ");
	wordDictionary.Add(13, "Thirteen ");
	wordDictionary.Add(14, "Fourteen ");
	wordDictionary.Add(15, "Fifteen ");
	wordDictionary.Add(16, "Sixteen ");
	wordDictionary.Add(17, "Seventeen ");
	wordDictionary.Add(18, "Eightteen ");
	wordDictionary.Add(19, "Nineteen ");
	wordDictionary.Add(20, "Twenty ");
	wordDictionary.Add(30, "Thirty ");
	wordDictionary.Add(40, "Forty ");
	wordDictionary.Add(50, "Fifty ");
	wordDictionary.Add(60, "Sixty ");
	wordDictionary.Add(70, "Seventy ");
	wordDictionary.Add(80, "Eighty ");
	wordDictionary.Add(90, "Ninety ");
	wordDictionary.Add(100, "Hundred ");
	wordDictionary.Add(1000, "Thousand ");
	wordDictionary.Add(100000000, "Million ");
	wordDictionary.Add(1000000000, "Billion ");


	StringBuilder output = new StringBuilder();
	
	while (num != 0)
	{
<<<<<<< HEAD
		var outputNum = 0;
		
		if(num > 999999999)
		{
			outputNum = num / 1000000000;
			output.Append(BuildOutputString(wordDictionary, outputNum));
			output.Append(wordDictionary[1000000000]);
			
			num = num % 1000000000;
=======
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
>>>>>>> c04760614cabfaf3466df7530a05dde1efa19e1d
		}
		else if(num <= 999999999 && num > 99999999)
		{
<<<<<<< HEAD
			outputNum = num / 100000000;
			output.Append(BuildOutputString(wordDictionary, outputNum));
			output.Append(wordDictionary[100]);


			if (num % 100000000 == 0)
			{
				output.Append(wordDictionary[100000000]);
			}
			
			num = num % 100000000;
		}
		else if (num <= 99999999 && num > 999999)
		{
			outputNum = num / 1000000;
			output.Append(BuildOutputString(wordDictionary, outputNum));
			output.Append(wordDictionary[100000000]);

			num = num % 1000000;
		}
		else if (num <= 999999 && num > 99999)
		{
			outputNum = num / 100000;
			output.Append(BuildOutputString(wordDictionary, outputNum));
			output.Append(wordDictionary[100]);
			
			if(num % 100000 < 1000)
			{
				output.Append(wordDictionary[1000]);
			}

			num = num % 100000;
		}
		else if (num <= 99999 && num > 999)
		{
			outputNum = num / 1000;
			output.Append(BuildOutputString(wordDictionary, outputNum));
			output.Append(wordDictionary[1000]);

			num = num % 1000;
=======
			output = GetOutputString(wordDictionary, num, multiplier, output);
>>>>>>> c04760614cabfaf3466df7530a05dde1efa19e1d
		}
		else if (num <= 999 && num > 99)
		{
			outputNum = num / 100;
			output.Append(BuildOutputString(wordDictionary, outputNum));
			output.Append(wordDictionary[100]);

			num = num % 100;
		}
		else if (num <= 99)
		{
			output.Append(BuildOutputString(wordDictionary, num));
			num = num / 100;
		}
	}

<<<<<<< HEAD
	return output.ToString().Trim();
}


private string BuildOutputString(Dictionary<int, string> wordDictionary, int num)
{
	if (wordDictionary.ContainsKey(num))
	{
		return wordDictionary[num];
	}
	else
	{
		var outputNum = num % 10;
		num = (num / 10 ) * 10;
		string output = null;
		
		if(wordDictionary.ContainsKey(num))
		{
			output = wordDictionary[num];
		}
		
		if (wordDictionary.ContainsKey(outputNum))
		{
			 output += wordDictionary[outputNum];
		}
		
		return output;
=======
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
>>>>>>> c04760614cabfaf3466df7530a05dde1efa19e1d
	}
}