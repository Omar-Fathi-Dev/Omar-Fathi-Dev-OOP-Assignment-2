namespace SrpLab;

// Changes when the rules or the text of pager codes change.
public class PagerDispatcher
{
    private readonly List<string> _log = new();

    public void Consider(int bed, int acuity, DateTime utcNow)
    {
        if (acuity >= 8)
            _log.Add($"CODE-YELLOW bed={bed} at {utcNow:HH:mm}");
    }

    public IReadOnlyList<string> DrainLog()
    {
        var copy = _log.ToList();
        _log.Clear();
        return copy;
    }
}