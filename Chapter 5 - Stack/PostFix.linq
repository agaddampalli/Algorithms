<Query Kind="Program" />

void Main()
{
	var exp = "a+b*(c^d-e)^(f+g*h)-i";
	var postfixExpression = InfixToPostFix(exp);
	EvaluatePostFix("231*+9-").Dump();
}

// Define other methods and classes here
private static string InfixToPostFix(string exp)
{
	var operatorDictionary = new Dictionary<char, int> { { '*', 2 }, { '/', 2 }, { '%', 2 }, { '+', 1 }, { '-', 1 } , { '^', 3 } };
	string result = null;
	var stack = new Stack<char>();
	for (int i = 0; i < exp.Length; i++)
	{

		if (exp[i] == '(')
		{
			stack.Push(exp[i]);
		}
		else if (exp[i] == ')')
		{
			while (!stack.IsEmpty() && stack.Peek() != '(')
			{
				result += stack.Pop();
			}

			if (!stack.IsEmpty() && stack.Peek() == '(')
				stack.Pop();// invalid expression                 
		}
		else if (operatorDictionary.ContainsKey(exp[i]))
		{
			while (!stack.IsEmpty() && stack.Peek() != '(' && operatorDictionary[exp[i]] <= operatorDictionary[stack.Peek()])
			{
				result += stack.Pop();
			}
			stack.Push(exp[i]);
		}
		else
		{
			result += exp[i];
		}
	}
	
	while(!stack.IsEmpty())
	{
		result += stack.Pop();
	}
	
	return result;
}

private static int EvaluatePostFix(string exp)
{
	var result = new Stack<int>();
	var operatorDictionary = new Dictionary<char, int> { { '*', 2 }, { '/', 2 }, { '%', 2 }, { '+', 1 }, { '-', 1 } , { '^', 3 } };
	
	for (int i = 0; i < exp.Length; i++)
	{
		if (operatorDictionary.ContainsKey(exp[i]))
		{
			var operatorValue = exp[i];
			var value1 = result.Pop();
			var value2 = result.Pop();
			
			var output = PerformOperation(operatorValue,value1,value2) ;
			if(output != null)
			{
				result.Push(output.Value);
			}
		}
		else
		{
			result.Push(Char.GetNumericValue(exp[i]));
		}
	}
	
	return result.Pop();
}

private static int? PerformOperation(char operatorValue, int value1, int value2)
{
	switch (operatorValue)
	{
		case '*':
			return value1 * value2;
		case '+':
			return value1 + value2;
		case '-':
			return value1 - value2;
		case '/':
			return (value1 / value2);
		case '%':
			return (value1 % value2);
		case '^':
			return (value1 ^ value2);
		default:
			return null;
	}
}

public class Stack<T>
{
	private T[] _elements;
	private int _top;
	private int _max = 4;

	public Stack()
	{
		_elements = new T[_max];
		_top = -1;
	}

	public void Push(T input)
	{
		if (_top == _max - 1)
		{
			_max = _max * 2;
			var newArray = new T[_max];
			Array.Copy(_elements, newArray, _elements.Length);
			_elements = newArray;
		}
		_elements[++_top] = input;
	}

	public T Pop()
	{
		if (_top == -1)
		{
			throw new ArgumentNullException("Stack is Empty");
		}
		else
		{
			return _elements[_top--];
		}
	}

	public bool IsEmpty()
	{
		return _top == -1;
	}

	public T Peek()
	{
		if (_top == -1)
		{
			throw new ArgumentNullException("Stack is Empty");
		}

		return _elements[_top];
	}

	public void Print()
	{
		var count = 0;
		for (int i = _top; i >= 0; i--)
		{
			Console.WriteLine($"Element at {count} : {_elements[i]}");
			count++;
		}
	}
}