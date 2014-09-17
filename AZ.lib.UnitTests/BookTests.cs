using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			GivenBookOneIs("SomeTitle", "SomeAuthor");
			GivenBookTwoIs("AnotherTitle", "AnotherAuthor");
			WhenTheTwoBooksAreCompared();
			ThenTheTwoBooksAreNotTheSame();
		}

		[TestMethod]
		public void ShouldCompareTwoBooksThatAreTheSame()
		{
			GivenBookOneIs("SomeTitle", "SomeAuthor");
			GivenBookTwoIs("SomeTitle", "SomeAuthor");
			WhenTheTwoBooksAreCompared();
			ThenTheTwoBooksAreTheSame();
		}

		private void GivenBookOneIs(string title, string author)
		{
			_bookOne.Title = title;
			_bookOne.Author = author;
		}

		private void GivenBookTwoIs(string title, string author)
		{
			_bookTwo.Title = title;
			_bookTwo.Author = author;
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
	}
}
