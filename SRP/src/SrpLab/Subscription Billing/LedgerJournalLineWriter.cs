namespace SrpLab;

// Changes when the accounting export format changes.
public class LedgerJournalLineWriter
{
    public string Write(string customerId, string invoiceNumber, decimal amount)
    {
        return $"{customerId},{invoiceNumber},{amount:0.00},AR-SUB";
    }
}