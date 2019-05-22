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

	PreorderTraversalIterative(tree).Dump();
	"*****************************************".Dump();
	PreorderTraversalRecursive(tree, new List<int>()).Dump();
}


// root left right
// 			1
//		2		3
//	 4      5
//6

public IList<int> PreorderTraversalIterative(TreeNode root)
{
	if (root == null)
	{
		return null;
	}

	var output = new List<int>();
	var valueStack = new Stack<TreeNode>();
	output.Add(root.val);

	if (root.right != null) valueStack.Push(root.right);
	if (root.left != null) valueStack.Push(root.left);

	while (valueStack.Count != 0)
	{
		root = valueStack.Pop();
		output.Add(root.val);
		
		if (root.right != null) valueStack.Push(root.right);
		if (root.left != null) valueStack.Push(root.left);
	}

	return output;
}

public IList<int> PreorderTraversalRecursive(TreeNode root,List<int> output)
{
	if (root == null)
	{
		return output;
	}

	output = output ?? new List<int>();
	output.Add(root.val);

	PreorderTraversalRecursive(root.left, output);
	PreorderTraversalRecursive(root.right, output);
	
	return output;
}
