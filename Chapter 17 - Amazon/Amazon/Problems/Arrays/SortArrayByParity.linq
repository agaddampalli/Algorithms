<Query Kind="Program" />

void Main()
{
	var nums = new int[] {3,2,4,1,6};
	
	SortArrayByParity(nums).Dump();
}

//https://leetcode.com/problems/sort-array-by-parity/
public int[] SortArrayByParity1(int[] A)
{

	Array.Sort(A, new Comparator());

	return A;
}

public int[] SortArrayByParity(int[] A)
{
	int left = 0;
	int right = A.Length - 1;

	while (left != right)
	{
		if (A[left] % 2 == 0)
		{
			left++;
		}
		else
		{
			var a = A[left];
			A[left] = A[right];
			A[right] = a;
			right--;
		}
	}
	
	return A;
}

public class Comparator : IComparer<int>
{
	public int Compare(int x, int y)
	{
		if(x % 2 == 0 && y % 2 == 1)
		{
			return -1;
		}
		else if(x % 2 == 1 && y % 2 == 0)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}
}