<Query Kind="Program" />

void Main()
{
	var cache = new LRUCache(2);
	cache.Put(1, 1);
	cache.Put(2, 2);

	cache.Get(1).Dump();

	cache.Put(3, 3);

}

public class Node
{
	public int key {get; set; }
	public int val { get; set; }

	public Node next {get; set;}
	public Node prev {get; set;}
	
	public Node(int key, int val)
	{
		this.key = key;
		this.val = val;
	}
}

class DoublyLinkedList
{
	private Node head = new Node(0, 0); 
	private Node tail = new Node(0, 0);

	public DoublyLinkedList()
	{
		head.next = tail;
		tail.prev = head;
	}

	public void addFirst(Node n)
	{
		if (n == null)
		{
			return;
		}
		
		n.prev = head;
		n.next = head.next;
		head.next.prev = n;
		head.next = n;
	}

	public void remove(Node n)
	{ // Assumes 'n' is in this list
		if (n == null || n.prev == null || n.next == null)
		{
			return;
		}
		n.prev.next = n.next;
		n.next.prev = n.prev;
	}

	public Node getFirst()
	{
		if (head.next == tail)
		{
			return null; // list has 0 Nodes
		}
		return head.next;
	}

	public Node getLast()
	{
		if (head.next == tail)
		{
			return null; // list has 0 Nodes
		}
		return tail.prev;
	}
}

public class LRUCache
{
	private int size;
	private Dictionary<int, Node> dictionary = new Dictionary<int, Node>();
	private DoublyLinkedList dll;
	
	public LRUCache(int capacity)
	{
		size = capacity;
		dll = new DoublyLinkedList();
	}

	public int Get(int key)
	{
		if (!dictionary.ContainsKey(key))
		{
			return -1;
		}
		
		var node = dictionary[key];
		if(node != dll.getFirst())
		{
			updateFreshness(node);
		}
		
		return node.val;
	}

	public void Put(int key, int value)
	{
		remove(key);
		if (dictionary.Count >= size)
		{
			remove(dll.getLast().key);
		}

		Node n = new Node(key, value);
		dll.addFirst(n);
		dictionary.Add(key, n);
	}

	public void remove(int key)
	{
		if (!dictionary.ContainsKey(key))
		{
			return;
		}
		
		Node n = dictionary[key];
		dll.remove(n);
		dictionary.Remove(key);
	}
	
	private void updateFreshness(Node n)
	{ // Assumes 'n' is in this list
		dll.remove(n);
		dll.addFirst(n);
	}
}
