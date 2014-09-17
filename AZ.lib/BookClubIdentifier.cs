namespace AZ.lib
{
	public class BookClubIdentifier
	{
		public WishList Identify(WishList wishList, BookClub bookClub)
		{
			foreach (var bookClubBook in bookClub.Books)
			{
				foreach (var wishListBook in wishList.Books)
				{
					if (wishListBook.Book.IsSameTitleAndAuthor(bookClubBook))
					{
						wishListBook.IsBookClubSelection = true;
					}
				}
			}

			return wishList;
		}
	}
}