<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 2, 3, 4 };
	
	ProductExceptSelf(input).Dump();
}

public int[] ProductExceptSelf(int[] nums)
{
	
	var output = new int[nums.Length];
	
//	for (int i = 0; i < nums.Length; i++)
//	{
//		var value = 1;
//		for (int j = 0; j < nums.Length; j++)
//		{
//			if(i ==j )
//			{
//				continue;
//			}
//			
//			value = value * nums[j];
//		}
//		
//		output[i] = value;
//	}
	
	int[] leftProduct = new int[nums.Length];
    for (int i = 0, tmp = 1; i < nums.Length; i++) {
		leftProduct[i] = tmp;
		tmp *= nums[i];
	}
	
	int[] rightProduct = new int[nums.Length];
	for (int i = nums.Length - 1, tmp = 1; i >= 0; i--)
	{
		rightProduct[i] = tmp;
		tmp *= nums[i];
	}

	for (int i = 0; i < leftProduct.Length; i++)
	{
		output[i] = leftProduct[i] * rightProduct[i];
	}


	return output;
}
