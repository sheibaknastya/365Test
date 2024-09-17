using System.Net;
using System.Text.Json;
using _365Test.core;
using _365Test.core.entities;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;

namespace _365Test.tests;

[TestFixture]
[AllureNUnit]
public class AddPost : BaseTest
{
    [Test]
    [Retry(3)]
    [AllureName("Add post to random user")]
    public void AddUserPost()
    {
        var userId = GetRandomUserId();
        CreatePost(userId);
    }
    
    [AllureStep("Get random user's ID")]
    private int GetRandomUserId()
    {
        var response = ApiClient.GetUsers(); 
        var users = JsonSerializer.Deserialize<User[]>(response.Content!);
        
        return users![new Random().Next(0, 9)].id;
    }

    [AllureStep("Create post using random user's ID")]
    private void CreatePost(int userId)
    {
        var response = ApiClient.CreatePost(userId);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Content, Is.Not.Null);
    }
}