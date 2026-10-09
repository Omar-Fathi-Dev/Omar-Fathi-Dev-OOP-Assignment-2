namespace SrpLab;

// Changes when the wording of the SMS reminder changes.
public class SmsReminderText
{
    public string SmsReminder(DateTimeOffset slot, string clinicPhone)
    {
        // Messaging channel copy — fourth concern hiding in the "scheduler".
        return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
    }
}


