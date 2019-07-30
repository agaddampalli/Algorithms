<Query Kind="Program" />

void Main()
{
	var states = new int[] { 1, 0, 0, 0, 0, 0, 0, 1 };

	//	cellComplete(states, 1).Dump();

	var cells = new int[] {1,0,0,1,0,0,1,0 };
	PrisonAfterNDaysCorrect(cells, 1000000000).Dump();
	PrisonAfterNDays(cells, 1000000000).Dump();
}


public int[] PrisonAfterNDaysCorrect(int[] cells, int N)
{
	if (cells == null || !cells.Any() || N == 0)
	{
		return cells;
	}

	var state = State(cells);
	var dictionary = new Dictionary<int, int[]> { { state, cells } };
	var statesList = new List<int>();
	statesList.Add(state);

	int i = 0;
	for (i = 0; i < N; i++)
	{
		var temp = StateForDay(cells);
		var currentState = State(temp);
		if (dictionary.ContainsKey(currentState))
		{
			break;
		}

		dictionary.Add(currentState, temp);
		statesList.Add(currentState);
		
		cells = temp;
	}

	var index = N % i == 0 ? i : N % i;

	return dictionary[statesList[index]];
}


public int[] PrisonAfterNDays(int[] cells, int N)
{
	if (cells == null || !cells.Any() || N == 0)
	{
		return cells;
	}

	N = N % 14 == 0 ? N : N % 14;

	for (int i = N; i > 0; i--)
	{
		cells = StateForDay(cells);
	}

	return cells;
}

private int[] StateForDay(int[] cells)
{
	var temp = new int[cells.Length];
	for (int j = 1; j < cells.Length; j++)
	{
		if (j == cells.Length - 1)
		{
			temp[j] = 0;
		}
		else if (cells[j - 1] == cells[j + 1])
		{
			temp[j] = 1;
		}
		else
		{
			temp[j] = 0;
		}
	}

	return temp;
}

private int State(int[] cells)
{
	int state = 0;
	for (int i = 0; i < cells.Length; i++)
	{
		if (cells[i] > 0)
		{
			state ^= (1 << i);
		}
	}

	return state;
}



public int[] cellComplete(int[] states, int days)
{

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