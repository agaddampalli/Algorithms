<Query Kind="Program" />

static VendingMachine vendingMachine;
static void Main(string[] args)
{
	vendingMachine = VendingMachine.GetInstance();
	vendingMachine.RegisterObserver(new MachineLoggerObserver());
	vendingMachine.RegisterObserver(new MachineScreenObserver());

	PrintColored("- Initialized Vending Machine.", ConsoleColor.Cyan);
	RequestUserAction();
}

static void RequestUserAction()
{
	Console.WriteLine("What action would you like to use?\n1 - Print Machine Info, 2 - Print 5 Last Sale Records, 3 - Refill Machine, 4 - Purchase a Product\nHINT: Type EXIT to disconnect from the system.");
	string userInput = Console.ReadLine();
	switch (userInput)
	{
		case "1":
			PrintColored(vendingMachine.ToString(), ConsoleColor.Green);
			break;
		case "2":
			DisplaySaleRecords();
			break;
		case "3":
			vendingMachine.RefillItems();
			//
			break;
		case "4":
			ProductPurchase();
			break;
		case "EXIT":
			Environment.Exit(0);
			break;
		default:
			break;
	}
	RequestUserAction();
}
static void DisplaySaleRecords()
{
	List<SaleRecord> saleRecords = vendingMachine.GetLastSaleRecords(5);

	if (saleRecords == null || saleRecords.Count == 0)
	{
		PrintColored("There are currently no sale records to present.", ConsoleColor.Red);
		return; ;
	}

	foreach (SaleRecord saleRecord in saleRecords)
		PrintColored(saleRecord.ToString(), ConsoleColor.DarkYellow);
}
static void ProductPurchase()
{
	Item requestedItem = null;
	string userInputString = string.Empty;
	int userInputInt;
	double userInputDouble;

	if (vendingMachine.MachineItems.Count == 0)
	{
		PrintColored("[ERROR] This vending machine does not have any items in stock.", ConsoleColor.Red);
		return;
	}

	PrintColored("Select the item you would like to purchase (Item ID).", ConsoleColor.Cyan);
	Console.WriteLine("HINT: Type EXIT in order to return to the previous menu.");
	PrintColored("Available Machine Items:", ConsoleColor.Cyan);
	foreach (Item item in vendingMachine.MachineItems.Keys)
	{
		PrintColored(string.Format("{0} [IN STOCK: {1}]", item.ToString(), vendingMachine.MachineItems[item]),
			ConsoleColor.DarkGreen);
	}

	userInputString = Console.ReadLine();

	if (userInputString == "EXIT")
		return;

	if (!int.TryParse(userInputString, out userInputInt))
	{
		PrintColored("[ERROR] Invalid input.", ConsoleColor.Red);
		ProductPurchase();
		return;
	}

	foreach (Item item in vendingMachine.MachineItems.Keys)
	{
		if (item.ItemID == userInputInt)
		{
			requestedItem = item;
			break;
		}
	}

	if (requestedItem == null)
	{
		PrintColored("[ERROR] No such item in the vending machine. Please try again.", ConsoleColor.Red);
		ProductPurchase();
		return;
	}

	if (vendingMachine.GetItemStock(requestedItem) == 0)
	{
		PrintColored("[ERROR] Item is out of stock.", ConsoleColor.Red);
		ProductPurchase();
		return;
	}

	Console.WriteLine(requestedItem);
	Console.WriteLine("How much money are you paying?");
	userInputString = Console.ReadLine();

	if (!Double.TryParse(userInputString, out userInputDouble))
	{
		PrintColored("[ERROR] Invalid input.", ConsoleColor.Red);
		ProductPurchase();
		return;
	}
	if (userInputDouble < requestedItem.ItemPrice)
	{
		PrintColored("[ERROR]  Item price is higher than the paid amount.", ConsoleColor.Red);
		ProductPurchase();
		return;
	}

	vendingMachine.SellItem(requestedItem, userInputDouble);

	string recordMessage = string.Format("[Vending Machine]: Item has been successfully sold (Paid: {0}, Returned: {1}).",
			userInputDouble.ToString("C"), (userInputDouble - requestedItem.ItemPrice).ToString("C"));

	SaleRecord saleRecord = new SaleRecord(DateTime.Now, recordMessage, requestedItem, userInputDouble);
	vendingMachine.AddSaleRecord(saleRecord);
	PrintColored(recordMessage, ConsoleColor.Green);
}

