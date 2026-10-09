namespace SrpLab;

// Changes when the layout of the transcript changes.
public class TranscriptPlainWriter
{
    public string Write(string studentId, string fullName, decimal average, string letter, bool honor)
    {
        return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {average}\nLetter: {letter}\nHonor: {honor}\n";
    }

}


