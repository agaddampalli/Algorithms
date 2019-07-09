<Query Kind="Program" />

void Main()
{
	var input = new int[][]{
					new int[]{0,0,0},
					new int[]{0,1,1}
					};

	FloodFill(input, 1, 1, 1).Dump();
}

public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
{
	if (image[sr][sc] == newColor)
	{
		return image;
	}

	DFS(image, sr, sc, newColor, image[sr][sc]);

	return image;
}


public void DFS(IList<IList<int>> image, int row, int column, int newColor, int currentColor)
{
	if (row >= image.Count || row < 0 || column < 0 || column >= image[row].Count || image[row][column] != currentColor)
	{
		return;
	}

	image[row][column] = newColor;

	DFS(image, row + 1, column, newColor, currentColor);
	DFS(image, row - 1, column, newColor, currentColor);
	DFS(image, row, column - 1, newColor, currentColor);
	DFS(image, row, column + 1, newColor, currentColor);
}