static void PrintColored(string text, ConsoleColor color)
{
	Console.ForegroundColor = color;
	Console.WriteLine(text);
	Console.ResetColor();
}

public sealed class VendingMachine : ObserverCommands
{
	private static VendingMachine instance;

	private readonly Dictionary<Item, int> machineItems;
	private readonly Stack<SaleRecord> saleRecords;
	private double machineBank;
	private List<Observer> machineObservers;

	private VendingMachine()
	{
		this.machineItems = new Dictionary<Item, int>();
		this.saleRecords = new Stack<SaleRecord>();
		this.machineBank = 0;
		this.machineObservers = new List<Observer>();
	}

	public static VendingMachine GetInstance()
	{
		if (instance == null)
			instance = new VendingMachine();
		return instance;
	}
	public double MachineBank
	{
		get
		{
			return this.machineBank;
		}
	}
	public Dictionary<Item, int> MachineItems
	{
		get
		{
			return this.machineItems;
		}
	}
	public Stack<SaleRecord> SaleRecords
	{
		get
		{
			return this.saleRecords;
		}
	}

	public List<SaleRecord> GetLastSaleRecords(int num)
	{
		List<SaleRecord> list;

		if (num <= 0)
			return null;

		list = new List<SaleRecord>();

		foreach (SaleRecord saleRecord in saleRecords)
		{
			list.Add(saleRecord);
			if (--num == 0)
				break;
		}

		return list;
	}
	
	public int GetItemStock(Item item)
	{
		if (machineItems.ContainsKey(item))
			return machineItems[item];

		return -1;
	}
	
	public int GetTotalMachineItems()
	{
		int totalItems = 0;
		foreach (Item item in machineItems.Keys)
			totalItems += machineItems[item];
		return totalItems;

	}

	public void RefillItems()
	{
		machineItems.Clear();
		this.machineItems.Add(ItemFactory.GetItem("Coca Cola 330"), 20);
		this.machineItems.Add(ItemFactory.GetItem("Coca Cola Zero 330"), 20);
		this.machineItems.Add(ItemFactory.GetItem("Fuze Tea 500"), 20);
		this.machineItems.Add(ItemFactory.GetItem("Pepsi Max 330"), 20);
		this.machineItems.Add(ItemFactory.GetItem("Pepsi Max 500"), 10);
		this.machineItems.Add(ItemFactory.GetItem("Evian 500"), 10);
		this.machineItems.Add(ItemFactory.GetItem("Lays Barbecue"), 3);
		this.machineItems.Add(ItemFactory.GetItem("Lays Sour Cream & Onion"), 1);

		NotifyAllObservers(new VendingMachineLog("Machine has been refilled."));
	}
	
	public void SellItem(Item item, double amountPaid)
	{
		machineBank += item.ItemPrice;
		machineItems[item]--;
		NotifyAllObservers(new VendingMachineLog("Item has been sold."));
	}
	
	public void AddSaleRecord(SaleRecord saleRecord)
	{
		this.saleRecords.Push(saleRecord);
		NotifyAllObservers(new VendingMachineLog("Sale Record Added"));
	}

	public void RegisterObserver(Observer observer)
	{
		this.machineObservers.Add(observer);
	}
	
	public void UnregisterObserver(Observer observer)
	{
		this.machineObservers.Remove(observer);
	}
	
	public void NotifyAllObservers(VendingMachineLog log)
	{
		foreach (Observer observer in this.machineObservers)
			observer.Update(log);
	}

