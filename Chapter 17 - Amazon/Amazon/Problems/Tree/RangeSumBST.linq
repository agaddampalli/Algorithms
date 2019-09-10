<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(18);

	root.left = new TreeNode(9);
	root.right = new TreeNode(27);

	root.left.left = new TreeNode(6);
	root.left.right = new TreeNode(15);

	root.right.left = new TreeNode(24);
	root.right.right = new TreeNode(30);

	root.left.left.left = new TreeNode(3);
	root.right.left.left = new TreeNode(21);

	root.left.right.left = new TreeNode(12);
	
	RangeSumBST(root, 18, 24).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}


public void Inorder(TreeNode root, List<int> nums)
{
	if (root == null)
	{
		return;
	}

	Inorder(root.left, nums);
	nums.Add(root.val);
	Inorder(root.right, nums);
}

public int sum = 0;
public bool found = false;
public int RangeSumBST(TreeNode root, int L, int R)
{
	InOrder(root, L, R);
	return sum;
}

public void InOrder(TreeNode root, int L, int R)
{
	if (root == null)
	{
		return;
	}

	InOrder(root.left, L, R);
	
	if(root.val >= L && root.val <= R)
	{
		sum += root.val;
	}

	InOrder(root.right, L, R);
}