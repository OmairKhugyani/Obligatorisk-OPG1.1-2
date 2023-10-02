using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

[TestClass]
public class BooksRepositoryTests
{
    [TestMethod]
    public void Get_ReturnsAllBooks()
    {
        // Arrange
        var repository = new BooksRepository();

        // Act
        var result = repository.Get();

        // Assert
        Assert.AreEqual(5, result.Count);
    }

    [TestMethod]
    public void Get_FilterByPrice_ReturnsFilteredBooks()
    {
        // Arrange
        var repository = new BooksRepository();

        // Act
        var result = repository.Get(150);

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.IsTrue(result.All(book => book.Price <= 150));
    }

    [TestMethod]
    public void GetById_ValidId_ReturnsCorrectBook()
    {
        // Arrange
        var repository = new BooksRepository();
        int validId = 3;

        // Act
        var result = repository.GetById(validId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(validId, result.Id);
    }
}
