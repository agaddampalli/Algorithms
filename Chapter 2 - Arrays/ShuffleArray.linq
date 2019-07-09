<Query Kind="Program" />

void Main()
{
	var nums = new int[] {-6, 10,184};
	var sol = new Solution(nums);
	
	sol.Shuffle().Dump();
}

public class Solution
{
	private int[] sourceArray;
	private int[] shuffledArray;
	private Random random = new Random();

	public Solution(int[] nums)
	{
		sourceArray = nums;
		shuffledArray = new int[nums.Length];
		Array.Copy(nums, shuffledArray, nums.Length);
	}

	/** Resets the array to its original configuration and return it. */
	public int[] Reset()
	{
		Array.Copy(sourceArray, shuffledArray, sourceArray.Length);
		return sourceArray;
	}

	/** Returns a random shuffling of the array. */
	public int[] Shuffle()
	{
		for (int i = 0; i < shuffledArray.Length; i++)
		{
			Swap(i, random.Next(shuffledArray.Length - 1));
		}

		return shuffledArray;
	}

	public void Swap(int i, int j)
	{
		var temp = shuffledArray[i];
		shuffledArray[i] = shuffledArray[j];
		shuffledArray[j] = temp;
	}
}
