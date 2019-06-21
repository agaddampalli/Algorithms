<Query Kind="Program" />

void Main()
{
	
}

public int[] TwoSum(int[] numbers, int target)
{
	int[] result = new int[2];
        int left = 0, right = numbers.Length - 1;
        while(left < right){
            if (numbers[left] + numbers[right] == target){
                result[0] = left + 1;
                result[1] = right + 1;
                return result;
		}
		else if (numbers[left] + numbers[right] > target)
		{
			right--;
		}
		else
		{
			left++;
		}
	}
	return result;
}
