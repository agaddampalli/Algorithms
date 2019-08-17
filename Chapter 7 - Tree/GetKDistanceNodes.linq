<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);

	root.left = new TreeNode(5);
	root.right = new TreeNode(1);

	root.left.left = new TreeNode(6);
	root.left.right = new TreeNode(2);
	root.left.right.left = new TreeNode(7);
	root.left.right.right = new TreeNode(4);

	root.right.left = new TreeNode(0);
	root.right.right = new TreeNode(8);
	
	DistanceK(root, root.left, 2).Dump();

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
public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
{
	this.target = target;
	this.k = K;
	
	var res = new List<int>();
	
	var foundAtLevel = -1;
	if(root == target)
	{
		foundAtLevel = 0;
	}
	
	Find(root, 0, foundAtLevel, res);
	
	return res;
}

public void Find(TreeNode root, int level, int foundAtLevel, List<int> res)
{
	if((foundAtLevel != -1 && level - foundAtLevel > k) || root == null)
	{
		return;
	}
	
	if(foundAtLevel != -1 && level - foundAtLevel == k)
	{
		res.Add(root.val);
	}
	
	if(foundAtLevel == -1 && root == target)
	{
		foundAtLevel = level;
	}

	Find(root.left, level + 1, foundAtLevel,  res);
	Find(root.right, level + 1, foundAtLevel,  res);
}
