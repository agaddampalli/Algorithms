<Query Kind="Program" />

void Main()
{
	MyAtoi("-4+2").Dump();
}

public int MyAtoi(string str)
{
	var numericHashSet = new HashSet<char>{'0','1','2','3','4','5','6','7','8','9', '-', '+'};
	
	if(string.IsNullOrWhiteSpace(str))
	{
		return 0;
	}
	
	string result = null;
	bool hasADigit = false;
	bool isNegative = false;
	for (int i = 0; i < str.Length; i++)
	{
		if(str[i] == ' ' && !hasADigit)
		{
			continue;
		}
		
		if(!numericHashSet.Contains(str[i]) || (hasADigit && (str[i] == '-' || str[i] == '+')))
		{
			break;
		}
		
		if(!hasADigit && (str[i] == '-' || str[i] == '+'))
		{
			isNegative = str[i] == '-';
			hasADigit = true;
			continue;
		}
		
		result += str[i];
		hasADigit = true;
	}
	
	var doubleResult = isNegative ? Convert.ToDouble(result) * -1 : Convert.ToDouble(result);
	
	if(doubleResult < int.MinValue)
	{
		return int.MinValue;
	}

	if (doubleResult > int.MaxValue)
	{
		return int.MaxValue;
	}
	
	return Convert.ToInt32(doubleResult);
}
