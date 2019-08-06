<Query Kind="Program" />

void Main()
{
	ValidIPAddress("20EE:FGb8:85a3:0:0:8A2E:0370:7334").Dump();
}

public string ValidIPAddress(string IP)
{
	bool isIpv4 = false;
	for (int i = 0; i < IP.Length; i++)
	{
		if(IP[i] == '.' || IP[i] == ':')
		{
			isIpv4 = IP[i] == '.';
			break;
		}
	}
	
	if(isIpv4 && ValidateIPv4(IP))
	{
		return "IPv4";
	}
	else if(ValidateIPv6(IP))
	{
		return "IPv6";
	}
	
	return "Neither";
}

public bool ValidateIPv4(string IP)
{
	var numbers = IP.Split('.');
	
	if(numbers.Length != 4)
	{
		return false;
	}
	
	bool hasLeadingZero = false;
	var num = 0;
	foreach (var number in numbers)
	{
		if(string.IsNullOrWhiteSpace(number))
		{
			return false;
		}
		
		for (int i = 0; i < number.Length; i++)
		{
			if(!Char.IsDigit(number[i]))
			{
				return false;
			}
			
			var ch = number[i] - '0';
			if (hasLeadingZero)
			{
				return false;
			}
			else if (ch == 0)
			{
				hasLeadingZero = true;
			}

			num = num * 10 + ch;
			if (num > 255)
			{
				return false;
			}
		}
		
		num = 0;
		hasLeadingZero = false;
	}

	return true;
}

public bool ValidateIPv6(string IP)
{
	var numbers = IP.Split(':');
	
	if(numbers.Length != 8)
	{
		return false;
	}
	
	foreach (var number in numbers)
	{
		if (string.IsNullOrWhiteSpace(number) || number.Length > 4)
		{
			return false;
		}

		for (int i = 0; i < number.Length; i++)
		{
			if (!Char.IsDigit(number[i]) && !(number[i] >= 'a' && number[i] <= 'f') && !(number[i] >= 'A' && number[i] <= 'F'))
			{
				return false;
			}
		}
	}

	return true;
}