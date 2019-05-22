<Query Kind="Program" />

void Main()
{
	var root = new Node(1);
	root.left = new Node(2);
	root.right = new Node(3);

	root.left.left = new Node(4);
	root.left.right = new Node(5);
	
	root.right.left = new Node(6);


	Connect(root).Dump();
}

public class Node
{
	public int val;
	public Node left;
	public Node right;
	public Node next;
	public Node(int x) { val = x; }
}

public Node Connect(Node root)
{
	if(root == null)
	{
		return null;
	}
	
	var queue = new Queue<Node>();
	queue.Enqueue(root);
	
	while(queue.Count != 0)
	{
		var count = queue.Count;
		Node previousRightNode =  null;
		for (int i = 0; i < count; i++)
		{
			var node = queue.Dequeue();
			node.next = previousRightNode;
			previousRightNode = node;
			
			if(node.right != null)
			{
				queue.Enqueue(node.right);
			}

			if (node.left != null)
			{
				queue.Enqueue(node.left);
			}
		}
	}
	
	return root;
}