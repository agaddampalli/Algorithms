<Query Kind="Program" />

public static void Main()
{
	var array = new int[] { 10, -2, -1, -1, 0, -2, 1 };
//	var array = new int[] { 10, 3, 30, 20, 40, 90, 1 };

	QuickSort(array, 0, array.Length - 1);

	array.Dump();
}

private static void QuickSort(int[] input, int lowestIndex, int highestIndex)
{
	if (lowestIndex < highestIndex)
	{
		var pivotIndex = PartitionFirst(input, lowestIndex, highestIndex);

		QuickSort(input, lowestIndex, pivotIndex - 1);

		QuickSort(input, pivotIndex + 1, highestIndex);
	}
}

private static int PartitionFirst(int[] input, int lowestIndex, int highestIndex)
{
	var pivot = input[lowestIndex];
	int tmp = 0;
	int startIndex = lowestIndex;

	for (int i = lowestIndex + 1; i <= highestIndex; i++)
	{
		if (input[i] <= pivot)
		{
			startIndex++;
			tmp = input[i];
			input[i] = input[startIndex];
			input[startIndex] = tmp;
		}
	}

	tmp = input[startIndex];
	input[startIndex] = input[lowestIndex];
	input[lowestIndex] = tmp;

	return startIndex;
}

private static int PartitionFirstLessPerformant(int[] input, int lowestIndex, int highestIndex)
{
	var pivot = input[lowestIndex];
	var pivotIndex = lowestIndex;
	int tmp = 0;
	int startIndex = lowestIndex;
	int j = 0;
	int y = 0;

	for (int i = lowestIndex + 1; i <= highestIndex; i++)
	{
		if (input[i] <= pivot)
		{
			j = i;
			y = i;
			while (j > startIndex)
			{
				j--;
				tmp = input[j];
				input[j] = input[y];
				input[y] = tmp;
				y--;
			}

			startIndex++;
		}
	}

	return startIndex;
}

private static int PartitionLast(int[] input, int lowestIndex, int highestIndex)
{
	var pivot = input[highestIndex];
	int startIndex = lowestIndex-1;
	int tmp =0;
	
	//10, 3, 30, 20, 40, 90, 1
	for (int i = lowestIndex ; i < highestIndex; i++)
	{
		if (input[i] <= pivot)
		{
			startIndex++;
			tmp = input[i];
			input[i] = input[startIndex];
			input[startIndex] = tmp;
		}
	}

	tmp = input[startIndex + 1];
	input[startIndex + 1] = input[highestIndex];
	input[highestIndex] = tmp;

	return startIndex + 1;
}