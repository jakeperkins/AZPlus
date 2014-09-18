using System.Collections.Generic;
using System.Linq;

namespace AZ.lib.Cart
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            BooksToPurchase = new List<Book>();
        }
        public IList<Book> BooksToPurchase { get; set; }
        public OrderSummary OrderSummary { get; set; }

        public void AddBook(Book book)
        {
            BooksToPurchase.Add(book);
        }

        public OrderSummary Checkout(User user)
        {
            int bookClubCount = user.BookClub != null ? GetBookClubSelections(user.BookClub.Books) : 0;
            return new OrderSummary {TotalPrice = BooksToPurchase.Sum(book => book.Price), BookClubSelectionsCount=bookClubCount};
        }

        private int GetBookClubSelections(IEnumerable<Book> bookClubBooks)
        {
            return BooksToPurchase.Sum(book => bookClubBooks.Count(bookClubBook => bookClubBook.IsSameEdition(book)));
        }
    }

    public class OrderSummary
    {
        public decimal TotalPrice { get; set; }
        public int BookClubSelectionsCount { get; set; }
    }
}
