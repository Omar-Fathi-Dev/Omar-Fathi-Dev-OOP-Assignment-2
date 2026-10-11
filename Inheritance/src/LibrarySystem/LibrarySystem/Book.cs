namespace LibrarySystem;

public class Book :  LibraryItem
{
    public Book(string catalogNumber, string title, decimal baseFee) :
        base(catalogNumber, title, 21, baseFee, 1)
    {
        
    }
}