<Query Kind="Program" />

void Main()
{
	LetterCombinations("234").Dump();
}

public Dictionary<char, char[]> digitDictionary = new Dictionary<char, char[]>();

public IList<string> LetterCombinations(string digits)
{
	var output = new List<string>();

	if (string.IsNullOrWhiteSpace(digits))
	{
		return output;
	}

	digitDictionary.Add('2', new char[] { 'a', 'b', 'c' });
	digitDictionary.Add('3', new char[] { 'd', 'e', 'f' });
	digitDictionary.Add('4', new char[] { 'g', 'h', 'i' });
	digitDictionary.Add('5', new char[] { 'j', 'k', 'l' });
	digitDictionary.Add('6', new char[] { 'm', 'n', 'o' });
	digitDictionary.Add('7', new char[] { 'p', 'q', 'r', 's' });
	digitDictionary.Add('8', new char[] { 't', 'u', 'v' });
	digitDictionary.Add('9', new char[] { 'w', 'x', 'y', 'z' });
	
	output = LetterCombinations(digits, output, 0);
	
	return output;
}

public List<string> LetterCombinations(string digits,List<string> output, int i)
{
	if(i > digits.Length-1)
	{
		return output;
	}
	
	var charArray = digitDictionary[digits[i]];
	
	output =  Combinations(output, charArray);
	
	var result = LetterCombinations(digits,output, ++i);
	
	return result;
}

public List<string> Combinations(List<string> output, char[] target)
{
	var result = new List<string>();
	
	if(output.Count == 0)
	{
		for (int i = 0; i < target.Length; i++)
		{
			result.Add(target[i].ToString());
		}
	}
	
	for (int i = 0; i < output.Count; i++)
	{
		for (int j = 0; j < target.Length; j++)
		{
			result.Add(output[i] + target[j]);
		}
	}
	
	return result;
}


