namespace SrpLab;

// Changes when the words on the gift card change
public class GiftMessageCardWriter
{
    public string Write(string fromName, IEnumerable<string> skus, decimal grandTotal)
    {
        var items = string.Join(", ", skus);
        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
    }

}

