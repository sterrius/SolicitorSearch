using Microsoft.AspNetCore.Mvc;

namespace SolicitorSearch.API.Handlers;

public interface ISolicitorSearchHandler
{
    public Task<IActionResult> SearchSolicitors(string location);
}
