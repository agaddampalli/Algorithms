<Query Kind="Program" />

void Main()
{
	var arr1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
	var arr2 = new int[] { 2, 1, 4, 3, 9, 6 };
	
	RelativeSortArray(arr1, arr2).Dump();
}

public Dictionary<int, int> arr2Dict;
public int[] RelativeSortArray(int[] arr1, int[] arr2)
{
	arr2Dict = new Dictionary<int, int>();
	for (int i = 0; i < arr2.Length; i++)
	{
		arr2Dict.Add(arr2[i], i);
	}
	
	Sort(arr1, 0, arr1.Length -1);
	
	return arr1;
}

public void Sort(int[] arr1, int left, int right)
{
	if (left > right)
	{
		return;
	}

	var pivot = Partition(arr1, left, right);

	Sort(arr1, left, pivot - 1);
	Sort(arr1, pivot + 1, right);
}

private int Partition(int[] arr1, int left, int right)
{
	var pivot = arr1[left];
	var index = left;
	var isPivotExists = arr2Dict.ContainsKey(pivot);

	if (isPivotExists)
	{
		var pivotIndex = arr2Dict[pivot];
		for (int i = left + 1; i <= right; i++)
		{
			if (!arr2Dict.ContainsKey(arr1[i]))
			{
				continue;
			}
			else if (pivotIndex > arr2Dict[arr1[i]])
			{
				index++;
				Swap(arr1, index, i);
			}
		}
	}
	else
	{
		for (int i = left + 1; i <= right; i++)
		{
			if (!arr2Dict.ContainsKey(arr1[i]) && pivot > arr1[i])
			{
				index++;
				Swap(arr1, index, i);
			}
			else if(arr2Dict.ContainsKey(arr1[i]))
			{
				index++;
				Swap(arr1, index, i);
			}
		}
	}

	Swap(arr1, index, left);

	return index;
}

private void Swap(int[] arr1, int i, int j)
{
	var temp = arr1[i];
	arr1[i] = arr1[j];
	arr1[j] = temp;
}