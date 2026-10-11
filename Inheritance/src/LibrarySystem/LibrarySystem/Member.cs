namespace LibrarySystem;

public class Member : Person
{
    private List<Loan> _loanHistory = new ();
    public int MaxConcurrentLoans { get; }
    public decimal LateFeeDiscountPercentage { get; }
    public IReadOnlyList<Loan> LoanHistory => _loanHistory.AsReadOnly();

    protected Member(int id, string name, string phoneNumber, int maxLoans, decimal discountPercentage) :
        base(id, name, phoneNumber)
    {
        if(maxLoans < 1)
            throw new  ArgumentOutOfRangeException(nameof(maxLoans) ,maxLoans , "maxLoans must be positive");
        
        if(discountPercentage < 0 || discountPercentage > 100)
            throw new  ArgumentOutOfRangeException(nameof(discountPercentage) ,discountPercentage , "Discount percentage must be between 0 and 100");
        
        (MaxConcurrentLoans , LateFeeDiscountPercentage) = (maxLoans, discountPercentage);

    }

    public Loan BorrowItem(LibraryItem item, int loanId, DateTime borrowDate)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        int activeLoans = 0;

        foreach (Loan loan in _loanHistory)
        {
            if (loan.Status == LoanStatus.Borrowed)
                activeLoans++;
        }

        if (activeLoans >= MaxConcurrentLoans)
            throw new InvalidOperationException(
                "Member has reached the maximum number of active loans.");

        Loan newLoan = new Loan(loanId, borrowDate, this, item);

        _loanHistory.Add(newLoan);

        return newLoan;
    }
}