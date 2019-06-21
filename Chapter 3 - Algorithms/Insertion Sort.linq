<Query Kind="Program" />

void Main()
{
	var a = new List<int>{8,3,6,2,1,11,10,7,9,1,2,3};
	
	for(int i =1; i< a.Count ; i++)
	{
		var currentNumber = a[i];
		int j = i-1;
		while(j >= 0 && a[j] > currentNumber)
		{
			var temp = a[j];
			a[j+1] = temp;
			a[j] = currentNumber;
			j--;
		}
	}
	
	a.Dump();
	
	for(int i =1; i< a.Count ; i++)
	{
		var currentNumber = a[i];
		int j = i-1;
		while(j >= 0 && a[j] < currentNumber)
		{
			var temp = a[j];
			a[j+1] = temp;
			a[j] = currentNumber;
			j--;
		}
	}
	
	a.Dump();
}

// Define other methods and classes here