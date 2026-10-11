namespace SrpLab;

// Changes when the stock allocation or backorder policy changes.
public class StockAllocator
{
    public IReadOnlyList<(string Sku, int Allocated)> Allocate(IEnumerable<PickLine> lines)
    {
        var result = new List<(string, int)>();
        foreach (var line in lines)
            result.Add((line.Sku, Math.Min(line.QtyNeeded, line.QtyOnHand)));
        return result;
    }
}