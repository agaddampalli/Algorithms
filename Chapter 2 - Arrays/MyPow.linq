<Query Kind="Program" />

void Main()
{
	MyPow(2,11).Dump();
}

 private double fastPow(double x, long n) {
        if (n == 0) {
            return 1.0;
        }
        double half = fastPow(x, n / 2);
        if (n % 2 == 0) {
            return half * half;
        } else {
            return half * half * x;
        }
    }
	
    public double MyPow(double x, int n) {
        long N = n;
        if (N < 0) {
		x = 1 / x;
		N = -N;
	}

	return fastPow(x, N);
}

public double MyPowIteraive(double x, int n)
{
	if (n == 0)
	{
		return 0;
	}

	double value = 1;

	for (int i = 0; i < Math.Abs(n); i++)
	{
		value = value * x;
	}

	if (n < 0)
	{
		return (1 / value);
	}

	return value;
}

public double MyPowRecursion(double x, int n)
{
	if (n == 0)
	{
		return 0;
	}

	var value = MyPow(x, Math.Abs(n), 1);

	if (n < 0)
	{
		return (1 / value);
	}

	return value;
}

private double MyPow(double x, int n, double value)
{
	if(n == 0)
	{
		return value;
	}
	
	value = value * x;
	
	return MyPow(x,--n,value);
}