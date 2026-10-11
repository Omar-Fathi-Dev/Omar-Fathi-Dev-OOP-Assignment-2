namespace SrpLab;

// Changes when the rules for assigning patients to beds change.
public class BedAssignments
{
    private readonly Dictionary<int, BedEntry> _beds = new();

    public void Assign(int bed, string patientId, int acuity)
    {
        if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
        if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");
        _beds[bed] = new BedEntry(patientId.Trim().ToUpperInvariant(), acuity);
    }

    public BedEntry? Find(int bed) => _beds.TryGetValue(bed, out var entry) ? entry : null;

    public IEnumerable<KeyValuePair<int, BedEntry>> OrderedByBed() => _beds.OrderBy(kv => kv.Key);
}