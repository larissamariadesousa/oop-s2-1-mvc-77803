namespace Library.Tests;

using Xunit;
using Library.Domain;

public class LibraryTests
{
    [Fact]
    public void Book_Should_Be_Available_By_Default()
    {
        var book = new Book();
        Assert.True(book.IsAvailable);
    }

    [Fact]
    public void Loan_Should_Start_Not_Returned()
    {
        var loan = new Loan();
        Assert.Null(loan.ReturnedDate);
    }

    [Fact]
    public void Member_Should_Have_Name()
    {
        var member = new Member { FullName = "Test" };
        Assert.Equal("Test", member.FullName);
    }
}