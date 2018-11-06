<Query Kind="Program" />

public static void Main()
{
	var array = new int[]{10, 3, 20, 50, 30, 40, 90, 1};
	
	QuickSort(array, 0, array.Length-1);
	
	array.Dump();
}

private static void QuickSort(int[] input, int lowestIndex, int highestIndex)
{
	while(lowestIndex < highestIndex)
	{
		var pivotIndex = Partition(input, lowestIndex, highestIndex);
		
		
//		$"FirstLevel Sorting : LowIndex: {lowestIndex}; PivotIndex: {pivotIndex}; HighestIndex: {highestIndex};".Dump();
		QuickSort(input, lowestIndex, pivotIndex-1);
		
//		$"Second Sorting : LowIndex: {lowestIndex}; PivotIndex: {pivotIndex}; HighestIndex: {highestIndex};".Dump();
		QuickSort(input, pivotIndex+1, highestIndex);
	}
}

private static int Partition(int[] input, int lowestIndex, int highestIndex)
{
	var pivot = input[lowestIndex];
	var pivotIndex = lowestIndex;
	int i = 0;
	
	for(int j= lowestIndex ; j <= highestIndex; j++)
	{
		if(input[j] <= pivot)
		{
			i++;
			var tmp = input[j];
			input[i] = tmp;
			input[j] = pivot;
		}
	}
	
	var temp = input[i];
	input[pivotIndex] = temp;
	input[i] = pivot;
	
	input.Dump();
	return i;
}