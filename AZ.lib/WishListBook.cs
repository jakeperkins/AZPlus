using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.lib
{
    public class WishListBook
    {
        public WishListBook()
        {
            BookDetails = new Book();
        }
        public bool IsBookClubSelection { get; set; }
        public Book BookDetails { get; set; }
    }
}
