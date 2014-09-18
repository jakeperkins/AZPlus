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
			var amazonBookOne = new BookBuilder().WithAuthor("Author").WithTitle("Title").IsType(BookType.Hardback);
			var amazonBookTwo = new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title").IsType(BookType.Paperback);

			GivenAmazonHasTheseBooks(amazonBookOne, amazonBookTwo);
			GivenAUserWithOwnedBooks(new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title").IsType(BookType.Kindle));
			WhenTheUserRequestsAmazonBooks();
			TheDiscountOfTheBookIs(amazonBookTwo, 10);
			TheDiscountOfTheBookIs(amazonBookOne, 0);
		}

		[TestMethod]
		public void ShouldNotReturnDiscountedPaperbackBooksBecauseUserDoesNotOwnKindleVersion()
		{
			var amazonBookOne = new BookBuilder().WithAuthor("Author").WithTitle("Title").IsType(BookType.Hardback);
			var amazonBookTwo = new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title").IsType(BookType.Paperback);

			GivenAmazonHasTheseBooks(amazonBookOne, amazonBookTwo);
			GivenAUserWithOwnedBooks(new BookBuilder().WithAuthor("Author").WithTitle("Title").IsType(BookType.Hardback));
			WhenTheUserRequestsAmazonBooks();
			TheDiscountOfTheBookIs(amazonBookTwo, 0);
			TheDiscountOfTheBookIs(amazonBookOne, 0);
		}

		[TestMethod]
		public void ShouldNotReturnAnyDiscountedBooksBecauseAmazonHasNoPaperbackVersions()
		{
			var amazonBookOne = new BookBuilder().WithAuthor("Author").WithTitle("Title").IsType(BookType.Hardback);
			var amazonBookTwo = new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title").IsType(BookType.Kindle);

			GivenAmazonHasTheseBooks(amazonBookOne, amazonBookTwo);
			GivenAUserWithOwnedBooks(new BookBuilder().WithAuthor("SomeAuthor").WithTitle("Title").IsType(BookType.Kindle));
			WhenTheUserRequestsAmazonBooks();
			TheDiscountOfTheBookIs(amazonBookTwo, 0);
			TheDiscountOfTheBookIs(amazonBookOne, 0);
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
}