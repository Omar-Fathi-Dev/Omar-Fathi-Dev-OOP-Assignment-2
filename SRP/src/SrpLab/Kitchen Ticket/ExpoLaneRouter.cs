namespace SrpLab;

// Changes when the rules for choosing the expo lane change.
public class ExpoLaneRouter
{
    public string ExpoLaneHint(bool hasAllergens, int etaMinutes)
    {
        return hasAllergens ? "LANE-ALLERGY" : etaMinutes > 20 ? "LANE-SLOW" : "LANE-FAST";
    }
}