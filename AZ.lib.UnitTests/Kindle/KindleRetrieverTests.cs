using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace AZ.lib.UnitTests.Kindle
{
	[TestClass]
	public class KindleRetrieverTests
	{
		[TestInitialize]
		public void Setup()
		{
			_user = new User();
			_returnedKindle = new lib.Kindle();
		}

		[TestMethod]
		public void ShouldHydrateKindleWithPreviewChaptersFromBookClubSelection()
		{
			GivenAUserWithAKindle();
			GivenAUsersBookClubHasBooks(new BookBuilder().WithAuthor("author1").WithTitle("title"));
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheKindleHasPreviewChaptersFor(new BookBuilder().WithAuthor("author1").WithTitle("title"));
		}

		[TestMethod]
		public void ShouldHydrateKindleWithPreviewChaptersFromMutlipleBooksInAClubSelection()
		{
			GivenAUserWithAKindle();
			GivenAUsersBookClubHasBooks(new BookBuilder().WithAuthor("author1").WithTitle("title"), new BookBuilder().WithAuthor("author2").WithTitle("title2"));
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheKindleHasPreviewChaptersFor(new BookBuilder().WithAuthor("author1").WithTitle("title"));
			ThenTheKindleHasPreviewChaptersFor(new BookBuilder().WithAuthor("author2").WithTitle("title2"));
		}

		[TestMethod]
		public void ShouldNotHydrateKindleDueToNotBeingPartOfABookClub()
		{
			GivenAUserWithAKindle();
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheKindleHasNoNewBooksOrPreviewChapters();
		}

		[TestMethod]
		public void ShouldNotDoAnythingDoToUserNotOwningAKindle()
		{
			GivenAUserWithNoKindle();
			GivenAUsersBookClubHasBooks(new BookBuilder().WithAuthor("author1").WithTitle("title"), new BookBuilder().WithAuthor("author2").WithTitle("title2"));
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheUserStillHasNoKindle();
		}

		private void ThenTheKindleHasNoNewBooksOrPreviewChapters()
		{
			_user.Kindle.Books.Count.ShouldEqual(0);
		}

		private void ThenTheUserStillHasNoKindle()
		{
			_user.Kindle.ShouldBeNull();
		}

		private void ThenTheKindleHasPreviewChaptersFor(Book book)
		{
			_returnedKindle.Books.Select(x => x).First(x => x.Book.IsSameTitleAndAuthor(book)).ShowOnlyPreviewChapters.ShouldBeTrue();
		}

		private void WhenAmazonTriesToSetupAUsersKindle()
		{
			_returnedKindle = new KindleRetriever().Retrieve(_user);
		}

		private void GivenAUsersBookClubHasBooks(params Book[] books)
		{
			_user.BookClub = new BookClub {Books = new List<Book>()};
			_user.BookClub.Books = books.ToList();
		}

		private void GivenAUserWithAKindle()
		{
			_user.Kindle = new lib.Kindle {Books = new List<KindleBook>()};
		}

		private void GivenAUserWithNoKindle()
		{
		}


		private lib.Kindle _returnedKindle;
		private User _user;
	}
}