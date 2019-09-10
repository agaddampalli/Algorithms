<Query Kind="Program" />

void Main()
{
	var input = new int[][] {
	new int[]{0,0,0},
	new int[]{0,1,0},
	new int[]{1,1,1},
	};
	
	UpdateMatrix(input).Dump();
}

public struct Point
{
	public int x;
	public int y;
}

public int[][] UpdateMatrix(int[][] matrix)
{
	var res = new int[matrix.Length][];
	var queue = new Queue<Point>();
	for (var i = 0; i < matrix.Length; i++)
	{
		res[i] = new int[matrix[i].Length];
		for (var j = 0; j < matrix[i].Length; j++)
		{
			if (matrix[i][j] == 0)
			{
				res[i][j] = 0;
				queue.Enqueue(new Point { x = i, y = j });
			}
			else
			{
				res[i][j] = int.MaxValue;
			}
		}
	}
	
	while (queue.Count > 0)
	{
		var point = queue.Dequeue();
		Visit(point.x - 1, point.y, res, point, queue);
		Visit(point.x + 1, point.y, res, point, queue);
		Visit(point.x, point.y - 1, res, point, queue);
		Visit(point.x, point.y + 1, res, point, queue);
	}
	return res;
}

public void Visit(int x, int y, int[][] res, Point current, Queue<Point> queue)
{
	if(x < 0 || x > res.Length -1 || y <0 || y > res[0].Length-1)
	{
		return;
	}
	
	if (res[x][y] > res[current.x][current.y]+1)
	{
		res[x][y] = 1 + res[current.x][current.y];
		queue.Enqueue(new Point { x = x, y = y });
	}
}
