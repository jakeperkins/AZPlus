using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace AZ.lib.UnitTests
{
	[TestClass]
	public class BookTests
	{
		[TestInitialize]
		public void Setup()
		{
			_bookOne = new Book();
			_bookTwo = new Book();
		}

		[TestMethod]
		public void ShouldCompareTwoBooksThatAreDifferent()
		{
            GivenBookOneIs("SomeTitle", "SomeAuthor", SomePrice);
			GivenBookTwoIs("AnotherTitle", "AnotherAuthor");
			WhenTheTwoBooksAreCompared();
			ThenTheTwoBooksAreNotTheSame();
		}

		[TestMethod]
		public void ShouldCompareTwoBooksThatAreTheSame()
		{
            GivenBookOneIs("SomeTitle", "SomeAuthor", SomePrice);
            GivenBookTwoIs("SomeTitle", "SomeAuthor");
			WhenTheTwoBooksAreCompared();
			ThenTheTwoBooksAreTheSame();
		}

	    [TestMethod]
	    public void BookShouldHavePrice()
	    {
	        GivenBookOneIs("SomeTitle", "SomeAuthor", SomePrice);
	        ThenTheBookShouldHavePrice(SomePrice);
	    }

	    private void ThenTheBookShouldHavePrice(decimal price)
	    {
	        _bookOne.Price.ShouldEqual(price);
	    }


	    private void GivenBookOneIs(string title, string author, decimal price)
		{
			_bookOne.Title = title;
			_bookOne.Author = author;
			_bookOne.BookType = BookType.Hardback;
	        _bookOne.Price = price;
		}

		private void GivenBookTwoIs(string title, string author)
		{
			_bookTwo.Title = title;
			_bookTwo.Author = author;
			_bookTwo.BookType = BookType.Hardback;
		}

		private void WhenTheTwoBooksAreCompared()
		{
			_bookComparison = _bookOne.IsSameTitleAndAuthor(_bookTwo);
		}

		private void ThenTheTwoBooksAreNotTheSame()
		{
			Assert.IsFalse(_bookComparison);
		}

		private void ThenTheTwoBooksAreTheSame()
		{
			Assert.IsTrue(_bookComparison);
		}

		private bool _bookComparison;
		private Book _bookOne;
		private Book _bookTwo;

	    private const decimal SomePrice = (decimal) 5.99;
	}
}
