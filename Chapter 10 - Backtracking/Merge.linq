<Query Kind="Program" />

void Main()
{
	var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
	var nums2 = new int[] { 2, 5, 6 };

	Merge(nums1, 3, nums2, 3);
}

public void Merge(int[] nums1, int m, int[] nums2, int n)
{
	for (int i = m - 1, j = n - 1, k = m + n - 1; k >= 0 && j >= 0; k--)
	{
		if (i < 0 || nums1[i] < nums2[j])
		{
			nums1[k] = nums2[j--];
		}
		else
		{
			nums1[k] = nums1[i--];
		}
	}
	
	nums1.Dump();
}