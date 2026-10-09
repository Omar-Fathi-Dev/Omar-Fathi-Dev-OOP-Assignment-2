namespace SrpLab;

// Changes when the printer or the layout of the printed ticket changes.
public class ThermalTicketPrinter
{
    public string RenderThermalTicket(int orderNumber, IReadOnlyList<TicketItem> items,
        IReadOnlyList<string> allergens, int etaMinutes)
    {
        var width = 32;
        var line = new string('=', width);
        var body = string.Join('\n', items.Select(i => $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));
        var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
        return $"{line}\nORDER #{orderNumber}\nETA {etaMinutes} MIN\n{body}\n{allergyLine}\n{line}\n";
    }

}