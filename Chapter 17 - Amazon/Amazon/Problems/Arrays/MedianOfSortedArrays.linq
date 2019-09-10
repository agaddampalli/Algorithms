<Query Kind="Program" />

void Main()
{
	var a = new int[] { 1, 2, 3, 4, 5 };
	var b = new int[] { 6, 7, 8, 9, 10};
	
	FindMedian(a,b).Dump();
}

// 1 2 3 4 6 7 8 9 10 11 15

/* 
Brute force is merging both the arrays and finding median.
Time & Space Complexity: O(m+n)
Better approach is doing a binary search to get the Time complexity to O(logn)

1. Find the smaller array
2. Partition the array into two halfs by doing binary search

	1 2 3 4 5   ==> start = 0 , end = length -1 (4) --> partition = 0+4/2 = 2
	
	6 7 8 9 10 11 ==> (lengthA + lengthB + 1)/2 - PartitionValue of A ==>  (5+6+1)/2 - 2= 4
	
	in first case we saw 2 elements in the left and 3 elements to the right
	int the second array we saw  4 elements in the left and 2 elements in the right

*/
public double FindMedian(int[] a, int[] b)
{
	if(a.Length > b.Length)
	{
		return FindMedian(b, a);
	}
	
	var x = a.Length;
	var y = b.Length;
	
	var length = x + y;
	bool isEven = length % 2 ==0;

	var start = 0;
	var end = x;
	
	while(start <= end)
	{
		var mid = (start + end)/2;

		var xleft = mid == 0 ? int.MinValue : a[mid - 1];
		var xright = mid == x ? int.MaxValue : a[mid];
		
		var longPartitionIndex = (x + y + 1)/2 - mid;

		var yleft = longPartitionIndex == 0 ? int.MinValue : b[longPartitionIndex - 1];
		var yright = longPartitionIndex == y ? int.MaxValue : b[longPartitionIndex];
		
		if(xleft <= yright && yleft <= xright)
		{
			if(isEven)
			{
				return (double) (Math.Max(xleft,yleft) + Math.Min(xright,yright))/2;
			}
			
			return Math.Max(xleft,yleft);
		}
		else if(yleft > xright)
		{
			start = mid + 1;
		}
		else
		{
			end = mid - 1;
		}
	}
	
	return -1;
}

class MedianFinder
{
	int[] A = new int[100]; int n = 0;

	public void addNum(int num)
	{
		A[num]++;
		n++;
	}

	public double findMedian()
	{
		int count = 0, i = 0;
		while (count < n / 2) count += A[i++];
		int j = i;
		while (count < n / 2 + 1) count += A[j++];
		return (n % 2 == 1) ? j - 1 : (i + j - 2) / 2.0;
	}
}