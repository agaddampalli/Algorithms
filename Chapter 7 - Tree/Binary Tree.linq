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
	
	"***InOrder******".Dump();
	binaryTree.Inorder(binaryTree.Root);
	"***InOrder Stack******".Dump();
	binaryTree.InorderWithStack(binaryTree.Root);
	"***PreOrder******".Dump();
	binaryTree.Preorder(binaryTree.Root);
	"***PostOrder******".Dump();
	binaryTree.Postorder(binaryTree.Root);
	"***BFS******".Dump();
	binaryTree.BFS();
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
	
	public void Inorder(Node<T> leftSubtree)
	{
		if(leftSubtree == null)
		{
			return;
		}
		
		Inorder(leftSubtree.LeftNode);
		
		leftSubtree.Data.Dump();
		
		Inorder(leftSubtree.RightNode);
	}

	public void InorderWithStack(Node<T> leftSubtree)
	{
		Stack<Node<T>> treeStack = new Stack<Node<T>>();
		Node<T> current = leftSubtree;
		while(current != null)
		{
			treeStack.Push(current);
			current = current.LeftNode;
			
			while(current == null && treeStack.Count != 0)
			{
			 	current = treeStack.Pop();
				current.Data.Dump();
				current = current.RightNode;
			}
		}
	}

	public void Preorder(Node<T> root)
	{
		if (root == null)
		{
			return;
		}

		root.Data.Dump();
		
		Preorder(root.LeftNode);

		Preorder(root.RightNode);
	}

	public void Postorder(Node<T> leftSubtree)
	{
		if (leftSubtree == null)
		{
			return;
		}

		Postorder(leftSubtree.LeftNode);
		
		Postorder(leftSubtree.RightNode);

		leftSubtree.Data.Dump();
	}

	public void BFS()
	{
		var queue = new Queue<Node<T>>();
		queue.Enqueue(Root);
		
		while(queue.Count != 0)
		{
			var node = queue.Dequeue();
			node.Data.Dump();
			
			if(node.LeftNode != null)
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