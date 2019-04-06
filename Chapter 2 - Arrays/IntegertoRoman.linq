<Query Kind="Program" />

void Main()
{
	IntToRoman(70).Dump();
}

public string IntToRoman(int num)
{

//	string[] M = { "", "M", "MM", "MMM" };
//	string[] C = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
//	string[] X = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
//	string[] I = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
//	return M[num / 1000] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
	
	if(num == 0 || num > 3999)
	{
		return string.Empty;
	}

	var romanDictionary = new Dictionary<int, string>{
		{1, "I"},
		{5, "V"},
		{10, "X"},
		{50, "L"},
		{100, "C"},
		{500, "D"},
		{1000, "M"},
		{4, "IV"},
		{9, "IX"},
		{40, "XL"},
		{90, "XC"},
		{400, "CD"},
		{900, "CM"},
	};
	var multiplier = 1;
	for (int i = 0; i < num.ToString().Length -1; i++)
	{
		multiplier = multiplier * 10;
	}
	
	var romanString = new StringBuilder();
	while(num != 0)
	{
		var currentDigit = num/multiplier;
		if(romanDictionary.ContainsKey(currentDigit * multiplier))
		{
			romanString.Append(romanDictionary[currentDigit * multiplier]);
		}
		else
		{
			if(currentDigit < 5)
			{
				romanString.Append(GetRomanString(currentDigit, romanDictionary[1 * multiplier]));
			}
			else
			{
				var remainder = currentDigit % 5;
				
				if(romanDictionary.ContainsKey(remainder))
				{
					romanString.Append(romanDictionary[5 * multiplier] + romanDictionary[remainder * multiplier]);
				}
				else
				{
					romanString.Append(romanDictionary[5 * multiplier] + GetRomanString(remainder, romanDictionary[(currentDigit / 5) * multiplier]));
				}
			}
		}
		
		num = num % multiplier;
		multiplier = multiplier/10;
	}
	
	return romanString.ToString();
}

public string GetRomanString(int count, string romanString)
{
	var stringBuilder = new StringBuilder();
	
	for (int i = 0; i <count; i++)
	{
		stringBuilder.Append(romanString);
	}
	
	return stringBuilder.ToString();
}