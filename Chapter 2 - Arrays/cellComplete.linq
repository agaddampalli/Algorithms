<Query Kind="Program" />

void Main()
{
	var states = new int[] { 1, 0, 0, 0, 0, 0, 0, 1 };

	cellComplete(states, 1).Dump();
}


public int[] cellComplete(int[] states, int days)
{
	if (states == null || !states.Any() || days == 0)
	{
		return states;
	}

	for (int i = 0; i < days; i++)
	{
		var currentState = states[0];
		for (int j = 0; j < states.Length; j++)
		{
			if (j == 0 && j + 1 < states.Length)
			{
				if (states[j + 1] == 1)
					states[j] = 1;
				else
					states[j] = 0;
			}
			else if (j == states.Length - 1 && j - 1 > 0)
			{
				if (currentState == 1)
					states[j] = 1;
				else
					states[j] = 0;
			}
			else
			{
				var nextState = states[j + 1];
				var previousState = currentState;
				currentState = states[j];

				if ((nextState == 1 && previousState == 1) || (nextState == 0 && previousState == 0))
				{
					states[j] = 0;
				}
				else
				{
					states[j] = 1;
				}
			}
		}
	}

	return states;
}
