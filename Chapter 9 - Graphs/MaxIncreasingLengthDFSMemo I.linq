<Query Kind="Program" />

void Main()
{
	var input = new int[][]{
					new int[]{9,9,4},
					new int[]{6,6,8},
					new int[]{2,1,1},
					};

	LongestIncreasingPath(input).Dump();
}

public int maxLength;
private static  int[][] dirs = new int[][] { new int[]{ 0, 1 }, new int[]{ 1, 0 }, new int[]{ 0, -1 }, new int[]{ -1, 0 } };
private int m, n;
public int LongestIncreasingPath(int[][] matrix)
{
	if (matrix == null || matrix.Length == 0)
	{
		return 0;
	}

	m = matrix.Length;
	n = matrix[0].Length;
	maxLength = int.MinValue;
	var cache = new int[m][];
	for (int i = 0; i < cache.Length; i++)
	{
		cache[i] = new int[n];
	}
	
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			maxLength = Math.Max(maxLength, Find(matrix, i, j, cache));
		}
	}

	return maxLength;
}

 private int Find(int[][] matrix, int i, int j, int[][] cache) {
        if (cache[i][j] != 0) return cache[i][j];
       foreach (var d in dirs)
		{
            int x = i + d[0], y = j + d[1];
            if (0 <= x && x < m && 0 <= y && y < n && matrix[x][y] > matrix[i][j])
                cache[i][j] = Math.Max(cache[i][j], Find(matrix, x, y, cache));
        }
	return ++cache[i][j];
}