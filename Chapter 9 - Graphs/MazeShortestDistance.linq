<Query Kind="Program" />

void Main()
{

}

public int ShortestDistance(int[][] maze, int[] start, int[] destination)
{
	var queue = new Queue<Coordinates>();
	queue.Enqueue(new Coordinates(start[0], start[1]));
	var visited = new bool[maze.Length, maze[0].Length];
	visited[start[0], start[1]] = true;

	int count = 0;
	while (queue.Count != 0)
	{
		var size = queue.Count;

		for (int i = 0; i < size; i++)
		{
			var node = queue.Dequeue();
			
			if (node.isRight && !IsWall(node.x + 1, node.y, maze, visited))
			{
				var temp = new Coordinates(node.x + 1, node.y);
				visited[node.x + 1, node.y] = true;
				temp.isRight = true;
				queue.Enqueue(temp);
				continue;
			}

			if (node.isLeft && !IsWall(node.x - 1, node.y, maze, visited))
			{
				var temp = new Coordinates(node.x - 1, node.y);
				visited[node.x - 1, node.y] = true;
				temp.isLeft = true;
				queue.Enqueue(temp);
				continue;
			}

			if (node.isUp && !IsWall(node.x, node.y - 1, maze, visited))
			{
				var temp = new Coordinates(node.x, node.y - 1);
				visited[node.x, node.y - 1] = true;
				temp.isUp = true;
				queue.Enqueue(temp);
				continue;
			}

			if (node.isDown && !IsWall(node.x, node.y + 1, maze, visited))
			{
				var temp = new Coordinates(node.x, node.y + 1);
				visited[node.x, node.y + 1] = true;
				temp.isDown = true;
				queue.Enqueue(temp);
				continue;
			}

			if (!IsWall(node.x + 1, node.y, maze, visited))
			{
				var temp = new Coordinates(node.x + 1, node.y);
				visited[node.x + 1, node.y] = true;
				temp.isRight = true;
				queue.Enqueue(temp);
			}

			if (!IsWall(node.x - 1, node.y, maze, visited))
			{
				var temp = new Coordinates(node.x - 1, node.y);
				visited[node.x - 1, node.y] = true;
				temp.isLeft = true;
				queue.Enqueue(temp);
			}


			if (!IsWall(node.x, node.y - 1, maze, visited))
			{
				var temp = new Coordinates(node.x, node.y - 1);
				visited[node.x, node.y - 1] = true;
				temp.isUp = true;
				queue.Enqueue(temp);
			}

			if (!IsWall(node.x, node.y + 1, maze, visited))
			{
				var temp = new Coordinates(node.x, node.y + 1);
				visited[node.x, node.y + 1] = true;
				temp.isDown = true;
				queue.Enqueue(temp);
			}
		}

		count++;
	}

	return -1;
}


private static bool IsWall(int row, int col, int[][] maze, bool[,] visisted)
{
	return row < maze.Length || row > 0 ||
	col < maze[0].Length || col > 0 || visisted[row, col] ||
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