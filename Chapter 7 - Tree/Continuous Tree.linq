<Query Kind="Program" />

void Main()
{
	var binaryTree = new BinaryTree(3);

	binaryTree.Root.LeftNode = new Node<int>(2);
//	binaryTree.Root.RightNode = new Node<int>(4);
//	binaryTree.Root.LeftNode.LeftNode = new Node<int>(1);
//	binaryTree.Root.LeftNode.RightNode = new Node<int>(3);
//	binaryTree.Root.RightNode.RightNode = new Node<int>(5);

	//	binaryTree.Root.RightNode.LeftNode = new Node<int>(6);
	//	binaryTree.Root.RightNode.RightNode = new Node<int>(7);
	//	binaryTree.Root.LeftNode.LeftNode.LeftNode = new Node<int>(6);
	//	binaryTree.Root.LeftNode.RightNode.RightNode = new Node<int>(7);
	binaryTree.Root.Dump();
	binaryTree.IsContinuousTree().Dump();
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

public class BinaryTree
{
	public Node<int> Root { get; set; }

	public BinaryTree(int data)
	{
		Root = new Node<int>(data);
	}

	public void Insert(int value)
	{
		var root = Root;
		while (root != null)
		{
			if (root.Data.GetHashCode() >= value.GetHashCode())
			{
				if (root.RightNode == null)
				{
					root.RightNode = new Node<int>(value);
					break;
				}
				root = root.RightNode;
			}
			else
			{
				if (root.LeftNode == null)
				{
					root.LeftNode = new Node<int>(value);
					break;
				}
				root = root.LeftNode;
			}
		}
	}

	public bool IsContinuousTree()
	{
		var queue = new Queue<Node<int>>();
		queue.Enqueue(Root);

		while (queue.Count != 0)
		{
			var node = queue.Dequeue();

			if (node.LeftNode != null)
			{
				if(Math.Abs(node.Data - node.LeftNode.Data) != 1)
				{
					return false;
				}
				queue.Enqueue(node.LeftNode);
			}

			if (node.RightNode != null)
			{
				if (Math.Abs(node.Data - node.RightNode.Data) != 1)
				{
					return false;
				}
				queue.Enqueue(node.RightNode);
			}
		}
		
		return true;
	}

	
}