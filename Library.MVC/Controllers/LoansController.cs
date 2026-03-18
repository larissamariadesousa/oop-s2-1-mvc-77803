using Library.Domain;
using Library.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.MVC.Controllers;

public class LoansController : Controller
{
    private readonly ApplicationDbContext _context;

    public LoansController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Create(Loan loan)
    {
        var activeLoan = await _context.Loans
            .FirstOrDefaultAsync(l => l.BookId == loan.BookId && l.ReturnedDate == null);

        if (activeLoan != null)
        {
            return BadRequest("Book already on loan");
        }

        loan.LoanDate = DateTime.Now;

        _context.Add(loan);

        var book = await _context.Books.FindAsync(loan.BookId);
        book.IsAvailable = false;

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Books");
    }
}