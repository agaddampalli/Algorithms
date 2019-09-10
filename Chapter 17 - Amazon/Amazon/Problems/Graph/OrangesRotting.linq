<Query Kind="Program" />

void Main()
{
	var grid = new int[][] {
		new int[]{1,2,1,1,2,1,1}
		};
		
	OrangesRotting(grid).Dump();
}

public int[][] directions = new int[][]{
		new int[]{-1, 0}, //up
        new int[]{0, 1},//right
        new int[]{1, 0},//down
        new int[]{0, -1} ,//left
    };
	
public int OrangesRotting(int[][] grid)
{
	int count = 0;
	var queue = new Queue<int[]>();
	for (int i = 0; i < grid.Length; i++)
	{
		for (int j = 0; j < grid[0].Length; j++)
		{
			if(grid[i][j] == 2)
			{
				queue.Enqueue(new int[] {i, j});
			}
		}
	}

	while (queue.Count != 0)
	{
		var size = queue.Count;
		bool found = false;
		for (int i = 0; i < size; i++)
		{
			var node = queue.Dequeue();
			foreach (var dir in directions)
			{
				var x = node[0] + dir[0];
				var y = node[1] + dir[1];

				if (x < 0 || x > grid.Length - 1 || y < 0
					|| y > grid[0].Length - 1
					|| grid[x][y] == 0 || grid[x][y] == 2)
				{
					continue;
				}
				
				found = true;
				grid[x][y] = 2;
				queue.Enqueue(new int[] { x, y });
			}
		}
		
		if(found)
		{
		  count++;
		}
	}
	
	for (int i = 0; i < grid.Length; i++)
	{
		for (int j = 0; j < grid[0].Length; j++)
		{
			if (grid[i][j] == 1)
			{
				return -1;
			}
		}
	}
	
	return count;
}


	
public int BFS(int[][] grid, int row, int col)
{
	int count = -1;
	
	var queue = new Queue<int[]>();
	queue.Enqueue(new int[] {row, col});
	
	while(queue.Count != 0)
	{
		var size = queue.Count;
		
		for (int i = 0; i < size; i++)
		{
			var node = queue.Dequeue();
			foreach (var dir in directions)
			{
				var x = node[0] + dir[0];
				var y = node[1] + dir[1];
				
				if( x < 0 || x > grid.Length-1 || y< 0 
					|| y> grid[0].Length -1 
					|| grid[x][y] == 0 || grid[x][y] == 2)
				{
					continue;
				}
				
				grid[x][y] = 2;
				queue.Enqueue(new int[] {x,y});
			}
		}
		
		count++;
	}
	
	return count;
}