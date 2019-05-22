<Query Kind="Program" />

void Main()
{
	
}

public void Rotate(int[][] matrix)
{
	var k = matrix.GetLength(0) - 1;

	int j = 0;
	int previousValue = 0;
	while (j < k)
	{
		int i = j;
		int n = k - j;
		while (i < n)
		{
			var temp = matrix[i][n];
			matrix[i][n] = matrix[j][i];

			previousValue = matrix[n][k - i];
			matrix[n][k - i] = temp;
			temp = previousValue;

			previousValue = matrix[k - i][j];
			matrix[k - i][j] = temp;
			temp = previousValue;

			matrix[j][i] = temp;

			i++;
		}

		j++;
	}
}
