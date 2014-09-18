using System.Collections.Generic;
using System.Linq;

namespace AZ.lib
{
	public class KindleRetriever
	{
		public Kindle Retrieve(User user)
		{
			if (!UserHasKindle(user)) return user.Kindle;
			if (!UserIsInBookClub(user)) return user.Kindle;

			var bookClubBooks = user.BookClub.Books.ToList();
			var kindleBooks = user.Kindle.Books;

			bookClubBooks = RemoveOwnedBooks(bookClubBooks, kindleBooks);

			foreach (var bookClubBook in bookClubBooks)
			{
				kindleBooks.Add(new KindleBook {Book = bookClubBook, ShowOnlyPreviewChapters = true});
			}
			return user.Kindle;
		}

		private List<Book> RemoveOwnedBooks(List<Book> bookClubBooks, IList<KindleBook> kindleBooks)
		{
			var books = bookClubBooks.ToList();
			foreach (var book in bookClubBooks)
			{
				foreach (var kindleBook in kindleBooks)
				{
					if (book.IsSameTitleAndAuthor(kindleBook.Book))
					{
						books.Remove(book);
					}
				}
			}
			return books;
		}

		private bool UserIsInBookClub(User user)
		{
			return user.BookClub != null;
		}

		private bool UserHasKindle(User user)
		{
			return user.Kindle != null;
		}
	}
}