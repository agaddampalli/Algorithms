<Query Kind="Program" />

void Main()
{
	var inorder = new int[] { 9, 3, 15, 20, 7 };
	var preorder = new int[] { 3, 9, 20, 15, 7 };

	BuildTree(inorder, preorder).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

int preorderIndex = 0;
Dictionary<int, int> inOrderValues = new Dictionary<int, int>();

public TreeNode BuildTree(int[] preorder, int[] inorder)
{
	preorderIndex = 0;
	for (int i = 0; i < inorder.Length; i++)
	{
		inOrderValues.Add(inorder[i], i);
	}
	return Build(preorder, 0, inorder.Length - 1);
}

private TreeNode Build(int[] preorder, int start, int end)
{
	if (start > end)
	{
		return null;
	}

	var treeNode = new TreeNode(preorder[preorderIndex++]);

	var index = inOrderValues[treeNode.val];
	treeNode.left = Build(preorder, start, index - 1);
	treeNode.right = Build(preorder, index + 1, end);

	return treeNode;
}
