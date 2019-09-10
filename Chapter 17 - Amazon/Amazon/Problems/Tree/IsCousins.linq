<Query Kind="Program" />

void Main()
{
	var treeNode = new TreeNode(1);
	treeNode.left = new TreeNode(2);
	treeNode.left.left = new TreeNode(3);

	treeNode.right = new TreeNode(4);
	treeNode.right.right = new TreeNode(5);
	
	IsCousins(treeNode, 3,5).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

//https://leetcode.com/problems/cousins-in-binary-tree/

public Dictionary<int,int> depth;
public Dictionary<int, TreeNode> parents;

public bool IsCousins(TreeNode root, int x, int y)
{
	depth = new Dictionary<int, int>();
	parents = new Dictionary<int, TreeNode>();

	IsCousins(root, null);
	
	return depth[x] == depth[y] && parents[x] != parents[y];
}

public void IsCousins(TreeNode root, TreeNode parent)
{
	if (root != null)
	{
		depth.Add(root.val, parent != null ? 1 + depth[parent.val] : 0);
		
		parents.Add(root.val, parent);

		IsCousins(root.left, root);
		IsCousins(root.right, root);
	}
}