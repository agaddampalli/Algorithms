<Query Kind="Program" />

void Main()
{
	AddStrings("99","9").Dump();
}

public string AddStrings(string num1, string num2)
{
	var num1Length = num1.Length;
	var num2Length = num2.Length;
	var first = num1Length > num2Length ? num1 : num1.PadLeft(num2Length, '0');
	var second = num2Length > num1Length ? num2 : num2.PadLeft(num1Length, '0');

	string output = string.Empty;
	int carry = 0;
	for (int i = first.Length-1; i >=0 ; i--)
	{
		var digit1 = first[i] - 48;
		var digit2 = second[i] - 48;
		
		var sum = digit1 + digit2 + carry;
		
		output = (sum%10) + output ;
		carry = sum/10;
	}

	if(carry >= 1)
	{
		return $"{carry}{output}";
	}
	
	return output;
}