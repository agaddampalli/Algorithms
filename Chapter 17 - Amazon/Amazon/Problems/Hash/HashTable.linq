<Query Kind="Program" />

void Main()
{
//["MyHashMap","remove","get","put","put","put","get","put","put","put","put"]
//[[],[14],[4],[7,3],[11,1],[12,1],[7],[1,19],[0,3],[1,8],[2,6]]

	var map = new MyHashMap();
	map.Get(79);
	map.Put(72, 7);
	map.Put(77, 1);
	map.Put(10, 21);
	map.Remove(26);
	map.Put(94, 5);
	map.Put(53, 35);
	map.Put(34, 9);
	map.Get(94).Dump();
	map.Put(1, 19);
	map.Put(0, 3);
	map.Put(1, 8);
	map.Put(2, 6);
}

public class MyHashMap {
    LinkNode[] set;
    int length = 1000;
    /** Initialize your data structure here. */
    public MyHashMap () {
        set = new LinkNode[length];
    }

    int Hash (int val) {
        return val % length;
    }

    public void Put (int key, int value) {
        int index = Hash (key);

        if (set[index] == null) set[index] = new LinkNode (-1, -1);
        LinkNode prev = FindNode (index,key);
        if (prev.next == null) prev.next = new LinkNode (key, value);
        else prev.next.val = value;
    }

    public int Get (int key) {
        int index = Hash (key);
        if (set[index] == null) return -1;

		LinkNode prev = FindNode(index, key);
		return prev.next == null ? -1 : prev.next.val;
	}

	public void Remove(int key)
	{
		int index = Hash(key);
		if (set[index] == null) return;

		LinkNode prev = FindNode(index, key);
		if (prev.next == null) return;
		else prev.next = prev.next.next;
	}

	LinkNode FindNode(int index, int key)
	{
		LinkNode cur = set[index];
		LinkNode prev = null;
		while (cur != null && cur.key != key)
		{
			prev = cur;
			cur = cur.next;
		}

		return prev;
	}

	class LinkNode
	{
		public int val, key;
		public LinkNode next;
		public LinkNode(int _key, int _val)
		{
			key = _key;
			val = _val;
			next = null;
		}
	}
}
