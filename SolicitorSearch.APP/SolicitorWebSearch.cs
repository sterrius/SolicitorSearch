using SolicitorSearch.BLL.Solicitor;
using SolicitorSearch.BLL.SolicitorSource;
using SolicitorSearch.DAL.Repositories;
using SolicitorSearch.INF;

namespace SolicitorSearch.APP;

public class SolicitorWebSearch : ISolicitorWebSearch
{
    private readonly ISolicitorSourceRepository _solicitorSourceRepository;
    private readonly IHttpClientWrapper _httpClientWrapper;

    public SolicitorWebSearch(ISolicitorSourceRepository solicitorSourceRepository, IHttpClientWrapper httpClientWrapper)
    {
        _solicitorSourceRepository = solicitorSourceRepository;
        _httpClientWrapper = httpClientWrapper;
    }

    public async Task<IEnumerable<SolicitorModel>> SearchSolicitors(string location)
    {
        List<SolicitorModel> solicitorModels = new List<SolicitorModel>();
        IEnumerable<SolicitorSourceBaseModel> solicitorSourceModels = _solicitorSourceRepository.GetSolicitorSources().Select(s => s.MapToSolicitorSourceModel());

        foreach (SolicitorSourceBaseModel solicitorSourceModel in solicitorSourceModels)
        {
            try
            {
                string httpResponseBody = await _httpClientWrapper.GetAsync($"{solicitorSourceModel.BaseUrl}{solicitorSourceModel.GetPopulatedQueryString(location)}", solicitorSourceModel.HostHeader);
                solicitorModels.AddRange(solicitorSourceModel.ExtractContactDetails(httpResponseBody));
            }
            catch (Exception ex)
            {
                // TODO: Log exception
            }
        }

        return solicitorModels;
    }
}
