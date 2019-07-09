<Query Kind="Program" />

void Main()
{
	RemoveKdigits("5337", 2).Dump();
	removeKdigits("1432219", 3).Dump();
}

public string RemoveKdigits(string num, int k)
{
	if(num.Length <= k)
	{
		return "0";
	}


	string minimum = num.Substring(0, 0) + num.Substring(k); ;
	
	int i = 1;
	int j = k + 1;
	
	while(j <= num.Length)
	{
		var temp = num.Substring(0,i) + num.Substring(j);
		
		var res = CompareNumbers(temp, minimum);
		
		if(res == -1)
		{
			minimum = temp;
		}
		
		i++;
		j++;
	}
	
	var output = minimum.TrimStart(new Char[] { '0' } );
	
	if(string.IsNullOrWhiteSpace(output))
	{
		return "0";
	}
	
	return output;
}

public static int CompareNumbers(string x, string y)
{
	if (x.Length > y.Length) y = y.PadLeft(x.Length, '0');
	else if (y.Length > x.Length) x = x.PadLeft(y.Length, '0');

	for (int i = 0; i < x.Length; i++)
	{
		if (x[i] < y[i]) return -1;
		if (x[i] > y[i]) return 1;
	}
	return 0;
}

public String removeKdigits(String num, int k)
{
	if (num == null || k >= num.Length) return "0";
	
	StringBuilder sb = new StringBuilder();
	sb.Append(num[0]);

	for (int i = 1; i < num.Length; i++)
	{
		while (k > 0 && sb.Length > 0 && num[i] < sb[sb.Length - 1])
		{
			sb.Remove(sb.Length - 1,1);
			k--;
		}
		
		sb.Append(num[i]);
	}

	// Remove from the tail of the string if necessary
	while (k-- > 0) sb.Remove(sb.Length - 1,1);

	// Remove the preceeding '0'
	while (sb[0] == '0' && sb.Length > 1) sb.Remove(0,1);

	return sb.ToString();
}
