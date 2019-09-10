<Query Kind="Program" />

void Main()
{
	var costs = new int[][] { 
	new int[] {259,770},
	new int[] {448,54},
	new int[] {926,667},
	new int[] {184,139},
	new int[] {840,118},
	new int[] {577,469}};
	
	TwoCitySchedCost(costs).Dump();
}

// https://leetcode.com/problems/two-city-scheduling/
public int TwoCitySchedCost(int[][] costs)
{
	Array.Sort(costs, (x,y) => (x[0] - x[1]) - (y[0] - y[1]));

	var sum1 = 0;
	var sum2 = 0;

	var mid = costs.Length/2;
	for (int i = 0; i < costs.Length; i++)
	{
		if(i < mid)
		{
			sum1 += costs[i][0];
			sum2 += costs[i][1];
		}
		else
		{
			sum2 += costs[i][0];
			sum1 += costs[i][1];
		}
	}

	return Math.Min(sum1, sum2);
}
