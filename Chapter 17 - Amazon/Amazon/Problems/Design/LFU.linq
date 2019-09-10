<Query Kind="Program" />

void Main()
{
	var cache = new LFUCache(3);

	cache.Put(0, 0);
	cache.Get(0).Dump();
	
//	cache.Put(2, 2);
//	cache.Put(3, 3);
//
//	cache.Get(1).Dump();
//	cache.Get(1).Dump();
//	cache.Get(1).Dump();
//	cache.Get(3).Dump();
//	cache.Get(3).Dump();
//	cache.Get(3).Dump();
//	cache.Get(2).Dump();
//
//	cache.Put(4, 4);
//	cache.Get(2).Dump();
//	cache.Put(5, 5);
//	cache.Get(4).Dump();
}

public class LFUCache
{
	private int capacity, minFrequency;
	private Dictionary<int, Node> cache;
	private Dictionary<int, DLinkedList> frequencyMap;
	
	public LFUCache(int capacity)
	{
		this.capacity = capacity;
		this.minFrequency = int.MaxValue;
		
		cache = new Dictionary<int, Node>();
		frequencyMap = new Dictionary<int, DLinkedList>();
	}
	
	public int Get(int key)
	{
		if(!cache.ContainsKey(key))
		{
			return -1;
		}
		
		var node = cache[key];
		UpdateNodeFrequency(node);
		
		return node.val;
	}
	
	
	public void Put(int key, int value)
	{
		if (capacity == 0)
		{
			return;
		}

		if (cache.ContainsKey(key))
		{
			var node = cache[key];
			node.val = value;
			UpdateNodeFrequency(node);
		}
		else
		{
			if(cache.Count == capacity)
			{
				var dll = frequencyMap[minFrequency];
				var node = dll.RemoveLFUNode();
				if (dll.Count == 0)
				{
					frequencyMap.Remove(minFrequency);
				}
				
				cache.Remove(node.key);
			}

			var nodeToAdd = new Node(key, value);
			minFrequency = nodeToAdd.freq;
			if (!frequencyMap.ContainsKey(nodeToAdd.freq))
			{
				frequencyMap.Add(nodeToAdd.freq, new DLinkedList());
			}
			
			frequencyMap[1].AddFront(nodeToAdd);
			cache.Add(key, nodeToAdd);
		}
	}
	
	public void UpdateNodeFrequency(Node node)
	{
		var dll = frequencyMap[node.freq];
		dll.Remove(node);
		
		if(dll.Count == 0)
		{
			frequencyMap.Remove(node.freq);
			
			if(node.freq == minFrequency)
			{
				minFrequency++;
			}
		}
		
		node.freq++;
		
		if(!frequencyMap.ContainsKey(node.freq))
		{
			frequencyMap.Add(node.freq, new DLinkedList());
		}
		
		frequencyMap[node.freq].AddFront(node);
	}

}

public class Node
{
	public int key { get; set; }
	public int val { get; set; }
	public int freq { get; set; }
	public Node next { get; set; }
	public Node prev { get; set; }

	public Node()
	{
	  
	}
	
	public Node(int key, int val)
	{
		this.key = key;
		this.val = val;
		this.freq = 1;
	}
}

public class DLinkedList
{
	public Node Head { get; set; }
	public Node Tail { get; set; }
	public int Count {get; private set;}
	
	public DLinkedList()
	{
		Head = new Node();
		Tail = new Node();
		Head.next = Tail;
		Tail.prev = Head;
		Count = 0;
	}

	public void AddFront(Node node)
	{
		var next = Head.next;
		
		next.prev = node;
		node.next = next;
		
		node.prev = Head;
		Head.next = node;
		
		Count++;
	}

	public void Remove(Node node)
	{
		var prev = node.prev;
		var next = node.next;
		
		prev.next = next;
		next.prev = prev;
		
		node.next = null;
		node.prev = null;
		
		Count--;
	}
	
	public Node RemoveLFUNode()
	{
		var node = Tail.prev;
		Remove(node);
		return node;
	}
}