<Query Kind="Program" />

void Main()
{
	var ListNode = new ListNode(1);
	ListNode.next = new ListNode(2);
	ListNode.next.next = new ListNode(3);
	ListNode.next.next.next = new ListNode(4);
	ListNode.next.next.next.next = new ListNode(5);
	
	RemoveNthFromEnd(ListNode, 5).Dump();
}

public ListNode RemoveNthFromEnd(ListNode head, int n)
{
	ListNode dummy = new ListNode(0);
	dummy.next = head;
	ListNode first = dummy;
	ListNode second = dummy;
	// Advances first pointer so that the gap between first and second is n nodes apart
	for (int i = 1; i <= n + 1; i++)
	{
		first = first.next;
	}
	// Move first to the end, maintaining the gap
	while (first != null)
	{
		first = first.next;
		second = second.next;
	}
	second.next = second.next.next;
	return dummy.next;
}

//public ListNode RemoveNthFromEnd(ListNode head, int n)
//{
//	if (head == null || (head.next == null && n ==1))
//	{
//		return null;
//	}
//	
//	var dictionary = new Dictionary<int, ListNode>();
//	
//	var i = 1;
//	dictionary.Add(i++, head);
//	var node = head.next;
//	while(node != null)
//	{
//		dictionary.Add(i, node);
//		node = node.next;
//		if(node != null)
//		{
//			i++;
//		}
//	}
//	
//	ListNode previousNode = null;
//	if(dictionary.ContainsKey(i-n))
//	{
//		previousNode = dictionary[i-n];
//	}
//
//	if( previousNode== null)
//	{
//		return dictionary[i-n+2];
//	}
//	
//	ListNode nextNode = null;
//	if (dictionary.ContainsKey(i-n + 2))
//	{
//		nextNode = dictionary[i-n + 2];
//	}
//
//	if(nextNode == null)
//	{
//		previousNode.next = null;
//	}
//	else
//	{
//		previousNode.next = nextNode;
//	}
//	
//	return dictionary[1];
//}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
 