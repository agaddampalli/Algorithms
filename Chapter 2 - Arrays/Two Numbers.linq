<Query Kind="Program" />

void Main()
{
	int[] nums = {0, 5, 5, 2};
	TwoSumLessTime(nums,10).Dump();
}

 private static int[] TwoSum(int[] nums, int target) 
 {
       //more time
       for(int i=0;i<nums.Length;i++)
        {
            for(int j=i+1;j<nums.Length; j++)
            {
                if(nums[i]+nums[j] == target)
                {
                    return new int[]{i, j};
                }
            }
        }
        
        return null;
}

private static int[] TwoSumLessTime(int[] nums, int target) 
 {
 	   Dictionary<int,int> numsDict = new Dictionary<int,int>();
       for(int i=0;i<nums.Length;i++)
       {
       		if(numsDict.TryGetValue(target-nums[i], out int index))
			{
			   return new int[]{index, i};
			}
			
			numsDict.Add(nums[i], i);
       }
        
        return null;
}
// Define other methods and classes here
