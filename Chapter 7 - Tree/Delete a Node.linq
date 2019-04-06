<Query Kind="Program" />

void Main()
{
	var binaryTree = new BinaryTree<int>(1);

	binaryTree.Root.LeftNode = new Node<int>(2);
	binaryTree.Root.RightNode = new Node<int>(3);
	binaryTree.Root.LeftNode.LeftNode = new Node<int>(4);
	binaryTree.Root.LeftNode.RightNode = new Node<int>(5);
	binaryTree.Root.RightNode.LeftNode = new Node<int>(6);
	binaryTree.Root.RightNode.RightNode = new Node<int>(7);
	//	binaryTree.Root.LeftNode.LeftNode.LeftNode = new Node<int>(6);
	//	binaryTree.Root.LeftNode.RightNode.RightNode = new Node<int>(7);

	"***BFS******".Dump();
	binaryTree.BFS();
	binaryTree.Delete(7);
	"***BFS******".Dump();
	binaryTree.BFS();

}

//Node with no children are leafs
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
		Node<T> previousNode = null;
		
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
			
			if(node.LeftNode != null || node.RightNode != null)
			{
				previousNode = node;
			}
			
			if (nodeToDelete != null && queue.Count == 1)
			{
				nodeToDelete.Data = queue.Dequeue().Data;
				if (previousNode.RightNode != null)
				{
					previousNode.RightNode = null;
				}
				else
				{
					previousNode.LeftNode = null;
				}
			}

		}
		
		if(previousNode != null && nodeToDelete != null)
		{
			if (previousNode.RightNode != null)
			{
				previousNode.RightNode = null;
			}
			else
			{
				previousNode.LeftNode = null;
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