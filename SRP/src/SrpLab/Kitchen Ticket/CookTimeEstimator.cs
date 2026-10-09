namespace SrpLab;

// Changes when the kitchen's time rules change.
public class CookTimeEstimator
{
    public int EstimatedReadyMinutes(IReadOnlyList<TicketItem> items, int openStations, bool hasAllergens)
    {
        if (openStations <= 0) openStations = 1;
        var sequential = items.Sum(i => i.PrepMinutes);
        var parallel = (int)Math.Ceiling(sequential / (double)openStations);
        if (hasAllergens) parallel += 3;
        var longest = items.Count == 0 ? 0 : items.Max(i => i.PrepMinutes);
        return Math.Max(parallel, longest);
    }
}