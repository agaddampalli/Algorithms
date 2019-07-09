<Query Kind="Program" />

void Main()
{
	var input = new List<IList<int>>{
					new List<int>{0,2,3},
					new List<int>{0,0,4},
					new List<int>{7,6,5}
					};
					
	CutOffTree(input).Dump();
	input.Dump();
}

public int count = 0;
public int CutOffTree(IList<IList<int>> forest)
{

	DFS(forest, 0, 0);

	for (int i = 0; i < forest.Count; i++)
	{
		for (int j = 0; j < forest[i].Count; j++)
		{
			if (forest[i][j] > 1)
			{
				return -1;
			}
		}
	}
	
	return count;
}

public void DFS(IList<IList<int>> forest, int row, int column)
{
	if (row > forest.Count || row < 0 || column < 0 || column > forest[row].Count || forest[row][column] == 0)
	{
		return;
	}
	
	forest[row][column] = 1;
	
	if(row + 1 < forest.Count && forest[row+1][column] > 1)
	{
		count++;
		DFS(forest, row+1, column);
	}

	if (row - 1 >= 0 && forest[row - 1][column] > 1)
	{
		count++;
		DFS(forest, row - 1, column);
	}

	if (column - 1 >= 0 && forest[row][column-1] > 1)
	{
		count++;
		DFS(forest, row, column-1);
	}

	if (column + 1 < forest[row].Count && forest[row][column + 1] > 1)
	{
		count++;
		DFS(forest, row, column + 1);
	}
}