<Query Kind="Program" />

void Main()
{
	var A = new List<int>{ -7, -13};
	var B = new List<int>{1, -5};
	
      
        double length = 0;
        
        for(int i = 0 ; i< A.Count -1; i++)
        {
			var aDistance = Math.Abs(A[i] - A[i+1]);
			var bDistance = Math.Abs(B[i] - B[i+1]);
            length += aDistance > bDistance ? aDistance : bDistance;
        }
        
        length.Dump();
}

// Define other methods and classes here
