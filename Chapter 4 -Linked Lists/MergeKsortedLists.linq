<Query Kind="Program" />

void Main()
{
	
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode MergeKLists(ListNode[] lists)
{
	return mergeKLists(lists, lists.Length-1);
}

public static ListNode mergeKLists(ListNode[] arr, int last)
{
	// repeat until only one list is left  
	while (last != 0)
	{
		int i = 0, j = last;

		// (i, j) forms a pair  
		while (i < j)
		{
			// merge List i with List j and store  
			// merged list in List i  
			arr[i] = SortedMerge(arr[i], arr[j]);

			// consider next pair  
			i++; j--;

			// If all pairs are merged, update last  
			if (i >= j)
				last = j;
		}
	}

	return arr[0];
}

public static ListNode SortedMerge(ListNode a, ListNode b)
{
	ListNode result = null;

	/* Base cases */
	if (a == null)
		return b;
	else if (b == null)
		return a;

	/* Pick either a or b, and recur */
	if (a.val <= b.val)
	{
		result = a;
		result.next = SortedMerge(a.next, b);
	}
	else
	{
		result = b;
		result.next = SortedMerge(a, b.next);
	}

	return result;
}

