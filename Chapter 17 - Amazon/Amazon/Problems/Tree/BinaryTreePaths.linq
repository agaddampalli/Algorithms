<Query Kind="Program" />

void Main()
{
	var p = new TreeNode(1);
	p.left = new TreeNode(2);
//	p.right = new TreeNode(3);
	
	BinaryTreePaths(p).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public IList<string> BinaryTreePaths(TreeNode root)
{
	var output = new List<string>();
	
	if(root == null)
	{
		return output;
	}
	
	DFS(root, output, root.val.ToString());
	
	return output;
}

public void DFS(TreeNode root, List<string> output, string path)
{
	if(root == null)
	{
		return;
	}
	
	if(root.left == null && root.right == null)
	{
		output.Add(path);
	}
	
	if(root.left != null)
	{
		DFS(root.left, output, $"{path}->{root.left.val}");
	}

	if (root.right != null)
	{
		DFS(root.right, output, $"{path}->{root.right.val}");
	}
}