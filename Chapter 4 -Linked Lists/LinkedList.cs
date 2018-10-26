public class Node
{
	public Node(string value)
	{
		Value = value;
	}
	
    public string Value { get; set; }

    public Node NextNode { get; set; }
}

public class LinkedList
{
    public Node Head { get; set; }

    public Node Node { get; set; }

    public Node Add(Node node, string value)
    {
        if (node == null)
        {
            node = new Node(value);
            return node;
        }

        node.NextNode = Add(node.NextNode, value);
		return node;
    }

    public void Get(LinkedList linkedList)
    {
        if(linkedList?.Head == null)
        {
            return;
        }

        Print(linkedList.Head, 1);
    }

    private void Print(Node node, int counter)
    {
        if(node.NextNode != null)
        {
            Console.WriteLine($"Element at Node {counter}: {node.Value}");
            Print(node.NextNode, counter++);
        }
		else{
			Console.WriteLine($"Element at Node {counter}: {node.Value}");
		}
    }
}

public static void Main()
{
    var linkedList = new LinkedList();

	linkedList.Node = new Node("First Element");
    linkedList.Head = linkedList.Node;
	linkedList.Node = linkedList.Add(linkedList.Head, "Second Element");
	linkedList.Node = linkedList.Add(linkedList.Head, "Thrid Element");

	linkedList.Get(linkedList);
}

