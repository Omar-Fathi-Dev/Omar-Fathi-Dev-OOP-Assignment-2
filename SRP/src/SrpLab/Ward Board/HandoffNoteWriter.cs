namespace SrpLab;

// Changes when the format of the nurse handoff note changes.
public class HandoffNoteWriter
{
    public string Write(int bed, BedEntry? entry, DateTime utcNow)
    {
        if (entry is null) return $"Bed {bed}: empty";

        var tone = entry.Acuity >= 8 ? "ESCALATE" : entry.Acuity >= 4 ? "WATCH" : "STABLE";
        return $"[HANDOFF {utcNow:yyyy-MM-dd}] Bed {bed} · {entry.PatientId} · acuity={entry.Acuity} · {tone}";
    }
}