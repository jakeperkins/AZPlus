namespace AZ.lib
{
	public class PaperBackDiscountRule : IBookRule
	{
		public Book Execute(Book userBook, Book amazonBook)
		{
			if (userBook.IsSameTitleAndAuthor(amazonBook) && userBook.BookType == BookType.Kindle &&
			    amazonBook.BookType == BookType.Paperback)
			{
				amazonBook.DiscountPercentage = Discount;
			}

			return amazonBook;
		}

		private const int Discount = 10;
	}
}