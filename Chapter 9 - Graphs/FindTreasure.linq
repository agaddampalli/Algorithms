<Query Kind="Program" />

void Main()
{
	var graph = new int[,] { { 1, 0, 0, 1 }, 
							 { 0, 0, 0, 1 },
							 { 1, 1, 1, 1 },
							 { 1, 0, 0, 2 }};
							 
	FindTreasure(graph).Dump();
}

public int distance = int.MaxValue;

public int FindTreasure(int[,] graph)
{
	Find(graph, 0, 0, 0);
	
	return distance == int.MaxValue ? -1 : distance;
}


public void Find(int[,] graph, int row, int col, int count)
{
	if(row < 0 || row > graph.GetLength(0)-1 || col < 0 || col > graph.GetLength(1)-1 || graph[row,col] == 0)
	{
		return;
	}
	
	if( graph[row,col] == 2)
	{
		distance = Math.Min(count, distance);
		return;
	}
	
	var temp = graph[row,col];
	graph[row,col] = 0;

	Find(graph, row + 1, col, count + 1);
	Find(graph, row - 1, col, count + 1);
	Find(graph, row, col+1, count + 1);
	Find(graph, row, col-1, count + 1);
	
	graph[row,col] = temp;
}