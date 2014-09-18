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
        private OrderSummary _orderSummary;
        private BookClub _bookClub;
        private User _user;

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
            GivenAUser();
            GivenBooksAreInTheCart();
            WhenUserChecksOut();
            ThenTotalPriceReturnedIs((decimal)10.98);
        }

        [TestMethod]
        public void UserHasABookClubBookInCart()
        {
            GivenANewShoppingCart();
            GivenAUserIsMemberOfABookClub();
            GivenBookClubBooksAreInTheCart();
            WhenUserChecksOut();
            ThenTotalPriceReturnedIs((decimal)5.99);
            ThenTheNumberOfBookClubBooksReturnedIs(1);
        }

        [TestMethod]
        public void UserHasMultipleBookClubBooksInCart()
        {
            GivenANewShoppingCart();
            GivenAUserIsMemberOfABookClub();
            GivenMultipleBookClubBooksAreInTheCart();
            WhenUserChecksOut();
            ThenTotalPriceReturnedIs((decimal)10.98);
            ThenTheNumberOfBookClubBooksReturnedIs(2);
        }

        private void GivenAUser()
        {
            _user = new User();
        }

        private void ThenTheNumberOfBookClubBooksReturnedIs(int bookClubCount)
        {
            _orderSummary.BookClubSelectionsCount.ShouldEqual(bookClubCount);
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

        private void GivenMultipleBookClubBooksAreInTheCart()
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
            _cart.BooksToPurchase.Add(new Book
            {
                Author = "OtherAuthor",
                Title = "OtherTitle",
                BookType = BookType.Paperback,
                Price = (decimal)4.99
            });
        }

        private void GivenAUserIsMemberOfABookClub()
        {
            _user = new User
            {
                BookClub = new BookClub
                {
                    Books = new List<Book>()
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
                    }
                }
            };
        }

        private void ThenTotalPriceReturnedIs(decimal price)
        {
            _orderSummary.TotalPrice.ShouldEqual(price);
        }

        private void WhenUserChecksOut()
        {
            _orderSummary = _cart.Checkout(_user);
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
