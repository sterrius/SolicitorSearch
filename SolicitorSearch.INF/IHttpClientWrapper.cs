namespace SolicitorSearch.INF;

public interface IHttpClientWrapper
{
    Task<string> GetAsync(string url, string hostHeader);
}
