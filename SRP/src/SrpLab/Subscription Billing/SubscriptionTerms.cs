namespace SrpLab;

// Changes when the data we keep about a subscription period changes.
public record  SubscriptionTerms(
    string CustomerId,
    decimal MonthlyPrice,
    DateOnly PeriodStart,
    DateOnly PeriodEnd);