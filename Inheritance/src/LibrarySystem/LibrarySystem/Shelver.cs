namespace LibrarySystem;

public class Shelver : Staff
{
    private string _section;

    public string Section
    {
        get => _section;
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new  ArgumentException("Section cannot be empty." , nameof(value));
            _section = value;
        } 
    }

    public Shelver(int id, string name, string phoneNumber, DateTime hireDate, decimal salary , string section) :
        base(id, name, phoneNumber, hireDate, salary, 0)
    {
        Section = section;
    }

    public void ReassignSection(string newSection) => Section = newSection;
    
    
}