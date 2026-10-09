namespace SrpLab;

// Changes when the internal escalation text changes.
public class EscalationBlurbWriter
{
    public string Write(string ticketId, string priority, DateTimeOffset slaDeadline)
        => $"ESCALATE {ticketId} priority={priority} breachAt={slaDeadline:u} keywords-scanned=yes";
}