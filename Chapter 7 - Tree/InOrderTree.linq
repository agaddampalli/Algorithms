<Query Kind="Program" />

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

void Main()
{
	var tree = new TreeNode(1);
	tree.left = new TreeNode(2);
	tree.right = new TreeNode(3);

	tree.left.left = new TreeNode(4);
	tree.left.right = new TreeNode(5);

	tree.left.left.left = new TreeNode(6);
	tree.left.left.right = new TreeNode(7);

	tree.left.left.right.left = new TreeNode(9);
	tree.left.left.right.left.left = new TreeNode(10);
	tree.left.left.right.right = new TreeNode(8);

	InOrderTraversalIterative(tree).Dump();
	"*****************************************".Dump();
	InOrderTraversalRecursive(tree, new List<int>()).Dump();
}


// root left right
// 			1
//		2		3
//	 4      5
//6

public IList<int> InOrderTraversalIterative(TreeNode root)
{
	var output = new List<int>();
	
	if (root == null)
	{
		return output;
	}
	
	var valueStack = new Stack<TreeNode>();
	valueStack.Push(root);

	while (valueStack.Count != 0)
	{
		if(root != null)
		{
			valueStack.Push(root);
			root = root.left;
		}
		else
		{
			root = valueStack.Pop();
			output.Add(root.val);
			root = root.right;
		}
	}

	output.RemoveAt(output.Count - 1);
	return output;
}

public IList<int> InOrderTraversalRecursive(TreeNode root, List<int> output)
{
	if (root == null)
	{
		return output;
	}

	output = output ?? new List<int>();

	InOrderTraversalRecursive(root.left, output);
	output.Add(root.val);
	InOrderTraversalRecursive(root.right, output);

	return output;
}
