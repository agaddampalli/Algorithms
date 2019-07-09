<Query Kind="Program" />

void Main()
{
	Divide(-1010369383 , -2147483648).Dump();
}

public int Divide(int dividend, int divisor)
{
	int count = 1;
	long positiveDividend = 0;
	long positiveDivisor = 0;
	bool isNegative = false;
	
	if(dividend >= 0 && divisor > 0)
	{
		positiveDividend = dividend;
		positiveDivisor = divisor;
	}
	else if(dividend < 0 && divisor > 0)
	{
		positiveDividend = dividend == int.MinValue ? int.MaxValue : ~dividend + 1;
		positiveDivisor = divisor;
		isNegative = true;
	}
	else if(dividend > 0 && divisor < 0)
	{
		positiveDividend = dividend;
		positiveDivisor = divisor == int.MinValue ? int.MaxValue :  ~divisor + 1;
		isNegative = true;
	}
	else if(dividend < 0 && divisor < 0)
	{
		positiveDividend = dividend == int.MinValue ? int.MaxValue : ~dividend + 1;
		positiveDivisor = divisor == int.MinValue ? int.MaxValue :  ~divisor + 1;
	}
	
	if(dividend == int.MinValue)
	{
		positiveDividend++;
	}

	if (divisor == int.MinValue)
	{
		positiveDivisor++;
	}
	
	if(positiveDivisor == 1)
	{
		if(dividend == int.MinValue || dividend == int.MaxValue)
		{
			return isNegative ? int.MinValue : int.MaxValue;
		}
	}
	
	var temp = positiveDivisor;
	var res = 0;
	while(positiveDividend >= 0)
	{
		if(temp + temp < positiveDividend)
		{
			temp +=temp;
			count += count;
		}
		else
		{
			positiveDividend = positiveDividend - temp;
			temp = positiveDivisor;
			res += count;
			count = 1;
		}
	}
	
	res = res -1;
	if(isNegative)
	{
		res = res - res - res;
	}
	
	return res;
}
