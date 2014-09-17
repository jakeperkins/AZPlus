using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

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
            _wishList.Books.Count().ShouldEqual(0);
        }

        [TestMethod]
        public void WishListIsEmpty()
        {
            GivenAWishList();
            ThenNumberOfBooksShouldBe(0);
        }
    }
}
