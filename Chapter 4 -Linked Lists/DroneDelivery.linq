<Query Kind="Program" />

void Main()
{
	var head = new Node("seattle");
	head.next = new Node("tacoma");
	head.next.next = new Node("portland");
	head.next.next.next = new Node("los angeles");
	head.next.next.next.next = new Node("austin");
	head.next.next.next.next.next = new Node("dallas");

	head.UdpateRoute(head, new string[] {"seattle", "tacoma", "portland"}).Dump();
}

public class Node
{
	public string val {get;}
	
	public Node next {get; set;}

	public Node(string val)
	{
		this.val = val;
	}
	
	public Node(string val, Node node)
	{
		this.val = val;
		this.next = node;
	}
	
	
	public Node Insert(Node head, string val)
	{
		if(head == null)
		{
			head = new Node(val);
		}
		else
		{
			var temp = head;
			while(temp.next != null)
			{
				temp = temp.next;
			}
			
			temp.next = new Node(val);
		}
		
		return head;
	}
	
	public Node UdpateRoute(Node initialRoute, string[] citiesToSkip)
	{
		if(citiesToSkip == null || !citiesToSkip.Any() || initialRoute == null)
		{
			return initialRoute;
		}
		
		var cities = new HashSet<string>();
		
		foreach (var element in citiesToSkip)
		{
			cities.Add(element);
		}
		
		var temp = initialRoute;
		Node previousNode = null;
		
		while(temp != null)
		{
			if(cities.Contains(temp.val))
			{
				if(previousNode == null)
				{
					temp = temp.next;
					initialRoute = temp;
				}
				else
				{
					var nextNode = temp.next;
					previousNode.next = nextNode;
					temp = nextNode;
				}
				
				continue;
			}
			
			previousNode = temp;
			temp = temp.next;
		}
		
		return initialRoute;
	}
}