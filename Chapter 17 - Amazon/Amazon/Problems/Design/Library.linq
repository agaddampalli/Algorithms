<Query Kind="Program" />

void Main()
{

}

public enum BookFormat
{
	HARDCOVER,
	PAPERBACK,
	AUDIO_BOOK,
	EBOOK,
	NEWSPAPER,
	MAGAZINE,
	JOURNAL
}

public enum BookStatus
{
	AVAILABLE,
	RESERVED,
	LOANED,
	LOST
}

public enum ReservationStatus
{
	WAITING,
	PENDING,
	CANCELED,
	NONE
}

public enum AccountStatus
{
	ACTIVE,
	CLOSED,
	CANCELED,
	BLACKLISTED,
	NONE
}

public class Address
{
	private String streetAddress;
	private String city;
	private String state;
	private String zipCode;
	private String country;
}

public class Person
{
	private String name;
	private Address address;
	private String email;
	private String phone;
}

public class Constants
{
	public static int MAX_BOOKS_ISSUED_TO_A_USER = 5;
	public static int MAX_LENDING_DAYS = 10;
}

public abstract class Account
{
	private String id;
	private String password;
	private AccountStatus status;
	private Person person;

	private int _totalBooks;

	public abstract bool resetPassword();

	public int getTotalBooksCheckedOut()
	{
		return _totalBooks;
	}
}

public abstract class BookReservation
{
	public DateTime creationDateTime;
	public ReservationStatus status;
	public String bookItemBarcode;
	public String memberId;

	public abstract BookReservation fetchReservationDetails(String barcode);
}

public abstract class BookLending
{
	public DateTime creationDateTime;
	public DateTime dueDateTime;
	public DateTime returnDateTime;
	public String bookItemBarcode;
	public String memberId;

	public abstract void lendBook(String barcode, String memberId);
	public abstract BookLending fetchLendingDetails(String barcode);
}

public class Fine
{
	private DateTime creationDateTime;
	private double bookItemBarcode;
	private String memberId;

	public static void collectFine(String memberId, long days) { }
}

public class Librarian : Account
{
	public bool addBookItem(BookItem bookItem)
	{
		return false;
	}

	public bool blockMember(Member member)
	{
		return false;
	}

	public override bool resetPassword()
	{
		throw new NotImplementedException();
	}

	public bool unBlockMember(Member member)
	{
		return false;
	}
}

public class Member : Account
{
	private DateTime DateTimeOfMembership;
	private int totalBooksCheckedout;

	public bool checkoutBookItem(BookItem bookItem)
	{
		if (this.getTotalBooksCheckedOut() >= Constants.MAX_BOOKS_ISSUED_TO_A_USER)
		{
			ShowError("The user has already checked-out maximum number of books");
			return false;
		}
		BookReservation bookReservation = BookReservation.fetchReservationDetails(bookItem.barcode);
		if (bookReservation != null && bookReservation.memberId != this.getId())
		{
			// book item has a pending reservation from another user
			ShowError("This book is reserved by another member");
			return false;
		}
		else if (bookReservation != null)
		{
			// book item has a pending reservation from the give member, upDateTime it
			bookReservation.upDateTimeStatus(ReservationStatus.COMPLETED);
		}

		if (!bookItem.checkout(this.getId()))
		{
			return false;
		}

		this.incrementTotalBooksCheckedout();
		return true;
	}

	void ShowError(string v)
	{
		throw new NotImplementedException();
	}

	private void checkForFine(String bookItemBarcode)
	{
		BookLending bookLending = BookLending.fetchLendingDetails(bookItemBarcode);
		DateTime dueDateTime = bookLending.getDueDateTime();
		DateTime today = new DateTime();
		// check if the book has been returned within the due DateTime
		if (today.compareTo(dueDateTime) > 0)
		{
			long diff = todayDateTime.getTime() - dueDateTime.getTime();
			long diffDays = diff / (24 * 60 * 60 * 1000);
			Fine.collectFine(memberId, diffDays);
		}
	}

	public void returnBookItem(BookItem bookItem)
	{
		this.checkForFine();
		BookReservation bookReservation = BookReservation.fetchReservationDetails(bookItem.getBarcode());
		if (bookReservation != null)
		{
			// book item has a pending reservation
			bookItem.upDateTimeBookItemStatus(BookStatus.RESERVED);
			bookReservation.sendBookAvailableNotification();
		}
		bookItem.upDateTimeBookItemStatus(BookStatus.AVAILABLE);
	}

	public bool renewBookItem(BookItem bookItem)
	{
		this.checkForFine();
		BookReservation bookReservation = BookReservation.fetchReservationDetails(bookItem.getBarcode());
		// check if this book item has a pending reservation from another member
		if (bookReservation != null && bookReservation.getMemberId() != member.getMemberId())
		{
			ShowError("This book is reserved by another member");
			member.decrementTotalBooksCheckedout();
			bookItem.upDateTimeBookItemState(BookStatus.RESERVED);
			bookReservation.sendBookAvailableNotification();
			return false;
		}
		else if (bookReservation != null)
		{
			// book item has a pending reservation from this member
			bookReservation.upDateTimeStatus(ReservationStatus.COMPLETED);
		}
		BookLending.lendBook(bookItem.getBarCode(), this.getMemberId());
		bookItem.upDateTimeDueDateTime(LocalDateTime.now().plusDays(Constants.MAX_LENDING_DAYS));
		return true;
	}

	public override bool resetPassword()
	{
		throw new NotImplementedException();
	}
}

public abstract class Book
{
	public String ISBN;
	public String title;
	public String subject;
	public String publisher;
	public String language;
	public int numberOfPages;
	public List<Account> authors;
}

public class BookItem : Book
{
	public String barcode;
	public bool isReferenceOnly;
	public DateTime borrowed;
	public DateTime dueDateTime;
	public double price;
	public BookFormat format;
	public BookStatus status;
	public DateTime DateTimeOfPurchase;
	public DateTime publicationDateTime;
	public Rack placedAt;

	public bool checkout(String memberId)
	{
		if (bookItem.getIsReferenceOnly())
		{
			ShowError("This book is Reference only and can't be issued");
			return false;
		}
		if (!BookLending.lendBook(this.getBarCode(), memberId))
		{
			return false;
		}
		this.upDateTimeBookItemStatus(BookStatus.LOANED);
		return true;
	}
}

public interface ISearch
{
	List<Book> searchByTitle(String title);
	List<Book> searchByAuthor(String author);
	List<Book> searchBySubject(String subject);
	List<Book> searchByPubDate(Date publishDate);
}

public class Catalog : ISearch
{
	private Dictionary<String, List<Book>> bookTitles;
	private Dictionary<String, List<Book>> bookAuthors;
	private Dictionary<String, List<Book>> bookSubjects;
	private Dictionary<String, List<Book>> bookPublicationDates;

	public List<Book> searchByTitle(String query)
	{
		// return all books containing the string query in their title.
		return bookTitles.get(query);
	}

	public List<Book> searchByAuthor(String query)
	{
		// return all books containing the string query in their author's name.
		return bookAuthors.get(query);
	}

	public List<Book> searchBySubject(string subject)
	{
		throw new NotImplementedException();
	}

	public List<Book> searchByPubDate(Date publishDate)
	{
		throw new NotImplementedException();
	}
}

public class Rack
{
	private int number;
	private String locationIdentifier;
}
