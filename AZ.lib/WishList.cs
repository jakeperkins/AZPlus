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
            Items = new List<object>();
        }

        public IList<object> Items { get; set; }
    }
}
