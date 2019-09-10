<Query Kind="Program" />

void Main()
{
	var kthlargest = new KthLargest(2, new int[] {1, 3,4,2});

	kthlargest.Add(6).Dump();
	kthlargest.Add(0).Dump();
}

// 1 2 3 4 6 
public class KthLargest
{	
	int k, actualSize = 0;
    SortedDictionary<int, int> heap;
    public KthLargest(int k, int[] nums) 
    {
        heap = new SortedDictionary<int, int>();
        this.k = k;
        foreach(var i in nums)
            Add(i);
    }
    
    public int Add(int val) 
    {
        if(actualSize < k || val > heap.First().Key)
        {
            if(heap.ContainsKey(val))
                heap[val]++;
            else
                heap.Add(val, 1);
            actualSize++;
        }
		
        if(actualSize > k)
        {
            var first = heap.First();
			if (first.Value > 1)
				heap[first.Key]--;
			else
				heap.Remove(first.Key);
			actualSize--;
		}
		return heap.First().Key;
	}
}

