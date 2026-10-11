namespace SrpLab;

// Changes when the rules for recording bookings or detecting conflicts change.
public class AppointmentBook
{
    private readonly HashSet<DateTimeOffset> _booked = new();
    private readonly ClinicBusinessHours  _hours;
    
    public AppointmentBook(ClinicBusinessHours hours) => _hours = hours;
    
    public bool IsBooked(DateTimeOffset slot) => _booked.Contains(slot);
    
    public bool TryBook(DateTimeOffset slot)
    {
        if (!_hours.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
        _booked.Add(slot);
        return true;
    }
    
    
}

