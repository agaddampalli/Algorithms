<Query Kind="Program" />

void Main()
{
	factorial(30).Dump();
	TrailingZeroes(30).Dump();
}

public int TrailingZeroes(int n)
{
	return n == 0 ? 0 : n/5 + TrailingZeroes(n/5);
}

public long factorial(int n)
{
	if(n == 0 || n == 1)
	{
		return 1;
	}
	
	return n * factorial(n-1);
}
