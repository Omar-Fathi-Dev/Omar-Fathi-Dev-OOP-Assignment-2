namespace SrpLab;

public class GradeCsvExporter
{
    
    private readonly StudentScores _scores;
    private readonly LetterGradeBands _bands;
    private readonly HonorRollRule _honorRule;

    public GradeCsvExporter(StudentScores scores, LetterGradeBands bands, HonorRollRule honorRule)
    {
        _scores = scores;
        _bands = bands;
        _honorRule = honorRule;
    }
    
    public string ExportCsv()
    {
        var rows = new List<string> { "studentId,average,letter,honor" };
        foreach (var id in _scores.StudentIds.OrderBy(x => x))
        {
            var avg = _scores.Average(id);
            rows.Add($"{id},{avg},{_bands.Letter(avg)},{(_honorRule.MeetsHonorRoll(avg) ? 1 : 0)}");
        }
        return string.Join('\n', rows);
    }
}

