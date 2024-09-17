using System.Text.Json;
using _365Test.core.entities;
using RestSharp;

namespace _365Test.core.api;

public partial class ApiClient
{
    public RestResponse GetUsers()
    {
        return _restClient.Execute(new RestRequest(Endpoints.Users));
    }
    
    public User GetRandomUser()
    {
        var response = GetUsers(); 
        var users = JsonSerializer.Deserialize<User[]>(response.Content!);
        
        return users![new Random().Next(0, 9)];
    }
}