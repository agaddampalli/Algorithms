<Query Kind="Program" />

void Main()
{
//	Generate(28).Dump();
	
	GetRow(4).Dump();
}

public IList<IList<int>> Generate(int numRows)
{
	var output = new List<IList<int>>();
	
	for (int i = 0; i < numRows; i++)
	{
		var currentList = new List<int>();
		var j =0;
		
		while (j<=i)
		{
			if(j == 0 || j == i)
			{
				currentList.Add(1);
			}
			else
			{
				currentList.Add(output[i-1][j-1] + output[i-1][j]);
			}
			
			j++;
		}
		
		output.Add(currentList);
	}
	
	return output;
}

public IList<int> GetRow(int rowIndex)
{
	var output = new List<int>();
	
	for (int i = 0; i <= rowIndex; i++)
	{
		output.Add(1);
		for (int j = i-1; j > 0; j--)
		{
			output[j] = output[j-1] + output [j];  
		}
	}
	
	return output;
}

private int GetValue(int rowIndex, int columnIndex)
{
	if(columnIndex == 0 || columnIndex == rowIndex)
	{
		return 1;
	}
	
	return GetValue(rowIndex -1, columnIndex -1) + GetValue(rowIndex -1, columnIndex);
}