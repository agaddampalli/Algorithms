<Query Kind="Program" />

void Main()
{
	List<List<int>> A = new List<List<int>>{
new List<int>{150, 6, 240, 129, 168, 346, 218, 168, 309, 242, 26, 327},
new List<int>{98, 275, 315, 389, 270, 2, 172, 100, 151, 41, 217, 176},
new List<int>{267, 5, 324, 344, 134, 122, 229, 196, 225, 280, 200, 274},
new List<int>{155, 320, 8, 215, 273, 291, 174, 165, 279, 26, 327, 214},
new List<int>{207, 91, 121, 46, 125, 247, 303, 387, 214, 249, 97, 316}};

	var finalList = new List<int>();
	if (A != null && A.Count > 0)
	{
		var x = A.Count.Dump();
		var y = A[0].Count.Dump();
		var length = x * y;

		int i = 0;
		int j = 0;
		while (finalList.Count != length)
		{
			var a = i;
			var b = j;
			while (j < y && finalList.Count != length)
			{
				finalList.Add(A[i][j]);
				if (j == y - 1)
				{
					break;
				}
				j++;
			} // 00 01 02 j = 2

			while (i < x && finalList.Count != length)
			{
				i++;
				finalList.Add(A[i][j]);
				if (i == x - 1)
				{
					break;
				}
			}// 12 22 i = 2

			while (j > 0 && finalList.Count != length)
			{
				j--;
				finalList.Add(A[i][j]);
				if (j == b)
				{
					break;
				}
			}
			//21 20 j = 0

			while (i > 0 && finalList.Count != length)
			{
				i--;
				if (i == a)
				{
					break;
				}
				finalList.Add(A[i][j]);
			}
			//10 i = 1

			x--;
			y--;
			i++;
			j++;
		}
	}
	finalList.Dump();
}

public List<int> spiralOrder(List<List<int>> A)
{
	var finalList = new List<int>();
	return finalList;
}

public void GenerateSpiralOrder(List<List<int>> A, List<int> finalList, int i, int j)
{


}
// Define other methods and classes here

//1 2 3 4
//5 6 7 8
//9 10 11 12
//13 14 15 16