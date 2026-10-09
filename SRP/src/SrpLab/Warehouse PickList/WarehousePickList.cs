namespace SrpLab;

// Changes when the data we keep for a pick request changes.
public class WarehousePickList
{
    private readonly List<PickLine> _lines = new();

    public IReadOnlyList<PickLine> Lines => _lines;

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
        => _lines.Add(new PickLine(sku, aisle, bin, qtyNeeded, qtyOnHand));
}