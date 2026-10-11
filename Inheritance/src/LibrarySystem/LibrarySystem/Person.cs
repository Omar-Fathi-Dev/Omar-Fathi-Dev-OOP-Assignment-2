namespace LibrarySystem;
using System.Text.RegularExpressions;

public class Person
{
    public int PersonId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }
    
    protected  Person(int personId, string fullName, string phoneNumber)
    {
        if(personId < 1)
            throw new  ArgumentOutOfRangeException(nameof(personId) ,personId , "Id must be positive");
        if(string.IsNullOrWhiteSpace(fullName))
            throw new  ArgumentException("Full name cannot be empty." , nameof(fullName));
        if(string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber , @"^01[0125][0-9]{8}$"))
            throw new  ArgumentException($"Invalid phone number."  ,nameof(phoneNumber) );
        
        (PersonId , FullName , PhoneNumber) = (personId, fullName, phoneNumber);
    }
    
}