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
	
	IsValidSudoku(board).Dump();
}

public bool IsValidSudoku(char[][] board)
{
	if(board == null || board.Length == 0)
	{
		return false;
	}

	var rows = new HashSet<int>[9];
	var columns = new HashSet<int>[9];
	var boxes = new HashSet<int>[9];
	
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
			if(board[i][j] == '.')
			{
				continue;
			}
			
			var num = board[i][j] - '0';
			
			var boxIndex = GetBoxIndex(i, j);
			if(rows[i].Contains(num) || columns[j].Contains(num) || boxes[boxIndex].Contains(num))
			{
				return false;
			}

			rows[i].Add(num);
			columns[j].Add(num);
			boxes[boxIndex].Add(num);
		}
	}

	return true;
}

public int GetBoxIndex(int row, int column)
{
	return (row/3) * 3 + (column/3);
}