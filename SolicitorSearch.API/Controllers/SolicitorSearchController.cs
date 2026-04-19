using Microsoft.AspNetCore.Mvc;
using SolicitorSearch.API.Handlers;

namespace SolicitorSearch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SolicitorSearchController : ControllerBase
{
    private readonly ISolicitorSearchHandler _solicitorSearchHandler;

    public SolicitorSearchController(ISolicitorSearchHandler solicitorSearchHandler)
    {
        _solicitorSearchHandler = solicitorSearchHandler;
    }

    [HttpGet(Name = "GetSolicitors")]
    public async Task<IActionResult> Get([FromQuery] string location)
    {
        try
        {
            return await _solicitorSearchHandler.SearchSolicitors(location);
        }
        catch (Exception ex)
        {
            return Problem(title: "An error occurred while fetching the solicitors list. Please try again and contact support if the problem persists.");
        }
    }
}
