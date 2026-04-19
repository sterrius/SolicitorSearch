using Microsoft.AspNetCore.Mvc;
using SolicitorSearch.APP;

namespace SolicitorSearch.API.Handlers;

public class SolicitorSearchHandler : ISolicitorSearchHandler
{
    private readonly ISolicitorWebSearch _solicitorWebSearch;

    public SolicitorSearchHandler(ISolicitorWebSearch solicitorWebSearch)
    {
        _solicitorWebSearch = solicitorWebSearch;
    }

    public async Task<IActionResult> SearchSolicitors(string location)
    {
        try
        {
            return new OkObjectResult(await _solicitorWebSearch.SearchSolicitors(location));
        }
        catch (Exception ex)
        {
            // TODO: Log exception
            throw;      
        }
    }
}
