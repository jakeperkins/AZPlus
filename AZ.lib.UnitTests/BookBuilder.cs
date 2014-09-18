namespace AZ.lib.UnitTests
{
	public class BookBuilder
	{
		public BookBuilder()
		{
			book = new Book {BookType = BookType.Hardback};
		}

		public BookBuilder WithAuthor(string author)
		{
			book.Author = author;
			return this;
		}

		public BookBuilder WithTitle(string title)
		{
			book.Title = title;
			return this;
		}

		public BookBuilder IsType(BookType bookType)
		{
			book.BookType = bookType;
			return this;
		}

		public static implicit operator Book(BookBuilder builder)
		{
			return builder.book;
		}

		private readonly Book book;
	}
}