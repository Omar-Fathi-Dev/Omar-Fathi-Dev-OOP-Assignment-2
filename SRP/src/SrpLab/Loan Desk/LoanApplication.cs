namespace SrpLab;

// Changes when the data we keep about a loan request changes.
public record LoanApplication(
    decimal RequestedAmount,
    int CreditScore,
    int EmploymentMonths,
    bool HasCollateral);