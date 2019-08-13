<Query Kind="Program" />

void Main()
{
	var gas = new int[] {1,2,3,4,5};
	var cost =  new int[] {3,4,5,1,2};
	
	CanCompleteCircuit(gas, cost).Dump();
}

public int CanCompleteCircuit(int[] gas, int[] cost)
{
	var sumRemainingGas = 0;
	var totalRemaining = 0;
	var startIndex = 0;
	
	for (int i = 0; i < gas.Length; i++)
	{
		var remaining = gas[i] - cost[i];
		
		if(sumRemainingGas >= 0)
		{
			sumRemainingGas += remaining;
		}
		else
		{
			sumRemainingGas = remaining;
			startIndex = i;
		}
		
		totalRemaining += remaining;
	}
	
	if(totalRemaining >= 0)
	{
		return startIndex;
	}
	
	return -1;
}