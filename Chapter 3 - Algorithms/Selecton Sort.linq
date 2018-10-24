<Query Kind="Program" />

void Main()
{
	int[] a = {3,2,1};
	

	for(int i=0; i<a.Length; i++)
	{
		var smallestNumber = a[i];
		var smallestIndex = i;
		for(int j=i+1; j< a.Length; j++)
		{
			if(smallestNumber >= a[j])
			{
				smallestNumber = a[j];
				smallestIndex =j;
			}
		}
		
		a[smallestIndex] = a[i];
		a[i] = smallestNumber;
	}
	
	a.Dump();
}

// Define other methods and classes here