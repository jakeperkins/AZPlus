using System;
using System.Text;
using System.Collections.Generic;
using AZ.lib.Cart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace AZ.lib.UnitTests
{
    /// <summary>
    /// Summary description for CartTests
    /// </summary>
    [TestClass]
    public class CartTests
    {
        private ShoppingCart _cart;
        private decimal _totalPrice;
        private BookClub _bookClub;

        [TestMethod]
        public void CreateANewCart()
        {
            GivenANewShoppingCart();
            ThenNumberOfBooksInCartShouldBe(0);
        }

        [TestMethod]
        public void UserAddsABookToCart()
        {
            GivenANewShoppingCart();
            WhenABookIsAddedToTheCart();
            ThenNumberOfBooksInCartShouldBe(1);
        }

        [TestMethod]
        public void UserBuysBooksInCart()
        {
            GivenANewShoppingCart();
            GivenBooksAreInTheCart();
            WhenUserChecksOut();
            ThenTotalPriceReturnedIs((decimal)10.98);
        }

        [TestMethod]
        public void UserHasBookClubBooksInCart()
        {
            GivenANewShoppingCart();
            GivenABookClub();
            GivenBookClubBooksAreInTheCart();
            WhenUserChecksOut();
            ThenTotalPriceReturnedIs((decimal)5.99);
        }

        private void GivenBookClubBooksAreInTheCart()
        {
            _cart.BooksToPurchase.Add(
                new Book
                {
                    Author = "SomeAuthor",
                    Title = "SomeTitle",
                    BookType = BookType.Hardback,
                    Price = (decimal)5.99
                }
            );
        }

        private void GivenABookClub()
        {
            IList<Book> bookClubBooks = new List<Book>()
            {
                new Book
            {
                Author = "SomeAuthor",
                Title = "SomeTitle",
                BookType = BookType.Hardback,
                Price = (decimal) 5.99
            },
            new Book
            {
                Author = "OtherAuthor",
                Title = "OtherTitle",
                BookType = BookType.Paperback,
                Price = (decimal) 4.99
            },
            new Book
            {
                Author = "NewAuthor",
                Title = "NewTitle",
                BookType = BookType.Kindle,
                Price = (decimal) 6.99
            }
            };
            _bookClub = new BookClub {Books = bookClubBooks};
        }

        private void ThenTotalPriceReturnedIs(decimal price)
        {
            _totalPrice.ShouldEqual(price);
        }

        private void WhenUserChecksOut()
        {
            _totalPrice = _cart.Checkout();
        }

        private void GivenBooksAreInTheCart()
        {
            _cart.BooksToPurchase.Add(new Book
            {
                Author = "SomeAuthor",
                Title = "SomeTitle",
                BookType = BookType.Hardback,
                Price = (decimal)5.99
            });
            _cart.BooksToPurchase.Add(new Book
            {
                Author = "OtherAuthor",
                Title = "OtherTitle",
                BookType = BookType.Hardback,
                Price = (decimal)4.99
            });
        }

        private void WhenABookIsAddedToTheCart()
        {
            _cart.AddBook(new Book
            {
                Author = "SomeAuthor",
                Title = "SomeTitle",
                BookType = BookType.Hardback,
                Price = (decimal)4.99
            });
        }

        private void ThenNumberOfBooksInCartShouldBe(int count)
        {
            _cart.BooksToPurchase.Count.ShouldEqual(count);
        }

        private void GivenANewShoppingCart()
        {
            _cart = new ShoppingCart();
        }
    }
}
