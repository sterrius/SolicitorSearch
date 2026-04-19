using SolicitorSearch.BLL.Solicitor;

namespace SolicitorSearch.BLL.SolicitorSource;

public class SolicitorSourceBaseModel
{
    public int SolicitorSourceId = 0;
    public string SolicitorSourceName { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public string QueryStringTemplate { get; set; } = string.Empty;
    public string HostHeader { get; set; } = string.Empty;

    public SolicitorSourceBaseModel(int solicitorSourceId, string solicitorSourceName, string baseUrl, string queryStringTemplate, string hostHeader)
    {
        SolicitorSourceId = solicitorSourceId;
        SolicitorSourceName = solicitorSourceName;
        BaseUrl = baseUrl;
        QueryStringTemplate = queryStringTemplate;
        HostHeader = hostHeader;
    }

    public virtual string GetPopulatedQueryString(string location)
    {
        throw new NotImplementedException($"{nameof(SolicitorSourceBaseModel)}.{nameof(GetPopulatedQueryString)} not implemented.");
    }

    public virtual IEnumerable<SolicitorModel> ExtractContactDetails(string solicitorListRawResponse)
    {
        throw new NotImplementedException($"{nameof(SolicitorSourceBaseModel)}.{nameof(ExtractContactDetails)} not implemented.");
    }
}
