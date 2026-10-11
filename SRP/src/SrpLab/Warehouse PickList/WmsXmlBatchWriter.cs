namespace SrpLab;

// Changes when the XML contract with the WMS changes.
public class WmsXmlBatchWriter
{
    public string Write(string batchId, IReadOnlyList<(string Sku, int Allocated)> allocations)
    {
        var parts = allocations.Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
        return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
    }
}