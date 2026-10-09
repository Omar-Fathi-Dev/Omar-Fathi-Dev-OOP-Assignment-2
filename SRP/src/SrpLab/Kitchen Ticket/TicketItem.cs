namespace SrpLab;

// Changes when the data we keep for one ordered dish changes.
public record TicketItem(string Item, IReadOnlyList<string> Ingredients, int PrepMinutes);