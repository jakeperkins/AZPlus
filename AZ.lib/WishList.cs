using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Books.Add(new WishListBook {BookDetails = book});
        }
    }
}
