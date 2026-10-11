namespace SrpLab;

// Changes when the invoice format or the tax (VAT) rule changes.
public class TuitionInvoiceLineWriter
{
    private readonly string _courseCode;
    private readonly decimal _tuition;

    public TuitionInvoiceLineWriter(string courseCode, decimal tuition)
    {
        _courseCode = courseCode;
        _tuition = tuition;
    }
    public string TuitionInvoiceLine(bool isSeated)
    {
        if (!isSeated) return $"{_courseCode},WAITLIST,0.00";
        var vat = Math.Round(_tuition * 0.14m, 2);
        return $"{_courseCode},TUITION,{_tuition:0.00},VAT,{vat:0.00},TOTAL,{(_courseCode + vat):0.00}";
    }
}