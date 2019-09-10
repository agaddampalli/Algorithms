<Query Kind="Program" />

void Main()
{
	var s1 = "AABC";
	var s2 = "AACB";
	
	CountSteps(s1.ToCharArray(), s2.ToCharArray()).Dump();
}

public int CountSteps(char[] s1, char[] s2)
{
	int i = 0, j = 0;
	int result = 0;

	// Iterate over the first string and convert 
	// every element equal to the second string 
	while (i < s1.Length)
	{
		j = i;

		// Find index element of first string which 
		// is equal to the ith element of second string 
		while (s1[j] != s2[i])
		{
			j++;
		}

		// Swap adjacent elements in first string so 
		// that element at ith position becomes equal 
		while (i < j)
		{

			// Swap elements using temporary variable 
			char temp = s1[j];
			s1[j] = s1[j - 1];
			s1[j - 1] = temp;
			j -= 1;
			result += 1;
		}
		i++;
	}
	
	return result;
}