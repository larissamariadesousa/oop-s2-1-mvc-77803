using Library.Domain;
using Library.MVC.Models;

namespace Library.MVC.Data;

public static class SeedData
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Books.Any())
            return;

        var books = new List<Book>
        {
            new Book { Title = "Clean Code", Author = "Robert Martin", Category = "Programming", Isbn = "111" },
            new Book
            {
                Title = "The Pragmatic Programmer", Author = "Andy Hunt", Category = "Programming", Isbn = "222"
            },
            new Book { Title = "Design Patterns", Author = "GoF", Category = "Programming", Isbn = "333" },
            new Book { Title = "C# in Depth", Author = "Jon Skeet", Category = "Programming", Isbn = "444" },

            new Book { Title = "Refactoring", Author = "Martin Fowler", Category = "Programming", Isbn = "555" },
            new Book { Title = "Code Complete", Author = "Steve McConnell", Category = "Programming", Isbn = "666" },
            new Book
            {
                Title = "Head First Design Patterns", Author = "Eric Freeman", Category = "Programming", Isbn = "777"
            },
            new Book { Title = "You Don't Know JS", Author = "Kyle Simpson", Category = "Programming", Isbn = "888" },
            new Book
            {
                Title = "Introduction to Algorithms", Author = "CLRS", Category = "Computer Science", Isbn = "999"
            },
            new Book { Title = "The Clean Coder", Author = "Robert Martin", Category = "Programming", Isbn = "1010" },

            new Book { Title = "Harry Potter", Author = "J.K. Rowling", Category = "Fantasy", Isbn = "1111" },
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Category = "Fantasy", Isbn = "2222" },
            new Book { Title = "Game of Thrones", Author = "George R.R. Martin", Category = "Fantasy", Isbn = "3333" },

            new Book { Title = "Atomic Habits", Author = "James Clear", Category = "Self-help", Isbn = "4444" },
            new Book { Title = "The Power of Habit", Author = "Charles Duhigg", Category = "Self-help", Isbn = "5555" },

            new Book
            {
                Title = "Thinking, Fast and Slow", Author = "Daniel Kahneman", Category = "Psychology", Isbn = "6666"
            },
            new Book { Title = "Deep Work", Author = "Cal Newport", Category = "Productivity", Isbn = "7777" }
        };

        context.Books.AddRange(books);
        context.SaveChanges();

        var booksToLoan = context.Books.Take(3).ToList();

        foreach (var book in booksToLoan)
        {
            var loan = new Loan
            {
                BookId = book.Id,
                LoanDate = DateTime.Now
            };

            book.IsAvailable = false;
            context.Loans.Add(loan);
        }

        context.SaveChanges();
    }
}