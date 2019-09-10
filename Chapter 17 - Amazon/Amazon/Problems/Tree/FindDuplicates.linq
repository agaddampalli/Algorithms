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

public Dictionary<string, int> countDict;
public IList<TreeNode> result;
public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
{
	result = new List<TreeNode>();
	
	if(root == null)
	{
		return result;
	}
	
	countDict = new Dictionary<string, int>();
	
	return result;
}

public string Count(TreeNode node)
{
	if(node == null)
	{
		return null;
	}

	var serial = $"{node.val}, {Count(node.left)}, {Count(node.right)}";
	
	if(!countDict.ContainsKey(serial))
	{
		countDict.Add(serial,0);
	}
	
	countDict[serial]++;
	
	if(countDict[serial] == 2)
	{
		result.Add(node);
	}
	
	return serial;
}

