<Query Kind="Program" />

void Main()
{
	
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Solution
{
	enum Flag { ROOT, LEFT, RIGHT, MIDDLE };
	public List<int> boundaryOfBinaryTree(TreeNode root)
	{
		if (root == null)
		{
			return new List<int>();
		}
		List<int> leftBoundary = new List<int>();
		List<int> leaves = new List<int>();
		List<int> rightBoundary = new List<int>();
		preOrder(root, leftBoundary, leaves, rightBoundary, Flag.ROOT);

		leftBoundary.AddRange(leaves);
		leftBoundary.AddRange(rightBoundary);
		return leftBoundary;
	}

	// root -> left -> right
	private void preOrder(TreeNode root, List<int> leftBoundary, List<int> leaves, List<int> rightBoundary, Flag flag)
	{
		if (root == null)
		{
			return;
		}
		//Root
		if (flag == Flag.ROOT || flag == Flag.LEFT)
		{
			leftBoundary.Add(root.val);
		}
		else if (flag == Flag.RIGHT)
		{
			rightBoundary.Insert(0, root.val);
		}
		else if (root.left == null && root.right == null)
		{
			leaves.Add(root.val);
		}

		//Left
		if (root.left != null)
		{
			preOrder(root.left, leftBoundary, leaves, rightBoundary, childFlag(root, flag, true));
		}

		//Right
		if (root.right != null)
		{
			preOrder(root.right, leftBoundary, leaves, rightBoundary, childFlag(root, flag, false));
		}
	}

	private Flag childFlag(TreeNode parent, Flag flag, bool isLeftChild)
	{
		if (flag == Flag.ROOT)
		{
			return isLeftChild ? Flag.LEFT : Flag.RIGHT;
		}

		//Parent on left boundary, if exist left child, the right child should be a middle node
		if (flag == Flag.LEFT && !isLeftChild && parent.left != null)
		{
			return Flag.MIDDLE;
		}

		//Parent on right boundary, if exist right node, the left child should be a middle node.
		if (flag == Flag.RIGHT && isLeftChild && parent.right != null)
		{
			return Flag.MIDDLE;
		}

		return flag;
	}
}
