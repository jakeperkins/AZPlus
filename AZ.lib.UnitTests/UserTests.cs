using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace AZ.lib.UnitTests
{
    [TestClass]
    public class UserTests
    {
        private User _user;
        private IList<Book> _books;

        [TestMethod]
        public void UserHasAListOfOwnedBooks()
        {
            GivenANewUser();
            ThenTheListOfOwnedBooksHasSize(0);
        }

        [TestMethod]
        public void CanAddABookToOwnedBooks()
        {
            GivenANewUser();
            WhenABookIsPurchased();
            ThenTheListOfOwnedBooksHasSize(1);
        }

        private void WhenABookIsPurchased()
        {
            _user.BuysBook(new Book
            {
                Author = "John Doe",
                BookType = BookType.Kindle,
                DiscountPercentage = 0,
                Title = "Testing Purchases"
            });
        }

        private void GivenANewUser()
        {
            _user = new User();
        }

        private void ThenTheListOfOwnedBooksHasSize(int bookCount)
        {
            _user.OwnedBooks.Count.ShouldEqual(bookCount);
        }
    }
}
