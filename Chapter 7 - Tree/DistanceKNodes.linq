<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(0);
	root.right = new TreeNode(1);

	root.right.right = new TreeNode(2);
	root.right.right.left = new TreeNode(3);
	
	DistanceK(root, root.right.right.left , 2).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public TreeNode target;
public int k;
public List<int> result;
public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
{
	this.target = target;
	this.k = K;
	result = new List<int>();
	
	FindNode(root);
	
	return result;
}

private int FindNode(TreeNode node)
{
	if(node == null)
	{
		return -1;
	}
	
	if(node == target)
	{
		AddNode(node,0);
		return 1;
	}
	else
	{
		var l = FindNode(node.left);
		var r = FindNode(node.right);
		
		if(l != -1)
		{
			if(l == k)
			{
				result.Add(node.val);
			}
			
			AddNode(node.right,l+1);
			return l+1;
		}
		else if (r != -1)
		{
			if (r == k)
			{
				result.Add(node.val);
			}

			AddNode(node.left, r + 1);
			return r + 1;
		}
		else
		{
			return -1;
		}
	}

}

private void AddNode(TreeNode node, int dist)
{
	if(node == null)
	{
		return;
	}
	
	if(dist == k)
	{
		result.Add(node.val);
	}
	else
	{
		AddNode(node.left, dist + 1);
		AddNode(node.right, dist + 1);
	}
}

