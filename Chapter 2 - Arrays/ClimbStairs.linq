<Query Kind="Program" />

void Main()
{
	ClimbStairs(4).Dump();
	climbStairs(0,5,new int[5+1]).Dump();
	climbStairs(6).Dump();
	climbStairsFib(6).Dump();
}

public int ClimbStairs(int n)
{
	return climbStairs(0,n);
}

public int climbStairs(int n)
{
	if(n==1)
	{
		return 1;
	}
	
	var dp = new int[n+1];
	dp[1] =1;
	dp[2] = 2;
	
	for (int i = 3; i <= n; i++)
	{
		dp[i] = dp[i-1] + dp[i-2];
	}
	
	return dp[n];
}

public int climbStairsFib(int n)
{
	if (n == 1)
	{
		return 1;
	}

	var first = 1;
	var second = 2;
	var third = 0;
	for (int i = 3; i <= n; i++)
	{
		third = first + second;
		first = second;
		second = third;
	}

	return third;
}

private int climbStairs(int i, int n)
{
	if(i>n)
	{
		return 0;
	}
	
	if(i==n)
	{
		return 1;
	}
	
	return climbStairs(i+1, n) + climbStairs(i+2, n);
}

private int climbStairs(int i, int n, int[] memo)
{
	if (i > n)
	{
		return 0;
	}

	if (i == n)
	{
		return 1;
	}
	
	if(memo[i] > 0)
	{
		return memo[i];
	}

	memo[i] =  climbStairs(i + 1, n) + climbStairs(i + 2, n);
	
	return memo[i];
}