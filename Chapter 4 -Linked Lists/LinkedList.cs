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
            if (this.Head == null)
            {
                this.Node = node;
                this.Head = node;
            }
            return node;
        }

        node.NextNode = Add(node.NextNode, value);
        this.Node = node;
        return node;
    }

    public bool DetectAndRemoveLoop()
    {
        if(Head == null)
        {
            return false;
        }

        var traversedNodes = new HashSet<Node>();
        var node = Head;
        while(node != null)
        {
            if(node.NextNode != null && traversedNodes.TryGetValue(node.NextNode, out var outputNode))
            {
                node.NextNode = null;
                return true;
            }

            traversedNodes.Add(node);
            node = node.NextNode;
        }

        return false;
    }
    
    public void AddAtStart(string value)
    {
       var node = new Node(value);
       node.NextNode = this.Head;
       this.Head = node;
    }

    public void Get(LinkedList linkedList)
    {
        if (linkedList?.Head == null)
        {
            return;
        }

        Print(linkedList.Head, 1);
    }

    private void Print(Node node, int counter)
    {
        if (node.NextNode != null)
        {
            Console.WriteLine($"Element at Node {counter}: {node.Value}");
            Print(node.NextNode, counter++);
        }
        else
        {
            Console.WriteLine($"Element at Node {counter}: {node.Value}");
        }
    }
}

public static void Main()
{
    var linkedList = new LinkedList();

    linkedList.Add(linkedList.Head, "First Element");
    linkedList.Add(linkedList.Head, "Second Element");
    linkedList.Add(linkedList.Head, "Thrid Element");

    linkedList.Get(linkedList);

    linkedList.Add(linkedList.Head, "Zero Element");
    linkedList.Get(linkedList);
}