	public override string ToString()
	{
		return string.Format("Unique Items: {0}, Total Items: {1}, Total Sales: {2}, Machine Bank: {3}",
			machineItems.Count, GetTotalMachineItems(), saleRecords.Count, machineBank.ToString("C"));
	}
}

public abstract class Item : ICloneable
{
	private static int totalItemCount = 0;

	protected readonly int itemID;
	protected readonly string itemName;
	protected readonly ItemMakerType.Value itemMaker;
	protected readonly double itemPrice;

	public Item(string itemName, ItemMakerType.Value itemMaker, double itemPrice)
	{
		this.itemID = totalItemCount++;
		this.itemName = itemName;
		this.itemMaker = itemMaker;
		this.itemPrice = itemPrice;
	}
	public Item(Item item)
	{
		this.itemID = item.itemID;
		this.itemName = item.itemName;
		this.itemMaker = item.itemMaker;
		this.itemPrice = item.itemPrice;
	}

	public int ItemID
	{
		get
		{
			return this.itemID;
		}
	}
	public string ItemName
	{
		get
		{
			return this.itemName;
		}
	}
	public ItemMakerType.Value ItemMaker
	{
		get
		{
			return this.itemMaker;
		}
	}
	public double ItemPrice
	{
		get
		{
			return this.itemPrice;
		}
	}

	public static int TotalItems()
	{
		return totalItemCount;
	}

	public override string ToString()
	{
		return string.Format("[Item Details] ID: {0}, Name: {1}, Maker: {2}, Price: {3}",
			this.itemID, this.itemName, this.itemMaker.ToString(), itemPrice.ToString("C"));
	}
	public override bool Equals(object obj)
	{
		Item castedItem;
		try
		{
			castedItem = (Item)obj;
			return this.itemID == castedItem.itemID;
		}
		catch { }
		return false;
	}
	public override int GetHashCode()
	{
		return this.itemID;
	}

	public abstract Object Clone();
}
public class ItemFood : Item, IEatable
{
	protected int packCapacity;

	public ItemFood(string itemName, ItemMakerType.Value itemMaker, int packCapacity, double itemPrice)
		: base(itemName, itemMaker, itemPrice)
	{
		this.packCapacity = packCapacity;
	}
	public ItemFood(ItemFood itemFood) :
		base(itemFood)
	{
		this.packCapacity = itemFood.packCapacity;
	}

	public int PackCapacity
	{
		get
		{
			return this.packCapacity;
		}
	}

	public void Eat()
	{
		this.packCapacity = 0;
	}

	public override Object Clone()
	{
		return new ItemFood(this);
	}
	public override string ToString()
	{
		return string.Format("[FOOD] ID: {0}, Name: {1}, Maker: {2}, Price: {3}",
			this.itemID, string.Format("{0} ({1}g)", this.itemName, this.packCapacity), this.itemMaker, this.itemPrice.ToString("C"));
	}
}
public class ItemDrink : Item, IDrinkable
{
	protected int canCapacity;

	public ItemDrink(string itemName, ItemMakerType.Value itemMaker, int canCapacity, double itemPrice)
		: base(itemName, itemMaker, itemPrice)
	{
		this.canCapacity = canCapacity;
	}
	public ItemDrink(ItemDrink itemDrink) :
		base(itemDrink)
	{
		this.canCapacity = itemDrink.canCapacity;
	}

	public int CanCapacity
	{
		get
		{
			return this.canCapacity;
		}
	}
	public void Drink()
	{
		this.canCapacity = 0;
	}

	public override Object Clone()
	{
		return new ItemDrink(this);
	}
	public override string ToString()
	{
		return string.Format("[DRINK] ID: {0}, Name: {1}, Maker: {2}, Price: {3}",
			this.itemID, string.Format("{0} ({1}ml)", this.itemName, this.canCapacity), this.itemMaker, this.itemPrice.ToString("C"));
	}
}
public static class ItemMakerType
{
	public enum Value
	{
		CocaCola, PepsiCo, Faygo, Toscana, Regions, Fritolay
	}
}

