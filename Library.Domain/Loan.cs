
namespace Library.Domain;

public class Loan
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public int MemberId { get; set; }

    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }

    public DateTime? ReturnedDate { get; set; }
}
