<Query Kind="Program" />

void Main()
{
	ReverseStr("abcdef", 2).Dump();
}

public string ReverseStr(string s, int k)
{
	char[] a = s.ToCharArray();
	for (int start = 0; start < a.Length; start += 2 * k)
	{
		int i = start, j = Math.Min(start + k - 1, a.Length - 1);
		while (i < j)
		{
			char tmp = a[i];
			a[i++] = a[j];
			a[j--] = tmp;
		}
	}
	
	return new String(a);
}

public void Swap(StringBuilder builder, int i, int j)
{
	var temp = builder[j];
	builder[j] = builder[i];
	builder[i] = temp;
}

public void Reverse(StringBuilder s, int start, int end)
{
	while (start < end)
	{
		Swap(s, start++, end--);
	}
}
