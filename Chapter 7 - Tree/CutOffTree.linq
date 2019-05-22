<Query Kind="Program" />

void Main()
{

	var input = new List<IList<int>> {
		new List<int> {1,2,3},
		new List<int> {0,0,4},
		new List<int> {7,6,5},
	};

	CutOffTree(input).Dump();
}

public int CutOffTree(IList<IList<int>> forest)
{
	if (forest == null)
	{
		return -1;
	}

	int rowIndex = 0;
	int columnIndex = 0;
	
	int smallestNumber = forest[0][0];
	
	for (int i = 0; i < forest.Count; i++)
	{
		for (int j = 0; j < forest[i].Count; j++)
		{
			if(forest[i][j] < smallestNumber)
			{
				smallestNumber = forest[i][j];
				rowIndex = i;
				columnIndex = j;
			}
		}
	}
	
	

	return -1;
}


