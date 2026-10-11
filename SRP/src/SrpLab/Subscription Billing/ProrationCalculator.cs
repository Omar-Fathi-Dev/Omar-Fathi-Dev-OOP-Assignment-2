namespace SrpLab;

// Changes when the finance rules for proration change.
public class ProrationCalculator
{
    public decimal Prorate(SubscriptionTerms terms, DateOnly activeFrom)
    {
       if (activeFrom <= terms.PeriodStart) return terms.MonthlyPrice;
               if (activeFrom >= terms.PeriodEnd) return 0m;
               var totalDays = terms.PeriodEnd.DayNumber - terms.PeriodStart.DayNumber;
               if (totalDays <= 0) return terms.MonthlyPrice;
               var used = terms.PeriodEnd.DayNumber - activeFrom.DayNumber;
               return Math.Round(terms.MonthlyPrice * used / totalDays, 2);
    }
}