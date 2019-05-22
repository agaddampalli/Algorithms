<Query Kind="Program" />

void Main()
{
	var inorder = new int[] { 9, 3, 15, 20, 7 };
	var postorder = new int[] { 9, 15, 7, 20, 3 };
	
	BuildTree(inorder, postorder).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

int postOrderIndex =0;
Dictionary<int, int> inOrderValues = new Dictionary<int, int>();

public TreeNode BuildTree(int[] inorder, int[] postorder)
{
	postOrderIndex = postorder.Length -1;
	for (int i = 0; i < inorder.Length; i++)
	{
		inOrderValues.Add(inorder[i],i);
	}
	return Build(inorder, postorder, 0, inorder.Length-1);
}

private TreeNode Build(int[] inorder, int[] postorder, int start, int end)
{
	if (start > end)
	{
		return null;
	}

	var treeNode = new TreeNode(postorder[postOrderIndex--]);
	
	var index = inOrderValues[treeNode.val];
	treeNode.right = Build(inorder, postorder, index + 1, end);
	treeNode.left = Build(inorder, postorder, start, index - 1);

	return treeNode;
}
