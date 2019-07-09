<Query Kind="Program" />

void Main()
{
	var input =  new int[4,4];

	input[2, 3] = 9;
	input[1, 1] = 1;
	input[2, 2] = 1;
	input[0, 3] = 1;
	input[3, 0] = 1;
	
	input.Dump();
	
	FindTreasure(input, 4, 4).Dump();
}

public int FindTreasure(int[,] board, int rows, int cols)
{
	var visisted = new bool[rows,cols];
	int count = 0;
	var queue = new Queue<Result>();
	queue.Enqueue(new Result(0, 0));
	var result = new List<int[]> ();
	
	while(queue.Count != 0)
	{
		var size = queue.Count;
		for (int i = 0; i < size; i++)
		{
			var node = queue.Dequeue();
			var row = node.row;
			var col = node.col;
			
			if(row < 0 || row > rows-1 || col < 0 || col > cols-1 || board[row, col] == 1 || visisted[row, col])
			{
				continue;
			}
			
			if(board[row, col] == 9)
			{
				visisted.Dump();
				return count;
			}

			visisted[row, col] = true;
			result.Add(new int[] {row, col});
			
			queue.Enqueue(new Result(row + 1, col));
			queue.Enqueue(new Result(row - 1, col));
			queue.Enqueue(new Result(row, col+1));
			queue.Enqueue(new Result(row, col-1));
		}
		
		count++;
	}
	
	
	return -1;
}

public class Result
{
	public int row { get; set; }
	public int col {get; set;}
	
	public Result(int row, int col)
	{
		this.row = row;
		this.col = col;
	}
}

