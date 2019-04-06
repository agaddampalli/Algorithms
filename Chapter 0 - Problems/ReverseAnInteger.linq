<Query Kind="Program" />

void Main()
{
	Reverse(1534236469).Dump();
}

public int Reverse(int x)
{
	if(x==0)
	{
		return x;
	}
	
	double result = 0;
	while(x!=0)
	{
		result = result * 10  + x % 10;
		
		x= x/10;
	}
	
	return Math.Abs(result) > int.MaxValue  ? 0 : Convert.ToInt32(result);

}
