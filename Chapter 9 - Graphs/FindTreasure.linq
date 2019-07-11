<Query Kind="Program" />

void Main()
{
<<<<<<< HEAD
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

=======
	var graph = new int[,] { { 1, 0, 0, 1 }, 
							 { 0, 0, 0, 1 },
							 { 1, 1, 1, 1 },
							 { 1, 0, 0, 2 }};
							 
	FindTreasure(graph).Dump();
}

public int distance = int.MaxValue;

public int FindTreasure(int[,] graph)
{
	Find(graph, 0, 0, 0);
	
	return distance == int.MaxValue ? -1 : distance;
}


public void Find(int[,] graph, int row, int col, int count)
{
	if(row < 0 || row > graph.GetLength(0)-1 || col < 0 || col > graph.GetLength(1)-1 || graph[row,col] == 0)
	{
		return;
	}
	
	if( graph[row,col] == 2)
	{
		distance = Math.Min(count, distance);
		return;
	}
	
	var temp = graph[row,col];
	graph[row,col] = 0;

	Find(graph, row + 1, col, count + 1);
	Find(graph, row - 1, col, count + 1);
	Find(graph, row, col+1, count + 1);
	Find(graph, row, col-1, count + 1);
	
	graph[row,col] = temp;
}
>>>>>>> 60b163d884b968463d18d5d056c40e7e5c90a09c
