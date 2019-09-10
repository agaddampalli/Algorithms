<Query Kind="Program" />

void Main()
{
	var board = new char[][] {
		new char[] {'5','3','.','.','7','.','.','.','.'},
		new char[] {'6','.','.','1','9','5','.','.','.'},
		new char[] {'.','9','8','.','.','.','.','6','.'},
		new char[] {'8','.','.','.','6','.','.','.','3'},
		new char[] {'4','.','.','8','.','3','.','.','1'},
		new char[] {'7','.','.','.','2','.','.','.','6'},
		new char[] {'.','6','.','.','.','.','2','8','.'},
		new char[] {'.','.','.','4','1','9','.','.','5'},
		new char[] {'.','.','.','.','8','.','.','7','9'}
	};
	
	SolveSudoku(board);
	
	board.Dump();
}

public HashSet<int>[] rows;
public HashSet<int>[] columns;
public HashSet<int>[] boxes;

public void SolveSudoku(char[][] board)
{
	this.rows = new HashSet<int>[9];
	this.columns = new HashSet<int>[9];
	this.boxes = new HashSet<int>[9];

	for (int i = 0; i < 9; i++)
	{
		rows[i] = new HashSet<int>();
		columns[i] = new HashSet<int>();
		boxes[i] = new HashSet<int>();
	}

	for (int i = 0; i < 9; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			if (board[i][j] == '.')
			{
				continue;
			}

			var num = board[i][j] - '0';
			var boxIndex = GetBoxIndex(i, j);
			rows[i].Add(num);
			columns[j].Add(num);
			boxes[boxIndex].Add(num);
		}
	}

	for (int i = 0; i < 9; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			if (board[i][j] != '.')
			{
				continue;
			}
			
			var num = GetNextNumber(i, j);
			board[i][j] = (char)(num + '0');
			
			var boxIndex = GetBoxIndex(i, j);
			rows[i].Add(num);
			columns[j].Add(num);
			boxes[boxIndex].Add(num);
		}
	}
}

public int GetBoxIndex(int row, int column)
{
	return (row / 3) * 3 + (column / 3);
}

public int GetNextNumber(int row, int column)
{
	var boxIndex = GetBoxIndex(row, column);
	
	for (int i = 1; i <= 9; i++)
	{
		if(!rows[row].Contains(i) && !columns[column].Contains(i) && !boxes[boxIndex].Contains(i))
		{
			return i;
		}
	}
	
	return 0;
}