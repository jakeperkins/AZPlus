using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.lib.Cart
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            BooksToPurchase = new List<Book>();
        }
        public IList<Book> BooksToPurchase { get; set; }

        public void AddBook(Book book)
        {
            BooksToPurchase.Add(book);
        }

        public decimal Checkout()
        {
            return BooksToPurchase.Sum(book => book.Price);
        }
    }
}
