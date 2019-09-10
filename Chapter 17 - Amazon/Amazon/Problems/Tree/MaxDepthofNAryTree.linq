<Query Kind="Program" />

void Main()
{
	var root = new Node(1);
	root.children = new List<Node> {new Node(3), new Node(2), new Node(4)};

	root.children[0].children = new List<Node> { new Node(5), new Node(6) };

	root.children[0].children[0].children = new List<Node> { new Node(7), new Node(8) };
	root.children[0].children[1].children = new List<Node> { new Node(9), new Node(10) };
	
	MaxDepth(root).Dump();
}

//https://leetcode.com/problems/maximum-depth-of-n-ary-tree/
public class Node
{
	public int val;
	public IList<Node> children;

	public Node() { }

	public Node(int _val)
	{
		val = _val;
	}
	
	public Node(int _val, IList<Node> _children)
	{
		val = _val;
		children = _children;
	}
}

public int MaxDepth(Node root)
{
	if (root == null)
	{
		return 0;
	}

	if (root.children == null)
	{
		return 1;
	}

	var maxdepth = int.MinValue;
	foreach (var child in root.children)
	{
		maxdepth = Math.Max(maxdepth, 1 + MaxDepth(child));
	}

	return maxdepth;
}