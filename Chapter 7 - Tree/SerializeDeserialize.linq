<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	root.right.left = new TreeNode(4);
	root.right.right = new TreeNode(5);
//	root.right.right = new TreeNode(3);
//
//	root.left.right.left = new TreeNode(7);
//	root.left.right.right = new TreeNode(4);



	var input = serialize(root).Dump();
	deserialize(input).Dump();
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}


// Encodes a tree to a single string.
public string serialize(TreeNode root)
{
	if(root == null)
	{
		return null;
	}
	
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	StringBuilder output = new StringBuilder();
	output.Append(root.val + ",");
	
	while(queue.Count != 0)
	{
		var node = queue.Dequeue();

		output.Append((node.left != null ? node.left.val.ToString() : "a") + ",");
		output.Append((node.right != null ? node.right.val.ToString() : "a") + ",");

		if (node.left != null)
		{
			queue.Enqueue(node.left);
		}

		if (node.right != null)
		{
			queue.Enqueue(node.right);
		}
	}

	output.Remove(output.Length-1, 1);
	
	return output.ToString();
}

// Decodes your encoded data to tree.
public TreeNode deserialize(string data)
{
	if(string.IsNullOrWhiteSpace(data))
	{
		return null;
	}
	
	var values = data.Split(',');
	var queue = new Queue<TreeNode>();
	int i = 1;
	TreeNode root = new TreeNode(Convert.ToInt32(values[0]));
	queue.Enqueue(root);
	while(i < values.Length || queue.Count != 0)
	{
		var node = queue.Dequeue();
		
		var leftValue = GetValue(values[i++]);
		if(leftValue != null)
		{
			node.left = new TreeNode(leftValue.Value);
			queue.Enqueue(node.left);
		}

		var rightValue = GetValue(values[i++]);
		if (rightValue != null)
		{
			node.right = new TreeNode(rightValue.Value);
			queue.Enqueue(node.right);
		}
	}

	return root;
}

private int? GetValue(string data)
{
	int? value = null;
	if (data != "a")
	{
		value = Convert.ToInt32(data);
	}
	
	return value;
}