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

	PostOrderTraversalIterative(tree).Dump();
	"*****************************************".Dump();
	PostOrderTraversalRecursive(tree, new List<int>()).Dump();
}


// root left right
// 			1
//		2		3
//	 4      5
//6

public IList<int> PostOrderTraversalIterative(TreeNode root)
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
		while (root != null)
		{
			if (root.right != null) valueStack.Push(root.right);
			if (root.left != null) valueStack.Push(root.left);
			root = root.left;
		}

		root = valueStack.Pop();
		output.Add(root.val);
		root = root.right;
	}

	return output;
}

public IList<int> PostOrderTraversalRecursive(TreeNode root, List<int> output)
{
	output = output ?? new List<int>();
	
	if (root == null)
	{
		return output;
	}

	PostOrderTraversalRecursive(root.left, output);
	PostOrderTraversalRecursive(root.right, output);
	output.Add(root.val);

	return output;
}
