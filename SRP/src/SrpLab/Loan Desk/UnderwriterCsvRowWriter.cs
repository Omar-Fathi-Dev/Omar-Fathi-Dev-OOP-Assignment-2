namespace SrpLab;

// Changes when the columns or format of the analytics CSV row change.
public class UnderwriterCsvRowWriter
{
    public string Write(string applicationId, LoanApplication app, decimal riskScore, bool isEligible)
    {
        return $"{applicationId},{app.CreditScore},{app.EmploymentMonths},{(app.HasCollateral ? 1 : 0)},{riskScore:0.00},{(isEligible ? "Y" : "N")}";
    }
}