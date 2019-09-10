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
	int maxProfit = int.MinValue;

	for (int i = 1; i < prices.Length; i++)
	{
		minCurrent = prices[i] < minCurrent ? prices[i] : minCurrent;
		var profit = prices[i] - minCurrent;
		maxProfit = maxProfit > profit ? maxProfit : profit;
	}

	if (maxProfit < 0)
	{
		return 0;
	}

	return maxProfit;
}
