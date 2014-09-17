using System.Collections.Generic;

namespace AZ.lib
{
	public interface ISearch
	{
		IList<Book> GetBooks(User user);
	}

	public class Search : ISearch
	{
		public IList<Book> GetBooks(User user)
		{
			foreach (var userBook in user.OwnedBooks)
			{
				foreach (var amazonBook in AmazonBooks)
				{
					if (userBook.IsSameTitleAndAuthor(amazonBook) && userBook.BookType == BookType.Kindle &&
					    amazonBook.BookType == BookType.Paperback)
					{
						amazonBook.DiscountPercentage = Discount;
					}
				}
			}

			return AmazonBooks;
		}

		internal IList<Book> AmazonBooks = new[] 
		{
			new Book{Author = "author1", Title = "book1", BookType = BookType.Hardback},
			new Book{Author = "author2", Title = "book2", BookType = BookType.Paperback},
			new Book{Author = "author3", Title = "book3", BookType = BookType.Kindle}
		};

		private const int Discount = 10;
	}
}