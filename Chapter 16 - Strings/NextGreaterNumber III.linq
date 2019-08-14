<Query Kind="Program" />

void Main()
{
	NextGreaterElement(1999999999).Dump();
}

public int NextGreaterElement(int n)
{
	var s = new StringBuilder(n.ToString());

	int x = -1;
	int y = -1;
	
	for (int i = 0; i < s.Length - 1; i++)
	{
		if (s[i] < s[i + 1])
		{
			x = i;
		}
	}
	
	if(x == -1)
	{
		return -1;
	}

	for (int i = 0; i < s.Length; i++)
	{
		if (s[x] < s[i])
		{
			y = i;
		}
	}

	Swap(s, x, y);

	Reverse(s, x + 1, s.Length - 1);
	
	int output = 0;
	
	if(!Int32.TryParse(s.ToString(),out output))
	{
		return -1;
	}
	
	return output;
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