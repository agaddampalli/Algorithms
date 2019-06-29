<Query Kind="Program" />

void Main()
{
	var nums = new int[] {9,9,8};
	
	PlusOne(nums).Dump();
}

public int[] PlusOne(int[] digits)
{
	int carry = 0;
	
	for (int i = digits.Length - 1 ; i >=0 ; i--)
	{
		var sum = digits[i] + carry;
		
		if(i == digits.Length-1)
		{
			sum = sum +1 ;
		}
		
		carry = sum / 10;
		digits[i] = sum % 10;
	}
	
	if(carry > 0)
	{
		var output = new int[digits.Length +1];
		
		output[0] = carry;
		

		
		return output
	}
	
	return digits;
}