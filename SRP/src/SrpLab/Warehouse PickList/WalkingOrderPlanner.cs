namespace SrpLab;

// Changes when the path rule for walking in the warehouse changes.
public class WalkingOrderPlanner
{
    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> Plan(IEnumerable<PickLine> lines)
    {
        return lines
            .OrderBy(l => l.Aisle)
            .ThenBy(l => l.Bin)
            .Select(l => (l.Aisle, l.Bin, l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand)))
            .Where(x => x.Item4 > 0)
            .ToList();
    }
}