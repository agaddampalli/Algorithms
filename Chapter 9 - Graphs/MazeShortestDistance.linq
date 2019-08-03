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
		new int[] {0,0,0,0,1,0,0}
	};

	var start = new int[] { 0, 0 };
	var end = new int[] { 8, 6 };
	
	ShortestDistance(maze, start, end).Dump();
}

public int ShortestDistance(int[][] maze, int[] start, int[] destination)
{
	var queue = new Queue<Coordinates>();
	queue.Enqueue(new Coordinates(start[0], start[1]));
	var visited = new bool[maze.Length, maze[0].Length];
	visited[start[0], start[1]] = true;

	int count = 0;
	bool isFound = false;
	while (queue.Count != 0)
	{
		var size = queue.Count;

		for (int i = 0; i < size; i++)
		{
			var node = queue.Dequeue();
			
			if(node.x == destination[0] && node.y == destination[1])
			{
				isFound = true;
			}
			
			if (node.isRight && !IsWall(node.x, node.y+1, maze, visited))
			{
				if(isFound) return -1;
				
				var temp = new Coordinates(node.x, node.y+1);
				visited[node.x, node.y+1] = true;
				temp.isRight = true;
				queue.Enqueue(temp);
				continue;
			}

			if (node.isLeft && !IsWall(node.x, node.y-1, maze, visited))
			{
				if (isFound) return -1;

				var temp = new Coordinates(node.x, node.y-1);
				visited[node.x, node.y-1] = true;
				temp.isLeft = true;
				queue.Enqueue(temp);
				continue;
			}

			if (node.isUp && !IsWall(node.x-1, node.y, maze, visited))
			{
				if (isFound) return -1;

				var temp = new Coordinates(node.x-1, node.y);
				visited[node.x-1, node.y] = true;
				temp.isUp = true;
				queue.Enqueue(temp);
				continue;
			}

			if (node.isDown && !IsWall(node.x+1, node.y, maze, visited))
			{
				if (isFound) return -1;

				var temp = new Coordinates(node.x+1, node.y);
				visited[node.x+1, node.y] = true;
				temp.isDown = true;
				queue.Enqueue(temp);
				continue;
			}

			if (!IsWall(node.x, node.y+1, maze, visited))
			{
				var temp = new Coordinates(node.x, node.y+1);
				visited[node.x, node.y+1] = true;
				temp.isRight = true;
				queue.Enqueue(temp);
			}

			if (!IsWall(node.x, node.y-1, maze, visited))
			{
				var temp = new Coordinates(node.x, node.y-1);
				visited[node.x, node.y-1] = true;
				temp.isLeft = true;
				queue.Enqueue(temp);
			}


			if (!IsWall(node.x-1, node.y, maze, visited))
			{
				var temp = new Coordinates(node.x-1, node.y);
				visited[node.x-1, node.y] = true;
				temp.isUp = true;
				queue.Enqueue(temp);
			}

			if (!IsWall(node.x+1, node.y, maze, visited))
			{
				var temp = new Coordinates(node.x+1, node.y);
				visited[node.x+1, node.y] = true;
				temp.isDown = true;
				queue.Enqueue(temp);
			}
		}

		if (isFound) return count;

		count++;
	}

	return -1;
}


private static bool IsWall(int row, int col, int[][] maze, bool[,] visisted)
{
	return row > maze.Length-1 || row < 0 ||
	col > maze[0].Length-1 || col < 0 || visisted[row, col] ||
	maze[row][col] == 1;
}

public class Coordinates
{
	public int x { get; set; }

	public int y { get; set; }

	public bool isLeft { get; set; }
	public bool isRight { get; set; }
	public bool isUp { get; set; }
	public bool isDown { get; set; }

	public Coordinates(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
}