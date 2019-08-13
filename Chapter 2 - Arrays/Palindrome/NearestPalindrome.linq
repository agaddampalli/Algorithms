<Query Kind="Program" />

void Main()
{
	NearestPalindromic("11").Dump();
}

public string NearestPalindromic(string n)
{
	if(n == "1")
	{
		return "0";
	}
	
	var a = MirrorString(n);
	
	var diff1 = Math.Abs(Convert.ToInt64(a) - Convert.ToInt64(n));
	
	if(diff1 == 0)
	{
		diff1 = int.MaxValue;
	}
	
	var b = SmallerPalindrome(n);
	Int64.TryParse(b, out long bLong);
	long diff2 = Math.Abs(bLong - Convert.ToInt64(n));
	
	var c = LargerPalindrome(n);
	Int64.TryParse(c, out long cLong);
	var diff3 = Math.Abs(cLong - Convert.ToInt64(n));

	if (diff2 <= diff1 && diff2 <= diff3)
		return b;
	if (diff1 <= diff3 && diff1 <= diff2)
		return a;
	else
		return c; ;
}

public string MirrorString(string n)
{
	var str = new StringBuilder(n);
	
	int i = 0, j = n.Length -1;
	
	while(i < j)
	{
		str[j] = str[i];
		i++;
		j--;
	}
	
	return str.ToString();
}

public string SmallerPalindrome(string n)
{
	var s = new StringBuilder(n);
	
	var i = n.Length % 2 == 0 ? (n.Length / 2) - 1 : (n.Length / 2);
	
	while(i >= 0 && s[i] == '0')
	{
		s[i] = '9';
		i--;
	}
	
	if(i == 0 && s[i] == '1')
	{
		s.Remove(0,1);
		var mid = (s.Length-1)/2;
		s[mid] = '9';
	}
	else
	{
		s[i] = (char)(s[i] - 1);
	}
	
	return MirrorString(s.ToString());
}

public string LargerPalindrome(string n)
{
	var s = new StringBuilder(n);

	var i = n.Length % 2 == 0 ? (n.Length / 2) - 1 : (n.Length / 2);

	while (i >= 0 && s[i] == '9')
	{
		s[i] = '0';
		i--;
	}

	if (i < 0 )
	{
		s.Insert(0, '1');
	}
	else
	{
		s[i] = (char)(s[i] + 1);
	}

	return MirrorString(s.ToString());
}