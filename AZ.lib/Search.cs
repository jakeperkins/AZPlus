using System.Collections.Generic;

namespace AZ.lib
{
	public interface ISearch
	{
		IList<Book> GetBooks(User user);
	}

	public class Search : ISearch
	{
		public Search() : this(new PaperBackDiscountRule()){}

		public Search(IBookRule bookRule)
		{
			_bookRule = bookRule;
		}

		public IList<Book> GetBooks(User user)
		{
			foreach (var userBook in user.OwnedBooks)
			{
				for (var i = 0; i < AmazonBooks.Count; i++)
				{
					AmazonBooks[i] = _bookRule.Execute(userBook, AmazonBooks[i]);
				}
			}

			return AmazonBooks;
		}

		private readonly IBookRule _bookRule;

		internal IList<Book> AmazonBooks = new[] 
		{
			new Book{Author = "author1", Title = "book1", BookType = BookType.Hardback},
			new Book{Author = "author2", Title = "book2", BookType = BookType.Paperback},
			new Book{Author = "author3", Title = "book3", BookType = BookType.Kindle}
		};
	}
}