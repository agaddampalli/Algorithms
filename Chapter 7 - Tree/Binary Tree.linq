<Query Kind="Program" />

void Main()
{
	var binaryTree = new BinaryTree<int>(1);

	binaryTree.Insert(5);
	binaryTree.Insert(4);
	binaryTree.Insert(6);
	binaryTree.Insert(2);
	binaryTree.Insert(0);
	binaryTree.Insert(1);
}

//Node with no children are leafs
public class Node<T>
{
	public T Data {get; set;}
	public Node<T> RightNode { get; set; }
	public Node<T> LeftNode { get; set; }
	
	public Node(T data)
	{
		Data = data;
	}
}

public class BinaryTree<T>
{
	public Node<T> Root {get; set;}
	
	public BinaryTree(T data)
	{
		Root = new Node<T>(data);
	}
	
	public void Insert(T value)
	{
		var root = Root;
		while (root != null)
		{
			if (root.Data.GetHashCode() >= value.GetHashCode())
			{
				if(root.RightNode == null)
				{
					root.RightNode = new Node<T>(value);
					break;
				}
				root = root.RightNode;
			}
			else
			{
				if (root.LeftNode == null)
				{
					root.LeftNode = new Node<T>(value);
					break;
				}
				root = root.LeftNode;
			}
		}
	}
}