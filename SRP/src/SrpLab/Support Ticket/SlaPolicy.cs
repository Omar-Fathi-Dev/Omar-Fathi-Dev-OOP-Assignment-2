namespace SrpLab;

// Changes when the SLA hours or the breach rule change.
public class SlaPolicy
{
    public DateTimeOffset Deadline(string priority, DateTimeOffset openedAt)
    {
        var hours = priority switch
        {
            "P1" => 4,
            "P2" => 24,
            _ => 72
        };
        return openedAt.AddHours(hours);
    }

    public bool IsBreached(string priority, DateTimeOffset openedAt, DateTimeOffset now)
        => now > Deadline(priority, openedAt);
}