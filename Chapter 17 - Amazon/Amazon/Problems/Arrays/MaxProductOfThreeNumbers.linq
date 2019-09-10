<Query Kind="Program" />

void Main()
{
	var nums = new int[] {-710,-107,-851,657,-14,-859,278,-182,-749,718,-640,127,-930,-462,694,969,143,309,904,-651,160,451,-159,-316,844,-60,611,-169,-73,721,-902,338,-20,-890,-819,-644,107,404,150,-219,459,-324,-385,-118,-307,993,202,-147,62,-94,-976,-329,689,870,532,-686,371,-850,-186,87,878,989,-822,-350,-948,-412,161,-88,-509,836,-207,-60,771,516,-287,-366,-512,509,904,-459,683,-563,-766,-837,-333,93,893,303,908,532,-206,990,280,826,-13,115,-732,525,-939,-787};
	
	MaximumProduct(nums).Dump();
}

public int MaximumProduct(int[] nums)
{
	
	Array.Sort(nums);
	
	var n = nums.Length;
	
	var prod1 = 0;
	if(nums[0] < 0 && nums[1] < 0)
	{
		prod1 = nums[0] * nums[1] * nums[n-1];
	}
	
	return Math.Max(nums[n-1] * nums[n-2] * nums[n-3], prod1);
}

public int MaximumProduct1(int[] nums)
{
	int min1 = Int32.MaxValue;
	int min2 = Int32.MaxValue;
	int max1 = Int32.MinValue;
	int max2 = Int32.MinValue;
	int max3 = Int32.MaxValue;


	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] < min1)
		{
			min2 = min1;
			min1 = nums[i];
		}
		else if (nums[i] < min2)
		{
			min2 = nums[i];
		}

		if (nums[i] > max1)
		{
			max3 = max2;
			max2 = max1;
			max1 = nums[i];

		}
		else if (nums[i] > max2)
		{
			max3 = max2;
			max2 = nums[i];
		}
		else if (nums[i] > max3)
		{
			max3 = nums[i];
		}

	}
	return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
}
