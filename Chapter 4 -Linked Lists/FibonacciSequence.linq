<Query Kind="Program" />

void Main()
{
	FibonacciSequence(10).Dump();
}

public int FibonacciSequence(int n)
{
	if(n <= 1)
	{
		return 1;
	}
	
	var dp = new int[n+1];
	
	dp[0] = 1;
	dp[1] = 1;
	
	for (int i = 2; i <= n; i++)
	{
		dp[i] = dp[i-1] + dp[i-2];
	}
	
	return dp[n];
}
