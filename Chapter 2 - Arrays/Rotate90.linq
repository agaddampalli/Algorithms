<Query Kind="Program" />

void Main()
{
	var length = 5;
	var input = new int[length,length];
	
	int count = 1;
	for (int i = 0; i < length; i++)
	{
		for (int j = 0; j < length; j++)
		{
			input[i,j] = count++;
		}
	}
	
	input.Dump();

	Rotate90(input).Dump();
	PerfRotate90(input).Dump();
}

public int[,] Rotate90(int[,] input)
{
	var length = input.GetLength(0);
	var output = new int[length, length];
	for (int i = 0; i < length; i++)
	{
		int k = 0;
		for (int j = length-1; j >= 0; j--)
		{
			output[i, k++] = input[j,i];
		}
	}
	
	return output;
}

public int[,] PerfRotate90(int[,] input)
{
	
	var k = input.GetLength(0)-1;
	
	int j =0;
	int previousValue = 0;
	while(j < k)
	{
		int i = j;
		int n = k - j;
		while (i < n)
		{
			var temp = input[i, n];
			input[i, n] = input[j, i];

			previousValue = input[n, k - i];
			input[n, k - i] = temp;
			temp = previousValue;

			previousValue = input[k - i, j];
			input[k - i, j] = temp;
			temp = previousValue;

			input[j, i] = temp;

			i++;
		}
		
		j++;
	}




	return input;
}