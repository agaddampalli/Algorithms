<Query Kind="Program" />

void Main()
{
	 var A = new List<int>{ 4, 6, 5, 5, 6, 6, 5, 6, 7, 5, 5, 7, 7 };
	 
	 // i = 2
	 if(A == null || !A.Any())
	 {
	 	0.Dump();
 	 }
	 
	 int leftSpecialValue = 0;
	 bool isMultipleLeftSpecialValues = false;
	 int rightSpecialValue = 0;
	 bool isMultipleRightSpecialValues = false;
	 long maximumProduct = 0;
	 for(int i = 0 ; i< A.Count; i++)
	 {
	 	for(int j = 0; j< A.Count; j++)
		{
			if(i > j && A[j] > A[i])
			{
				if(!isMultipleLeftSpecialValues)
				{
					leftSpecialValue = j;
					isMultipleLeftSpecialValues = true;
				}
				else if(j > leftSpecialValue)
				{
					leftSpecialValue = j;
				}	
			}
			
			if(j > i && A[j] > A[i])
			{
				if(!isMultipleRightSpecialValues)
				{
					rightSpecialValue = j;
					isMultipleRightSpecialValues = true;
				}
				else if(j < rightSpecialValue)
				{
					rightSpecialValue = j;
				}
			}
		}
		
		$"{i} : {A[i]} : {(leftSpecialValue * rightSpecialValue)}".Dump();
		if(maximumProduct < leftSpecialValue * rightSpecialValue)
		{
			maximumProduct = leftSpecialValue * rightSpecialValue;
		}	
		leftSpecialValue = 0;
		rightSpecialValue = 0;
		isMultipleLeftSpecialValues = false;
		isMultipleRightSpecialValues = false;
	 }
	 
	 ("*******").Dump();
	 maximumProduct.Dump();
}


