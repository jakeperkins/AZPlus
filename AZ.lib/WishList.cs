using System.Collections.Generic;
using System.Linq;

namespace AZ.lib
{
    public class WishList
    { 
        public WishList()
        {
            Books = new List<WishListBook>();
        }

        public IList<WishListBook> Books { get; set; }

        public void AddBook(Book book)
        {
            var isBookAlreadyAdded = false; 
            foreach (var wishListBook in Books)
            {
                isBookAlreadyAdded = wishListBook.Book.IsSameTitleAndAuthor(book);
            }
            if (!isBookAlreadyAdded)
                Books.Add(new WishListBook {Book = book});
        }

        public void RemoveBook(Book book)
        {
            var booksToRemove = (from b in Books where b.Book.IsSameTitleAndAuthor(book) select b).ToList();
            if (!booksToRemove.Any()) return;
            foreach (var wishListBook in booksToRemove)
            {
                Books.Remove(wishListBook);
            }
        }
    }
}
