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
			_bookOne = new BookBuilder().WithAuthor("author1").WithTitle("title");
			_bookTwo = new BookBuilder().WithAuthor("author2").WithTitle("title2");
		}

		[TestMethod]
		public void ShouldHydrateKindleWithPreviewChaptersFromBookClubSelection()
		{
			GivenAUserWithAKindle();
			GivenAUsersBookClubHasBooks(_bookOne);
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheKindleHasPreviewChaptersFor(_bookOne);
		}

		[TestMethod]
		public void ShouldHydrateKindleWithPreviewChaptersFromMutlipleBooksInAClubSelection()
		{
			GivenAUserWithAKindle();
			GivenAUsersBookClubHasBooks(_bookOne, _bookTwo);
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheKindleHasPreviewChaptersFor(_bookOne);
			ThenTheKindleHasPreviewChaptersFor(_bookTwo);
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
			GivenAUsersBookClubHasBooks(_bookOne, _bookTwo);
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheUserStillHasNoKindle();
		}

		[TestMethod]
		public void ShouldNotAddPreviewChaptersIfUserAlreadyOwnsBook()
		{
			GivenAUserWithAKindle();
			GivenAUsersKindleHasBooks(_bookOne);
			GivenAUsersBookClubHasBooks(_bookOne, _bookTwo);
			WhenAmazonTriesToSetupAUsersKindle();
			ThenTheKindleHasPreviewChaptersFor(_bookTwo);
			ThenTheKindleDoesNotHavePreviewChaptersFor(_bookOne);
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

		private void ThenTheKindleDoesNotHavePreviewChaptersFor(Book book)
		{
			_returnedKindle.Books.Select(x => x).First(x => x.Book.IsSameTitleAndAuthor(book)).ShowOnlyPreviewChapters.ShouldBeFalse();
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

		private void GivenAUsersKindleHasBooks(Book book)
		{
			_user.Kindle.Books.Add(new KindleBook {Book = book, ShowOnlyPreviewChapters = false});
		}

		private void GivenAUserWithNoKindle()
		{
		}

		private Book _bookOne;
		private Book _bookTwo;
		private lib.Kindle _returnedKindle;
		private User _user;
	}
}