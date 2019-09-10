<Query Kind="Program" />

void Main()
{
	var root = new Node(1);
	root.children = new List<Node> { new Node(3), new Node(2), new Node(4) };

	root.children[0].children = new List<Node> { new Node(5), new Node(6) };

	root.children[0].children[0].children = new List<Node> { new Node(7), new Node(8) };
	root.children[0].children[1].children = new List<Node> { new Node(9), new Node(10) };

	LevelOrder(root).Dump();
}

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

public IList<IList<int>> LevelOrder(Node root)
{
	var output = new List<IList<int>>();
	
	if(root == null)
	{
		return output;
	}
	
	var queue = new Queue<Node>();
	queue.Enqueue(root);
	
	while(queue.Any())
	{
		var size = queue.Count;
		var temp = new List<int>();
		for (int i = 0; i < size; i++)
		{
			var node = queue.Dequeue();
			temp.Add(node.val);
			
			if(node.children != null)
			{
				foreach (var child in node.children)
				{
					queue.Enqueue(child);
				}
			}
		}

		output.Add(temp);
	}

	return output;
}
