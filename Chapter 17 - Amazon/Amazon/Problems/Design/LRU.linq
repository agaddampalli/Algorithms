<Query Kind="Program" />

void Main()
{
	var cache = new LRUCache(3);

	cache.Put(1, 1);
	cache.Put(2, 2);
	cache.Get(1).Dump(); // 1 2
	cache.Put(3, 3); // 3 1 2
	cache.Get(2).Dump();  // 2 3 1
	cache.Put(4, 4); // 4 2 3
	
	cache.Get(1).Dump(); // -1
	cache.Get(3).Dump(); // 3 4 2
	cache.Get(4).Dump(); // 4 3 2
	
	cache.Put(5, 5);
	cache.Get(2).Dump();
}

public class LRUCache
{
	private int capacity;
	public DLinkedList cacheList;
	private Dictionary<int, Node> cache;

	public LRUCache(int capacity)
	{
		this.capacity = capacity;
		cacheList = new DLinkedList();
		cache = new Dictionary<int, Node>();
	}

	public int Get(int key)
	{
		if (!cache.ContainsKey(key))
		{
			return -1;
		}

		var node = cache[key];
		if (key != cacheList.Head.next.val)
		{
			updateFreshness(node);
		}
		
		return cache[key].val;
	}

	public void Put(int key, int value)
	{
		if(capacity == 0)
		{
			return;
		}
		
		Remove(key);
		
		if(cache.Count >= capacity)
		{
			var removed = cacheList.RemoveLRU();
			cache.Remove(removed.key);
		}
		
		var node = new Node(key, value);
		cacheList.AddAtHead(node);
		cache.Add(key, node);
	}

	private void updateFreshness(Node n)
	{ 
		cacheList.Remove(n);
		cacheList.AddAtHead(n);
	}
	
	public void Remove(int key)
	{
		if(!cache.ContainsKey(key))
		{
			return;
		}
		
		var node = cache[key];
		cacheList.Remove(node);
		cache.Remove(key);
	}

}

public class Node
{
	public int val { get; set; }
	public int key { get; set; }
	public Node next { get; set; }
	public Node prev { get; set; }

	public Node(int key, int val)
	{
		this.val = val;
		this.key = key;
	}

	public Node()
	{
	}
}

public class DLinkedList
{
	public Node Head { get; set; }
	public Node Tail { get; set; }
	
	public DLinkedList()
	{
		Head = new Node();
		Tail = new Node();
		
		Head.next = Tail;
		Tail.prev = Head;
	}
	
	public void AddAtHead(Node node)
	{
		var next = Head.next;
		
		node.next = next;
		next.prev = node;
		
		node.prev = Head;
		Head.next = node;
	}

	public void Remove(Node node)
	{
		var prev = node.prev;
		var next = node.next;
		
		prev.next = next;
		next.prev = prev;
	}
	
	public Node RemoveLRU()
	{
		var node = Tail.prev;
		Remove(node);
		return node;
	}
}