using System.Collections.Generic;

namespace AZ.lib
{
	public interface ISearch
	{
		IList<Book> GetBooks(User user);
	}

	public class Search : ISearch
	{
		public IList<Book> GetBooks(User user)
		{
			throw new System.NotImplementedException();
		}
	}
}