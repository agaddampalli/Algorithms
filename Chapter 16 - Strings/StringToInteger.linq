<Query Kind="Program" />

void Main()
{
	MyAtoi("0+312-1").Dump();
}

public int MyAtoi(string str)
{
	bool hasDigits = false;
	bool isNegative = false;
	bool hasSign = false;
	
	double output = 0;
	for (int i = 0; i < str.Length; i++)
	{
		if(str[i] == ' ')
		{
			if (hasSign && !hasDigits)
			{
				return 0;
			}
			
			if(hasDigits)
			{
				break;
			}

			continue;
		}
		
		if(!hasDigits && !hasSign && (str[i] == '+' || str[i] == '-'))
		{
			isNegative = str[i] == '-';
			hasSign = true;
			continue;
		}
		
		if(!IsDigit(str[i]))
		{
			if(hasDigits)
			{
				return isNegative ? Convert.ToInt32(output * -1) : Convert.ToInt32(output);
			}
			
			return 0;
		}
		
		hasDigits = true;
		var ch = str[i] - '0';
		output = output * 10 + ch;
		
		if(output > int.MaxValue)
		{
			return isNegative ? int.MinValue : int.MaxValue;
		}
	}

	return isNegative ? Convert.ToInt32(output * -1) : Convert.ToInt32(output);
}

public bool IsDigit(char ch)
{
	return ch >= '0' && ch <= '9';
}