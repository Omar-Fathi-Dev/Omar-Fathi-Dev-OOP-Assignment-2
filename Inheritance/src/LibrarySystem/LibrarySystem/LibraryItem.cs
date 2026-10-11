namespace LibrarySystem;

public class LibraryItem
{
    private decimal _baseLateFeePerDay;
    private readonly decimal _dailyFeeMultiplier;
    
    public string CatalogNumber { get; }
    public string Title { get; }
    public int LoanPeriodDays { get; }

    public decimal BaseLateFeePerDay
    {
        get => _baseLateFeePerDay;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            _baseLateFeePerDay = value;
        }
    }
    public bool IsWithdrawn { get; private set; }
    public bool IsOnLoan { get; private set; }
    
    protected LibraryItem(string catalogNumber, string title,
        int loanPeriodDays, decimal baseFee,
        decimal feeMultiplier)
    {
        if (string.IsNullOrWhiteSpace(catalogNumber))
            throw new ArgumentException("Catalog number is required.", nameof(catalogNumber));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));
        if (loanPeriodDays <= 0)
            throw new ArgumentOutOfRangeException(nameof(loanPeriodDays));
        if (feeMultiplier <= 0)
            throw new ArgumentOutOfRangeException(nameof(feeMultiplier));

        CatalogNumber = catalogNumber;
        Title = title;
        LoanPeriodDays = loanPeriodDays;
        BaseLateFeePerDay = baseFee;
        _dailyFeeMultiplier = feeMultiplier;
    }
    
    public decimal GetDailyLateFee() => _baseLateFeePerDay * _dailyFeeMultiplier;

    public void UpdateBaseLateFee(decimal newBaseFee)
    {
        BaseLateFeePerDay = newBaseFee;
    }

    public void Withdraw()
    {
        if (IsOnLoan)
            throw new InvalidOperationException("Cannot withdraw an item that is on loan.");
        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    public void MarkAsBorrowed()
    {
        if (IsWithdrawn)
            throw new InvalidOperationException("Item is withdrawn.");
        if (IsOnLoan)
            throw new InvalidOperationException("Item is already on loan.");
        IsOnLoan = true;
    }

    public void MarkAsReturned()
    {
        if (!IsOnLoan)
            throw new InvalidOperationException("Item is not on loan.");
        IsOnLoan = false;
    }
}