<Query Kind="Program" />

void Main()
{
	var node1 = new ListNode(5);
	node1.next = new ListNode(4);
	node1.next.next = new ListNode(3);

	var node2 = new ListNode(5);
	node2.next =  new ListNode(6);
	node2.next.next =  new ListNode(7);
//	node2.next.next.next = node1.next;

	GetIntersectionNode(node1, node2).Dump();
	GetIntersectionNodeWithLoop(node1, node2).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
{
	if (headA == null || headB == null)
	{
		return null;
	}

	var headALength = GetLength(headA);
	var headBLength = GetLength(headB);
	
	if(headALength.Item2 != headBLength.Item2)
	{
		return null;
	}

	var longer = headALength.Item1 > headBLength.Item1 ? headA : headB;
	var shorter = headALength.Item1 > headBLength.Item1 ? headB : headA;

	var diff = Math.Abs(headALength.Item1 - headBLength.Item1);
	for (int i = 0; i < diff; i++)
	{
		longer = longer.next;
	}
	
	
	while(longer != shorter)
	{
		longer = longer.next;
		shorter = shorter.next;
	}
	
	return longer;
}

public ListNode GetIntersectionNodeWithLoop(ListNode headA, ListNode headB)
{
	if (headA == null || headB == null)
	{
		return null;
	}

	var node = headA;
	while(node.next != null)
	{
		node = node.next;
	}
	
	node.next = headB;

	var fast = headA;
	var slow = headA;

	while (fast != null && fast.next != null)
	{
		fast = fast.next.next;
		slow = slow.next;
		
		if(slow == fast)
		{
			break;
		}
	}
	
	if(fast == null || fast.next == null)
	{
		node.next = null;
		return null;
	}
	
	slow = headA;
	
	while(slow != fast)
	{
		slow = slow.next;
		fast = fast.next;
	}
	
	var output = slow;
	
	while(output != node)
	{
		output = output.next;
	}
	
	output.next = null;
	return fast;
}


private Tuple<int, ListNode> GetLength(ListNode head)
{
	
	int count = 1;
	var node = head;
	while(node.next != null)
	{
		++count;
		node = node.next;
	}

	return Tuple.Create(count, node);
}