<Query Kind="Program" />

void Main()
{
	var maze = new int[][] {
	new int[]{0,0,0,0,1,0,0},
	new int[]{0,0,1,0,0,0,0},
	new int[]{0,0,0,0,0,0,0},
	new int[]{0,0,0,0,0,0,1},
	new int[]{0,1,0,0,0,0,0},
	new int[]{0,0,0,1,0,0,0},
	new int[]{0,0,0,0,0,0,0},
	new int[]{0,0,1,0,0,0,1},
	new int[]{0,0,0,0,1,0,0}
	};

	var start = new int[] { 0, 0 };
	var end = new int[] { 8, 6 };

	ShortestDistance(maze, start, end).Dump();
}

public int count = 0;

public int ShortestDistance(int[][] maze, int[] start, int[] destination)
{
	if (maze == null || maze.Length == 0)
	{
		return -1;
	}

	var visisted = new bool[maze.Length, maze[0].Length];

	if(DFS(maze, start, destination, visisted))
	{
		return count;
	}
	
	return -1;
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

	if (DFS(maze, new int[] { start[0], r - 1 }, destination, visited))
	{
		count = count + (r-1-start[1]);
		return true;
	}

	//Go Left
	while (l >= 0 && maze[start[0]][l] == 0)
	{
		l--;
	}

	if (DFS(maze, new int[] { start[0], l + 1 }, destination, visited))
	{
		count = count + (start[1] -(l+1));
		return true;
	}

	//Go Up
	while (up >= 0 && maze[up][start[1]] == 0)
	{
		up--;
	}

	if (DFS(maze, new int[] { up + 1, start[1] }, destination, visited))
	{
		count = count + (start[0] - (up +1));
		return true;
	}

	//Go Down
	while (down < maze.Length && maze[down][start[1]] == 0)
	{
		down++;
	}

	if (DFS(maze, new int[] { down - 1, start[1] }, destination, visited))
	{
		count = count + (down - 1-start[0]);
		return true;
	}

	return false;
}