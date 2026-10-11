namespace SrpLab;

// Changes when the honor roll rule changes.
public class HonorRollRule
{
    private readonly LetterGradeBands  letterGradeBands;
    
    public HonorRollRule(LetterGradeBands letterGradeBands) => this.letterGradeBands = letterGradeBands;
    
    public bool MeetsHonorRoll(decimal average)
    {
        return average >= 85 && letterGradeBands.Letter(average) is "A" or "B";
    }
}

