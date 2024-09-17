using RestSharp;

namespace _365Test.core.api;

public partial class ApiClient
{
    public RestResponse GetPosts()
    {
        return _restClient.Execute(new RestRequest(Endpoints.Posts));
    }

    public RestResponse CreatePost(int userId)
    {
        var request = new RestRequest(Endpoints.Posts, Method.Post);
        
        request.AddHeader("Content-type", "application/json; charset=UTF-8");    
        request.AddJsonBody(new {
            title = "title",
            body = "body",
            userId
        });

        return _restClient.Execute(request);
    }
}