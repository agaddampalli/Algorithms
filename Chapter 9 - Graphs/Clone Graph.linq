<Query Kind="Program" />

void Main()
{
	var node1 = new Node(1, new List<Node>());
	var node2 = new Node(2, new List<Node>());
	var node3 = new Node(3, new List<Node>());
	var node4 = new Node(4, new List<Node>());

	node1.neighbors.Add(node2);
	node1.neighbors.Add(node3);


	node2.neighbors.Add(node3);
	node4.neighbors.Add(node3);

	node3.neighbors.Add(node2);
	node3.neighbors.Add(node4);

	CloneGraph(node1).Dump();
}

public class Node
{
	public int val;
	public IList<Node> neighbors;

	public Node() { }
	public Node(int _val, IList<Node> _neighbors)
	{
		val = _val;
		neighbors = _neighbors;
	}
}

public Node CloneGraph(Node node)
{
	IDictionary<int, Node> dict = new Dictionary<int, Node>();
	Node newGraph = DFS(node, dict);
	return newGraph;
}

private Node DFS(Node node, IDictionary<int, Node> dict)
{
	if (node == null) return null;
	if (dict.ContainsKey(node.val))
	{
		return dict[node.val];
	}
	IList<Node> newNeigbhors = new List<Node>();
	Node newnode = new Node(node.val, newNeigbhors);
	dict.Add(node.val, newnode);
	foreach (var neighbor in node.neighbors)
	{
		if (dict.ContainsKey(neighbor.val))
		{
			newnode.neighbors.Add(dict[neighbor.val]);
		}
		else
		{
			var newneighbor = DFS(neighbor, dict);
			newnode.neighbors.Add(newneighbor);
		}
	}
	return newnode;
}