<Query Kind="Program" />

void Main()
{
	int[] nums1 = {1,2};
	int[] nums2 = {3};
	var length = nums1.Length + nums2.Length;
	var output =  new int[length];
	float median = 0f;
	
	int i=0,j=0;
	for(int k = 0; k < length; k++)
	{
		if (i == nums1.Length)
        {
            output[k] = nums2[j];
            j++;
        }
        else if (j == nums2.Length)
        {
            output[k] = nums1[i];
            i++;
        }
		else if(nums1[i] <= nums2[j])
		{
			output[k] = nums1[i];
			i++;
		}
		else
		{
			output[k] = nums2[j];
			j++;
		}
	}

	var middle = length/2;
	if(length%2 == 0)
	{
		median = (output[middle] + output[middle-1])/2f;
	}
	else
	{
		median = output[middle];
	}
	
	output.Dump();
	median.Dump();
}

private static int[] Merge(int[] nums1, int[] nums2)
{
	var length = nums1.Length + nums2.Length;
	var output =  new int[length];
	
	int i=0,j=0;
	for(int k = 0; k < length; k++)
	{
		if (i == nums1.Length)
        {
            output[k] = nums2[j];
            j++;
        }
        else if (j == nums2.Length)
        {
            output[k] = nums1[i];
            i++;
        }
		else if(nums1[i] <= nums2[j])
		{
			output[k] = nums1[i];
			i++;
		}
		else
		{
			output[k] = nums2[j];
			j++;
		}
	}
	
	return output;
}
// Define other methods and classes here