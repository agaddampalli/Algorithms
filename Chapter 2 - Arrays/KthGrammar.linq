<Query Kind="Program" />

void Main()
{
	KthGrammar(2,1).Dump();
}

public int KthGrammar(int N, int K)
{
	int TotalLen = (int)Math.Pow(2, N - 1);
	int lo = 1, hi = TotalLen;
	int mid;
	if (K > TotalLen) return 3;
	int state = 0;
	while (lo < hi)
	{
		mid = lo + (hi - lo) / 2;
		if (K > mid)
		{
			lo = mid + 1;
			state = (state == 0) ? 1 : 0;
		}
		else    // state doesn't change
		{
			hi = mid;
		}
	}
	return state;
}

public int KthGrammarRecursive(int N, int K)
{
	if (N == 1) return 0;
	int prev = KthGrammarRecursive(N - 1, (K + 1) / 2);
	if (prev == 0) return K % 2 == 1 ? 0 : 1;
	else return K % 2 == 1 ? 1 : 0;
}

//public int KthGrammar(int N, int K)
//{
//	if(N == 1)
//	
//	{
//		return 0;
//	}
//	
//	if(N == 2)
//	{
//		return (int)("01"[K-1] - '0');
//	}
//	
//	var valuesDict = new Dictionary<string, string>();
//
//	valuesDict.Add("0", "01");
//	valuesDict.Add("1", "10");
//	
//	StringBuilder output = new StringBuilder("01");
//	for (int i = 3; i <= N; i++)
//	{
//		var n = output.Length/2;
//		var subString = output.ToString().Substring(n);
//		if(valuesDict.ContainsKey(subString))
//		{
//			var prevOut = output.ToString();
//			output.Append(valuesDict[subString]);
//			valuesDict.Add(prevOut, output.ToString());
//		}
//		else
//		{
//			var sub1 = subString.Substring(0,subString.Length/2);
//			var sub2 = subString.Substring(subString.Length/2);
//			var temp = valuesDict[sub1] + valuesDict[sub2];
//			valuesDict.Add(subString, temp);
//			var prevOut = output.ToString();
//			output.Append(temp);
//			valuesDict.Add(prevOut, output.ToString());
//		}
//	}
//
//	return (int)(output[K-1] - '0');
//}
//
//public int kth(int K)
//{
//	if (K == 0) return 0;
//	if (K % 2 == 0) return kth(K / 2);
//	else return reverse(kth(K / 2));
//}
//
//private int reverse(int val)
//{
//	return val == 0 ? 1 : 0;
//}
//