using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace AZ.lib.UnitTests
{
	[TestClass]
	public class BookClubIdentifierTests
	{
		[TestInitialize]
		public void Setup()
		{
			_wishList = new WishList();
			_bookClub = new BookClub();

			_bookOne = new Book
			{
				Title = "someTitle",
				Author = "someAuthor"
			};
			_bookTwo = new Book
			{
				Title = "anotherTitle",
				Author = "anotherAuthor"
			};
		}

		[TestMethod]
		public void ShouldCreateWishListWithBookClubBooks()
		{
			GivenAWishlist(new []{_bookOne, _bookTwo});
			GivenABookClubList(new [] {_bookTwo});
			WhenBookClubSelectionsAreIdentified();
			ThenTheBookOnTheBookClubListsIs(_bookTwo);
			ThenTheBookNotOnTheBookClubListIs(_bookOne);
		}

		[TestMethod]
		public void ShouldCreateWishListWithAllBookClubBooks()
		{
			GivenAWishlist(new[] { _bookOne, _bookTwo });
			GivenABookClubList(new[] { _bookOne, _bookTwo });
			WhenBookClubSelectionsAreIdentified();
			ThenTheBookOnTheBookClubListsIs(_bookTwo);
			ThenTheBookOnTheBookClubListsIs(_bookOne);
		}

		[TestMethod]
		public void ShouldCreateWishListWithNoBookClubBooks()
		{
			GivenAWishlist(new[] { _bookOne, _bookTwo });
			GivenABookClubList(new List<Book>());
			WhenBookClubSelectionsAreIdentified();
			ThenTheBookNotOnTheBookClubListIs(_bookTwo);
			ThenTheBookNotOnTheBookClubListIs(_bookOne);
		}

		private void GivenAWishlist(IEnumerable<Book> books)
		{
			foreach (var book in books)
			{
				_wishList.AddBook(book);
			}
		}

		private void GivenABookClubList(IEnumerable<Book> books)
		{
			_bookClub.Books = books;
		}

		private void WhenBookClubSelectionsAreIdentified()
		{
			_decoratedWishlist = new BookClubIdentifier().Identify(_wishList, _bookClub);
		}

		private void ThenTheBookOnTheBookClubListsIs(Book book)
		{
			WishListBook returnedBook = (_decoratedWishlist.Books.Select(x => x).First(x => x.Book.IsSameTitleAndAuthor(book)));
			returnedBook.IsBookClubSelection.ShouldBeTrue();
		}

		private void ThenTheBookNotOnTheBookClubListIs(Book book)
		{
			WishListBook returnedBook = (_decoratedWishlist.Books.Select(x => x).First(x => x.Book.IsSameTitleAndAuthor(book)));
			returnedBook.IsBookClubSelection.ShouldBeFalse();
		}

		private Book _bookOne;
		private Book _bookTwo;
		private BookClub _bookClub;
		private WishList _wishList;
		private WishList _decoratedWishlist;
	}
}