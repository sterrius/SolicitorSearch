using SolicitorSearch.BLL.Solicitor;
using System.Text.RegularExpressions;

namespace SolicitorSearch.BLL.SolicitorSource;

public class SolicitorsDotComSolicitorSourceModel : SolicitorSourceBaseModel
{
    private const string SECTION_START = "<div class=\"result-item\">";
    private const string REGEX_SOLICITOR_NAME = "<span class=\"h2\">(.+?)<div class=\"greentick\"";
    private const string REGEX_TELEPHONE_NUMBER = "tel:(.+?)\">";
    private const string REGEX_ADDRESS = @"<address>(.+?)<\/address>";

    public SolicitorsDotComSolicitorSourceModel(int solicitorSourceId, string solicitorSourceName, string baseUrl, string queryStringTemplate, string hostHeader)
        : base(solicitorSourceId, solicitorSourceName, baseUrl, queryStringTemplate, hostHeader)
    {
        /* no op */
    }

    public override string GetPopulatedQueryString(string location)
    {
        return QueryStringTemplate.Replace("{location}", location);
    }

    public override IEnumerable<SolicitorModel> ExtractContactDetails(string solicitorListRawResponse)
    {
        List<SolicitorModel> solicitorModels = new List<SolicitorModel>();

        Regex solicitorNameRegex = new Regex(REGEX_SOLICITOR_NAME, RegexOptions.Compiled, TimeSpan.FromSeconds(2));
        Regex telephoneRegex = new Regex(REGEX_TELEPHONE_NUMBER, RegexOptions.Compiled, TimeSpan.FromSeconds(2));
        Regex addressRegex = new Regex(REGEX_ADDRESS, RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        Match solicitorNameMatch;
        Match telephoneMatch;
        Match addressMatch;
        
        int sectionStartIndex = solicitorListRawResponse.IndexOf(SECTION_START, 0);
        int sectionEndIndex = 0;

        while (sectionStartIndex >= 0 && sectionEndIndex < solicitorListRawResponse.Length-1)
        {
            sectionEndIndex = solicitorListRawResponse.IndexOf(SECTION_START, sectionStartIndex + 1);
            sectionEndIndex = sectionEndIndex >= 0 ? sectionEndIndex : solicitorListRawResponse.Length;

            string section = solicitorListRawResponse.Substring(sectionStartIndex, sectionEndIndex - sectionStartIndex);

            solicitorNameMatch = solicitorNameRegex.Match(section);
            telephoneMatch = telephoneRegex.Match(section);
            addressMatch = addressRegex.Match(section);

            solicitorModels.Add(new SolicitorModel
            {
                SolicitorName = solicitorNameMatch.Success ? solicitorNameMatch.Groups[1].Value : string.Empty,
                TelephoneNumber = telephoneMatch.Success ? telephoneMatch.Groups[1].Value : string.Empty,
                Address = addressMatch.Success ? addressMatch.Groups[1].Value : string.Empty
            });

            sectionStartIndex = sectionEndIndex+1;            
        }

        return solicitorModels;
    }
}
