<Query Kind="Program" />

void Main()
{
	Multiply("123", "456").Dump();
	Multiply1("123", "456").Dump();
}

public string Multiply(string num1, string num2)
{
	var longString = num1.Length > num2.Length ? num1 : num2;
	var shortString = num1.Length > num2.Length ? num2 : num1;


	double sum = 0;
	var sourceMulfactor = 1;
	for (int i = shortString.Length-1; i >= 0 ; i--)
	{
		var temp = 0;
		var carry = 0;
		var shortVal = shortString[i] - '0';
		var mulfactor  = sourceMulfactor;
		for (int j = longString.Length-1; j >= 0; j--)
		{
			var val = (longString[j] - '0') * shortVal + carry;
			
			temp = (val%10) * mulfactor + temp;
			carry = val/10;
			mulfactor = mulfactor * 10;
		}
		
		if(carry > 0)
		{
			temp = carry * mulfactor + temp;
		}
		sum = sum + temp;
		sourceMulfactor= sourceMulfactor * 10;
	}
	
	return sum.ToString();
}

public String Multiply1(String num1, String num2)
{
	int m = num1.Length, n = num2.Length;
	int[] pos = new int[m + n];

	for (int i = m - 1; i >= 0; i--)
	{
		for (int j = n - 1; j >= 0; j--)
		{
			int mul = (num1[i] - '0') * (num2[j] - '0');
			int p1 = i + j, p2 = i + j + 1;
			int sum = mul + pos[p2];

			pos[p1] += sum / 10;
			pos[p2] = (sum) % 10;
		}
	}

	StringBuilder sb = new StringBuilder();
	foreach (var element in pos)
	{
		if (!(sb.Length == 0 && element == 0)) sb.Append(element);
	}

	return sb.Length == 0 ? "0" : sb.ToString();
}
