namespace AZ.lib
{
	public class WishListBook
	{
		public WishListBook()
		{
			Book = new Book();
		}
		public bool IsBookClubSelection { get; set; }
		public Book Book { get; set; }
	}
}
