<Query Kind="Program" />

void Main()
{
	var grid = new int[][] {
					new int[] {1,0,2,0,1},
					new int[] {0,0,0,0,0},
					new int[] {0,0,1,0,0}
					};

	ShortestDistance(grid).Dump();
}

int[][] distance;
int[][] grid;
int m;
int n;
int[][] neighbors = new int[][]{
		new int[]{-1, 0}, //up
        new int[]{0, 1},//right
        new int[]{1, 0},//down
        new int[]{0, -1} ,//left
    };


/*
use bfs to calculate the distance to each pos reachable one building at a time. 
use distance to sum the total distance
pruning - can ignore pos not reachable by prev build.
*/
public int ShortestDistance(int[][] grid)
{
	this.grid = grid;
	this.m = grid.Length;
	this.n = m > 0 ? grid[0].Length : 0;

	if (m == 0 || n == 0) return -1;

	//intialize 
	this.distance = new int[m][];
	for (int i = 0; i < m; i++) distance[i] = new int[n];

	int k = 0; //build Id, starts from -1 goes -ve
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (grid[i][j] == 1)
			{
				BFSDistance(i, j, --k);
				grid.Dump();
				distance.Dump();
			}
		}
	}

	int minDist = int.MaxValue;
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (grid[i][j] == k)
			{
				minDist = Math.Min(minDist, distance[i][j]);
			}
		}
	}
	return minDist == int.MaxValue ? -1 : minDist;
}

//k in the building id
public void BFSDistance(int x, int y, int k)
{
	int prevK = k + 1;
	Queue<(int, int, int)> q = new Queue<(int, int, int)>();
	q.Enqueue((x, y, 0));
	while (q.Count > 0)
	{
		(int i, int j, int dist) = q.Dequeue();
		foreach (var neigh in neighbors)
		{
			int ii = i + neigh[0];
			int jj = j + neigh[1];
			if (ii >= 0 && ii < m && jj >= 0 && jj < n && grid[ii][jj] == prevK)
			{
				q.Enqueue((ii, jj, dist + 1));
				grid[ii][jj] = k; //mark as seen by current k
				distance[ii][jj] += dist + 1; //coz bfs, current dist, shortest dist
			}
		}
	}
}