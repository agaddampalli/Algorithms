<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(9);
	root.right = new TreeNode(8);

	root.left.left = new TreeNode(4);
//	root.left.right = new TreeNode(0);
//	root.left.right.right = new TreeNode(2);
	
//	root.right.left = new TreeNode(1);
	root.right.right = new TreeNode(7);
//	root.right.left.left = new TreeNode(5);
	
	var node = new TreeNode(1);
	node.right  = root;

	HeightofTree(node).Dump();
	DiameterOfTree(node).Dump();

	VerticalOrder(node).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public IList<IList<int>> VerticalOrder(TreeNode root)
{
	var output = new List<IList<int>>();
	
	if (root == null)
	{
		return output;
	}

	var mapDict = new Dictionary<int, List<int>>();

	var nodesQueue = new Queue<TreeNode>();
	nodesQueue.Enqueue(root);
	
	var columnQueue = new Queue<int>();
	columnQueue.Enqueue(0);
	int min = 0;
	int max = 0;
	
	while (nodesQueue.Count != 0)
	{
		var node = nodesQueue.Dequeue();
		var column = columnQueue.Dequeue();
		if(!mapDict.ContainsKey(column))
		{
			mapDict.Add(column, new List<int>());
		}
		
		mapDict[column].Add(node.val);
		
		if(node.left != null)
		{
			nodesQueue.Enqueue(node.left);
			columnQueue.Enqueue(column-1);
			min = column-1 < min ? column -1 : min;
		}

		if (node.right != null)
		{
			nodesQueue.Enqueue(node.right);
			columnQueue.Enqueue(column + 1);
			max = column+1 > max ? column+1 : max;
		}
	}

	for (int i = min; i <= max; i++)
	{
		output.Add(mapDict[i]);
	}

	return output;
}

public IList<IList<int>> VerticalOrderNotWOrking(TreeNode root)
{
	if(root == null)
	{
		return new List<IList<int>>();
	}

	var output = new List<int>[DiameterOfTree(root)];
	
	var node = root;
	int count = 0;
	
	while(node.left != null)
	{
		node = node.left;
		count++;
	}

	output[count] = new List<int> {root.val};
	
	VerticalOrder(root, count, output);
	
	var result = new List<IList<int>>();
	for (int i = 0; i < output.Length; i++)
	{
		if(output[i] != null)
		{
			result.Add(output[i]);
		}
	}
	
	return result;
}

private IList<IList<int>> VerticalOrder(TreeNode root, int level, List<int>[] output)
{
	if (root == null || level > output.Length || level < 0)
	{
		return output;
	}
	
	if(root.left != null)
	{
		var llist = output[level-1] ?? new List<int>();
		llist.Add(root.left.val);
		output[level-1] = llist;
	}
	
	if(root.right != null)
	{
		var rlist = output[level + 1] ?? new List<int>();
		rlist.Add(root.right.val);
		output[level+1] = rlist;
	}
	
	VerticalOrder(root.left, level-1, output);
	VerticalOrder(root.right, level+1, output);
	
	return output;
}

private int DiameterOfTree(TreeNode root)
{
	if(root == null)
	{
		return 0;
	}

	var leftHeight = HeightofTree(root.left);
	var rightHeight = HeightofTree(root.right);

	var leftDiameter = DiameterOfTree(root.left);
	var rightDiameter = DiameterOfTree(root.right);

	return Math.Max(leftHeight + rightHeight + 1,
						Math.Max(leftDiameter, rightDiameter)); ;
}

private int HeightofTree(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}

	return 1 + Math.Max(HeightofTree(root.left), HeightofTree(root.right));
}