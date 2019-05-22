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
	var tree = new TreeNode(1);
	tree.left = new TreeNode(2);
	tree.right = new TreeNode(3);

	tree.right.left = new TreeNode(11);
	tree.right.right = new TreeNode(12);

	tree.left.left = new TreeNode(4);
	tree.left.right = new TreeNode(5);

	tree.left.left.left = new TreeNode(6);
	tree.left.left.right = new TreeNode(7);

	tree.left.left.right.left = new TreeNode(9);
	tree.left.left.right.left.left = new TreeNode(10);
	tree.left.left.right.right = new TreeNode(8);

	LevelOrder(tree).Dump();
}


// root left right
// 			1
//		2		3
//	 4      5
//6

public IList<IList<int>> LevelOrder(TreeNode root)
{
	var output = new List<IList<int>>();

	if (root == null)
	{
		return output;
	}

	var queue = new Queue<Item>();
	queue.Enqueue(new Item(root,0));

	while (queue.Count != 0)
	{
		var item = queue.Dequeue();
		if(output.Count > item.Level)
		{
			output[item.Level].Add(item.Node.val);
		}
		else
		{
			output.Add(new List<int>() {item.Node.val});
		}
		
		if (item.Node.left != null)
		{
			queue.Enqueue(new Item(item.Node.left, item.Level + 1));
		}

		if (item.Node.right != null)
		{
			queue.Enqueue(new Item(item.Node.right, item.Level + 1));
		}
	}
	
	return output;
}


public class Item
{
	public TreeNode Node;
	
	public int Level;
	
	public Item(TreeNode node, int level)
	{
		Node = node;
		Level = level;
	}
}