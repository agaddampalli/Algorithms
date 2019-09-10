<Query Kind="Program" />

void Main()
{
	
}

public enum Suit
{
	Heart,
	Diamond,
	Club,
	Spade
}

public class Card
{
	public int Value { get; set; }
	public Suit Suit { get; set; }
	
	public Card(int val, Suit suit)
	{
		this.Value = val;
		this.Suit = suit;
	}
}

public class Deck
{
	private List<Card> cards;
	
	public Deck()
	{
		cards = new List<Card>();
		
		for (int i = 1; i <= 13; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				cards.Add(new Card(i, (Suit)j))
			}
		}
	}
}