public sealed class ItemFactory
{
	private static Dictionary<string, Item> cachedItems = new Dictionary<string, Item>();

	private static void LoadCachedItems()
	{
		cachedItems.Add("Coca Cola 330", new ItemDrink("Coca Cola Can", ItemMakerType.Value.CocaCola, 330, 1.49));
		cachedItems.Add("Coca Cola 500", new ItemDrink("Coca Cola Bottle", ItemMakerType.Value.CocaCola, 500, 2.49));
		cachedItems.Add("Coca Cola Diet 330", new ItemDrink("Coca Cola Diet Can", ItemMakerType.Value.CocaCola, 330, 1.49));
		cachedItems.Add("Coca Cola Diet 500", new ItemDrink("Coca Cola Diet Bottle", ItemMakerType.Value.CocaCola, 500, 2.49));
		cachedItems.Add("Coca Cola Zero 330", new ItemDrink("Coca Cola Zero Can", ItemMakerType.Value.CocaCola, 330, 1.49));
		cachedItems.Add("Coca Cola Zero 500", new ItemDrink("Coca Cola Zero Bottle", ItemMakerType.Value.CocaCola, 500, 2.49));
		cachedItems.Add("Sprite 330", new ItemDrink("Sprite Can", ItemMakerType.Value.CocaCola, 330, 1.49));
		cachedItems.Add("Sprite 500", new ItemDrink("Sprite Bottle", ItemMakerType.Value.CocaCola, 500, 2.49));
		cachedItems.Add("Sprite Diet 330", new ItemDrink("Sprite Diet Can", ItemMakerType.Value.CocaCola, 330, 1.49));
		cachedItems.Add("Sprite Diet 500", new ItemDrink("Sprite Diet Bottle", ItemMakerType.Value.CocaCola, 500, 2.49));
		cachedItems.Add("Fanta 330", new ItemDrink("Fanta Can", ItemMakerType.Value.CocaCola, 330, 1.49));
		cachedItems.Add("Fanta 500", new ItemDrink("Fanta Bottle", ItemMakerType.Value.CocaCola, 500, 2.49));
		cachedItems.Add("Fuze Tea 330", new ItemDrink("Fuze Tea Can", ItemMakerType.Value.CocaCola, 330, 1.49));
		cachedItems.Add("Fuze Tea 500", new ItemDrink("Fuze Tea Bottle", ItemMakerType.Value.CocaCola, 500, 2.49));
		cachedItems.Add("Pepsi 330", new ItemDrink("Pepsi Can", ItemMakerType.Value.PepsiCo, 330, 1.29));
		cachedItems.Add("Pepsi 500", new ItemDrink("Pepsi Bottle", ItemMakerType.Value.PepsiCo, 500, 2.29));
		cachedItems.Add("Pepsi Max 330", new ItemDrink("Pepsi Max Can", ItemMakerType.Value.PepsiCo, 330, 1.29));
		cachedItems.Add("Pepsi Max 500", new ItemDrink("Pepsi Max Bottle", ItemMakerType.Value.PepsiCo, 500, 2.29));
		cachedItems.Add("Evian 500", new ItemDrink("Evian Bottle", ItemMakerType.Value.Regions, 500, 1.79));
		cachedItems.Add("Aqua Panna 500", new ItemDrink("Aqua Panna Bottle", ItemMakerType.Value.Toscana, 500, 1.69));

		cachedItems.Add("Lays Classic", new ItemFood("Lays Classic", ItemMakerType.Value.Fritolay, 300, 2.99));
		cachedItems.Add("Lays Barbecue", new ItemFood("Lays Barbecue", ItemMakerType.Value.Fritolay, 300, 3.0));
		cachedItems.Add("Lays Sour Cream & Onion", new ItemFood("Lays Sour Cream & Onion", ItemMakerType.Value.Fritolay, 300, 3.0));
	}
	public static Item GetItem(string key)
	{
		if (cachedItems.Count == 0)
			LoadCachedItems();
		return cachedItems.ContainsKey(key) ? (Item)cachedItems[key].Clone() : null;
	}
}

