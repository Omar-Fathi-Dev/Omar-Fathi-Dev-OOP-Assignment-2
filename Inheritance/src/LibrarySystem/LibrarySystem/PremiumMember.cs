namespace LibrarySystem;

public class PremiumMember : Member
{
    private int _readingPoint;
    public int ReadingPoints => GetReadingPoints();
    

    public PremiumMember(int id, string name, string phoneNumber, decimal discountPercentage)
        : base(id, name, phoneNumber , 10 , discountPercentage)
    {
        
    }

    public int GetReadingPoints()
    {
        int points = 0;

        foreach (Loan loan in LoanHistory)
        {
            if (loan.Status == LoanStatus.Returned)
                points += 5;
        }

        return points;
    }
}