<Query Kind="Program" />

void Main()
{
	var ratings = new int[] {1 , 0, 2};
	
	DistributeCandy(ratings).Dump();
}

public int DistributeCandy(int[] ratings)
{
	var candies = new int[ratings.Length];
	
	candies[0] = 1;
	
	for (int i = 1; i < ratings.Length; i++)
	{
		if(ratings[i] > ratings[i-1])
		{
			candies[i] = candies[i-1] + 1;
		}
		else
		{
			candies[i] = 1;
		}
	}
	
	var output = candies[ratings.Length-1];
	for (int i = ratings.Length-1; i > 0; i--)
	{
		var curr = 1;
		if(ratings[i-1] > ratings[i])
		{
			curr = candies[i] + 1;
		}
		
		candies[i-1] = Math.Max(curr, candies[i-1]);
		output += candies[i-1];
	}
	
	candies.Dump();
	
	return output;
}
