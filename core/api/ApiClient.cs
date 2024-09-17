using RestSharp;

namespace _365Test.core.api;

public partial class ApiClient(string baseUrl)
{
    private readonly RestClient _restClient = new(baseUrl);
}