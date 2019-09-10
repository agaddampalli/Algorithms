<Query Kind="Program" />

void Main()
{
	var coins = new int[] {1, 2, 5};
	
	CoinChange(coins, 11).Dump();
}

public int CoinChange(int[] coins, int amount)
{
	if(amount < 0)
	{
		return -1;
	}
	
	var cache = new int[amount+1];
	return CoinChange(coins, amount, cache);
}


public int CoinChange(int[] coins, int remaining, int[] cache)
{
	if(remaining < 0)
	{
		return -1;
	}
	
	if(remaining == 0)
	{
		return 1;
	}
	
	if(cache[remaining] != 0)
	{
		return cache[remaining];
	}
	
	var min = int.MaxValue;
	foreach (var coin in coins)
	{
		var result = CoinChange(coins, remaining - coin, cache);
		
		if(result >=0 && result < min)
		{
			min = 1 + result;
		}
	}
	
	cache[remaining] = min != int.MaxValue ? min : -1;
	return cache[remaining];
}