public interface IEatable
{
	// Simple interface that demonstrates actions for a specifit set of objects (by object type).
	void Eat();
}
public interface IDrinkable
{
	// Simple interface that demonstrates actions for a specifit set of objects (by object type).
	void Drink();
}

public interface Observer
{
	void Update(VendingMachineLog log);
}
public sealed class MachineScreenObserver : Observer
{
	public void Update(VendingMachineLog log)
	{
		Console.WriteLine("Machine Screen: {0}", log.LogMessage);
	}
}
public sealed class MachineLoggerObserver : Observer
{
	private List<VendingMachineLog> vendingMachineLogs;

	public MachineLoggerObserver()
	{
		this.vendingMachineLogs = new List<VendingMachineLog>();
	}

	public void PrintLastMachineLogs(int num)
	{
		foreach (VendingMachineLog log in vendingMachineLogs)
		{
			if (num-- > 0)
				return;

			Console.WriteLine(log);
		}
	}
	public void Update(VendingMachineLog log)
	{
		this.vendingMachineLogs.Add(log);
		Console.WriteLine("Machine Logger: {0}", log.LogMessage);
	}
}
public interface ObserverCommands
{
	void RegisterObserver(Observer observer);
	void UnregisterObserver(Observer observer);
	void NotifyAllObservers(VendingMachineLog log);
}

public abstract class Record
{
	protected readonly int recordID;
	protected readonly DateTime recordDate;
	protected readonly string recordMessage;

	public Record(int recordID, DateTime recordDate, string recordMessage)
	{
		this.recordID = recordID;
		this.recordDate = recordDate;
		this.recordMessage = recordMessage;
	}

	public int RecordID
	{
		get
		{
			return this.recordID;
		}
	}
	public DateTime RecordDate
	{
		get
		{
			return this.recordDate;
		}
	}
	public string RecordMessage
	{
		get
		{
			return this.recordMessage;
		}
	}
}
public sealed class SaleRecord : Record
{
	private static int totalSaleRecords = 0;

	private readonly Item saleItem;
	private readonly double amountPaid;

	public SaleRecord(DateTime recordDate, string recordMessage, Item saleItem, double amountPaid) :
		base(totalSaleRecords++, recordDate, recordMessage)
	{
		this.saleItem = saleItem;
		this.amountPaid = amountPaid;
	}

	public Item SaleItem
	{
		get
		{
			return this.saleItem;
		}
	}
	public double AmountPaid
	{
		get
		{
			return this.amountPaid;
		}
	}

	public override string ToString()
	{
		return string.Format("[Sale Record] ID: {0}, Date: {1}, Item Sold: {2}, Sale Amount: {3}",
			this.recordID, this.recordDate.ToString("dd/MM/yyyy HH:mm:ss"), this.saleItem.ItemName, this.saleItem.ItemPrice);
	}
}

public class VendingMachineLog
{
	private static int totalVendingMachineLogs = 0;

	protected readonly int logID;
	protected readonly DateTime logDate;
	protected readonly string logMessage;

	public VendingMachineLog(string logMessage)
	{
		this.logID = totalVendingMachineLogs++;
		this.logDate = DateTime.Now;
		this.logMessage = logMessage;
	}
	public VendingMachineLog(DateTime logDate, string logMessage)
	{
		this.logID = totalVendingMachineLogs++;
		this.logDate = logDate;
		this.logMessage = logMessage;
	}

	public int LogID
	{
		get
		{
			return this.logID;
		}
	}
	public DateTime LogDate
	{
		get
		{
			return this.logDate;
		}
	}
	public string LogMessage
	{
		get
		{
			return this.logMessage;
		}
	}

	public override string ToString()
	{
		return string.Format("[Log] ID: {0}, Date: {1}, Message: {2}",
			this.logID, this.logDate.ToString("dd/MM/yyyy HH:mm:ss"), this.logMessage);
	}
}
