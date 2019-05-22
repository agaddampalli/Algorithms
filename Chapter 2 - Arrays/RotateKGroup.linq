<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(2);
	head.next.next = new ListNode(3);
	head.next.next.next = new ListNode(4);
	head.next.next.next.next = new ListNode(5);

	ReverseKGroup(head, 3).Dump();
	//	ReverseKGroupWithStack(head,3).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}


public ListNode ReverseKGroup(ListNode head, int k)
{
	ListNode result = new ListNode(0);
	result.next = head;
	ListNode current = result;
	while (true)
	{
		head = current;
		int i = 0;
		while (i < k)
		{
			if (current.next != null)
			{
				current = current.next;
			}
			else
			{
				break;
			}
			++i;
		}
		
		if (i < k)
		{
			break;
		}
		else
		{
			ListNode currentTail = current.next;
			ListNode currentHeadAndNextTail = head.next;
			current.next = null;
			head.next = reverse(currentHeadAndNextTail);
			currentHeadAndNextTail.next = currentTail;
			current = currentHeadAndNextTail;
		}
	}
	return result.next;
}

private ListNode reverse(ListNode head)
{
	ListNode prev = null;
	while (head != null)
	{
		ListNode tmp = head.next;
		head.next = prev;
		prev = head;
		head = tmp;
	}
	return prev;
}

public ListNode ReverseKGroupWithStack(ListNode head, int k)
{
	var mystack = new Stack<ListNode>();
	ListNode current = head;
	ListNode prev = null;

	while (current != null)
	{
		int count = 0;
		while (current != null && count < k)
		{
			mystack.Push(current);
			current = current.next;
			count++;
		}

		while (mystack.Count > 0)
		{
			if (prev == null)
			{
				prev = mystack.Pop();
				head = prev;
			}
			else
			{
				prev.next = mystack.Pop();
				prev = prev.next;
			}
		}

	}

	prev.next = null;

	return head;
}