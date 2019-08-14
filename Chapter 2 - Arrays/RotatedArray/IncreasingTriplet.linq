<Query Kind="Program" />

void Main()
{
	
}

public bool IncreasingTriplet(int[] nums)
{
	int small = int.MaxValue;
	int big = int.MaxValue;

	foreach (int num in nums)
	{
		if (num <= small)
		{
			small = num;// update x to be a smaller value
		}
		else if (num <= big)
		{
			big = num; // update y to be a smaller value
		}
		else
		{
			return true;
		}
	}

	return false;
}
