<Query Kind="Program" />

void Main()
{
	var board = new int[][] {
					new int[] {1,1,-1},
					new int[] {1,1,1},
					new int[] {-1,-1,1}
					};

	SnakesAndLadders(board).Dump();
}

public int SnakesAndLadders(int[][] board)
{
	if (board == null || board.Length == 0)
	{
		return -1;
	}

	var n = board.Length;
	var target = n * n;
	var queue = new Queue<int[]>();
	queue.Enqueue(new int[] { 1, 0 });

	var visited = new bool[n * n + 1];
	visited[1] = true;
	while (queue.Any())
	{
		var node = queue.Dequeue();

		if (node[0] == target)
		{
			return node[1];
		}

		for (int j = node[0] + 1; j <= Math.Min(node[0] + 6, target); j++)
		{
			var rc = GetRowCol(j, n);
			var val = board[rc[0]][rc[1]] == -1 ? j : board[rc[0]][rc[1]];

			if (visited[val])
			{
				continue;
			}
			
			queue.Enqueue(new int[] { val, node[1] + 1 });
			visited[val] = true;
		}
	}

	return -1;
}

private int[] GetRowCol(int val, int n)
{
	var quo = (val - 1) / n;
	var col = (val - 1) % n;

	var row = n - 1 - quo;
	col = quo % 2 == 0 ? col : n - 1 - col;

	return new int[] { row, col };
}
