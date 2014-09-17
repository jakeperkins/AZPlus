using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace AZ.lib.UnitTests
{
    [TestClass]
    public class WishListTests
    {
        [TestMethod]
        public void WishListCanHoldItems()
        {
            var wishList = new WishList();
            wishList.Items.ShouldNotBeNull();
        }

        [TestMethod]
        public void WishListIsEmpty()
        {
            var wishList = new WishList();
            wishList.Items.Count.ShouldEqual(0);
        }
    }
}
