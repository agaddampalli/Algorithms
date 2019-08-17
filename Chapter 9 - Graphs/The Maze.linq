<Query Kind="Program" />

void Main()
{
	var maze = new int[][] { 
	 new int[] {0,0,0,0,1,0,0}, 
	 new int[] {0,0,1,0,0,0,0},
	 new int[] {0,0,0,0,0,0,0},
	 new int[] {0,0,0,0,0,0,1},
	 new int[] {0,1,0,0,0,0,0},
	 new int[] {0,0,0,1,0,0,0},
	 new int[] {0,0,0,0,0,0,0},
	 new int[] {0,0,1,0,0,0,1},
	 new int[] {0,0,0,0,1,0,0}};

	var start = new int[] { 0, 0 };
	var end = new int[] {8, 6 };
	
	ShortestDistance(maze, start, end).Dump();
}

public bool ShortestDistance(int[][] maze, int[] start, int[] destination)
{
	if (maze == null || maze.Length == 0)
	{
		return false;
	}
	
	var visisted = new bool[maze.Length, maze[0].Length];
	
	BFS(maze, start, destination, visisted).Dump();
	
	visisted = new bool[maze.Length, maze[0].Length];
	return DFS(maze, start, destination, visisted);
}

public bool DFS(int[][] maze, int[] start, int[] destination, bool[,] visited)
{
	if (visited[start[0], start[1]])
	{
		return false;
	}
	
	if (start[0] == destination[0] && start[1] == destination[1])
	{
		return true;
	}

	visited[start[0], start[1]] = true;
	int r = start[1] + 1, l = start[1] - 1, up = start[0] - 1, down = start[0] + 1;
	
	//Go right
	while (r < maze[0].Length && maze[start[0]][r] == 0)
	{
		r++;
	}

	if (DFS(maze, new int[] { start[0], r-1 }, destination, visited))
	{
		return true;
	}

	//Go Left
	while (l >= 0 && maze[start[0]][l] == 0)
	{
		l--;
	}

	if (DFS(maze, new int[] { start[0], l+1}, destination, visited))
	{
		return true;
	}

	//Go Up
	while (up >= 0 && maze[up][start[1]] == 0)
	{
		up--;
	}

	if (DFS(maze, new int[] { up+1, start[1] }, destination, visited))
	{
		return true;
	}

	//Go Down
	while (down < maze.Length && maze[down][start[1]] == 0)
	{
		down++;
	}

	if (DFS(maze, new int[] { down-1, start[1] }, destination, visited))
	{
		return true;
	}
	
	return false;
}

public bool BFS(int[][] maze, int[] start, int[] destination, bool[,] visited)
{
	var queue = new Queue<int[]>();
	queue.Enqueue(start);
	visited[start[0], start[1]] = true;
	
	while(queue.Count != 0)
	{
		var node = queue.Dequeue();
		if (node[0] == destination[0] && node[1] == destination[1])
		{
			return true;
		}

		int r = node[1] + 1, l = node[1] - 1, up = node[0] - 1, down = node[0] + 1;

		while (r < maze[0].Length && maze[node[0]][r] == 0)
		{
			r++;
		}
		
		if(!visited[node[0], r-1])
		{
			queue.Enqueue(new int[] { node[0], r - 1 });
			visited[node[0], r - 1 ] = true;
		}

		while (l >= 0 && maze[node[0]][l] == 0)
		{
			l--;
		}

		if (!visited[node[0], l+1])
		{
			queue.Enqueue(new int[] { node[0], l+1});
			visited[node[0], l+1] = true;
		}

		while (up >= 0 && maze[up][node[1]] == 0)
		{
			up--;
		}

		if (!visited[up + 1, node[1]])
		{
			queue.Enqueue(new int[] {up + 1, node[1] });
			visited[up + 1, node[1]] = true;
		}

		while (down < maze.Length && maze[down][node[1]] == 0)
		{
			down++;
		}

		if (!visited[down - 1, node[1]])
		{
			queue.Enqueue(new int[] { down - 1, node[1] });
			visited[down - 1, node[1]] = true;
		}
	}

	return false;
}