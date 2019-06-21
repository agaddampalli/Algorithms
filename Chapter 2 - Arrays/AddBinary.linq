<Query Kind="Program" />

void Main()
{
	AddBinary("0", "0").Dump();
}

public string AddBinary(string a, string b)
{
	string output = null;
	
	if(string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b))
	{
		return a;
	}

	if (!string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b))
	{
		return b;
	}

	if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b))
	{
		return output;
	}
	
	var i = a.Length-1;
	var j = b.Length-1;
	int carry = 0;
	while(i>=0 || j>=0)
	{
		var char1 = ' ';
		if(i >= 0)
		{
			char1 = a[i--];
		}

		var char2 = ' ';
		if (j >= 0)
		{
			char2 = b[j--];
		}
		
		if(char1 == '1' && char2 == '1')
		{
			if(carry == 1)
			{
				output = "1" + output;
			}
			else
			{
				output = "0" + output;
			}
			
			carry = 1;
		}
		else if(char1 == '1' || char2 == '1')
		{
			if (carry == 1)
			{
				output = "0" + output;
				carry = 1;
			}
			else
			{
				output = "1" + output;
			}
		}
		else
		{
			if (carry == 1)
			{
				output = "1" + output;
				carry = 0;
			}
			else
			{
				output = "0" + output;
			}
		}
	}
	
	if(carry == 1)
	{
		output = "1" + output;
	}
	
	return output;
}
