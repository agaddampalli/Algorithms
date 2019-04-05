<Query Kind="Program" />

void Main()
{
	var binaryTree = new BinaryTree<int>(10);
	
	binaryTree.Root.LeftNode = new Node<int>(11);
	binaryTree.Root.RightNode = new Node<int>(9);
	binaryTree.Root.LeftNode.LeftNode = new Node<int>(7);
	binaryTree.Root.RightNode.LeftNode = new Node<int>(15);
	binaryTree.Root.RightNode.RightNode = new Node<int>(8);

	binaryTree.Insert(12);
	binaryTree.Insert(1);
	binaryTree.BFS();
}

public class Node<T>
{
	public T Data { get; set; }
	public Node<T> RightNode { get; set; }
	public Node<T> LeftNode { get; set; }

	public Node(T data)
	{
		Data = data;
	}
}

public class BinaryTree<T>
{
	public Node<T> Root { get; set; }

	public BinaryTree(T data)
	{
		Root = new Node<T>(data);
	}
	
	public void Insert(T data)
	{
		var queue = new Queue<Node<T>>();
		queue.Enqueue(Root);

		while (queue.Count != 0)
		{
			var node = queue.Dequeue();

			if(node.LeftNode != null && node.RightNode != null)
			{
				queue.Enqueue(node.LeftNode);
				queue.Enqueue(node.RightNode);
			}
			else if (node.LeftNode != null && node.RightNode == null)
			{
				node.RightNode = new Node<T>(data);
				break;
			}
			else
			{
				node.LeftNode = new Node<T>(data);
				break;
			}
		}
	}

	public void BFS()
	{
		var queue = new Queue<Node<T>>();
		queue.Enqueue(Root);

		while (queue.Count != 0)
		{
			var node = queue.Dequeue();
			node.Data.Dump();

			if (node.LeftNode != null)
			{
				queue.Enqueue(node.LeftNode);
			}

			if (node.RightNode != null)
			{
				queue.Enqueue(node.RightNode);
			}
		}
	}
}