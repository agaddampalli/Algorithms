<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 2, 5, 10, 35, 89 };

	MinRopesCost(input).Dump();


	var stones = new int[] { 2, 7, 4, 1, 8, 1 };
	LastStoneWeight(stones).Dump();
}

public int LastStoneWeight(int[] stones)
{
	if (stones.Length == 1) return stones[0];
	Array.Sort(stones);
	while (stones[stones.Length - 2] != 0)
	{
		stones[stones.Length - 1] = stones[stones.Length - 1] - stones[stones.Length - 2];
		stones[stones.Length - 2] = 0;
		Array.Sort(stones);
	}
	return stones[stones.Length - 1];
}


public int MinRopesCost(int[] stones)
{
	var cost = 0;

	Array.Sort(stones, (x, y) => x - y);
	var stonesList = new List<int>(stones);

	while (stonesList.Count >= 2)
	{
		var length1 = stonesList[0];
		var length2 = stonesList[1];

		var temp = length1 + length2;

		stonesList.RemoveAt(0);
		stonesList.RemoveAt(0);
		stonesList.Add(temp);

		stonesList.Sort((x, y) => x - y);

		cost += temp;
	}

	return cost;
}