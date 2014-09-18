namespace AZ.lib
{
	public interface IBookRule
	{
		Book Execute(Book userBook, Book amazonBook);
	}
}