namespace LibrarySystem;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(int id, string name, string phoneNumber, DateTime hireDate, decimal salary)
        : base(id, name, phoneNumber, hireDate, salary, 400)
    {
    }

    public void ChangeLateFee(LibraryItem item, decimal newBaseFee)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        item.UpdateBaseLateFee(newBaseFee);
    }

    public void WithdrawItem(LibraryItem item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        item.Withdraw();
    }

    public void RestoreItem(LibraryItem item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        item.Restore();
    }
}