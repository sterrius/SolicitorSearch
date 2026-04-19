using SolicitorSearch.DAL.Entities;

namespace SolicitorSearch.DAL.Repositories;

public interface ISolicitorSourceRepository
{
    IEnumerable<SolicitorSourceEntity> GetSolicitorSources();
}
