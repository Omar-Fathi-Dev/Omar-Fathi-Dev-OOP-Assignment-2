namespace SrpLab;

// Changes when the way we count failed payments changes.
public class FailedPaymentTracker
{
    public int Count { get; private set; }

    public void Register() => Count++;
}