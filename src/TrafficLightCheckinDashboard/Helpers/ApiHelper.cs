using System.Net.Http.Json;

namespace Dashboard.Helpers;

public class ApiHelper
{
    private readonly HttpClient _client;

    public ApiHelper(HttpClient client)
    {
        _client = client;
    }

    public async Task<T> GetFromJsonAsync<T>(string requestUri)
    {
        var result = await _client.GetFromJsonAsync<T>(requestUri);
        return result == null ? throw new InvalidOperationException("Nullable object must have a value.") : result;
    }
}
