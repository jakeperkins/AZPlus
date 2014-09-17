
namespace AZ.lib
{
	public class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }

		public bool IsSameTitleAndAuthor(Book book)
		{
			return Title == book.Title && Author == book.Author;
		}
	}
}
