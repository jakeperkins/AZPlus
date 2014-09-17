using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace AZ.lib.UnitTests
{
	[TestClass]
	public class SearchTests
	{
		[TestInitialize]
		public void Setup()
		{
			_user = new User();
			_search = new Search();
		}

		[TestMethod]
		public void ShouldReturnDiscountedPaperbackBooks()
		{
			GivenAmazonHasTheseBooks(
				new BookBuilder().WithAuthor("Author").WithTitle("Title").IsType(BookType.Hardback), 
				new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title").IsType(BookType.Paperback)
			);
			GivenAUserWithOwnedBooks(new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title").IsType(BookType.Kindle));
			WhenTheUserRequestsAmazonBooks();
			TheDiscountOfTheBookIs(new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title"), 10);
			TheDiscountOfTheBookIs(new BookBuilder().WithAuthor("Author").WithTitle("Title").IsType(BookType.Hardback), 0);
		}

		private void TheDiscountOfTheBookIs(Book book, int discount)
		{
			_returnedBooksForUser.Select(x => x).First(x => x.IsSameTitleAndAuthor(book)).DiscountPercentage.ShouldEqual(discount);
		}

		private void WhenTheUserRequestsAmazonBooks()
		{
			_returnedBooksForUser = _search.GetBooks(_user);
		}

		private void GivenAUserWithOwnedBooks(params Book [] books)
		{
			_user.OwnedBooks = books;
		}

		private void GivenAmazonHasTheseBooks(params Book [] books)
		{
			((Search) _search).AmazonBooks = books;
		}

		private ISearch _search;
		private User _user;
		private IList<Book> _returnedBooksForUser;
	}


	public class BookBuilder
	{
		public BookBuilder()
		{
			book = new Book {BookType = BookType.Hardback};
		}

		public BookBuilder WithAuthor(string author)
		{
			book.Author = author;
			return this;
		}

		public BookBuilder WithTitle(string title)
		{
			book.Title = title;
			return this;
		}

		public BookBuilder IsType(BookType bookType)
		{
			book.BookType = bookType;
			return this;
		}

		public static implicit operator Book(BookBuilder builder)
		{
			return builder.book;
		}

		private Book book;
	}
}