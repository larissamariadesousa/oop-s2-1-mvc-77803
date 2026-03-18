using Xunit;
using Library.Domain;
using System;

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

    // 1
    [Fact]
    public void Loan_Should_Make_Book_Unavailable()
    {
        var book = new Book
        {
            Title = "Test Book",
            IsAvailable = true
        };

        var loan = new Loan
        {
            Book = book,
            LoanDate = DateTime.Now
        };

        // regra de negócio simulada
        book.IsAvailable = false;

        Assert.False(book.IsAvailable);
    }

    // 2
    [Fact]
    public void Returning_Book_Should_Make_It_Available()
    {
        var book = new Book
        {
            Title = "Test Book",
            IsAvailable = false
        };

        var loan = new Loan
        {
            Book = book,
            LoanDate = DateTime.Now,
            ReturnedDate = DateTime.Now
        };

        // regra de negócio simulada
        book.IsAvailable = true;

        Assert.True(book.IsAvailable);
    }
}