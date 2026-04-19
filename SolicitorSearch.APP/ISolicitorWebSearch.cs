using SolicitorSearch.BLL.Solicitor;

namespace SolicitorSearch.APP;

public interface ISolicitorWebSearch
{
    Task<IEnumerable<SolicitorModel>> SearchSolicitors(string location);
}
