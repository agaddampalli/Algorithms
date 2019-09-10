<Query Kind="Program" />

void Main()
{
	var input = new int[] {1,7,2,4};

	MaxProfit(input).Dump();
	MaxProfit1(input).Dump();
	MaxProfitBruteForce(input).Dump();
}

public int MaxProfit1(int[] prices)
{
	if (prices.Length <= 1)
		return 0;

	int prevSell = 0;
	int buy = int.MaxValue;
	int sell = 0;

	for (int i = 0; i < prices.Length; i++)
	{
		buy = Math.Min(buy, prices[i] - prevSell);
		prevSell = sell;
		sell = Math.Max(sell, prices[i] - buy);
	}

	return sell;
}

public int MaxProfit(int[] prices)
{
	if (prices == null || prices.Length <= 1) { return 0; }

	// if we were to end day 0 bought, we would actually owe money at this point
	int boughtDMinus1 = -prices[0];

	// if we were to end day 0 sold, our purse would still be empty
	int soldDMinus1 = 0;        // purse is still empty
	int soldDMinus2 = 0;        // purse is still empty

	for (int i = 1; i < prices.Length; i++)
	{
		int bDM1 = boughtDMinus1;
		boughtDMinus1 = Math.Max(
			boughtDMinus1, soldDMinus2 - prices[i]);
		soldDMinus2 = soldDMinus1;
		soldDMinus1 = Math.Max(
			soldDMinus1, bDM1 + prices[i]);
	}

	return Math.Max(boughtDMinus1, soldDMinus1);
}
public int MaxProfitBruteForce(int[] prices)
{
	if (prices == null || prices.Length == 0)
	{
		return 0;
	}
	
	return BackTrack(prices, 0);
}

public int BackTrack(int[] prices, int index)
{
	if(index > prices.Length-1)
	{
		return 0;
	}
	
	var max = 0;
	for (int i = index; i < prices.Length; i++)
	{
		for (int j = i + 1; j < prices.Length; j++)
		{
			var temp = prices[j] - prices[i];
			var profit = 0;
			if (temp > 0)
			{
				profit = temp + BackTrack(prices, j + 2);
			}

			max = Math.Max(max, profit);
		}
	}
	
	return max;
}