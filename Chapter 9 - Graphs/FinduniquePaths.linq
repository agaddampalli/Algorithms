<Query Kind="Program" />

void Main()
{
	UniquePaths(3, 2).Dump();
	uniquePaths(3, 3).Dump();
	uniquePaths1(3,3).Dump();
}

public int count;

public int uniquePaths(int m, int n)
{
	int[] dp = new int[n];
	for (int i = 0; i < m; i++)
	{
		dp[0] = 1;
		for (int j = 1; j < n; j++)
		{
			dp[j] += dp[j - 1];
		}
	}
	return dp[n - 1];
}

public int uniquePaths1(int m, int n)
{
	int[,] memo = new int[m, n];
	for (int i = 0; i < n; i++)
	{
		memo[0,i] = 1;    
	}
	for (int i = 0; i < m; i++)
	{
		memo[i, 0] = 1;   
	}
	for (int row = 1; row < m; row++)
	{
		for (int col = 1; col < n; col++)
		{
			memo[row, col] = memo[row, col - 1] + memo[row - 1, col];
		}
		
		memo.Dump();
	}
	
	
	return memo[m - 1, n - 1];
}

public int UniquePaths(int m, int n)
{
	var board = new int[m,n];
	
	board[0, 0] = 2;
	board[m-1, n-1] = 9;

	FindPath(board, 0, 0, m, n);
	
	return count;
}

public void FindPath(int[,] board, int row, int col, int rowLength, int colLength)
{
	if(row >= rowLength || col >= colLength || board[row, col] == 1)
	{
		return;
	}
	
	if(board[row, col] == 9)
	{
		count++;
	}
	
	if(board[row, col] == 0)
	{
		board[row, col] = 1;
	}
	
	FindPath(board, row+1, col, rowLength, colLength);

	FindPath(board, row, col+1, rowLength, colLength);

	if (board[row, col] == 1)
	{
		board[row, col] = 0;
	}
}
