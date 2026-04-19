namespace SolicitorSearch.DAL.Entities;

public class SolicitorSourceEntity
{
    public int SolicitorSourceId { get; set; } = 0;

    public string SolicitorSourceName { get; set; } = string.Empty;

    public string BaseUrl { get; set; } = string.Empty;

    public string QueryStringTemplate { get; set; } = string.Empty;

    public string HostHeader { get; set; } = string.Empty;
}
