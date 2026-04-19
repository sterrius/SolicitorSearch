using SolicitorSearch.DAL.Entities;

namespace SolicitorSearch.DAL.Repositories;

public class SolicitorSourceRepository : ISolicitorSourceRepository
{
    public SolicitorSourceRepository()
    {
        /* no op */
    }

    public IEnumerable<SolicitorSourceEntity> GetSolicitorSources()
    {
        return new List<SolicitorSourceEntity>()
        {
            new SolicitorSourceEntity()
            {
                SolicitorSourceId = 1,
                SolicitorSourceName = "SolicitorsDotCom",
                BaseUrl = "https://www.solicitors.com",
                QueryStringTemplate = "/conveyancing+{location}.html",
                HostHeader = "www.solicitors.com"
            }
        };
    }
}
