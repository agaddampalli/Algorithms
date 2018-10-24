<Query Kind="Program" />

void Main()
{
	var A = new List<int>{0, 3, 7, 6, 4, 0, 5, 5, 5 };
	
	A.Reverse();
	int carryOn = 0;
	int total = 0;
	bool isFirstItem = true;
	var outputList = new List<int>();
    foreach(var item in A)
    {
		if(isFirstItem)
		{
			total = A[0] + 1;
			if(total >= 10)
			{
				carryOn = total/10;
				outputList.Add(total % 10);
			}
			else
			{
				outputList.Add(total);
			}
			isFirstItem = false;
			continue;
		}
		
		total = carryOn + item;
		if(total >= 10)
		{
			carryOn = total/10;
			outputList.Add(total % 10);
		}
		else
		{
			outputList.Add(total);
			carryOn = 0;
		}
    }
	
	if(carryOn > 0){
		outputList.Add(carryOn);
	}
    outputList.Reverse();
    
	var outputListWithoutZeros = new List<int>();
	bool isMostSignificantDigit = false;
	foreach(var item in outputList)
	{
		if(item <= 0 && !isMostSignificantDigit)
		{
			continue;
		}
		outputListWithoutZeros.Add(item);
		isMostSignificantDigit = true;
	}
	
	outputListWithoutZeros.ToArray().Dump();
}

// Define other methods and classes here
