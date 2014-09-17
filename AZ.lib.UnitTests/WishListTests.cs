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
            _wishListBook.BookDetails.ShouldNotBeNull();
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
            _wishList.AddBook(new Book {Author = "Matt Eagin", Title = "Testing"});
        }
    }
}
