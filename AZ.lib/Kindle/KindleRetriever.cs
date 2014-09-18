using System.Linq;

namespace AZ.lib
{
	public class KindleRetriever
	{
		public Kindle Retrieve(User user)
		{
			if (UserHasKindle(user))
			{
				if (UserIsInBookClub(user))
				{
					var bookClubBooks = user.BookClub.Books;
					var kindleBooks = user.Kindle.Books;

					foreach (var bookClubBook in bookClubBooks)
					{
						kindleBooks.Add(new KindleBook {Book = bookClubBook, ShowOnlyPreviewChapters = true});
					}
				}
			}
			return user.Kindle;
		}

		private bool UserIsInBookClub(User user)
		{
			return user.BookClub != null;
		}

		private bool UserHasKindle(User user)
		{
			return user.Kindle != null;
		}
	}
}