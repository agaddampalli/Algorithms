<Query Kind="Program" />

void Main()
{
	
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

	public void Delete(T data)
	{
		var queue = new Queue<Node<T>>();
		queue.Enqueue(Root);
		Node<T> nodeToDelete = null;
		
		while (queue.Count != 0)
		{
			var node = queue.Dequeue();
			if(node.Data.Equals(data))
			{
				nodeToDelete = node;
			}
			
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
