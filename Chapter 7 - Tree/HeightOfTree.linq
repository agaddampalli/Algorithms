<Query Kind="Program" />

void Main()
{
	var binaryTree = new BinaryTree<int>(10);
	binaryTree.Insert(8);
	binaryTree.Insert(11);
	binaryTree.Insert(7);
	binaryTree.Insert(5);
	binaryTree.Insert(4);
	binaryTree.Insert(9);
	binaryTree.Insert(8);
	binaryTree.Insert(1);
	
	//  	   10
	// 		8     11
	//	  7	  9
	//  5	8
	//4
	//1
//	binaryTree.Dump();
	Math.Max(Height(binaryTree.Root.LeftNode),Height(binaryTree.Root.RightNode)).Dump();
	Diameter(binaryTree.Root).Dump();
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

	public void Insert(T value)
	{
		var root = Root;
		while (root != null)
		{
			if (root.Data.GetHashCode() >= value.GetHashCode())
			{
				if (root.RightNode == null)
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

public int Height(Node<int> rootNode)
{
	if(rootNode == null)
	{
		return 0;
	}
	
	return 1 + Math.Max(Height(rootNode.LeftNode), Height(rootNode.RightNode));
}

public int Diameter(Node<int> rootNode)
{
	if(rootNode == null)
	{
		return 0;
	}

	var lheight = Height(rootNode.LeftNode);
	var rheight = Height(rootNode.RightNode);

	var ldiameter = Diameter(rootNode.LeftNode);
	var rdiameter = Diameter(rootNode.RightNode);
	
	return Math.Max(lheight + rheight+1, Math.Max(ldiameter, rdiameter));
}