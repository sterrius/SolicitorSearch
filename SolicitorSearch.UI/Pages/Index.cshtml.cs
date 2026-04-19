using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolicitorSearch.BLL.Solicitor;

namespace SolicitorSearch.UI.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string SelectedLocation { get; set; }
    public List<SelectListItem> LocationOptions { get; set; } = new();
    public List<SolicitorModel> Solicitors { get; set; } = new();

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiUrlTemplate = "https://localhost:44387/solicitorsearch?location={location}";

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        LoadLocationOptions();
    }

    public async Task OnPostAsync()
    {
        LoadLocationOptions();

        HttpClient httpClient = _httpClientFactory.CreateClient();
        Solicitors = await httpClient.GetFromJsonAsync<List<SolicitorModel>>(_apiUrlTemplate.Replace("{location}", SelectedLocation));
    }

    private void LoadLocationOptions()
    {
        LocationOptions = new List<SelectListItem>()
        {
            new() { Value = "london", Text = "London" },
            new() { Value = "birmingham", Text = "Birmingham" },
            new() { Value = "leeds", Text = "Leeds" },
            new() { Value = "manchester", Text = "Manchester" },
            new() { Value = "sheffield", Text = "Sheffield" },
            new() { Value = "bradford", Text = "Bradford" },
            new() { Value = "liverpool", Text = "Liverpool" },
            new() { Value = "bristol", Text = "Bristol" }
        };
    }
}
