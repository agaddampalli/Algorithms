<Query Kind="Program" />

void Main()
{
	var tree = new TreeNode(4);
	tree.left = new TreeNode(2);
	tree.right = new TreeNode(5);

	tree.left.left = new TreeNode(1);
	tree.left.right = new TreeNode(3);
	
	RightSideView(tree).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public int MaxLevel;
public List<int> Result;
public IList<int> RightSideView(TreeNode root)
{
	MaxLevel = int.MinValue;
	Result = new List<int>();
	
	DFS(root, 1);
	return Result;
}

public void DFS(TreeNode root, int level)
{
	if(root == null)
	{
		return;
	}
	
	if(MaxLevel < level)
	{
		Result.Add(root.val);
		MaxLevel = level;
	}

	DFS(root.right, level + 1);
	DFS(root.left, level + 1);
}