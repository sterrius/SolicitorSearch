using System.Net.Http.Headers;

namespace SolicitorSearch.INF;

public class HttpClientWrapper : IHttpClientWrapper
{
    private HttpClient _httpClient;

    public HttpClientWrapper()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
    }

    public async Task<string> GetAsync(string url, string hostHeader)
    {
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            if (hostHeader != null)
            {
                request.Headers.Host = hostHeader;
            }

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            // TODO: Log exception
            throw;
        }
    }
}
