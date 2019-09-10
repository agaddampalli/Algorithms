<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(1);
	root.right = new TreeNode(4);
	root.right.left = new TreeNode(2);
	
	RecoverTree(root);
	
	root.Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

TreeNode x = null, y = null, pred = null;

public void swap(TreeNode a, TreeNode b)
{
	int tmp = a.val;
	a.val = b.val;
	b.val = tmp;
}

public void findTwoSwapped(TreeNode root)
{
	if (root == null) return;
	findTwoSwapped(root.left);
	if (pred != null && root.val < pred.val)
	{
		y = root;
		if (x == null) x = pred;
		else return;
	}
	pred = root;
	findTwoSwapped(root.right);
}

public void recoverTree(TreeNode root)
{
	findTwoSwapped(root);
	swap(x, y);
}

public void RecoverTree(TreeNode root)
{
	var nums = new List<int>();
	Inorder(root, nums);
	
	int x = -1, y = -1;
	for (int i = 0; i < nums.Count-1; i++)
	{
		if(nums[i+1] < nums[i])
		{
			y = nums[i+1];
			
			if(x == -1)
			{
				x = nums[i]; 
			}
			else
			{
				break;
			}
		}
	}
	
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	
	int count = 2;
	while(queue.Count != 0)
	{
		var node = queue.Dequeue();
		
		if(node.val == y)
		{
			node.val = x;
			count--;
		}
		else if (node.val == x)
		{
			node.val = y;
			count--;
		}
		
		if(count == 0)
		{
			return;
		}
		
		if(node.left != null)
		{
			queue.Enqueue(node.left);
		}

		if (node.right != null)
		{
			queue.Enqueue(node.right);
		}
	}
}

public void Inorder(TreeNode root, List<int> nums)
{
	if(root == null)
	{
		return;
	}
	
	Inorder(root.left, nums);
	nums.Add(root.val);
	Inorder(root.right, nums);
}