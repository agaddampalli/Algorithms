<Query Kind="Program" />

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

void Main()
{
	var tree = new TreeNode(4);
	tree.left = new TreeNode(2);
	tree.right = new TreeNode(5);

	tree.left.left = new TreeNode(1);
	tree.left.right = new TreeNode(3);
	
	var compressed = serialize(tree);
	
	compressed.Dump();
	
	deserialize(compressed).Dump();
}

public string serialize(TreeNode root)
{
	var output = new StringBuilder();
	
	PreOrderTraversal(root, output);
	
	output.Remove(output.Length-1, 1);
	
	return output.ToString();
}

public int preorderIndex;
public int[] preorderArray;

public TreeNode deserialize(string data)
{
	if(string.IsNullOrWhiteSpace(data))
	{
		return null;
	}
	
	preorderIndex = 0;
	preorderArray = Array.ConvertAll(data.Split(':'), Int32.Parse);
	
	return Helper(int.MinValue, int.MaxValue);
}

public TreeNode Helper(int lower, int higher)
{
	if(preorderIndex == preorderArray.Length)
	{
		return null;
	}
	
	var val = preorderArray[preorderIndex];
	
	if(val < lower ||  val > higher)
	{
		return null;
	}
	
	preorderIndex++;
	
	var root = new TreeNode(val);

	root.left = Helper(lower, val);
	root.right = Helper(val, higher);
	
	return root;
}

public StringBuilder PreOrderTraversal(TreeNode root, StringBuilder output)
{
	if (root == null)
	{
		return output;
	}

	output.Append($"{root.val}:");
	PreOrderTraversal(root.left, output);
	PreOrderTraversal(root.right, output);

	return output;
}
