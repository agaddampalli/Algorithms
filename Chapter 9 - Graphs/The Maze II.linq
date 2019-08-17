<Query Kind="Program" />

void Main()
{
	var maze = new int[][] {
	new int[]{0,0,0,0,1,0,0},
	new int[]{0,0,1,0,0,0,0},
	new int[]{0,0,0,0,0,0,0},
	new int[]{0,0,0,0,0,0,1},
	new int[]{0,1,0,0,0,0,0},
	new int[]{0,0,0,1,0,0,0},
	new int[]{0,0,0,0,0,0,0},
	new int[]{0,0,1,0,0,0,1},
	new int[]{0,0,0,0,1,0,0}
	};

	var start = new int[] { 0, 0 };
	var end = new int[] { 8, 6 };
	
	ShortestDistance(maze, start, end).Dump();
}

public int ShortestDistance(int[][] maze, int[] start, int[] destination)
{
	var distance = new int[maze.Length][];
	
	for (int i = 0; i < maze.Length; i++)
	{
		distance[i] = new int[maze[0].Length];
		for (int j = 0; j < maze[0].Length; j++)
		{
			distance[i][j] = int.MaxValue;
		}
	}
	
	var queue = new Queue<int[]>();
	queue.Enqueue(start);
	distance[start[0]][start[1]] = 0;
	
	while(queue.Count != 0)
	{
		var node = queue.Dequeue();
		
		int right = node[1] + 1, left = node[1]-1, up = node[0]-1, down = node[0]+1;
		int count = 0;
		while(right < maze[0].Length && maze[node[0]][right] == 0)
		{
			count++;
			right++;
		}
		
		if(distance[node[0]][node[1]] + count < distance[node[0]][right-1])
		{
			distance[node[0]][right - 1] = distance[node[0]][node[1]] + count;
			queue.Enqueue(new int[] {node[0], right-1});
		}

		count = 0;
		while (left >= 0 && maze[node[0]][left] == 0)
		{
			count++;
			left--;
		}

		if (distance[node[0]][node[1]] + count < distance[node[0]][left + 1])
		{
			distance[node[0]][left + 1] = distance[node[0]][node[1]] + count;
			queue.Enqueue(new int[] { node[0], left + 1 });
		}

		count = 0;
		while (up >= 0 && maze[up][node[1]] == 0)
		{
			count++;
			up--;
		}

		if (distance[node[0]][node[1]] + count < distance[up+1][node[1]])
		{
			distance[up+1][node[1]] = distance[node[0]][node[1]] + count;
			queue.Enqueue(new int[] {up+1, node[1]});
		}

		count = 0;
		while (down < maze.Length && maze[down][node[1]] == 0)
		{
			count++;
			down++;
		}

		if (distance[node[0]][node[1]] + count < distance[down - 1][node[1]])
		{
			distance[down - 1][node[1]] = 	distance[node[0]][node[1]] + count;
			queue.Enqueue(new int[] { down - 1, node[1] });
		}
	}
	
	return distance[destination[0]][destination[1]] == int.MaxValue ? -1 : distance[destination[0]][destination[1]];
}