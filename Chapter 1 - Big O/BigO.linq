<Query Kind="Program" />

void Main()
{
	var complexity = new Complexity();
	
	complexity.OofOneComplexity(2,3).Dump();
	"************************************".Dump();
	complexity.OofNComplexity(5);
	"************************************".Dump();
	complexity.OofNSquareComplexity(3);
	"************************************".Dump();
	complexity.OofLogNComplexity(15);
	"************************************".Dump();
}

public class Complexity{

	public int OofOneComplexity(int a, int b){
		return a + b;
	}
	
	public void OofNComplexity(int n){
		for(int i = 0; i< n; i++){
		   i.Dump();
		}
	}
	
	public void OofNSquareComplexity(int n){
		for(int i = 0; i< n; i++){
			i.Dump();
			for(int j = 10; j < n + 10; j++){
		   		j.Dump();
			}
		}
	}
	
	public void OofLogNComplexity(int n){
		int[] numbers = new int[15]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
//		int[] numbers = new int[5]{1,2,3,4,5};
		var min = 0;
		var max = numbers.Length;

		while(min < numbers.Length && max > 0){
			var middle = (min + max)/2;
			var middleNumber = numbers[middle];
			
			if(n == middleNumber){
			   ("Found at index : " + middle).Dump();
			   break;
			}
			
			if(n > middleNumber){
			   min = middle + 1;
			}
			
			if(n < middleNumber){
			  max = middle -1;
			}
		}
	}

}