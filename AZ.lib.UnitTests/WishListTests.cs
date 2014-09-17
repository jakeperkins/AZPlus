using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Linq;

namespace AZ.lib.UnitTests
{
    [TestClass]
    public class WishListTests
    {
        private WishList _wishList;
        private WishListBook _wishListBook;

        [TestMethod]
        public void AWishListBookHasABookClubFlag()
        {
            GivenAWishListBook();
            ThenBookClubSelectionShouldBeFalse();
        }

        [TestMethod]
        public void AWishListBookHasBookDetails()
        {
            GivenAWishListBook();
            ThenBookDetailsShouldNotBeNull();
        }

        private void ThenBookDetailsShouldNotBeNull()
        {
            _wishListBook.Book.ShouldNotBeNull();
        }

        private void ThenBookClubSelectionShouldBeFalse()
        {
            _wishListBook.IsBookClubSelection.ShouldBeFalse();
        }

        private void GivenAWishListBook()
        {
            _wishListBook = new WishListBook();
            
        }

        private void GivenAWishList()
        {
            _wishList = new WishList();
        }

        private void ThenNumberOfBooksShouldBe(int bookCount)
        {
            _wishList.Books.Count().ShouldEqual(bookCount);
        }

        [TestMethod]
        public void WishListIsEmpty()
        {
            GivenAWishList();
            ThenNumberOfBooksShouldBe(0);
        }

        [TestMethod]
        public void CanAddABookToTheWishList()
        {
            GivenAWishList();
            WhenABookIsAddedToTheWishList();
            ThenNumberOfBooksShouldBe(1);
        }

        private void WhenABookIsAddedToTheWishList()
        {
            _wishList.AddBook(new Book {Author = Author, Title = Title});
        }

        [TestMethod]
        public void CannotAddSameBookToWishList()
        {
            GivenAWishList();
            WhenABookIsAddedToTheWishList(Author, Title);
            WhenABookIsAddedToTheWishList(Author, Title);
            ThenNumberOfBooksShouldBe(1);
        }

        [TestMethod]
        public void CanAddDifferentBookToWishList()
        {
            GivenAWishList();
            WhenABookIsAddedToTheWishList(Author, Title);
            WhenABookIsAddedToTheWishList(Author, OtherTitle);
            ThenNumberOfBooksShouldBe(2);
        }

        [TestMethod]
        public void CanRemoveABookFromWishList()
        {
            GivenAWishListWithBooksAdded();
            WhenABookIsRemovedFromTheWishList(Author, Title);
            ThenNumberOfBooksShouldBe(0);
        }

        [TestMethod]
        public void CanAttemptToRemoveABookFromEmptyWishList()
        {
            GivenAWishList();
            WhenABookIsRemovedFromTheWishList(Author, Title);
            ThenNumberOfBooksShouldBe(0);
        }

        private void WhenABookIsRemovedFromTheWishList(string author, string title)
        {
            _wishList.RemoveBook(new Book { Author= author, Title = title});
        }

        private void GivenAWishListWithBooksAdded()
        {
            GivenAWishList();
            WhenABookIsAddedToTheWishList(Author, Title);
        }

        private void WhenABookIsAddedToTheWishList(string author, string title)
        {
            _wishList.AddBook(new Book {Author = author, Title = title});
        }

        [TestMethod]
        public void CanSetBookClubFlag()
        {
            GivenAWishListBook();
            WhenBookIsBookClubOption();
            ThenBookClubSelectionShouldBeTrue();
        }

        private void ThenBookClubSelectionShouldBeTrue()
        {
            _wishListBook.IsBookClubSelection.ShouldBeTrue();
        }

        private void WhenBookIsBookClubOption()
        {
            _wishListBook.IsBookClubSelection = true;
        }

        private const string Title = "Testing";
        private const string Author = "Matt Eagin";

        private const string OtherTitle = "Refactoring";
    }
}
