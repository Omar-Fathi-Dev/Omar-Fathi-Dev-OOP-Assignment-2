namespace SrpLab;

// Changes when the invoice numbering scheme changes.
public class InvoiceNumberGenerator
{
    private static int _invoiceSeq = 1000;

    public string Next(DateOnly periodStart)
    {
        var n = ++_invoiceSeq;
        return $"INV-{periodStart:yyyyMM}-{n:D5}";
    }
}