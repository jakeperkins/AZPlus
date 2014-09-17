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

        public IEnumerable<WishListBook> Books { get; set; }
    }
}
