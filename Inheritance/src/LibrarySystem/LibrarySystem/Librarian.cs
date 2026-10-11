namespace LibrarySystem;

public class Librarian : Staff
{


    public Librarian(int id, string name, string phoneNumber, DateTime hireDate, decimal salary) :
        base(id, name, phoneNumber, hireDate, salary, 0)
    {

    }

    public void ProcessReturn(Loan loan, DateTime returnDate)
    {
        if (loan is null)
            throw new ArgumentNullException(nameof(loan));

        loan.ReturnItem(returnDate);
    }

    public void MarkAsLost(Loan loan)
    {
        if (loan is null)
            throw new ArgumentNullException(nameof(loan));

        loan.MarkAsLost();
    }
}