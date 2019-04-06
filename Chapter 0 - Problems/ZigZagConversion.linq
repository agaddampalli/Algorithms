<Query Kind="Program" />

void Main()
{
	var s = "AB";
	
	
	var length = s.Length;
	int numRows = 4;
	
	 if (numRows == 1)  s.Dump();
	 
	var rows = new List<StringBuilder>();

	for (int i = 0; i < Math.Min(numRows, length); i++)
	{
		rows.Add(new StringBuilder());
	}
	
	int currentRow =0;
	bool goingDown = false;
	for (int j = 0; j < s.Length; j++)
	{
		rows[currentRow].Append(s[j]);
		
		if(currentRow == 0 || currentRow == numRows-1)
		{
			goingDown = !goingDown;
		}
		
		currentRow += goingDown ? 1: -1;
	}
	
	var completeString = string.Empty;
	foreach (var element in rows)
	{
		completeString += element;
	}
	
	completeString.Dump();
}

