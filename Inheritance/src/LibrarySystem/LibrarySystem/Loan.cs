namespace LibrarySystem;

public class Loan
{
    public int LoanId { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public LoanStatus Status { get; private set; }
    public decimal LateFee => CalculateLateFee();

    public Member Member { get; }
    public LibraryItem LibraryItem { get; }

    public Loan(int loanId, DateTime borrowDate, Member member, LibraryItem item)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        if (item is null)
            throw new ArgumentNullException(nameof(item));

        if (loanId < 1)
            throw new ArgumentOutOfRangeException(
                nameof(loanId), loanId, "Id must be positive");

        LoanId = loanId;
        BorrowDate = borrowDate;
        Member = member;
        LibraryItem = item;

        DueDate = borrowDate.AddDays(item.LoanPeriodDays);
        Status = LoanStatus.Borrowed;

        item.MarkAsBorrowed();
    }

    public void ReturnItem(DateTime returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException(
                "Loan is not currently borrowed.");

        if (returnDate < BorrowDate)
            throw new ArgumentException(
                "Return date cannot be before borrow date.",
                nameof(returnDate));

        LibraryItem.MarkAsReturned();

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException(
                "Only a borrowed loan can be marked as lost.");

        Status = LoanStatus.Lost;
    }

    public decimal CalculateLateFee()
    {
        if (ReturnDate is null)
            return 0m;

        int daysLate = (ReturnDate.Value.Date - DueDate.Date).Days;

        if (daysLate <= 0)
            return 0m;

        decimal dailyFee = LibraryItem.GetDailyLateFee();
        decimal discount = Member.LateFeeDiscountPercentage / 100m;

        return daysLate * dailyFee * (1m - discount);
    }
}