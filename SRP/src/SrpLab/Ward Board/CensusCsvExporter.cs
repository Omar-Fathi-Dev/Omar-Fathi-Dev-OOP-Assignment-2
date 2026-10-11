namespace SrpLab;

// Changes when the columns or format of the census CSV change.
public class CensusCsvExporter
{
    public string Export(BedAssignments beds)
    {
        var lines = new List<string> { "bed,patient,acuity" };
        foreach (var (bed, entry) in beds.OrderedByBed())
            lines.Add($"{bed},{entry.PatientId},{entry.Acuity}");
        return string.Join('\n', lines);
    }
}