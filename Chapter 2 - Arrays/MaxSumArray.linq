<Query Kind="Program" />

void Main()
{
	var A = new List<int>{24115, -75629, -46517, 30105, 19451, -82188, 99505, 6752, -36716, 54438, -51501, 83871, 11137, -53177, 22294, -21609, -59745, 53635, -98142, 27968, -260, 41594, 16395, 19113, 71006, -97942, 42082, -30767, 85695, -73671};
	 List<int> outputList = null;
        var sum=0;
        var maxSum = 0;
        var maxSumOutputArrayDict = new Dictionary<int,List<int>>();
        foreach(var item in A)
        {
            if(item >= 0 && sum + item >= 0)
            {
                outputList = outputList != null ? outputList : new List<int>();
                sum = sum + item; 
                outputList.Add(item);
            }
            else
            {
              if(sum >= maxSum){
                 maxSum = sum;
                 
                  if(outputList != null && outputList.Count > 0)
                 {
                    if(maxSumOutputArrayDict.Any() &&
                     maxSumOutputArrayDict.ContainsKey(sum))
                     {
                         var existingList = maxSumOutputArrayDict[sum];
                         if(existingList.Count < outputList.Count)
                         {
                            maxSumOutputArrayDict[sum] = outputList;
                         }
                         else if(existingList.Count == outputList.Count)
                         {
                             var first = A.IndexOf(existingList[0]);
                             var second = A.IndexOf(outputList[0]);
                             if(first > second)
                             {
                                 maxSumOutputArrayDict[sum] = outputList;
                             }
                         }
                       
                     }
                     else
                     {
                        maxSumOutputArrayDict.Add(sum, outputList);
                     }
                   }
                  
                 }
				  outputList =  null;
                   sum = 0;
            }
        }
        
        if(sum >= maxSum && outputList != null){
             maxSum = sum;
            if(maxSumOutputArrayDict.Count > 0 &&
                     maxSumOutputArrayDict.ContainsKey(sum))
                     {
                         var existingList = maxSumOutputArrayDict[sum];
                         if(existingList.Count < outputList.Count)
                         {
                            maxSumOutputArrayDict[sum] = outputList;
                         }
                         else if(existingList.Count == outputList.Count && 
                          A.IndexOf(existingList[0]) > A.IndexOf(outputList[0]))
                         {
                              maxSumOutputArrayDict[sum] = outputList;
                         }
                       
                     }
                     else
                     {
                        maxSumOutputArrayDict.Add(sum, outputList);
                     }
        }
              
        if(maxSumOutputArrayDict.Count > 0){
          maxSumOutputArrayDict[maxSum].Dump();
        }
		
		"No Result".Dump();
}

// Define other methods and classes here
