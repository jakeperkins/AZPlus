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
