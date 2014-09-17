using System;
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
		public void ShouldCompareTwoBooks()
		{
			GivenBookOneIs("SomeTitle", "SomeAuthor");
			GivenBookTwoIs("AnotherTitle", "AnotherAuthor");
			WhenTheTwoBooksAreCompared();
			ThenTheTwoBooksAreNotTheSame();
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

		private bool _bookComparison;
		private Book _bookOne;
		private Book _bookTwo;
	}
}
