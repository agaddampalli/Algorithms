<Query Kind="Program" />

void Main()
{
	var length = 5;
	var input = new int[length, length];

	int count = 1;
	for (int i = 0; i < length; i++)
	{
		for (int j = 0; j < length; j++)
		{
			input[i, j] = count++;
		}
	}

	input[2,2] = 0;
	input.Dump();

	ZeroMatrix(input).Dump();
}

public int[,] ZeroMatrix(int[,] input)
{
	int M = input.GetLength(0);
	int N = input.GetLength(1);

	bool rowHasZero = false;
	bool columnHasZero = false;

	for (int i = 0; i < N; i++)
	{
		if (input[i, 0] == 0)
		{
			columnHasZero = true;
			break;
		}
	}

	for (int i = 0; i < M; i++)
	{
		if (input[0, i] == 0)
		{
			rowHasZero = true;
			break;
		}
	}

	for (int i = 1; i < M; i++)
	{
		for (int j = 1; j < N; j++)
		{
			if (input[i, j] == 0)
			{
				input[i, 0] = 0;
				input[0, j] = 0;
			}
		}
	}


	
	for (int i = 1; i < M; i++)
	{
		if (input[i, 0] == 0)
		{
			int j = 1;
			while (j < N)
			{
				input[i, j++] = 0;
			}
		}
	}


	for (int i = 1; i < N; i++)
	{
		if (input[0, i] == 0)
		{
			int j = 1;
			while (j < M)
			{
				input[j++, i] = 0;
			}
		}
	}


	if (rowHasZero)
	{
		int i = 0;
		while (i < M)
		{
			input[0, i++] = 0;
		}
	}
	
	if (columnHasZero)
	{
		int i = 0;
		while (i < N)
		{
			input[i++, 0] = 0;
		}
		
	}
	return input;
}