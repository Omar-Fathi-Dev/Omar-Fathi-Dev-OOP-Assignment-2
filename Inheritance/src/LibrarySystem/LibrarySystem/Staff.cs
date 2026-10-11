namespace LibrarySystem;

public class Staff : Person
{
    private decimal _monthlySalary;
    private decimal _responsibilityAllowance;
    
    public DateTime HireDate { get; }
    public decimal MonthlySalary
    {
        get => _monthlySalary;
        private set => _monthlySalary = value;
    }
    public decimal MonthlyPay => _monthlySalary +  _responsibilityAllowance;

    protected Staff(int id, string name, string phoneNumber, DateTime hireDate, decimal salary, decimal allowance) :
        base(id, name, phoneNumber)
    {
        if(hireDate > DateTime.Now)
            throw new ArgumentOutOfRangeException(nameof(hireDate) , hireDate , "Hire Date must not be in the future");
        if(salary <= 0)
            throw new ArgumentOutOfRangeException(nameof(salary) , salary , "Salary must be greater than zero");
        if(allowance < 0)
            throw new ArgumentOutOfRangeException(nameof(allowance) , allowance , "Allowance must not be negative");
        
        (HireDate , MonthlySalary , _responsibilityAllowance ) =(hireDate, salary, allowance);
    }

    public void GiveRaise(decimal percentage)
    {
        if(percentage <= 0 )
            throw new  ArgumentOutOfRangeException(nameof(percentage) ,percentage , "Percentage must be greater than 0");
        
        MonthlySalary = MonthlySalary * (1 + (percentage / 100));

    }
    
}