<Query Kind="Program" />

void Main()
{
	
}

public int MaxProfit(int[] prices)
{
	if (prices == null || prices.Length == 0)
	{
		return 0;
	}

	int minCurrent = prices[0];
	int maxProfit = 0;

	for (int i = 1; i < prices.Length; i++)
	{
		var profit = prices[i] - prices[i - 1];
		if (profit > 0)
		{
			maxProfit = maxProfit + profit;
		}
	}

	return maxProfit;
}
