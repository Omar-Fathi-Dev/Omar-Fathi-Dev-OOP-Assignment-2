namespace SrpLab;

// Changes when the way the final total is built from lines, coupon, and gift wrap changes.
public class CheckoutBasket
{
    private readonly BasketLines _lines = new();
    private readonly CouponDiscountCalculator _coupons = new();
    private string? _couponText;
    private bool _giftWrap;
    
    public int LineCount => _lines.Count;
    public IEnumerable<string> Skus => _lines.Skus;
    
    
    public void AddLine(string sku, decimal price, int qty) => _lines.AddLine(sku, price, qty);
    
    public void ApplyCouponText(string? couponText) => _couponText = couponText;
    
    public void EnableGiftWrap() => _giftWrap = true;
    
    public decimal SubTotal() => _lines.SubTotal();
    
    public decimal DiscountAmount() => _coupons.DiscountAmount(_couponText, SubTotal());
    
    public decimal GrandTotal()
    {
        var total = SubTotal() - DiscountAmount();
        if (_giftWrap) total += GiftWrapFee.Amount; // packaging fee policy ≠ cart math
        return Math.Max(0m, total);
    }
    
}

