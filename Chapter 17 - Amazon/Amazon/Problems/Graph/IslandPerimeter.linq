<Query Kind="Program" />

void Main()
{
	var grid = new int[][] {
	new int[] {1},
	new int[] {1}
	};
	
	IslandPerimeter(grid).Dump();
}

//https://leetcode.com/problems/island-perimeter/
public int IslandPerimeter(int[][] grid)
{
	if (grid == null || grid.Length == 0)
	{
		return 0;
	}
	
	var m = grid.Length;
	var n = grid[0].Length;
	var queue = new Queue<int[]>();
	bool found = false;
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if(grid[i][j] == 1)
			{
				queue.Enqueue(new int[] {i, j});
				found = true;
				break;
			}
		}
		
		if(found) 
		{
			break;
		}
	}

	int count = 0;
	var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 }};
	var visited = new bool[m,n];
	
	while(queue.Count != 0)
	{
		var node = queue.Dequeue();
		visited[node[0], node[1]] = true;
		
		foreach (var dir in directions)
		{
			var x = node[0] + dir[0];
			var y = node[1] + dir[1];
			
			if(x < 0 || x > m-1 || y< 0|| y > n-1 || grid[x][y] == 0)
			{
				count++;
				continue;
			}
			
			if(!visited[x,y])
			{
				queue.Enqueue(new int[] {x, y});
				visited[x,y] = true;
			}
		}
	}
	
	return count;
}

