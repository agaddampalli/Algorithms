<Query Kind="Program" />

void Main()
{
	var gas = new int[] { 1,2,3,4,5 };
	var cost = new int[] { 3,4,5,1,2 };

	CanCompleteCircuit(gas, cost).Dump();
	CanCompleteCircuit1(gas, cost).Dump();
}

public int CanCompleteCircuit(int[] gas, int[] cost)
{
	var start = 0;
	var totalTank = 0;
	var currentTank = 0;
	for (var i = 0; i < gas.Length; i++)
	{
		currentTank += gas[i] - cost[i];
		totalTank += currentTank;
		if (currentTank < 0)
		{
			start = i + 1;
			currentTank = 0;
		}
	}
	return totalTank < 0 ? -1 : start;
}

public int CanCompleteCircuit1(int[] gas, int[] cost)
{
	for (int i = 0; i < gas.Length; i++)
	{
		if (gas[i] >= cost[i] && CheckCircuit(gas, cost, i))
		{
			return i;
		}
	}

	return -1;
}

public bool CheckCircuit(int[] gas, int[] cost, int start)
{
	int currentGas = gas[start];
	int nextCost = cost[start];

	int i = start + 1;

	if (i >= gas.Length)
	{
		i = 0;
	}

	while (i != start)
	{
		var temp = currentGas - nextCost + gas[i];
		if (temp < cost[i])
		{
			return false;
		}

		currentGas = temp;
		nextCost = cost[i];

		i++;

		if (i >= gas.Length)
		{
			i = 0;
		}
	}

	return true;
}