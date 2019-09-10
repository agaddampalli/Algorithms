<Query Kind="Program" />

void Main()
{
	
}

public class Amazon
{
	
}

public class Account
{
	public string Name { get; set; }
	public string Password { get; set; }
	public string Email { get; set; }
	public long Phone { get; set; }
	public Payment PaymentInfo { get; set; }

	public IList<Address> ShippingAddress { get; set; }
	public IList<Address> BillingAddress { get; set; }
	
	public bool ResetPassword(string oldPassword, string newPassword)
	{
		return true;
	}
}

public interface IGuest
{
	bool RegisterAccount(Account account);
}

public class Customer : Account, IGuest
{
	public bool RegisterAccount(Account account)
	{
		throw new NotImplementedException();
	}
}

public class Item
{
	public string ProductId { get; set; }
	public int Quantity { get; set; }
	public double Price { get; set; }
	
	public bool UpdateQuantity(int quantity)
	{
		Quantity = quantity;
		return true;
	}
}

public interface IShoppingCart
{
	bool AddItem();
	bool RemoveItem();
	bool UpdateItem();
	bool GetItems();
}

public class ShoppingCart : IShoppingCart
{
	public List<Item> items { get; set; }

	public bool AddItem()
	{
		throw new NotImplementedException();
	}

	public bool GetItems()
	{
		throw new NotImplementedException();
	}

	public bool RemoveItem()
	{
		throw new NotImplementedException();
	}

	public bool UpdateItem()
	{
		throw new NotImplementedException();
	}
}

public class ProductCategory
{
	public string Name { get; set; }
	public string Description { get; set; }
}

public class Product
{
	public string SKUNumber { get; set; }
	public string Name { get; set; }
	public ProductCategory ProductCategory { get; set; }
	public int AvailableQuantity { get; set; }
	public double Price { get; set; }

	public bool UpdatePrice(double price)
	{
		Price = price;
		return true;
	}
}

public interface ISearch
{
	List<Product> SearchByName(string name);
	List<Product> SearchByCategory(string name);
}

public class ProductCatalog: ISearch
{
	public Dictionary<string, List<Product>> ProductNames { get; set; }
	public Dictionary<string, List<Product>> ProductCategories { get; set; }

	public List<Product> SearchByCategory(string name)
	{
		throw new NotImplementedException();
	}

	public List<Product> SearchByName(string name)
	{
		throw new NotImplementedException();
	}
}

public class Payment
{
	public string Name { get; set; }
	public IList<CrediCardPayment> CreditCardPayments {get; set;}
	public IList<BankTransaction> BankTransactions { get; set; }
}

public class CrediCardPayment
{
	public long CardNumber { get; set; }
	public DateTime ExpiryDate { get; set; }
	public int CVV { get; set; }
}

public class BankTransaction
{
	public long AccountNumber { get; set; }
	public long RoutingNumber { get; set; }
}

public class Address
{
	
}

public class OrderLog
{
	public String orderNumber;
	public DateTime creationDate;
}

public class Order
{
	public String orderNumber;
	public DateTime orderDate;
	public List<OrderLog> orderLog;

	public bool sendForShipment(){ return true;}
	public bool makePayment(Payment payment){ return true;}
	public bool addOrderLog(OrderLog orderLog){ return true;}
}