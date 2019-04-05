<Query Kind="Program" />

void Main()
{
	var input = new int[] {1,8,6,2,5,4,8,3,7};
	
	MaxArea(input).Dump();
}

public int MaxArea(int[] height)
{
	int maxArea = 0;
	int i =0 , j =height.Length-1;
//	for (int i = 0; i < height.Length; i++)
//	{
//		for (int j = 1; j < height.Length; j++)
//		{
//			 var area =  (j-i) * Math.Min(height[i] , height[j]); 
//			 if(area > maxArea)
//			 {
//			 	maxArea = area;
//			 }
//		}
//	}
	
	while(i<j)
	{
		maxArea = Math.Max(maxArea, (j-i) * Math.Min(height[i] , height[j]));
		if(height[i] < height[j])
		{
			i++;
		}
		else
		{
			j--;
		}
	}
	return maxArea;
}