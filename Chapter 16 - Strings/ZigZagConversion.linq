<Query Kind="Program" />

void Main()
{
	Convert("PAYPALISHIRING", 4).Dump();
}

public string Convert(string s, int numRows)
{
	if(numRows <= 1)
	{
		return s;
	}
	var temp = new StringBuilder[numRows];
	
	for (int i = 0; i < numRows; i++)
	{
		temp[i] = new StringBuilder();
	}
	
	var currentRow = 0;
	var isDownward = false;
	for (int i = 0; i < s.Length; i++)
	{
		temp[currentRow].Append(s[i]);
		
		if(currentRow == 0 || currentRow == numRows -1)
		{
			isDownward = !isDownward;
		}
		
		currentRow += isDownward ? 1 : -1;
	}
	
	return temp.Aggregate((x,y) => x.Append(y)).ToString();
}
