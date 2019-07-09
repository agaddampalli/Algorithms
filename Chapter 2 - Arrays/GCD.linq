<Query Kind="Program" />

static int gcd(int a, int b) 
    {
	if (a == 0)
		return b;
	return gcd(a % b, b);
}

// Function to find gcd of  
// array of numbers 
static int findGCD(int[] arr, int n)
{
	int result = arr[0];
	for (int i = 1; i < n; i++)
		result = gcd(arr[i], result);

	return result;
}

// Driver Code 
public static void Main()
{
	int[] arr = { 2, 4, 6, 8, 16 };
	int n = arr.Length;
	Console.Write(findGCD(arr, n));
}
