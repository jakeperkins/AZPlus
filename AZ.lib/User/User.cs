using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AZ.lib
{
	public class User
	{
		public User ()
		{
			OwnedBooks = new List<Book>();
		}

		public IList<Book> OwnedBooks { get; set; }

		public void BuysBook(Book book)
		{
			OwnedBooks.Add(book);
		}
	}
}