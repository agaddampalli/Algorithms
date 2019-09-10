<Query Kind="Program" />

void Main()
{
	NumberToWords(50868).Dump();
}

private static string[] LESS_THAN_20;
private static string[] TENS;
private static string[] THOUSANDS;

public string NumberToWords(int num)
{
	LESS_THAN_20 = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
	TENS = new string[] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
	THOUSANDS = new string[] { "", "Thousand", "Million", "Billion" };
	
	var i = 0;
	var result = string.Empty;
	
	while(num != 0)
	{
		var temp = num % 1000;
		
		if(temp != 0)
		{
			result = $"{Helper(temp)}{THOUSANDS[i]} {result}";
		}
		
		i++;
		num = num/1000;
	}
	
	return result;
}

private static string Helper(int num)
{
	if(num == 0)
	{
		return string.Empty;
	}
	else if(num < 20)
	{
		return $"{LESS_THAN_20[num]} ";
	}
	else if(num < 100)
	{
		return $"{TENS[num/10]} {Helper(num%10)}";
	}
	else
	{
		return $"{LESS_THAN_20[num/100]} Hundred {Helper(num%100)}";
	}
}