<Query Kind="Program" />

void Main()
{
	var sortedArray = new int[] {-10,-3,0,5,9};
	
	BuildTree(sortedArray).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

Dictionary<int, int> inOrderValues = new Dictionary<int, int>();

public TreeNode BuildTree(int[] postorder)
{
	return Build(postorder, 0, postorder.Length - 1);
}

private TreeNode Build(int[] postorder, int start, int end)
{
	if (start > end)
	{
		return null;
	}
	
	var mid = (start + end)/2;
	var treeNode = new TreeNode(postorder[mid]);

	treeNode.left = Build(postorder, start, mid - 1);
	treeNode.right = Build(postorder, mid + 1, end);

	return treeNode;
}
