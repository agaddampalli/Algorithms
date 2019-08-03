<Query Kind="Program" />

void Main()
{
	var input = new int[,] { { 1, 1, 1, 1 }, { 0, 1, 1, 1 }, { 0, 1, 0, 1 }, { 1, 1, 9, 1 }, {0,0,1,1}};
	minimumDistance(5,4,input).Dump();
}

// Time Complexity: O(numRows * numColumns)
// Space complexity: O(numRows * numColumns)
public int minimumDistance(int numRows, int numColumns, int[,] area)
{
	var visisted = new bool[numRows, numColumns];
	int count = 0;
	var queue = new Queue<Result>();
	queue.Enqueue(new Result(0, 0));
	var result = new List<int[]>();

	while (queue.Count != 0)
	{
		var size = queue.Count;
		for (int i = 0; i < size; i++)
		{
			var node = queue.Dequeue();
			var row = node.row;
			var col = node.col;

			if (row < 0 || row > numRows - 1 || col < 0 || col > numColumns - 1 || area[row, col] == 0 || visisted[row, col])
			{
				continue;
			}

			if (area[row, col] == 9)
			{
				visisted.Dump();
				return count;
			}

			visisted[row, col] = true;
			result.Add(new int[] { row, col });

			queue.Enqueue(new Result(row + 1, col));
			queue.Enqueue(new Result(row - 1, col));
			queue.Enqueue(new Result(row, col + 1));
			queue.Enqueue(new Result(row, col - 1));
		}

		count++;
	}


	return -1;
}

public class Result
{
	public int row { get; set; }
	public int col { get; set; }

	public Result(int row, int col)
	{
		this.row = row;
		this.col = col;
	}
}