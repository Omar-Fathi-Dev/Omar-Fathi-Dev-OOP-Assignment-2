namespace SrpLab;

// Changes when the iCalendar (ICS) output format changes.
public class IcsAppointmentWriter
{
    private readonly ClinicBusinessHours  _hours;
    public IcsAppointmentWriter(ClinicBusinessHours hours) => _hours = hours;
    
    public string ToIcs(DateTimeOffset slot, string patientName, string clinician)
    {
        // Calendar interoperability format changes with clients — not opening hours.
        var uid = Guid.NewGuid();
        var end = slot.AddMinutes(_hours.SlotMinutes);
        return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
               $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
    }
}


