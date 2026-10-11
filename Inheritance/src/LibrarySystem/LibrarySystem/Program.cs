namespace LibrarySystem;

class Program
{
public static void Main(string[] args)
{
    #region MUST NOT COMPILE - Access Restrictions

    // MUST NOT COMPILE: Cannot instantiate Person directly.
    // Person person = new Person(10, "Test Person", "01012345678");

    // MUST NOT COMPILE: Cannot instantiate Member directly.
    // Member member = new Member(11, "Test Member", "01012345678", 3, 0);

    // MUST NOT COMPILE: Cannot instantiate Staff directly.
    // Staff staff = new Staff(12, "Test Staff", "01012345678",
    //     DateTime.Today, 5000m, 0m);

    // MUST NOT COMPILE: Cannot instantiate LibraryItem directly.
    // LibraryItem item = new LibraryItem("X1", "Test Item", 7, 10m, 1m);

    StudentMember accessTestStudent = new StudentMember(
        13, "Access Test Student", "01012345678");

    // MUST NOT COMPILE: FullName is read-only.
    // accessTestStudent.FullName = "New Name";

    // MUST NOT COMPILE: LoanHistory does not expose Add().
    // accessTestStudent.LoanHistory.Add(someLoan);

    Book accessTestBook = new Book("X2", "Access Test Book", 10m);

    // MUST NOT COMPILE: IsOnLoan cannot be changed from outside.
    // accessTestBook.IsOnLoan = true;

    #endregion

    #region Setup - Create Main Objects

    StudentMember student = new StudentMember(
        1, "Ahmed Ali", "01012345678");

    Librarian librarian = new Librarian(
        2, "Mona Ali", "01112345678",
        DateTime.Today.AddYears(-3), 6000m);

    HeadLibrarian headLibrarian = new HeadLibrarian(
        3, "Omar Hassan", "01212345678",
        DateTime.Today.AddYears(-5), 9000m);

    Shelver shelver = new Shelver(
        4, "Sara Ahmed", "01512345678",
        DateTime.Today.AddYears(-2), 4000m, "Fiction");

    #endregion

    #region Test 1 - Polymorphism: List<Staff> Monthly Pay

    List<Staff> staffMembers = new List<Staff>
    {
        librarian,
        headLibrarian,
        shelver
    };

    foreach (Staff staffMember in staffMembers)
    {
        Console.WriteLine(
            $"{staffMember.FullName}: {staffMember.MonthlyPay:C}");
    }

    #endregion

    #region Test 2 - Polymorphism: List<LibraryItem>

    List<LibraryItem> items = new List<LibraryItem>
    {
        new Book("B1", "C# Basics", 10m),
        new DVD("D1", "Programming Video", 10m),
        new Magazine("M1", "Tech Monthly", 10m)
    };

    foreach (LibraryItem libraryItem in items)
    {
        Console.WriteLine(
            $"{libraryItem.Title}: " +
            $"Loan Period = {libraryItem.LoanPeriodDays} days, " +
            $"Daily Late Fee = {libraryItem.GetDailyLateFee():C}");
    }

    #endregion

    #region Test 3 - Reject Borrowing a Withdrawn Item

    Book withdrawnBook = new Book("B2", "Withdrawn Book", 10m);
    headLibrarian.WithdrawItem(withdrawnBook);

    try
    {
        student.BorrowItem(withdrawnBook, 1, DateTime.Today);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Rejected: {exception.Message}");
    }

    #endregion

    #region Test 4 - Reject Borrowing an Item Already on Loan

    Book sharedBook = new Book("B3", "Shared Book", 10m);

    StudentMember firstMember = new StudentMember(
        5, "First Member", "01022345678");

    StudentMember secondMember = new StudentMember(
        6, "Second Member", "01122345678");

    firstMember.BorrowItem(sharedBook, 2, DateTime.Today);

    try
    {
        secondMember.BorrowItem(sharedBook, 3, DateTime.Today);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Rejected: {exception.Message}");
    }

    #endregion

    #region Test 5 - Reject Student's Fourth Active Loan

    student.BorrowItem(
        new Book("B4", "Book Four", 10m), 4, DateTime.Today);

    student.BorrowItem(
        new Book("B5", "Book Five", 10m), 5, DateTime.Today);

    student.BorrowItem(
        new Book("B6", "Book Six", 10m), 6, DateTime.Today);

    try
    {
        student.BorrowItem(
            new Book("B7", "Book Seven", 10m), 7, DateTime.Today);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Rejected: {exception.Message}");
    }

    #endregion

    #region Test 6 - Premium Member: DVD Returned 5 Days Late

    PremiumMember premiumMember = new PremiumMember(
        7, "Premium Member", "01222345678", 20m);

    DVD premiumDvd = new DVD("D2", "C# Advanced Video", 10m);

    DateTime borrowDate = DateTime.Today.AddDays(-12);

    Loan premiumLoan = premiumMember.BorrowItem(
        premiumDvd, 8, borrowDate);

    DateTime returnDate = DateTime.Today;

    librarian.ProcessReturn(premiumLoan, returnDate);

    Console.WriteLine($"Due Date: {premiumLoan.DueDate:d}");
    Console.WriteLine($"Late Fee: {premiumLoan.LateFee:C}");
    Console.WriteLine($"Reading Points: {premiumMember.ReadingPoints}");

    #endregion

    #region Test 7 - Reject Returning the Same Loan Twice

    try
    {
        librarian.ProcessReturn(premiumLoan, returnDate);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Rejected: {exception.Message}");
    }

    #endregion

    #region Test 8 - Reject Marking a Returned Loan as Lost

    try
    {
        librarian.MarkAsLost(premiumLoan);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Rejected: {exception.Message}");
    }

    #endregion
}
}