<Query Kind="Program" />

void Main()
{
	var input = new List<IList<int>>{
					new List<int>{54581641,64080174,24346381,69107959},
					new List<int>{86374198,61363882,68783324,79706116},
					new List<int>{668150,92178815,89819108,94701471},
					new List<int>{83920491,22724204,46281641,47531096},
					new List<int>{89078499,18904913,25462145,60813308},
					};
					
	CutOffTree(input).Dump();
}

public int rLength = 0;
public int cLength = 0;
public int CutOffTree(IList<IList<int>> forest)
{
	this.rLength = forest.Count;
	this.cLength = forest[0].Count;
	
	var trees = new List<int[]>();
	
	for (int i = 0; i < rLength; i++)
	{
		for (int j = 0; j < cLength; j++)
		{
			if(forest[i][j] > 0)
			{
				trees.Add(new int[] {i, j, forest[i][j]});
			}
		}
	}
	
	trees.Sort((x,y) => x[2]-y[2]);
	
	var count = 0;
	var src = new int[] {0,0,0};
	
	foreach (var tree in trees)
	{
		var temp = BFS(forest, src, tree);
		
		if(temp < 0)
		{
			return -1;
		}
		
		count += temp;

		src[0] = tree[0];
		src[1] = tree[1];
		src[2] = 0;
	}	
	
	return count;
}

public int BFS(IList<IList<int>> forest, int[] src, int[] dest)
{
	var queue = new Queue<int[]>();
	var visited = new bool[rLength, cLength];
	queue.Enqueue(src);
	visited[src[0],src[1]] = true;
	
	while (queue.Count != 0)
	{
		var node = queue.Dequeue();
		
		if(node[0] == dest[0] && node[1] == dest[1])
		{
			return node[2];
		}

		if (node[0] + 1 < rLength && forest[node[0] + 1][node[1]] > 0 && !visited[node[0] + 1, node[1]])
		{
			queue.Enqueue(new int[] {node[0] + 1, node[1], node[2] + 1});
			visited[node[0] + 1, node[1]] = true;
		}

		if (node[0] - 1 >= 0 && forest[node[0] - 1][node[1]] > 0 && !visited[node[0] - 1, node[1]])
		{
			queue.Enqueue(new int[] { node[0] - 1, node[1], node[2] + 1 });
			visited[node[0] - 1, node[1]] = true;
		}

		if (node[1] + 1 < cLength && forest[node[0]][node[1]+1] > 0 && !visited[node[0], node[1] + 1])
		{
			queue.Enqueue(new int[] { node[0] , node[1]+ 1, node[2] + 1 });
			visited[node[0], node[1] + 1] = true;
		}

		if (node[1] - 1 >= 0 && forest[node[0]][node[1] - 1] > 0 && !visited[node[0], node[1] - 1])
		{
			queue.Enqueue(new int[] { node[0], node[1] - 1, node[2] + 1 });
			visited[node[0], node[1] - 1] = true;
		}
	}

	return -1;
}

