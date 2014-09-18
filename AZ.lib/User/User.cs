using System.Collections.Generic;

namespace AZ.lib
{
	public class User
	{
		public User ()
		{
			OwnedBooks = new List<Book>();
		}

		public IList<Book> OwnedBooks { get; set; }
		public WishList WishList { get; set; }
		public Kindle Kindle { get; set; }
		public BookClub BookClub { get; set; }

		public void BuysBook(Book book)
		{
			OwnedBooks.Add(book);
		}
	}
}