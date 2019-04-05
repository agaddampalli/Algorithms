<Query Kind="Program" />

void Main()
{
	LetterCombinations("23").Dump();
}

public IList<string> LetterCombinations(string digits)
{

	var dictionary = new Dictionary<int, List<string>>
	{
		{2, new List<string>{"a","b","c"}},
		{3, new List<string>{"d","e","f"}},
		{4, new List<string>{"g","h","i"}},
		{5, new List<string>{"j","k","l"}},
		{6, new List<string>{"m","n","o"}},
		{7, new List<string>{"p","q","r", "s"}},
		{8, new List<string>{"t","u","v"}},
		{9, new List<string>{"w","x","y", "z"}}
	};
	var result = new List<string>();

	for (int i = 0; i < digits.Length; i++)
	{
		var inputDigit = (int)Char.GetNumericValue(digits[i]);
		if (dictionary.ContainsKey(inputDigit))
		{
			var inputArray = dictionary[inputDigit];
			result = Combinations(result, inputArray);
		}
	}

	return result;
}


private List<string> Combinations(List<string> inputArray1, List<string> inputArray2)
{
	if (inputArray1.Count == 0)
	{
		return inputArray2;
	}

	if (inputArray2.Count == 0)
	{
		return inputArray1;
	}

	var result = new List<string>();

	for (int i = 0; i < inputArray1.Count; i++)
	{
		for (int j = 0; j < inputArray2.Count; j++)
		{
			result.Add(inputArray1[i] + inputArray2[j]);
		}
	}

	return result;
}