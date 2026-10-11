namespace SrpLab;

// Changes when the way we store and clean the dishes of a ticket changes.
public class KitchenTicket
{
    private readonly List<TicketItem> _items = new();

    public IReadOnlyList<TicketItem> Items => _items;

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        var cleaned = ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList();
        _items.Add(new TicketItem(item, cleaned, prepMinutes));
    }
}