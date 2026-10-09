namespace SrpLab;

// Changes when the rules for basket items or quantities change.
public class BasketLines
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
    public int Count => _lines.Count;
    
    public IEnumerable<string> Skus
    {
        get
        {
            foreach (var line in _lines)
            {
                yield return line.Sku;
            }
        }
    }
    
    
    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add((sku, price, qty));
    }
    
    public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);
}


