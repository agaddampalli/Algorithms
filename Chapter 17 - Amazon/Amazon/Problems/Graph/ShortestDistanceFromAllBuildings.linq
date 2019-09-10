<Query Kind="Program" />

void Main()
{
	var grid = new int[][] { 
					new int[] {1,0,2,0,1},
					new int[] {1,0,0,0,0},
					new int[] {0,0,1,0,0}
					};
					
	ShortestDistance(grid).Dump();
}

//https://leetcode.com/problems/shortest-distance-from-all-buildings/

public int[][] grid;
public int rowLength;
public int colLength;
public int[][] directions = new int[][] { new int[]{ 0, 1 }, new int[]{ 0, -1 }, new int[]{ 1, 0 }, new int[]{-1, 0}};

public int ShortestDistance(int[][] grid)
{
	if (grid == null || grid.Length  == 0)
	{
		return -1;
	}
	
	this.grid = grid;
	
	this.rowLength = grid.Length;
	this.colLength = grid[0].Length;

	var buildings = new List<int[]>();
	var emptyAreas = new List<int[]>();
	
	for (int i = 0; i < rowLength; i++)
	{
		for (int j = 0; j < colLength; j++)
		{
			if(grid[i][j] == 1)
			{
				buildings.Add(new int[] {i,j});
			}

			if (grid[i][j] == 0)
			{
				emptyAreas.Add(new int[] { i, j });
			}
		}
	}
	
	if(emptyAreas.Count == 0)
	{
		return -1;
	}
	
	var dist = int.MaxValue;
	foreach (var emptyArea in emptyAreas)
	{
		var temp = BFS(emptyArea, buildings.Count);
		
		if(temp == -1)
		{
			continue;
		}
		
		if(temp < dist)
		{
			dist = temp;
		}
	}
	
	return dist == int.MaxValue ? -1 : dist;
}

private int BFS(int[] start, int buildings)
{
	var queue = new Queue<int[]>();
	queue.Enqueue(new int[] {start[0], start[1], 0});
	
	var visited = new bool[rowLength, colLength];
	
	int count = 0;
	while(queue.Count != 0)
	{
		var area = queue.Dequeue();
		
		foreach (var direction in directions)
		{
			var x = area[0] + direction[0];
			var y = area[1] + direction[1];
			
			if(x < 0 || x > rowLength-1 || y < 0 || y > colLength-1 || visited[x,y] || grid[x][y] == 2)
			{
				continue;
			}
			
			visited[x,y] = true;
			
			if (grid[x][y] == 1)
			{
				count += area[2] + 1;
				buildings--;
				
				if(buildings == 0)
				{
					return count;
				}
				
				continue;
			}
			
			queue.Enqueue(new int[] {x, y, area[2] + 1});
			
		}
	}
	
	return -1;
}