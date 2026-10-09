namespace SrpLab;

// Changes when the school changes the letter grade bands.
public class LetterGradeBands
{
    public string Letter(decimal average)
    {
        if (average >= 90) return "A";
        if (average >= 80) return "B";
        if (average >= 70) return "C";
        if (average >= 60) return "D";
        return "F";
    }
}



