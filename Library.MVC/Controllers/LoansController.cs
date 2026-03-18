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

    // GET: Loans/Create
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Loan loan)
    {
        if (!ModelState.IsValid)
        {
            return View(loan);
        }

     
        var activeLoan = await _context.Loans
            .FirstOrDefaultAsync(l => l.BookId == loan.BookId && l.ReturnedDate == null);

        if (activeLoan != null)
        {
            ModelState.AddModelError("", "This book is already on loan.");
            return View(loan);
        }

    
        loan.LoanDate = DateTime.Now;

        _context.Loans.Add(loan);
        
        var book = await _context.Books.FindAsync(loan.BookId);

        if (book == null)
        {
            return NotFound();
        }

        book.IsAvailable = false;

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Books");
    }
    
    public async Task<IActionResult> Return(int id)
    {
        var loan = await _context.Loans.FindAsync(id);

        if (loan == null)
        {
            return NotFound();
        }

        loan.ReturnedDate = DateTime.Now;

        var book = await _context.Books.FindAsync(loan.BookId);

        if (book != null)
        {
            book.IsAvailable = true;
        }

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Books");
    }
}