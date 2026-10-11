namespace LibrarySystem;

public class Magazine : LibraryItem
{
    public Magazine(string catalogNumber, string title, decimal baseFee) :
        base(catalogNumber, title, 3, baseFee, 0.5m)
    {
        
    }
}