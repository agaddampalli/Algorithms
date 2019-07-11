<Query Kind="Program" />

void Main()
{
	var input = "123";
	
	var length = factorial(input.Length);
	
	LexicographicOrder(input);
	
}

public int factorial(int n)
{
	if(n == 0 || n == 1)
	{
		return 1;
	}
	
	return n * factorial(n-1);
}

public void LexicographicOrder(string input)
{
	bool finished = false;
	var s = new StringBuilder(input);
	
	while(!finished)
	{
		s.ToString().Dump();

		int x = -1;
		int y = -1;

		//step1
		for (int i = 0; i < s.Length - 1; i++)
		{
			if (s[i] < s[i + 1])
			{
				x = i;
			}
		}
	
		if(x == -1)
		{
			finished = true;
		}
		else
		{
			//step 2
			for (int i = 0; i < s.Length; i++)
			{
				if (s[x] < s[i])
				{
					y = i;
				}
			}

			Swap(s, x, y);

			Reverse(s, x + 1, s.Length - 1);
		}
	}
}

public void Swap(StringBuilder builder, int i, int j)
{
	var temp = builder[j];
	builder[j] = builder[i];
	builder[i] = temp;
}

public void Reverse(StringBuilder s, int start, int end)
{
	while(start < end)
	{
		Swap(s, start++, end--);
	}
}