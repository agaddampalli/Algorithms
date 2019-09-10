<Query Kind="Program" />

void Main()
{
	IsPowerOfTwo1(-16).Dump();
}

public bool IsPowerOfTwo(int n)
{
	if(n==0)
	{
		return false;
	}
	decimal temp = n;
	while( temp > 1)
	{
		temp = temp/2;
		
		if(temp % 1 != 0)
		{
			return false;
		}
	}
	
	return temp % 1 == 0;
}


public bool IsPowerOfTwo1(int n)
{

	if (n == 0) return false;
	if (n == 1) return true;
	int i = 0;
	for (i = n; i % 2 == 0; i = i / 2) ;
	
	if (i == 1)
		return true;
	else
		return false;

}