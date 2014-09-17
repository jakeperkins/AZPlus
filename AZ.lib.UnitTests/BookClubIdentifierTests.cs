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
			_bookClubList = new BookClubList();
		}

		[TestMethod]
		public void ShouldCreateWishListWithBookClubBooks()
		{
			GivenAWishlist(new []{
				new Book
				{
					Title = "someTitle", Author = "someAuthor"
				}, 
			
				new Book
				{
					Title = "anotherTitle", Author = "anotherAuthor"
				}});

			GivenABookClubList();
			WhenBookClubSelectionsAreIdentified();
			ThenTheBookOnTheBookClubListsIs();
			ThenTheBookNotOnTheBookClubListIs();
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
			throw new System.NotImplementedException();
		}

		private void WhenBookClubSelectionsAreIdentified()
		{
			_decoratedWishlist = new BookClubIdentifier().Identify(_wishList, _bookClubList);
		}

		private void ThenTheBookOnTheBookClubListsIs(Book book)
		{
			_decoratedWishlist.Books.Contains(new WishListBook {BookDetails = book, IsBookClubSelection = true}).ShouldBeTrue();
		}

		private void ThenTheBookNotOnTheBookClubListIs(Book book)
		{
			_decoratedWishlist.Books.Contains(new WishListBook {BookDetails = book, IsBookClubSelection = true}).ShouldBeFalse();
		}

		private BookClubList _bookClubList;
		private WishList _wishList;
		private WishList _decoratedWishlist;
	}
}